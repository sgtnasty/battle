namespace BattleWin
{
    partial class BattleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConsoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddPlayerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BattleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ConsoleRichTextBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(952, 438);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(952, 490);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 25);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ConsoleRichTextBox
            // 
            this.ConsoleRichTextBox.BackColor = System.Drawing.Color.Black;
            this.ConsoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleRichTextBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.ConsoleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.ConsoleRichTextBox.Name = "ConsoleRichTextBox";
            this.ConsoleRichTextBox.ReadOnly = true;
            this.ConsoleRichTextBox.Size = new System.Drawing.Size(952, 438);
            this.ConsoleRichTextBox.TabIndex = 0;
            this.ConsoleRichTextBox.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPlayerToolStripButton,
            this.RollToolStripButton,
            this.BattleToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(192, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // AddPlayerToolStripButton
            // 
            this.AddPlayerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddPlayerToolStripButton.Image")));
            this.AddPlayerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPlayerToolStripButton.Name = "AddPlayerToolStripButton";
            this.AddPlayerToolStripButton.Size = new System.Drawing.Size(57, 24);
            this.AddPlayerToolStripButton.Text = "Add";
            this.AddPlayerToolStripButton.Click += new System.EventHandler(this.AddPlayerToolStripButton_Click);
            // 
            // RollToolStripButton
            // 
            this.RollToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RollToolStripButton.Image")));
            this.RollToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RollToolStripButton.Name = "RollToolStripButton";
            this.RollToolStripButton.Size = new System.Drawing.Size(55, 24);
            this.RollToolStripButton.Text = "Roll";
            this.RollToolStripButton.Click += new System.EventHandler(this.RollToolStripButton_Click);
            // 
            // BattleToolStripButton
            // 
            this.BattleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("BattleToolStripButton.Image")));
            this.BattleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BattleToolStripButton.Name = "BattleToolStripButton";
            this.BattleToolStripButton.Size = new System.Drawing.Size(68, 24);
            this.BattleToolStripButton.Text = "Battle";
            this.BattleToolStripButton.Click += new System.EventHandler(this.BattleToolStripButton_Click);
            // 
            // BattleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 490);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "BattleForm";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.BattleForm_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddPlayerToolStripButton;
        private System.Windows.Forms.ToolStripButton RollToolStripButton;
        private System.Windows.Forms.ToolStripButton BattleToolStripButton;
        private System.Windows.Forms.RichTextBox ConsoleRichTextBox;
    }
}

