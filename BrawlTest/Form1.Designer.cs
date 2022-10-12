
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
            this.p2spclDesc = new System.Windows.Forms.Label();
            this.p2Name = new System.Windows.Forms.Label();
            this.p1spclDesc = new System.Windows.Forms.Label();
            this.p1Name = new System.Windows.Forms.Label();
            this.veloTmr = new System.Windows.Forms.Timer(this.components);
            this.p1atkTime = new System.Windows.Forms.Timer(this.components);
            this.p2atkTime = new System.Windows.Forms.Timer(this.components);
            this.p1stunTmr = new System.Windows.Forms.Timer(this.components);
            this.p2stunTmr = new System.Windows.Forms.Timer(this.components);
            this.aniTmr = new System.Windows.Forms.Timer(this.components);
            this.p1spclTmr = new System.Windows.Forms.Timer(this.components);
            this.p2spclTmr = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.Controls.Add(this.p2spclDesc);
            this.mainPanel.Controls.Add(this.p2Name);
            this.mainPanel.Controls.Add(this.p1spclDesc);
            this.mainPanel.Controls.Add(this.p1Name);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 750);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // p2spclDesc
            // 
            this.p2spclDesc.BackColor = System.Drawing.Color.Transparent;
            this.p2spclDesc.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2spclDesc.ForeColor = System.Drawing.Color.White;
            this.p2spclDesc.Location = new System.Drawing.Point(530, 306);
            this.p2spclDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2spclDesc.Name = "p2spclDesc";
            this.p2spclDesc.Size = new System.Drawing.Size(130, 76);
            this.p2spclDesc.TabIndex = 3;
            this.p2spclDesc.Text = "p2spclDesc";
            this.p2spclDesc.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.p2spclDesc.Visible = false;
            // 
            // p2Name
            // 
            this.p2Name.BackColor = System.Drawing.Color.Transparent;
            this.p2Name.Font = new System.Drawing.Font("Abel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Name.ForeColor = System.Drawing.Color.White;
            this.p2Name.Location = new System.Drawing.Point(500, 382);
            this.p2Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2Name.Name = "p2Name";
            this.p2Name.Size = new System.Drawing.Size(160, 38);
            this.p2Name.TabIndex = 2;
            this.p2Name.Text = "p2Name";
            this.p2Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.p2Name.Visible = false;
            // 
            // p1spclDesc
            // 
            this.p1spclDesc.BackColor = System.Drawing.Color.Transparent;
            this.p1spclDesc.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1spclDesc.ForeColor = System.Drawing.Color.White;
            this.p1spclDesc.Location = new System.Drawing.Point(340, 330);
            this.p1spclDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1spclDesc.Name = "p1spclDesc";
            this.p1spclDesc.Size = new System.Drawing.Size(140, 90);
            this.p1spclDesc.TabIndex = 1;
            this.p1spclDesc.Text = "p1spclDesc";
            this.p1spclDesc.Visible = false;
            // 
            // p1Name
            // 
            this.p1Name.BackColor = System.Drawing.Color.Transparent;
            this.p1Name.Font = new System.Drawing.Font("Abel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Name.ForeColor = System.Drawing.Color.White;
            this.p1Name.Location = new System.Drawing.Point(340, 300);
            this.p1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1Name.Name = "p1Name";
            this.p1Name.Size = new System.Drawing.Size(160, 38);
            this.p1Name.TabIndex = 0;
            this.p1Name.Text = "p1Name";
            this.p1Name.Visible = false;
            // 
            // veloTmr
            // 
            this.veloTmr.Interval = 15;
            this.veloTmr.Tick += new System.EventHandler(this.veloTmr_Tick);
            // 
            // p1atkTime
            // 
            this.p1atkTime.Interval = 125;
            this.p1atkTime.Tick += new System.EventHandler(this.p1atkTime_Tick);
            // 
            // p2atkTime
            // 
            this.p2atkTime.Interval = 125;
            this.p2atkTime.Tick += new System.EventHandler(this.p2atkTime_Tick);
            // 
            // p1stunTmr
            // 
            this.p1stunTmr.Tick += new System.EventHandler(this.p1stunTmr_Tick);
            // 
            // p2stunTmr
            // 
            this.p2stunTmr.Tick += new System.EventHandler(this.p2stunTmr_Tick);
            // 
            // aniTmr
            // 
            this.aniTmr.Enabled = true;
            this.aniTmr.Interval = 125;
            this.aniTmr.Tick += new System.EventHandler(this.aniTmr_Tick);
            // 
            // p1spclTmr
            // 
            this.p1spclTmr.Interval = 125;
            this.p1spclTmr.Tick += new System.EventHandler(this.p1spclTmr_Tick);
            // 
            // p2spclTmr
            // 
            this.p2spclTmr.Interval = 125;
            this.p2spclTmr.Tick += new System.EventHandler(this.p2spclTmr_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(998, 750);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1014, 789);
            this.MinimumSize = new System.Drawing.Size(1014, 789);
            this.Name = "Form1";
            this.Text = "Battle of Champions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.mainPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Label p1Name;
        private System.Windows.Forms.Label p1spclDesc;
        private System.Windows.Forms.Label p2spclDesc;
        private System.Windows.Forms.Label p2Name;
        private System.Windows.Forms.Timer p1spclTmr;
        private System.Windows.Forms.Timer p2spclTmr;
    }
}

