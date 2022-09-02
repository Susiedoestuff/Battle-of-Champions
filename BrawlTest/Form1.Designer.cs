
namespace BrawlTest
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.p2hpdisplay = new System.Windows.Forms.Label();
            this.p1hpdisplay = new System.Windows.Forms.Label();
            this.veloTmr = new System.Windows.Forms.Timer(this.components);
            this.p1atkTime = new System.Windows.Forms.Timer(this.components);
            this.p2atkTime = new System.Windows.Forms.Timer(this.components);
            this.p1stunTmr = new System.Windows.Forms.Timer(this.components);
            this.p2stunTmr = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.p2hpdisplay);
            this.mainPanel.Controls.Add(this.p1hpdisplay);
            this.mainPanel.Location = new System.Drawing.Point(-1, -1);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1131, 837);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // p2hpdisplay
            // 
            this.p2hpdisplay.AutoSize = true;
            this.p2hpdisplay.Location = new System.Drawing.Point(1044, 17);
            this.p2hpdisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.p2hpdisplay.Name = "p2hpdisplay";
            this.p2hpdisplay.Size = new System.Drawing.Size(46, 17);
            this.p2hpdisplay.TabIndex = 1;
            this.p2hpdisplay.Text = "label2";
            // 
            // p1hpdisplay
            // 
            this.p1hpdisplay.AutoSize = true;
            this.p1hpdisplay.Location = new System.Drawing.Point(19, 17);
            this.p1hpdisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.p1hpdisplay.Name = "p1hpdisplay";
            this.p1hpdisplay.Size = new System.Drawing.Size(46, 17);
            this.p1hpdisplay.TabIndex = 0;
            this.p1hpdisplay.Text = "label1";
            // 
            // veloTmr
            // 
            this.veloTmr.Enabled = true;
            this.veloTmr.Interval = 10;
            this.veloTmr.Tick += new System.EventHandler(this.veloTmr_Tick);
            // 
            // p1atkTime
            // 
            this.p1atkTime.Tick += new System.EventHandler(this.p1atkTime_Tick);
            // 
            // p2atkTime
            // 
            this.p2atkTime.Tick += new System.EventHandler(this.p2atkTime_Tick);
            // 
            // p1stunTmr
            // 
            this.p1stunTmr.Interval = 50;
            // 
            // p2stunTmr
            // 
            this.p2stunTmr.Interval = 50;
            this.p2stunTmr.Tick += new System.EventHandler(this.p2stunTmr_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 833);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer veloTmr;
        private System.Windows.Forms.Timer p1atkTime;
        private System.Windows.Forms.Timer p2atkTime;
        private System.Windows.Forms.Label p2hpdisplay;
        private System.Windows.Forms.Label p1hpdisplay;
        private System.Windows.Forms.Timer p1stunTmr;
        private System.Windows.Forms.Timer p2stunTmr;
    }
}

