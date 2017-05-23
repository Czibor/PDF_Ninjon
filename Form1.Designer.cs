namespace PDF_Ninjon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.textBoxOutputDirectory = new System.Windows.Forms.TextBox();
            this.numericUpDownPages = new System.Windows.Forms.NumericUpDown();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.radioButtonMulti = new System.Windows.Forms.RadioButton();
            this.textBoxPages = new System.Windows.Forms.TextBox();
            this.labelPages = new System.Windows.Forms.Label();
            this.labelOutputDirectorz = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.fileDialogInputFile = new System.Windows.Forms.Button();
            this.folderBrowserDialogOutput = new System.Windows.Forms.Button();
            this.checkBoxOpenResult = new System.Windows.Forms.CheckBox();
            this.buttonHelpOneFile = new System.Windows.Forms.Button();
            this.buttonHelpMoreFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPages)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.ForeColor = System.Drawing.Color.White;
            this.buttonStart.Location = new System.Drawing.Point(263, 306);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(110, 55);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputFile.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInputFile.Location = new System.Drawing.Point(30, 34);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(248, 22);
            this.textBoxInputFile.TabIndex = 1;
            // 
            // textBoxOutputDirectory
            // 
            this.textBoxOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputDirectory.Location = new System.Drawing.Point(30, 101);
            this.textBoxOutputDirectory.Name = "textBoxOutputDirectory";
            this.textBoxOutputDirectory.Size = new System.Drawing.Size(248, 22);
            this.textBoxOutputDirectory.TabIndex = 3;
            // 
            // numericUpDownPages
            // 
            this.numericUpDownPages.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDownPages.Location = new System.Drawing.Point(175, 227);
            this.numericUpDownPages.Name = "numericUpDownPages";
            this.numericUpDownPages.ReadOnly = true;
            this.numericUpDownPages.Size = new System.Drawing.Size(145, 22);
            this.numericUpDownPages.TabIndex = 11;
            this.numericUpDownPages.TabStop = false;
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Checked = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(50, 183);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(78, 21);
            this.radioButtonSingle.TabIndex = 15;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "One file";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            this.radioButtonSingle.CheckedChanged += new System.EventHandler(this.radioButtonSingle_CheckedChanged);
            // 
            // radioButtonMulti
            // 
            this.radioButtonMulti.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonMulti.AutoSize = true;
            this.radioButtonMulti.Location = new System.Drawing.Point(50, 226);
            this.radioButtonMulti.Name = "radioButtonMulti";
            this.radioButtonMulti.Size = new System.Drawing.Size(90, 21);
            this.radioButtonMulti.TabIndex = 12;
            this.radioButtonMulti.Text = "More files";
            this.radioButtonMulti.UseVisualStyleBackColor = true;
            this.radioButtonMulti.CheckedChanged += new System.EventHandler(this.radioButtonMulti_CheckedChanged);
            // 
            // textBoxPages
            // 
            this.textBoxPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPages.Location = new System.Drawing.Point(175, 181);
            this.textBoxPages.Name = "textBoxPages";
            this.textBoxPages.Size = new System.Drawing.Size(145, 22);
            this.textBoxPages.TabIndex = 5;
            // 
            // labelPages
            // 
            this.labelPages.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPages.AutoSize = true;
            this.labelPages.Location = new System.Drawing.Point(30, 154);
            this.labelPages.Name = "labelPages";
            this.labelPages.Size = new System.Drawing.Size(109, 17);
            this.labelPages.TabIndex = 7;
            this.labelPages.Text = "Splitting method";
            // 
            // labelOutputDirectorz
            // 
            this.labelOutputDirectorz.AutoSize = true;
            this.labelOutputDirectorz.Location = new System.Drawing.Point(30, 80);
            this.labelOutputDirectorz.Name = "labelOutputDirectorz";
            this.labelOutputDirectorz.Size = new System.Drawing.Size(110, 17);
            this.labelOutputDirectorz.TabIndex = 8;
            this.labelOutputDirectorz.Text = "Output directory";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(30, 14);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(87, 17);
            this.labelInputFile.TabIndex = 9;
            this.labelInputFile.Text = "Choose PDF";
            // 
            // fileDialogInputFile
            // 
            this.fileDialogInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDialogInputFile.BackColor = System.Drawing.Color.Silver;
            this.fileDialogInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileDialogInputFile.Location = new System.Drawing.Point(298, 28);
            this.fileDialogInputFile.Name = "fileDialogInputFile";
            this.fileDialogInputFile.Size = new System.Drawing.Size(75, 34);
            this.fileDialogInputFile.TabIndex = 0;
            this.fileDialogInputFile.Text = "File";
            this.fileDialogInputFile.UseVisualStyleBackColor = false;
            this.fileDialogInputFile.Click += new System.EventHandler(this.fileDialogInputFile_Click);
            // 
            // folderBrowserDialogOutput
            // 
            this.folderBrowserDialogOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderBrowserDialogOutput.BackColor = System.Drawing.Color.Silver;
            this.folderBrowserDialogOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.folderBrowserDialogOutput.Location = new System.Drawing.Point(298, 95);
            this.folderBrowserDialogOutput.Name = "folderBrowserDialogOutput";
            this.folderBrowserDialogOutput.Size = new System.Drawing.Size(75, 34);
            this.folderBrowserDialogOutput.TabIndex = 2;
            this.folderBrowserDialogOutput.Text = "Folder";
            this.folderBrowserDialogOutput.UseVisualStyleBackColor = false;
            this.folderBrowserDialogOutput.Click += new System.EventHandler(this.folderBrowserDialogOutput_Click);
            // 
            // checkBoxOpenResult
            // 
            this.checkBoxOpenResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxOpenResult.AutoSize = true;
            this.checkBoxOpenResult.Checked = true;
            this.checkBoxOpenResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOpenResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxOpenResult.Location = new System.Drawing.Point(32, 324);
            this.checkBoxOpenResult.Name = "checkBoxOpenResult";
            this.checkBoxOpenResult.Size = new System.Drawing.Size(221, 21);
            this.checkBoxOpenResult.TabIndex = 6;
            this.checkBoxOpenResult.Text = "Open file or folder when ready";
            this.checkBoxOpenResult.UseVisualStyleBackColor = true;
            // 
            // buttonHelpOneFile
            // 
            this.buttonHelpOneFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonHelpOneFile.BackColor = System.Drawing.Color.Silver;
            this.buttonHelpOneFile.Location = new System.Drawing.Point(338, 179);
            this.buttonHelpOneFile.Name = "buttonHelpOneFile";
            this.buttonHelpOneFile.Size = new System.Drawing.Size(35, 29);
            this.buttonHelpOneFile.TabIndex = 13;
            this.buttonHelpOneFile.TabStop = false;
            this.buttonHelpOneFile.Text = "?";
            this.buttonHelpOneFile.UseVisualStyleBackColor = false;
            this.buttonHelpOneFile.Click += new System.EventHandler(this.buttonHelpOneFile_Click);
            // 
            // buttonHelpMoreFiles
            // 
            this.buttonHelpMoreFiles.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonHelpMoreFiles.BackColor = System.Drawing.Color.Silver;
            this.buttonHelpMoreFiles.Location = new System.Drawing.Point(338, 224);
            this.buttonHelpMoreFiles.Name = "buttonHelpMoreFiles";
            this.buttonHelpMoreFiles.Size = new System.Drawing.Size(35, 29);
            this.buttonHelpMoreFiles.TabIndex = 14;
            this.buttonHelpMoreFiles.TabStop = false;
            this.buttonHelpMoreFiles.Text = "?";
            this.buttonHelpMoreFiles.UseVisualStyleBackColor = false;
            this.buttonHelpMoreFiles.Click += new System.EventHandler(this.buttonHelpMoreFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(400, 384);
            this.Controls.Add(this.buttonHelpMoreFiles);
            this.Controls.Add(this.buttonHelpOneFile);
            this.Controls.Add(this.checkBoxOpenResult);
            this.Controls.Add(this.folderBrowserDialogOutput);
            this.Controls.Add(this.fileDialogInputFile);
            this.Controls.Add(this.labelInputFile);
            this.Controls.Add(this.labelOutputDirectorz);
            this.Controls.Add(this.labelPages);
            this.Controls.Add(this.textBoxPages);
            this.Controls.Add(this.radioButtonMulti);
            this.Controls.Add(this.radioButtonSingle);
            this.Controls.Add(this.numericUpDownPages);
            this.Controls.Add(this.textBoxOutputDirectory);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.buttonStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "PDF Ninjon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.TextBox textBoxOutputDirectory;
        private System.Windows.Forms.NumericUpDown numericUpDownPages;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.RadioButton radioButtonMulti;
        private System.Windows.Forms.TextBox textBoxPages;
        private System.Windows.Forms.Label labelPages;
        private System.Windows.Forms.Label labelOutputDirectorz;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Button fileDialogInputFile;
        private System.Windows.Forms.Button folderBrowserDialogOutput;
        private System.Windows.Forms.CheckBox checkBoxOpenResult;
        private System.Windows.Forms.Button buttonHelpOneFile;
        private System.Windows.Forms.Button buttonHelpMoreFiles;
    }
}