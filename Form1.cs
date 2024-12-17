using SkiaSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ImageScaler
{
    public partial class Form1 : Form
    {
        private string selectedImagePath = string.Empty;
        private string imgscale = "2";

        public Form1()
        {
            InitializeComponent();
        }

        // Fungsi untuk memilih gambar
        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.dds";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    // Cek jika file adalah .dds, dan konversi ke .png
                    if (Path.GetExtension(selectedImagePath).ToLower() == ".dds")
                    {
                        string pngPath = Path.ChangeExtension(selectedImagePath, ".png");
                        ConvertDDSToPNG(selectedImagePath, pngPath);
                        selectedImagePath = pngPath; // Setelah konversi, pilih file .png
                    }

                    // Ambil dimensi gambar
                    using (var inputImage = SKBitmap.Decode(selectedImagePath))
                    {
                        txtWidth.Text = inputImage.Width.ToString();
                        txtHeight.Text = inputImage.Height.ToString();
                    }

                    Log($"Gambar dipilih: {selectedImagePath}");
                }
                else
                {
                    Log("Pemilihan gambar dibatalkan.");
                }
            }
        }

        // Fungsi untuk memproses gambar
        private void BtnResize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Silakan pilih gambar terlebih dahulu.");
                return;
            }

            if (!int.TryParse(txtWidth.Text, out int newWidth) || !int.TryParse(txtHeight.Text, out int newHeight))
            {
                Log("Masukkan angka valid untuk width dan height.");
                return;
            }

            string directory = Path.GetDirectoryName(selectedImagePath);
            string baseName = Path.GetFileNameWithoutExtension(selectedImagePath);

            string opaquePath = Path.Combine(directory, $"{baseName}_opaque_resized.png");
            string maskPath = Path.Combine(directory, $"{baseName}_mask_resized.png");
            string finalPath = Path.Combine(directory, $"{baseName}_final.png");

            try
            {
                Log("Memulai proses...");

                // File 1: Hilangkan transparansi
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha off -resize {newWidth}x{newHeight} \"{opaquePath}\"");
                Log($"File 1 selesai: {opaquePath}");

                // File 2: Buat layer mask
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha extract -resize {newWidth}x{newHeight} \"{maskPath}\"");
                Log($"File 2 selesai: {maskPath}");

                // File 3: Gabungkan kembali dengan transparansi
                ExecuteMagickCommand($"\"{opaquePath}\" \"{maskPath}\" -alpha off -compose CopyOpacity -composite \"{finalPath}\"");
                Log($"File final selesai: {finalPath}");

                Log("Proses selesai!");
            }
            catch (Exception ex)
            {
                Log($"Terjadi kesalahan: {ex.Message}");
            }

            selectedImagePath = string.Empty;
        }

        // Fungsi untuk menjalankan perintah ImageMagick
        private void ExecuteMagickCommand(string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "ImageMagick\\magick",
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            using (var process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    Log($"Output: {output}");
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Log($"Error: {error}");
                }

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Perintah ImageMagick gagal: {error}");
                }
            }
        }

        // Fungsi untuk mengonversi .dds ke .png menggunakan ImageMagick
        private void ConvertDDSToPNG(string ddsPath, string pngPath)
        {
            try
            {
                ExecuteMagickCommand($"\"{ddsPath}\" \"{pngPath}\"");
                Log($"File DDS telah dikonversi menjadi PNG: {pngPath}");
            }
            catch (Exception ex)
            {
                Log($"Gagal mengonversi DDS ke PNG: {ex.Message}");
            }
        }

        // Fungsi untuk mencatat log
        private void Log(string message)
        {
            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
        }


        // Fungsi untuk mengonversi gambar ke DDS format BC7 sRGB
        private void BtnDifuse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Silakan pilih gambar terlebih dahulu.");
                return;
            }

            string outputFilePath = GetOutputFilePath(selectedImagePath, "_diffuse.dds");
            ConvertToDDS(selectedImagePath, outputFilePath, "bc7");
        }

        // Fungsi untuk mengonversi gambar ke DDS format BC7 linear
        private void BtnLinear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Silakan pilih gambar terlebih dahulu.");
                return;
            }

            string outputFilePath = GetOutputFilePath(selectedImagePath, "_linear.dds");
            ConvertToDDS(selectedImagePath, outputFilePath, "bc7-linear");
        }

        // Fungsi untuk mendapatkan nama file output yang benar
        private string GetOutputFilePath(string inputPath, string suffix)
        {
            string directory = Path.GetDirectoryName(inputPath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputPath);
            return Path.Combine(directory, fileNameWithoutExtension + suffix);
        }

        // Fungsi untuk mengonversi gambar ke DDS menggunakan ImageMagick
        private void ConvertToDDS(string inputPath, string outputPath, string compression)
        {
            try
            {
                // Menjalankan ImageMagick convert untuk konversi ke DDS dengan BC7 compression
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "ImageMagick\\magick",  // Menggunakan perintah 'magick' untuk versi terbaru ImageMagick
                    Arguments = $"\"{inputPath}\" -format DDS -quality 100 -define dds:compression={compression} \"{outputPath}\"",  // Mengonversi gambar ke DDS dengan BC7
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,  // Menangkap output error
                    RedirectStandardOutput = true,  // Menangkap output standar
                };

                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    // Tangkap output standar dan error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();  // Tunggu hingga konversi selesai

                    // Tampilkan output
                    if (!string.IsNullOrEmpty(output))
                    {
                        Log($"Output: {output}");
                    }

                    // Tampilkan error jika ada
                    if (!string.IsNullOrEmpty(error))
                    {
                        Log($"Error: {error}");
                    }

                    // Cek jika konversi berhasil
                    if (process.ExitCode == 0)
                    {
                        Log($"File telah dikonversi menjadi DDS dengan {compression}: {outputPath}");
                    }
                    else
                    {
                        Log($"Gagal mengonversi gambar ke DDS: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Gagal mengonversi gambar ke DDS: {ex.Message}");
            }
        }

        private void RadX2_CheckedChanged(object sender, EventArgs e)
        {
            imgscale = "2";
        }

        private void RadX3_CheckedChanged(object sender, EventArgs e)
        {
            imgscale = "3";
        }

        private void RadX4_CheckedChanged(object sender, EventArgs e)
        {
            imgscale = "4";
        }

        private void BtnUpscale_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Silakan pilih gambar terlebih dahulu.");
                return;
            }

            string directory = Path.GetDirectoryName(selectedImagePath);
            string baseName = Path.GetFileNameWithoutExtension(selectedImagePath);

            string opaquePath = Path.Combine(directory, $"{baseName}_opaque.png");
            string opaquePath2 = Path.Combine(directory, $"{baseName}_opaque_upscaled.png");
            string maskPath = Path.Combine(directory, $"{baseName}_mask.png");
            string maskPath2 = Path.Combine(directory, $"{baseName}_mask_upscaled.png");
            string finalPath = Path.Combine(directory, $"{baseName}_final.png");

            string imgpathtemp;

            try
            {
                Log("Memulai proses...");

                // File 1: Hilangkan transparansi
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha off \"{opaquePath}\"");
                Log($"File 1 selesai: {opaquePath}");


                ProcessStartInfo ps = new ProcessStartInfo
                {
                    FileName = "Realesrgan\\realesrgan-ncnn-vulkan",
                    Arguments = $"-i \"{opaquePath}\" -n realesr-animevideov3 -s {imgscale} -o \"{opaquePath2}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(ps))
                {
                    process.WaitForExit();  // Tunggu sampai proses selesai
                    Log($"Upscale selesai: {opaquePath2}");
                }

                // File 2: Buat layer mask
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha extract \"{maskPath}\"");
                Log($"File 2 selesai: {maskPath}");

             

                ps.Arguments = $"-i \"{maskPath}\" -n realesr-animevideov3 -s {imgscale} -o \"{maskPath2}\"";

                using (var process = Process.Start(ps))
                {
                    process.WaitForExit();  // Tunggu sampai proses selesai
                    Log($"Upscale selesai: {maskPath2}");
                }

                // File 3: Gabungkan kembali dengan transparansi
                ExecuteMagickCommand($"\"{opaquePath2}\" \"{maskPath2}\" -alpha off -compose CopyOpacity -composite \"{finalPath}\"");
                Log($"File final selesai: {finalPath}");

                Log("Proses selesai!");
            }
            catch (Exception ex)
            {
                Log($"Terjadi kesalahan: {ex.Message}");
            }

            selectedImagePath = string.Empty;
        }



    }

}
