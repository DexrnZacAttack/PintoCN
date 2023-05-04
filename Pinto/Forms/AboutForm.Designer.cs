namespace PintoNS.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Translator2 = new System.Windows.Forms.LinkLabel();
            this.Translator1 = new System.Windows.Forms.LinkLabel();
            this.TranslatorsText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PintoNS.Logo.LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(122, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pinto!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.BackColor = System.Drawing.Color.Transparent;
            this.lVersion.Location = new System.Drawing.Point(119, 186);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(55, 13);
            this.lVersion.TabIndex = 3;
            this.lVersion.Text = "版本不明";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(115, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "深吸一口气...";
            // 
            // Translator2
            // 
            this.Translator2.AutoSize = true;
            this.Translator2.Location = new System.Drawing.Point(10, 246);
            this.Translator2.Name = "Translator2";
            this.Translator2.Size = new System.Drawing.Size(85, 13);
            this.Translator2.TabIndex = 5;
            this.Translator2.TabStop = true;
            this.Translator2.Text = "DexrnZacAttack";
            this.Translator2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Translator2_LinkClicked);
            // 
            // Translator1
            // 
            this.Translator1.AutoSize = true;
            this.Translator1.Location = new System.Drawing.Point(12, 228);
            this.Translator1.Name = "Translator1";
            this.Translator1.Size = new System.Drawing.Size(53, 13);
            this.Translator1.TabIndex = 6;
            this.Translator1.TabStop = true;
            this.Translator1.Text = "mc_kuhei";
            this.Translator1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Translator1_LinkClicked);
            // 
            // TranslatorsText
            // 
            this.TranslatorsText.AutoSize = true;
            this.TranslatorsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslatorsText.Location = new System.Drawing.Point(10, 201);
            this.TranslatorsText.Name = "TranslatorsText";
            this.TranslatorsText.Size = new System.Drawing.Size(86, 24);
            this.TranslatorsText.TabIndex = 7;
            this.TranslatorsText.Text = "翻译人员";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PintoNS.Logo.LOGO_BACKGROUND;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(291, 267);
            this.Controls.Add(this.TranslatorsText);
            this.Controls.Add(this.Translator1);
            this.Controls.Add(this.Translator2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(307, 306);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(307, 306);
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pinto! - 关于";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel Translator2;
        private System.Windows.Forms.LinkLabel Translator1;
        private System.Windows.Forms.Label TranslatorsText;
    }
}