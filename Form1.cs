using SkiaSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImageScaler
{
    public partial class Form1 : Form
    {
        private string selectedImagePath = string.Empty;
        private string imgscale = "2";
        string dataimg = "realesr-animevideov3";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkSound.Checked = Properties.Settings.Default.CheckSoundz;
            checkTemp.Checked = Properties.Settings.Default.CheckTempz;
            this.TopMost = CheckTop.Checked;
            CheckTop.Checked = Properties.Settings.Default.CheckTopz;

        }

        private void PlayCompletionSound()
        {
            // Set the path to your sound file (.wav)
            string soundFilePath ="completion_sound.wav";

            // Use SoundPlayer to play the sound
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundFilePath);
            if (checkSound.Checked == true)
            {
                player.Play();
            }
        }

        // Fungsi untuk memilih gambar
        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            btnResize.ForeColor = Color.Transparent;
            btnResize.BackColor = Color.Black;
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.BackColor = Color.Black;

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

                    Log($"Selected image: {selectedImagePath}");
                }
                else
                {
                    Log("Image selection canceled.");
                }
            }
        }

        // Fungsi untuk memproses gambar
        private void BtnResize_Click(object sender, EventArgs e)
        {
            btnResize.ForeColor = Color.Transparent;
            btnResize.BackColor = Color.Black;
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Please select an image first.");
                return;
            }

            if (!int.TryParse(txtWidth.Text, out int newWidth) || !int.TryParse(txtHeight.Text, out int newHeight))
            {
                Log("Enter a valid number for width and height.");
                return;
            }

            string directory = Path.GetDirectoryName(selectedImagePath);
            string baseName = Path.GetFileNameWithoutExtension(selectedImagePath);

            string opaquePath = Path.Combine(directory, $"{baseName}_opaque_resized.png");
            string maskPath = Path.Combine(directory, $"{baseName}_mask_resized.png");
            string finalPath = Path.Combine(directory, $"{baseName}_final.png");

            try
            {
                Log("Starting process...");

                // File 1: Hilangkan transparansi
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha off -resize {newWidth}x{newHeight} \"{opaquePath}\"");
                Log($"File 1 complete: {opaquePath}");

                // File 2: Buat layer mask
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha extract -resize {newWidth}x{newHeight} \"{maskPath}\"");
                Log($"File 2 complete: {maskPath}");

                // File 3: Gabungkan kembali dengan transparansi
                ExecuteMagickCommand($"\"{opaquePath}\" \"{maskPath}\" -alpha off -compose CopyOpacity -composite \"{finalPath}\"");
                Log($"Final file complete: {finalPath}");


                if (checkTemp.Checked == false)
                {
                    File.Delete(maskPath);
                    File.Delete(opaquePath);
                    Log($"Temporary images deleted");

                }

                Log("Process complete!");
            }
            catch (Exception ex)
            {
                Log($"An error occurred: {ex.Message}");
            }

            selectedImagePath = finalPath;
            Log($"Selected image: {finalPath}");
            PlayCompletionSound();
            btnResize.ForeColor = Color.Black;
            btnResize.BackColor = Color.Lime;
            BtnOpen.ForeColor = Color.Black;
            BtnOpen.BackColor = Color.Lime;
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
                    throw new Exception($"ImageMagick command failed: {error}");
                }
            }
        }

        // Fungsi untuk mengonversi .dds ke .png menggunakan ImageMagick
        private void ConvertDDSToPNG(string ddsPath, string pngPath)
        {
            try
            {
                ExecuteMagickCommand($"\"{ddsPath}\" \"{pngPath}\"");
                Log($"DDS file has been converted to PNG: {pngPath}");
            }
            catch (Exception ex)
            {
                Log($"Failed to convert DDS to PNG: {ex.Message}");
            }
        }

        // Fungsi untuk mencatat log
        private void Log(string message)
        {
            txtLog.AppendText($"{message}{Environment.NewLine}");
        }


        // Fungsi untuk mengonversi gambar ke DDS format BC7 sRGB
        private void BtnDifuse_Click(object sender, EventArgs e)
        {
            btnResize.ForeColor = Color.Transparent;
            btnResize.BackColor = Color.Black;
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Please select an image first.");
                return;
            }

            else if (Path.GetExtension(selectedImagePath).ToLower() == ".png")
            {
                string outputFilePath = GetOutputFilePath(selectedImagePath, "_diffuse.dds");
                ConvertToDDS(selectedImagePath, outputFilePath, "bc7");
                selectedImagePath = outputFilePath;
                Log($"Selected image: {selectedImagePath}");
                PlayCompletionSound();
                btnDifuse.ForeColor = Color.Black;
                btnDifuse.BackColor = Color.Lime;
                BtnOpen.ForeColor = Color.Black;
                BtnOpen.BackColor = Color.Lime;
            }
            else
            {
                Log($"Selected image is not .png");
            }
            
        }

        // Fungsi untuk mengonversi gambar ke DDS format BC7 linear
        private void BtnLinear_Click(object sender, EventArgs e)
        {
            btnResize.ForeColor = Color.Transparent;
            btnResize.BackColor = Color.Black;
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Please select an image first.");
                return;
            }
            else if (Path.GetExtension(selectedImagePath).ToLower() == ".png")
            {
                string outputFilePath = GetOutputFilePath(selectedImagePath, "_linear.dds");
            ConvertToDDS(selectedImagePath, outputFilePath, "bc7-linear");
            selectedImagePath = outputFilePath;
            Log($"Selected image: {selectedImagePath}");
            PlayCompletionSound();
            btnLinear.ForeColor = Color.Black;
            btnLinear.BackColor = Color.Lime;
            BtnOpen.ForeColor = Color.Black;
            BtnOpen.BackColor = Color.Lime;
            }
            else
            {
                Log($"Selected image is not .png");
            }
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
                        Log($"Image converted to DDS with {compression}: {outputPath}");
                    }
                    else
                    {
                        Log($"Failed to convert to DDS: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to convert to DDS: {ex.Message}");
            }
        }

        private void RadX2_CheckedChanged(object sender, EventArgs e)
        {
            imgscale = "2";
            dataimg = "realesr-animevideov3";
        }

        private void RadX3_CheckedChanged(object sender, EventArgs e)
        {
            imgscale = "3";
            dataimg = "realesr-animevideov3";
        }

        private void RadX4_CheckedChanged(object sender, EventArgs e)
        {
            imgscale = "4";
            dataimg = "realesrgan-x4plus-anime";
        }

        private void BtnUpscale_Click(object sender, EventArgs e)
        {
            btnResize.ForeColor = Color.Transparent;
            btnResize.BackColor = Color.Black;
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("Please select an image first.");
                return;
            }

            string directory = Path.GetDirectoryName(selectedImagePath);
            string baseName = Path.GetFileNameWithoutExtension(selectedImagePath);

            string opaquePath = Path.Combine(directory, $"{baseName}_opaque.png");
            string opaquePath2 = Path.Combine(directory, $"{baseName}_opaque_upscaled.png");
            string maskPath = Path.Combine(directory, $"{baseName}_mask.png");
            string maskPath2 = Path.Combine(directory, $"{baseName}_mask_upscaled.png");
            string finalPath = Path.Combine(directory, $"{baseName}_final.png");

            try
            {
                Log("Starting process...");

                // File 1: Hilangkan transparansi
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha off \"{opaquePath}\"");
                Log($"File 1 complete: {opaquePath}");


                ProcessStartInfo ps = new ProcessStartInfo
                {
                    FileName = "Realesrgan\\realesrgan-ncnn-vulkan",
                    Arguments = $"-i \"{opaquePath}\" -n {dataimg} -s {imgscale} -o \"{opaquePath2}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(ps))
                {
                    process.WaitForExit();  // Tunggu sampai proses selesai
                    Log($"Upscale complete: {opaquePath2}");
                }

                // File 2: Buat layer mask
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha extract \"{maskPath}\"");
                Log($"File 2 complete: {maskPath}");



                ps.Arguments = $"-i \"{maskPath}\" -n {dataimg} -s {imgscale} -o \"{maskPath2}\"";

                using (var process = Process.Start(ps))
                {
                    process.WaitForExit();  // Tunggu sampai proses selesai
                    Log($"Upscale complete: {maskPath2}");
                }

                // File 3: Gabungkan kembali dengan transparansi
                ExecuteMagickCommand($"\"{opaquePath2}\" \"{maskPath2}\" -alpha off -compose CopyOpacity -composite \"{finalPath}\"");
                Log($"Final File complete: {finalPath}");

                if (checkTemp.Checked == false)
                {
                    File.Delete(maskPath);
                    File.Delete(maskPath2);
                    File.Delete(opaquePath);
                    File.Delete(opaquePath2);
                    Log($"Temporary image deleted");

                }

                Log("Process complete!");
            }
            catch (Exception ex)
            {
                Log($"An error occurred: {ex.Message}");
            }

            selectedImagePath = finalPath;
            Log($"Image selected: {finalPath}");
            PlayCompletionSound();
            btnUpscale.ForeColor = Color.Black;
            btnUpscale.BackColor = Color.Lime;
            BtnOpen.ForeColor = Color.Black;
            BtnOpen.BackColor = Color.Lime;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnSwap1_Click(object sender, EventArgs e)
        {
            BtnSwap1.FlatStyle = FlatStyle.Flat;
            BtnSwap2.FlatStyle = FlatStyle.Popup;
            panelResize.BringToFront();
        }

        private void BtnSwap2_Click(object sender, EventArgs e)
        {
            BtnSwap2.FlatStyle = FlatStyle.Flat;
            BtnSwap1.FlatStyle = FlatStyle.Popup;
            panelUpscale.BringToFront();
        }

        private void checkSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckSoundz = checkSound.Checked;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/eroge69/TextureUpscaler";
            try
            {
                // Membuka URL di browser default
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Menyuruh sistem untuk membuka URL dengan browser
                });
            }
            catch (Exception ex)
            {
                Log($"An error occurred: {ex.Message}");
            }
        }

        private void checkTemp_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckTempz = checkTemp.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = CheckTop.Checked;
            Properties.Settings.Default.CheckTopz = CheckTop.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Ambil array file path yang di-drop
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Periksa apakah file pertama memiliki ekstensi PNG atau DDS
                string fileExtension = Path.GetExtension(files[0]).ToLower();

                if (fileExtension == ".png" || fileExtension == ".dds")
                {
                    e.Effect = DragDropEffects.Copy; // Tampilkan efek copy jika ekstensi valid
                }
                else
                {
                    e.Effect = DragDropEffects.None; // Tidak bisa drop jika ekstensi tidak valid
                }
            }
            else
            {
                e.Effect = DragDropEffects.None; // Tidak bisa drop
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Jika ada file yang di-drop
            if (files.Length > 0)
            {
                selectedImagePath = files[0]; // Ambil file pertama

                // Periksa ekstensi file
                string fileExtension = Path.GetExtension(selectedImagePath).ToLower();

                if (fileExtension == ".png" || fileExtension == ".dds")
                {
                    if (Path.GetExtension(selectedImagePath).ToLower() == ".dds")
                    {
                        string pngPath = Path.ChangeExtension(selectedImagePath, ".png");
                        ConvertDDSToPNG(selectedImagePath, pngPath);
                        selectedImagePath = pngPath; // Setelah konversi, pilih file .png
                    }

                    Log($"Image selected: {selectedImagePath}");
                }
                else
                {
                    Log($"Only PNG or DDS files are allowed.");
                }
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            btnResize.ForeColor = Color.Transparent;
            btnResize.BackColor = Color.Black;
            btnUpscale.ForeColor = Color.Transparent;
            btnUpscale.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen.ForeColor = Color.Transparent;
            BtnOpen.BackColor = Color.Black;

            try
            {
                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    // Membuka lokasi file di File Explorer dan memfokuskan file
                    Process.Start("explorer.exe", $"/select, \"{selectedImagePath}\"");
                }
                else
                {
                    MessageBox.Show("File path is invalid or file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }

}
