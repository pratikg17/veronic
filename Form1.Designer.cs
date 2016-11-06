namespace Ver
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTimer = new System.Windows.Forms.Label();
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.ShutdownTimer = new System.Windows.Forms.Timer(this.components);
            this.pbVer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbVer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(508, 381);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 13);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Visible = false;
            // 
            // lstCommands
            // 
            this.lstCommands.BackColor = System.Drawing.SystemColors.Desktop;
            this.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCommands.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.ItemHeight = 15;
            this.lstCommands.Location = new System.Drawing.Point(0, 4);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(165, 420);
            this.lstCommands.TabIndex = 1;
            this.lstCommands.Visible = false;
            this.lstCommands.SelectedIndexChanged += new System.EventHandler(this.lstCommands_SelectedIndexChanged);
            // 
            // ShutdownTimer
            // 
            this.ShutdownTimer.Enabled = true;
            this.ShutdownTimer.Interval = 10;
            this.ShutdownTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbVer
            // 
            this.pbVer.Image = global::Ver.Properties.Resources.cortana;
            this.pbVer.Location = new System.Drawing.Point(574, 65);
            this.pbVer.Name = "pbVer";
            this.pbVer.Size = new System.Drawing.Size(390, 329);
            this.pbVer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVer.TabIndex = 2;
            this.pbVer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(976, 431);
            this.Controls.Add(this.pbVer);
            this.Controls.Add(this.lstCommands);
            this.Controls.Add(this.lblTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VERONICA";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.Timer ShutdownTimer;
        private System.Windows.Forms.PictureBox pbVer;
    }
}

