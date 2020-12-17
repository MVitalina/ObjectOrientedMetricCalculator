namespace ObjectOrientedMetricCalculator
{
    partial class AnalyzerForm
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
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.buttonDepth = new System.Windows.Forms.Button();
            this.buttonChild = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenFolder.Location = new System.Drawing.Point(13, 13);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(165, 23);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "Open Folder To Analyze";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult.Location = new System.Drawing.Point(13, 71);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(775, 367);
            this.richTextBoxResult.TabIndex = 1;
            this.richTextBoxResult.Text = "";
            // 
            // buttonDepth
            // 
            this.buttonDepth.Enabled = false;
            this.buttonDepth.Location = new System.Drawing.Point(13, 42);
            this.buttonDepth.Name = "buttonDepth";
            this.buttonDepth.Size = new System.Drawing.Size(165, 23);
            this.buttonDepth.TabIndex = 2;
            this.buttonDepth.Text = "Get Depth Of Inheritance Tree";
            this.buttonDepth.UseVisualStyleBackColor = true;
            this.buttonDepth.Click += new System.EventHandler(this.buttonDepth_Click);
            // 
            // buttonChild
            // 
            this.buttonChild.Enabled = false;
            this.buttonChild.Location = new System.Drawing.Point(184, 42);
            this.buttonChild.Name = "buttonChild";
            this.buttonChild.Size = new System.Drawing.Size(165, 23);
            this.buttonChild.TabIndex = 3;
            this.buttonChild.Text = "Number Of Children";
            this.buttonChild.UseVisualStyleBackColor = true;
            this.buttonChild.Click += new System.EventHandler(this.buttonChild_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(184, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Default Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonChild);
            this.Controls.Add(this.buttonDepth);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.buttonOpenFolder);
            this.Name = "AnalyzerForm";
            this.Text = "AnalyzerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Button buttonDepth;
        private System.Windows.Forms.Button buttonChild;
        private System.Windows.Forms.Button button1;
    }
}