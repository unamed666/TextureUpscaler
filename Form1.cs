using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlTypes;

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
            string soundFilePath = "completion_sound.wav";

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
            BtnOpen2.ForeColor = Color.Transparent;
            BtnOpen2.BackColor = Color.Black;
            BtnOpen3.ForeColor = Color.Transparent;
            BtnOpen3.BackColor = Color.Black;

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
                    using (Image image = Image.FromFile(selectedImagePath))
                    {
                        txtWidth.Text = image.Width.ToString();
                        txtHeight.Text = image.Height.ToString();
                    }

                    Log($"\nSelected image: {selectedImagePath}");
                }
                else
                {
                    Log("\nImage selection canceled.");
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
            btnUpscale2.ForeColor = Color.Transparent;
            btnUpscale2.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen2.ForeColor = Color.Transparent;
            BtnOpen2.BackColor = Color.Black;
            BtnOpen3.ForeColor = Color.Transparent;
            BtnOpen3.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("\nPlease select an image first.");
                return;
            }

            if (!int.TryParse(txtWidth.Text, out int newWidth) || !int.TryParse(txtHeight.Text, out int newHeight))
            {
                Log("\nEnter a valid number for width and height.");
                return;
            }

            string directory = Path.GetDirectoryName(selectedImagePath);
            string baseName = Path.GetFileNameWithoutExtension(selectedImagePath);

            string opaquePath = Path.Combine(directory, $"{baseName}_opaque_resized.png");
            string maskPath = Path.Combine(directory, $"{baseName}_mask_resized.png");
            string finalPath = Path.Combine(directory, $"{baseName}_resized.png");

            try
            {
                Log("\nStarting process...");

                // File 1: Hilangkan transparansi
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha off -resize {newWidth}x{newHeight} \"{opaquePath}\"");
                Log($"\nFile 1 complete: {opaquePath}");

                // File 2: Buat layer mask
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha extract -resize {newWidth}x{newHeight} \"{maskPath}\"");
                Log($"\nFile 2 complete: {maskPath}");

                // File 3: Gabungkan kembali dengan transparansi
                ExecuteMagickCommand($"\"{opaquePath}\" \"{maskPath}\" -alpha off -compose CopyOpacity -composite \"{finalPath}\"");
                Log($"\nFinal file complete: {finalPath}");


                if (checkTemp.Checked == false)
                {
                    File.Delete(maskPath);
                    File.Delete(opaquePath);
                    Log($"\nTemporary images deleted");

                }

                Log("\nProcess complete!");
            }
            catch (Exception ex)
            {
                Log($"\nAn error occurred: {ex.Message}");
            }

            selectedImagePath = finalPath;
            Log($"\nSelected image: {finalPath}");
            PlayCompletionSound();
            btnResize.ForeColor = Color.Black;
            btnResize.BackColor = Color.Lime;
            BtnOpen2.ForeColor = Color.Black;
            BtnOpen2.BackColor = Color.Lime;
            BtnOpen3.ForeColor = Color.Black;
            BtnOpen3.BackColor = Color.Lime;
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
                    Log($"\nOutput: {output}");
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Log($"\nError: {error}");
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
                Log($"\nDDS file has been converted to PNG: {pngPath}");
            }
            catch (Exception ex)
            {
                Log($"\nFailed to convert DDS to PNG: {ex.Message}");
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
            BtnOpen2.ForeColor = Color.Transparent;
            BtnOpen2.BackColor = Color.Black;
            BtnOpen3.ForeColor = Color.Transparent;
            BtnOpen3.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("\nPlease select an image first.");
                return;
            }

            else if (Path.GetExtension(selectedImagePath).ToLower() == ".png")
            {
                string outputFilePath = Path.GetDirectoryName(selectedImagePath);
                ConvertToDDS(selectedImagePath, outputFilePath, "-f BC7_UNORM_SRGB -nologo --separate-alpha");
                selectedImagePath = GetOutputFilePath(selectedImagePath, ".dds");
                Log($"\nSelected image: {selectedImagePath}");
                PlayCompletionSound();
                Log("\nPNG file processed and converted to SRGB.\n");
                btnDifuse.ForeColor = Color.Black;
                btnDifuse.BackColor = Color.Lime;
                BtnOpen2.ForeColor = Color.Black;
                BtnOpen2.BackColor = Color.Lime;
                BtnOpen3.ForeColor = Color.Black;
                BtnOpen3.BackColor = Color.Lime;
            }
            else
            {
                Log($"\nSelected image is not .png");
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
            BtnOpen2.ForeColor = Color.Transparent;
            BtnOpen2.BackColor = Color.Black;
            BtnOpen3.ForeColor = Color.Transparent;
            BtnOpen3.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("\nPlease select an image first.");
                return;
            }
            else if (Path.GetExtension(selectedImagePath).ToLower() == ".png")
            {
                string outputFilePath = Path.GetDirectoryName(selectedImagePath);
                ConvertToDDS(selectedImagePath, outputFilePath, " -f BC7_UNORM -srgbo -nologo --separate-alpha ");
                selectedImagePath = GetOutputFilePath(selectedImagePath, ".dds");
                Log($"\nSelected image: {selectedImagePath}");
                PlayCompletionSound();
                Log("\nPNG file processed and converted to Linear.\n");
                btnLinear.ForeColor = Color.Black;
                btnLinear.BackColor = Color.Lime;
                BtnOpen2.ForeColor = Color.Black;
                BtnOpen2.BackColor = Color.Lime;
                BtnOpen3.ForeColor = Color.Black;
                BtnOpen3.BackColor = Color.Lime;
            }
            else
            {
                Log($"\nSelected image is not .png");
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
                    FileName = "texconv.exe",  // Menggunakan perintah 'magick' untuk versi terbaru ImageMagick
                    Arguments = $"\"{inputPath}\" {compression} -o \"{outputPath}\" -y",  // Mengonversi gambar ke DDS dengan BC7
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
                        Log($"\nOutput: {output}");
                    }

                    // Tampilkan error jika ada
                    if (!string.IsNullOrEmpty(error))
                    {
                        Log($"\nError: {error}");
                    }

                    // Cek jika konversi berhasil
                    if (process.ExitCode == 0)
                    {
                        Log($"\nImage converted to DDS with {compression}: {outputPath}");
                    }
                    else
                    {
                        Log($"\nFailed to convert to DDS: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"\nFailed to convert to DDS: {ex.Message}");
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
            btnUpscale2.ForeColor = Color.Transparent;
            btnUpscale2.BackColor = Color.Black;
            btnDifuse.ForeColor = Color.Transparent;
            btnDifuse.BackColor = Color.Black;
            btnLinear.ForeColor = Color.Transparent;
            btnLinear.BackColor = Color.Black;
            BtnOpen2.ForeColor = Color.Transparent;
            BtnOpen2.BackColor = Color.Black;
            BtnOpen3.ForeColor = Color.Transparent;
            BtnOpen3.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                Log("\nPlease select an image first.");
                return;
            }

            string directory = Path.GetDirectoryName(selectedImagePath);
            string baseName = Path.GetFileNameWithoutExtension(selectedImagePath);

            string opaquePath = Path.Combine(directory, $"{baseName}_opaque.png");
            string opaquePath2 = Path.Combine(directory, $"{baseName}_opaque_upscaled.png");
            string maskPath = Path.Combine(directory, $"{baseName}_mask.png");
            string maskPath2 = Path.Combine(directory, $"{baseName}_mask_upscaled.png");
            string finalPath = Path.Combine(directory, $"{baseName}_upscaled.png");

            try
            {
                Log("\nStarting process...");

                // File 1: Hilangkan transparansi
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha off \"{opaquePath}\"");
                Log($"\nFile 1 complete: {opaquePath}");


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
                    Log($"\nUpscale complete: {opaquePath2}");
                }

                // File 2: Buat layer mask
                ExecuteMagickCommand($"\"{selectedImagePath}\" -alpha extract \"{maskPath}\"");
                Log($"\nFile 2 complete: {maskPath}");



                ps.Arguments = $"-i \"{maskPath}\" -n {dataimg} -s {imgscale} -o \"{maskPath2}\"";

                using (var process = Process.Start(ps))
                {
                    process.WaitForExit();  // Tunggu sampai proses selesai
                    Log($"\nUpscale complete: {maskPath2}");
                }

                // File 3: Gabungkan kembali dengan transparansi
                ExecuteMagickCommand($"\"{opaquePath2}\" \"{maskPath2}\" -alpha off -compose CopyOpacity -composite \"{finalPath}\"");
                Log($"\nFinal File complete: {finalPath}");

                if (checkTemp.Checked == false)
                {
                    File.Delete(maskPath);
                    File.Delete(maskPath2);
                    File.Delete(opaquePath);
                    File.Delete(opaquePath2);
                    Log($"\nTemporary image deleted");

                }

                Log("\nProcess complete!");
            }
            catch (Exception ex)
            {
                Log($"\nAn error occurred: {ex.Message}");
            }

            selectedImagePath = finalPath;
            Log($"\nImage selected: {finalPath}");
            PlayCompletionSound();
            btnUpscale.ForeColor = Color.Black;
            btnUpscale.BackColor = Color.Lime;
            BtnOpen2.ForeColor = Color.Black;
            BtnOpen2.BackColor = Color.Lime;
            BtnOpen3.ForeColor = Color.Black;
            BtnOpen3.BackColor = Color.Lime;

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
            BtnSwap3.FlatStyle = FlatStyle.Popup;
            panelResize.BringToFront();
        }

        private void BtnSwap2_Click(object sender, EventArgs e)
        {
            BtnSwap2.FlatStyle = FlatStyle.Flat;
            BtnSwap1.FlatStyle = FlatStyle.Popup;
            BtnSwap3.FlatStyle = FlatStyle.Popup;
            panelUpscale.BringToFront();
        }
        private void BtnSwap3_Click(object sender, EventArgs e)
        {
            BtnSwap3.FlatStyle = FlatStyle.Flat;
            BtnSwap1.FlatStyle = FlatStyle.Popup;
            BtnSwap2.FlatStyle = FlatStyle.Popup;
            panelBatch.BringToFront();
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
                Log($"\nAn error occurred: {ex.Message}");
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

                    Log($"\nImage selected: {selectedImagePath}");
                }
                else
                {
                    Log($"\nOnly PNG or DDS files are allowed.");
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
            BtnOpen2.ForeColor = Color.Transparent;
            BtnOpen2.BackColor = Color.Black;

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


        private string selectedFolderPath = string.Empty;
        private string lastSelectedFolderPath = ""; // Menyimpan folder terakhir yang dipilih
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true; // Pilih folder, bukan file
                dialog.Title = "Select Folder"; // Judul dialog

                // Jika folder terakhir yang dipilih ada, folder ini akan dibuka secara otomatis
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string selectedFolder = dialog.FileName;
                    selectedFolderPath = selectedFolder;
                    Log($"\nSelected folder: {selectedFolderPath}");
                }
                else
                {
                    Log("\nFolder selection canceled.");
                }
            }
        }

        private bool CheckOverwriteWarning(string outputFolder)
        {
            var files = Directory.GetFiles(outputFolder, "*", SearchOption.TopDirectoryOnly);
            if (files.Length > 0)
            {
                var result = MessageBox.Show("The 'UPSCALED' folder already contains files. Do you want to continue and overwrite the existing files?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return result == DialogResult.Yes;
            }
            return true;
        }

        private void btnUpscale2_Click(object sender, EventArgs e)
        {
            btnUpscale2.ForeColor = Color.Transparent;
            btnUpscale2.BackColor = Color.Black;
            btnDifuse3.ForeColor = Color.Transparent;
            btnDifuse3.BackColor = Color.Black;
            btnLinear3.ForeColor = Color.Transparent;
            btnLinear3.BackColor = Color.Black;
            BtnOpen1.ForeColor = Color.Transparent;
            BtnOpen1.BackColor = Color.Black;
            pngCheck.CheckState = CheckState.Unchecked;



            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                Log("\nPlease select a folder first.");
                return;
            }

            string outputRoot = Path.Combine(selectedFolderPath, "UPSCALED");

            if (!Directory.Exists(outputRoot))
                Directory.CreateDirectory(outputRoot);

            if (!CheckOverwriteWarning(outputRoot))
            {
                Log("\nProcess cancelled by user.");
                return;
            }

            string[] supportedExtensions = { ".png", ".dds" };
            var imageFiles = Directory.GetFiles(selectedFolderPath, "*.*", SearchOption.AllDirectories)
            .Where(f =>
             (f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".dds", StringComparison.OrdinalIgnoreCase)) &&
             !f.Contains(Path.Combine("UPSCALED", "")) // Filter folder UPSCALED
             );

            foreach (var inputPath in imageFiles)
            {
                try
                {
                    Log($"\nProcessing: {inputPath}");
                    string relativeSubPath = Path.GetDirectoryName(GetRelativePath(selectedFolderPath, inputPath));
                    string outputDir = Path.Combine(outputRoot, relativeSubPath);
                    Directory.CreateDirectory(outputDir);

                    string outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));


                    string baseName = Path.GetFileNameWithoutExtension(inputPath);
                    string originalExt = Path.GetExtension(inputPath);
                    string tempInput = inputPath;

                    // Jika DDS, konversi dulu ke PNG
                    if (originalExt.ToLower() == ".dds")
                    {
                        tempInput = Path.Combine(Path.GetTempPath(), baseName + "_converted.png");
                        ConvertDDSToPNG(inputPath, tempInput);
                    }

                    string opaque = Path.Combine(Path.GetTempPath(), baseName + "_opaque.png");
                    string opaqueUpscaled = Path.Combine(Path.GetTempPath(), baseName + "_opaque_upscaled.png");
                    string mask = Path.Combine(Path.GetTempPath(), baseName + "_mask.png");
                    string maskUpscaled = Path.Combine(Path.GetTempPath(), baseName + "_mask_upscaled.png");
                    string finalOutput = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    ExecuteMagickCommand($"\"{tempInput}\" -alpha off \"{opaque}\"");
                    ExecuteRealesrgan(opaque, opaqueUpscaled);
                    ExecuteMagickCommand($"\"{tempInput}\" -alpha extract \"{mask}\"");
                    ExecuteRealesrgan(mask, maskUpscaled);
                    ExecuteMagickCommand($"\"{opaqueUpscaled}\" \"{maskUpscaled}\" -alpha off -compose CopyOpacity -composite \"{finalOutput}\"");

                    Log($"\nOutput created: {finalOutput}");
                                        
                        File.Delete(opaque);
                        File.Delete(opaqueUpscaled);
                        File.Delete(mask);
                        File.Delete(maskUpscaled);
                        if (originalExt.ToLower() == ".dds" && File.Exists(tempInput))
                            File.Delete(tempInput);
                    
                }
                catch (Exception ex)
                {
                    Log($"\nError processing {inputPath}: {ex.Message}");
                }
            }

            Log("\nAll images processed.\n");
            btnUpscale2.ForeColor = Color.Black;
            btnUpscale2.BackColor = Color.Lime;
            BtnOpen1.ForeColor = Color.Black;
            BtnOpen1.BackColor = Color.Lime;
            PlayCompletionSound();
        }
        private string GetRelativePath(string basePath, string targetPath)
        {
            Uri baseUri = new Uri(AppendDirectorySeparatorChar(basePath));
            Uri targetUri = new Uri(targetPath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(targetUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private string AppendDirectorySeparatorChar(string path)
        {
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                return path + Path.DirectorySeparatorChar;
            return path;
        }

        private void ExecuteRealesrgan(string input, string output)
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "Realesrgan\\realesrgan-ncnn-vulkan",
                Arguments = $"-i \"{input}\" -n {dataimg} -s {imgscale} -o \"{output}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(ps))
            {
                process.WaitForExit();
            }
        }

        private void BtnOpen1_Click(object sender, EventArgs e)
        {
            
            btnUpscale2.ForeColor = Color.Transparent;
            btnUpscale2.BackColor = Color.Black;
            btnDifuse3.ForeColor = Color.Transparent;
            btnDifuse3.BackColor = Color.Black;
            btnLinear3.ForeColor = Color.Transparent;
            btnLinear3.BackColor = Color.Black;
            BtnOpen1.ForeColor = Color.Transparent;
            BtnOpen1.BackColor = Color.Black;

            try
            {
                if (!string.IsNullOrEmpty(selectedFolderPath) && Directory.Exists(selectedFolderPath))
                {
                    // Membuka folder di File Explorer
                    Process.Start("explorer.exe", $"\"{selectedFolderPath}\"");
                }
                else
                {
                    MessageBox.Show("Folder path is invalid or does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDifuse3_Click(object sender, EventArgs e)
        {
            btnUpscale2.ForeColor = Color.Transparent;
            btnUpscale2.BackColor = Color.Black;
            btnDifuse3.ForeColor = Color.Transparent;
            btnDifuse3.BackColor = Color.Black;
            btnLinear3.ForeColor = Color.Transparent;
            btnLinear3.BackColor = Color.Black;
            BtnOpen1.ForeColor = Color.Transparent;
            BtnOpen1.BackColor = Color.Black;

            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                Log("\nPlease select a folder first.");
                return;
            }

            string inputFolder = Path.Combine(selectedFolderPath, "UPSCALED");
            if (!Directory.Exists(inputFolder))
            {
                inputFolder = selectedFolderPath; // Jika folder UPSCALED tidak ada, proses di folder utama
            }

            var pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.AllDirectories);

            foreach (var pngFile in pngFiles)
            {
                try
                {
                    string ddsFile = Path.GetDirectoryName(pngFile);

                    // Konversi PNG ke DDS dengan BC7 sRGB
                    ConvertToDDS(pngFile, ddsFile, " -f BC7_UNORM_SRGB -nologo --separate-alpha ");

                    Log($"\nConverted {pngFile} to {ddsFile}");

                    // Hapus file PNG jika pngCheck dicentang
                    if (!pngCheck.Checked)
                    {
                        File.Delete(pngFile);
                        Log($"Deleted PNG file: {pngFile}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"\nError processing {pngFile}: {ex.Message}");
                }
            }

            Log("\nAll PNG files processed and converted to SRGB.\n");
            btnDifuse3.ForeColor = Color.Black;
            btnDifuse3.BackColor = Color.Lime;
            BtnOpen1.ForeColor = Color.Black;
            BtnOpen1.BackColor = Color.Lime;
            PlayCompletionSound();
        }

        private void btnLinear3_Click(object sender, EventArgs e)
        {
            btnUpscale2.ForeColor = Color.Transparent;
            btnUpscale2.BackColor = Color.Black;
            btnDifuse3.ForeColor = Color.Transparent;
            btnDifuse3.BackColor = Color.Black;
            btnLinear3.ForeColor = Color.Transparent;
            btnLinear3.BackColor = Color.Black;
            BtnOpen1.ForeColor = Color.Transparent;
            BtnOpen1.BackColor = Color.Black; 
            
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                Log("\nPlease select a folder first.");
                return;
            }

            string inputFolder = Path.Combine(selectedFolderPath, "UPSCALED");
            if (!Directory.Exists(inputFolder))
            {
                inputFolder = selectedFolderPath; // Jika folder UPSCALED tidak ada, proses di folder utama
            }

            var pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.AllDirectories);

            foreach (var pngFile in pngFiles)
            {
                try
                {
                    string ddsFile = Path.GetDirectoryName(pngFile);

                    // Konversi PNG ke DDS dengan BC7 sRGB
                    ConvertToDDS(pngFile, ddsFile, " -f BC7_UNORM -srgbo -nologo --separate-alpha ");

                    Log($"\nConverted {pngFile} to {ddsFile}");

                    // Hapus file PNG jika pngCheck dicentang
                    if (!pngCheck.Checked)
                    {
                        File.Delete(pngFile);
                        Log($"\nDeleted PNG file: {pngFile}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"\nError processing {pngFile}: {ex.Message}");
                }
            }

            Log("\nAll PNG files processed and converted to Linear.\n");
            btnLinear3.ForeColor = Color.Black;
            btnLinear3.BackColor = Color.Lime;
            BtnOpen1.ForeColor = Color.Black;
            BtnOpen1.BackColor = Color.Lime;
            PlayCompletionSound();
        }
    }
}
