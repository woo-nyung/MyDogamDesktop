namespace MyDogamDesktop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUpload = new Button();
            lstCollections = new ListBox();
            lstItems = new ListBox();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(23, 23);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(174, 34);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Json 업로드";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // lstCollections
            // 
            lstCollections.FormattingEnabled = true;
            lstCollections.Location = new Point(23, 64);
            lstCollections.Name = "lstCollections";
            lstCollections.Size = new Size(174, 364);
            lstCollections.TabIndex = 1;
            lstCollections.SelectedIndexChanged += lstCollections_SelectedIndexChanged;
            // 
            // lstItems
            // 
            lstItems.FormattingEnabled = true;
            lstItems.Location = new Point(249, 24);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(526, 404);
            lstItems.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstItems);
            Controls.Add(lstCollections);
            Controls.Add(btnUpload);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private ListBox lstCollections;
        private Button btnUpload;
        private ListBox lstItems;
    }
}
