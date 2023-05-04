﻿namespace PintoNS.Forms
{
    partial class MessageForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.btnSend = new System.Windows.Forms.Button();
            this.rtxtInput = new System.Windows.Forms.RichTextBox();
            this.rtxtMessages = new System.Windows.Forms.RichTextBox();
            this.btnTalk = new System.Windows.Forms.Button();
            this.ilButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnBlock = new System.Windows.Forms.Button();
            this.tsMenuBar = new System.Windows.Forms.ToolStrip();
            this.tsddbMenuBarFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiMenuBarFileClearSavedData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbMenuBarHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiMenuBarHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslStatusBarTypingList = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnColor = new System.Windows.Forms.Button();
            this.cdPicker = new System.Windows.Forms.ColorDialog();
            this.tsMenuBar.SuspendLayout();
            this.ssStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(362, 283);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(60, 30);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "&发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtxtInput
            // 
            this.rtxtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtInput.HideSelection = false;
            this.rtxtInput.Location = new System.Drawing.Point(12, 283);
            this.rtxtInput.MaxLength = 384;
            this.rtxtInput.Name = "rtxtInput";
            this.rtxtInput.Size = new System.Drawing.Size(344, 56);
            this.rtxtInput.TabIndex = 0;
            this.rtxtInput.Text = "";
            this.rtxtInput.SelectionChanged += new System.EventHandler(this.rtxtInput_SelectionChanged);
            this.rtxtInput.TextChanged += new System.EventHandler(this.rtxtInput_TextChanged);
            this.rtxtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtInput_KeyDown);
            // 
            // rtxtMessages
            // 
            this.rtxtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMessages.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtMessages.Location = new System.Drawing.Point(12, 75);
            this.rtxtMessages.Name = "rtxtMessages";
            this.rtxtMessages.ReadOnly = true;
            this.rtxtMessages.Size = new System.Drawing.Size(410, 202);
            this.rtxtMessages.TabIndex = 2;
            this.rtxtMessages.Text = "";
            this.rtxtMessages.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtxtMessages_LinkClicked);
            this.rtxtMessages.TextChanged += new System.EventHandler(this.rtxtMessages_TextChanged);
            // 
            // btnTalk
            // 
            this.btnTalk.BackColor = System.Drawing.SystemColors.Control;
            this.btnTalk.FlatAppearance.BorderSize = 0;
            this.btnTalk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTalk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTalk.ImageKey = "TALK";
            this.btnTalk.ImageList = this.ilButtons;
            this.btnTalk.Location = new System.Drawing.Point(12, 28);
            this.btnTalk.Name = "btnTalk";
            this.btnTalk.Size = new System.Drawing.Size(68, 41);
            this.btnTalk.TabIndex = 3;
            this.btnTalk.Text = "呼叫";
            this.btnTalk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTalk.UseVisualStyleBackColor = false;
            this.btnTalk.Click += new System.EventHandler(this.btnTalk_Click);
            // 
            // ilButtons
            // 
            this.ilButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilButtons.ImageStream")));
            this.ilButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilButtons.Images.SetKeyName(0, "BLOCK");
            this.ilButtons.Images.SetKeyName(1, "TALK");
            // 
            // btnBlock
            // 
            this.btnBlock.BackColor = System.Drawing.SystemColors.Control;
            this.btnBlock.FlatAppearance.BorderSize = 0;
            this.btnBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBlock.ImageKey = "BLOCK";
            this.btnBlock.ImageList = this.ilButtons;
            this.btnBlock.Location = new System.Drawing.Point(86, 28);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(68, 41);
            this.btnBlock.TabIndex = 4;
            this.btnBlock.Text = "区块";
            this.btnBlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBlock.UseVisualStyleBackColor = false;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // tsMenuBar
            // 
            this.tsMenuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMenuBarFile,
            this.tsddbMenuBarHelp});
            this.tsMenuBar.Location = new System.Drawing.Point(0, 0);
            this.tsMenuBar.Name = "tsMenuBar";
            this.tsMenuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMenuBar.Size = new System.Drawing.Size(433, 25);
            this.tsMenuBar.TabIndex = 0;
            this.tsMenuBar.Text = "toolStrip1";
            // 
            // tsddbMenuBarFile
            // 
            this.tsddbMenuBarFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbMenuBarFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenuBarFileClearSavedData});
            this.tsddbMenuBarFile.Image = ((System.Drawing.Image)(resources.GetObject("tsddbMenuBarFile.Image")));
            this.tsddbMenuBarFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMenuBarFile.Name = "tsddbMenuBarFile";
            this.tsddbMenuBarFile.ShowDropDownArrow = false;
            this.tsddbMenuBarFile.Size = new System.Drawing.Size(35, 22);
            this.tsddbMenuBarFile.Text = "文件";
            this.tsddbMenuBarFile.ToolTipText = "tsddbMenuBarFile";
            // 
            // tsmiMenuBarFileClearSavedData
            // 
            this.tsmiMenuBarFileClearSavedData.Name = "tsmiMenuBarFileClearSavedData";
            this.tsmiMenuBarFileClearSavedData.Size = new System.Drawing.Size(182, 22);
            this.tsmiMenuBarFileClearSavedData.Text = "清除保存的聊天数据";
            this.tsmiMenuBarFileClearSavedData.Click += new System.EventHandler(this.tsmiMenuBarFileClearSavedData_Click);
            // 
            // tsddbMenuBarHelp
            // 
            this.tsddbMenuBarHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbMenuBarHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenuBarHelpAbout});
            this.tsddbMenuBarHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsddbMenuBarHelp.Image")));
            this.tsddbMenuBarHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMenuBarHelp.Name = "tsddbMenuBarHelp";
            this.tsddbMenuBarHelp.ShowDropDownArrow = false;
            this.tsddbMenuBarHelp.Size = new System.Drawing.Size(35, 22);
            this.tsddbMenuBarHelp.Text = "帮助";
            this.tsddbMenuBarHelp.ToolTipText = "Help";
            // 
            // tsmiMenuBarHelpAbout
            // 
            this.tsmiMenuBarHelpAbout.Name = "tsmiMenuBarHelpAbout";
            this.tsmiMenuBarHelpAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmiMenuBarHelpAbout.Text = "关于";
            this.tsmiMenuBarHelpAbout.Click += new System.EventHandler(this.tsmiMenuBarHelpAbout_Click);
            // 
            // ssStatusStrip
            // 
            this.ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusBarTypingList});
            this.ssStatusStrip.Location = new System.Drawing.Point(0, 351);
            this.ssStatusStrip.Name = "ssStatusStrip";
            this.ssStatusStrip.Size = new System.Drawing.Size(433, 22);
            this.ssStatusStrip.TabIndex = 5;
            this.ssStatusStrip.Text = "statusStrip1";
            // 
            // tsslStatusBarTypingList
            // 
            this.tsslStatusBarTypingList.Name = "tsslStatusBarTypingList";
            this.tsslStatusBarTypingList.Size = new System.Drawing.Size(0, 17);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColor.Location = new System.Drawing.Point(362, 319);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(60, 20);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "颜色";
            this.btnColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 373);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.ssStatusStrip);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.btnTalk);
            this.Controls.Add(this.rtxtMessages);
            this.Controls.Add(this.rtxtInput);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tsMenuBar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(149, 229);
            this.Name = "MessageForm";
            this.Activated += new System.EventHandler(this.MessageForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageForm_FormClosing);
            this.tsMenuBar.ResumeLayout(false);
            this.tsMenuBar.PerformLayout();
            this.ssStatusStrip.ResumeLayout(false);
            this.ssStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtxtInput;
        private System.Windows.Forms.RichTextBox rtxtMessages;
        private System.Windows.Forms.Button btnTalk;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.ImageList ilButtons;
        private System.Windows.Forms.ToolStrip tsMenuBar;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMenuBarHelp;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel tsslStatusBarTypingList;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuBarHelpAbout;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog cdPicker;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMenuBarFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuBarFileClearSavedData;
    }
}