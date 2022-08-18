
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
            this.VeloX = new System.Windows.Forms.Label();
            this.veloTmr = new System.Windows.Forms.Timer(this.components);
            this.p1atkTime = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.VeloX);
            this.mainPanel.Location = new System.Drawing.Point(-1, -1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(848, 680);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // VeloX
            // 
            this.VeloX.AutoSize = true;
            this.VeloX.Location = new System.Drawing.Point(14, 14);
            this.VeloX.Name = "VeloX";
            this.VeloX.Size = new System.Drawing.Size(33, 13);
            this.VeloX.TabIndex = 0;
            this.VeloX.Text = "Velox";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 677);
            this.Controls.Add(this.mainPanel);
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
        private System.Windows.Forms.Label VeloX;
        private System.Windows.Forms.Timer p1atkTime;
    }
}

