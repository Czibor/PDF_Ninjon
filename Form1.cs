using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PDF_Ninjon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FormLocation != null)
            {
                this.Location = Properties.Settings.Default.FormLocation;
            }

            if (Properties.Settings.Default.FormSize != null)
            {
                this.Size = Properties.Settings.Default.FormSize;
            }
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormLocation = this.Location;

            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.FormSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.FormSize = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();
        }

        void radioButtonSingle_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPages.ReadOnly = false;
            numericUpDownPages.ReadOnly = true;
        }

        void radioButtonMulti_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPages.ReadOnly = true;
            numericUpDownPages.ReadOnly = false;
        }

        void fileDialogInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select file";
            fd.Filter = "PDF files|*.pdf";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxInputFile.Text = fd.FileName;
            }

            // Displays available pages
            if (String.IsNullOrEmpty(textBoxPages.Text))
            {
                int lastPage = Parameters.NumberOfPages(textBoxInputFile.Text);

                if (lastPage != 0)
                {
                    textBoxPages.Text = $"1-{lastPage}";
                }
            }
        }

        void folderBrowserDialogOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select folder";
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputDirectory.Text = fbd.SelectedPath;
            }
        }

        void buttonHelpOneFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"You will get a PDF with the specified pages. {Environment.NewLine}You can use '-' for giving range and ',' for separation.",
                "Help");
        }

        void buttonHelpMoreFiles_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Your PDF will be splitted into smaller files. {Environment.NewLine}Give the number of pages you need in one file.",
                "Help");
        }

        void buttonStart_Click(object sender, EventArgs e)
        {
            SplitSettings splitSettings = new SplitSettings();
            splitSettings.InputFile = textBoxInputFile.Text;
            splitSettings.OutputDirectory = textBoxOutputDirectory.Text;

            if (radioButtonMulti.Checked == true)
            {
                splitSettings.MultiOutput = true;
                splitSettings.PageNumbers = new List<int>();
                
                if (numericUpDownPages.Value != 0)
                {
                	splitSettings.PageNumbers.Add(Convert.ToInt32(numericUpDownPages.Value));
                }
            }
            else
            {
                splitSettings.PageNumbers = splitSettings.GenerateNumberList(textBoxPages.Text);
            }

            List<string> errorMessage = Parameters.SearchForErrors(splitSettings);

            if (errorMessage.Count != 0)
            {
            	MessageBox.Show(errorMessage[0], errorMessage[1]);
            }
            else
            {
            	if (splitSettings.ChangedPageNumbers != null)
                {
                    MessageBox.Show($"The parameter for page numbers has been corrected: {Environment.NewLine}{splitSettings.ChangedPageNumbers}",
                        "Parameter change");
                }

                try
                {
                    Splitter.SplitPDF(splitSettings);

                    if (checkBoxOpenResult.Checked)
                    {
                        if (splitSettings.MultiOutput)
                        {
                            System.Diagnostics.Process.Start(splitSettings.OutputDirectory);
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(Path.Combine(splitSettings.OutputDirectory, splitSettings.PdfName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}