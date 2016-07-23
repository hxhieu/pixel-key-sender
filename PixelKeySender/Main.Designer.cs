namespace PixelKeySender
{
    partial class Main
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.ddlProcesses = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtPixelX = new System.Windows.Forms.TextBox();
            this.txtPixelY = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 117);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.StartClick);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(118, 91);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(131, 20);
            this.txtInterval.TabIndex = 1;
            this.txtInterval.Text = "200";
            // 
            // ddlProcesses
            // 
            this.ddlProcesses.FormattingEnabled = true;
            this.ddlProcesses.Location = new System.Drawing.Point(12, 64);
            this.ddlProcesses.Name = "ddlProcesses";
            this.ddlProcesses.Size = new System.Drawing.Size(237, 21);
            this.ddlProcesses.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 117);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.StopClick);
            // 
            // txtPixelX
            // 
            this.txtPixelX.Location = new System.Drawing.Point(12, 91);
            this.txtPixelX.Name = "txtPixelX";
            this.txtPixelX.Size = new System.Drawing.Size(48, 20);
            this.txtPixelX.TabIndex = 4;
            this.txtPixelX.Text = "1";
            // 
            // txtPixelY
            // 
            this.txtPixelY.Location = new System.Drawing.Point(66, 91);
            this.txtPixelY.Name = "txtPixelY";
            this.txtPixelY.Size = new System.Drawing.Size(46, 20);
            this.txtPixelY.TabIndex = 5;
            this.txtPixelY.Text = "1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(174, 117);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 152);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtPixelY);
            this.Controls.Add(this.txtPixelX);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.ddlProcesses);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pixel Key Sender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.ComboBox ddlProcesses;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtPixelX;
        private System.Windows.Forms.TextBox txtPixelY;
        private System.Windows.Forms.Button btnRefresh;
    }
}

