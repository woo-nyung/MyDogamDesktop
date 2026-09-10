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
            arrowLabel = new Label();
            btnDelete = new Button();
            pictureBoxItem = new PictureBox();
            txtItemInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).BeginInit();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(24, 18);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(74, 39);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "추가";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // lstCollections
            // 
            lstCollections.FormattingEnabled = true;
            lstCollections.Location = new Point(24, 59);
            lstCollections.Name = "lstCollections";
            lstCollections.Size = new Size(153, 364);
            lstCollections.TabIndex = 1;
            lstCollections.SelectedIndexChanged += lstCollections_SelectedIndexChanged;
            // 
            // lstItems
            // 
            lstItems.FormattingEnabled = true;
            lstItems.Location = new Point(217, 19);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(274, 404);
            lstItems.TabIndex = 2;
            lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
            // 
            // arrowLabel
            // 
            arrowLabel.AutoSize = true;
            arrowLabel.Font = new Font("맑은 고딕", 16F);
            arrowLabel.ForeColor = SystemColors.WindowFrame;
            arrowLabel.Location = new Point(177, 210);
            arrowLabel.Name = "arrowLabel";
            arrowLabel.Size = new Size(44, 37);
            arrowLabel.TabIndex = 3;
            arrowLabel.Text = "➜";
            arrowLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(104, 18);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(73, 39);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // pictureBoxItem
            // 
            pictureBoxItem.BackColor = SystemColors.WindowFrame;
            pictureBoxItem.Location = new Point(506, 19);
            pictureBoxItem.Name = "pictureBoxItem";
            pictureBoxItem.Size = new Size(271, 280);
            pictureBoxItem.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxItem.TabIndex = 5;
            pictureBoxItem.TabStop = false;
            // 
            // txtItemInfo
            // 
            txtItemInfo.BackColor = SystemColors.ControlLightLight;
            txtItemInfo.BorderStyle = BorderStyle.None;
            txtItemInfo.Location = new Point(506, 313);
            txtItemInfo.Multiline = true;
            txtItemInfo.Name = "txtItemInfo";
            txtItemInfo.ReadOnly = true;
            txtItemInfo.Size = new Size(271, 110);
            txtItemInfo.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(txtItemInfo);
            Controls.Add(pictureBoxItem);
            Controls.Add(btnDelete);
            Controls.Add(lstItems);
            Controls.Add(lstCollections);
            Controls.Add(btnUpload);
            Controls.Add(arrowLabel);
            Name = "MainForm";
            Text = "MY도감";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lstCollections;
        private Button btnUpload;
        private ListBox lstItems;
        private Label arrowLabel;
        private Button btnDelete;
        private PictureBox pictureBoxItem;
        private TextBox txtItemInfo;
    }
}
