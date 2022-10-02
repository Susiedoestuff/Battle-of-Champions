
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.veloTmr = new System.Windows.Forms.Timer(this.components);
            this.p1atkTime = new System.Windows.Forms.Timer(this.components);
            this.p2atkTime = new System.Windows.Forms.Timer(this.components);
            this.p1stunTmr = new System.Windows.Forms.Timer(this.components);
            this.p2stunTmr = new System.Windows.Forms.Timer(this.components);
            this.aniTmr = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 750);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // veloTmr
            // 
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
            this.p1stunTmr.Tick += new System.EventHandler(this.p1stunTmr_Tick);
            // 
            // p2stunTmr
            // 
            this.p2stunTmr.Interval = 50;
            this.p2stunTmr.Tick += new System.EventHandler(this.p2stunTmr_Tick);
            // 
            // aniTmr
            // 
            this.aniTmr.Enabled = true;
            this.aniTmr.Interval = 125;
            this.aniTmr.Tick += new System.EventHandler(this.aniTmr_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(999, 750);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Battle of Champions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer veloTmr;
        private System.Windows.Forms.Timer p1atkTime;
        private System.Windows.Forms.Timer p2atkTime;
        private System.Windows.Forms.Timer p1stunTmr;
        private System.Windows.Forms.Timer p2stunTmr;
        private System.Windows.Forms.Timer aniTmr;
    }
}

