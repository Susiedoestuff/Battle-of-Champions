
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
            this.p2nameBox = new System.Windows.Forms.TextBox();
            this.p1nameBox = new System.Windows.Forms.TextBox();
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
            this.p1nameLabel = new System.Windows.Forms.Label();
            this.p2nameLabel = new System.Windows.Forms.Label();
            this.centLbl1 = new System.Windows.Forms.Label();
            this.centLbl2 = new System.Windows.Forms.Label();
            this.centLbl3 = new System.Windows.Forms.Label();
            this.centLbl4 = new System.Windows.Forms.Label();
            this.p1charLbl = new System.Windows.Forms.Label();
            this.p2charLbl = new System.Windows.Forms.Label();
            this.p1battleResult = new System.Windows.Forms.Label();
            this.p2battleResult = new System.Windows.Forms.Label();
            this.p1dmgLabel = new System.Windows.Forms.Label();
            this.p2dmgLabel = new System.Windows.Forms.Label();
            this.p1hpLabel = new System.Windows.Forms.Label();
            this.p2hpLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.Controls.Add(this.centLbl1);
            this.mainPanel.Controls.Add(this.centLbl2);
            this.mainPanel.Controls.Add(this.centLbl3);
            this.mainPanel.Controls.Add(this.centLbl4);
            this.mainPanel.Controls.Add(this.p2hpLabel);
            this.mainPanel.Controls.Add(this.p1hpLabel);
            this.mainPanel.Controls.Add(this.p2dmgLabel);
            this.mainPanel.Controls.Add(this.p1dmgLabel);
            this.mainPanel.Controls.Add(this.p2battleResult);
            this.mainPanel.Controls.Add(this.p1battleResult);
            this.mainPanel.Controls.Add(this.p2charLbl);
            this.mainPanel.Controls.Add(this.p1charLbl);
            this.mainPanel.Controls.Add(this.p2nameLabel);
            this.mainPanel.Controls.Add(this.p1nameLabel);
            this.mainPanel.Controls.Add(this.p2nameBox);
            this.mainPanel.Controls.Add(this.p1nameBox);
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
            // p2nameBox
            // 
            this.p2nameBox.BackColor = System.Drawing.Color.Black;
            this.p2nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2nameBox.Font = new System.Drawing.Font("Abel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2nameBox.ForeColor = System.Drawing.Color.White;
            this.p2nameBox.Location = new System.Drawing.Point(610, 706);
            this.p2nameBox.Name = "p2nameBox";
            this.p2nameBox.Size = new System.Drawing.Size(200, 32);
            this.p2nameBox.TabIndex = 5;
            this.p2nameBox.TabStop = false;
            this.p2nameBox.Text = "Enter name (letters only)";
            this.p2nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p2nameBox.Visible = false;
            this.p2nameBox.Click += new System.EventHandler(this.p2nameBox_Click);
            this.p2nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p2nameBox_KeyDown);
            // 
            // p1nameBox
            // 
            this.p1nameBox.BackColor = System.Drawing.Color.Black;
            this.p1nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1nameBox.Font = new System.Drawing.Font("Abel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1nameBox.ForeColor = System.Drawing.Color.White;
            this.p1nameBox.Location = new System.Drawing.Point(191, 706);
            this.p1nameBox.Name = "p1nameBox";
            this.p1nameBox.Size = new System.Drawing.Size(200, 32);
            this.p1nameBox.TabIndex = 4;
            this.p1nameBox.TabStop = false;
            this.p1nameBox.Text = "Enter name (letters only)";
            this.p1nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p1nameBox.Visible = false;
            this.p1nameBox.Click += new System.EventHandler(this.p1nameBox_Click);
            this.p1nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1nameBox_KeyDown);
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
            // p1nameLabel
            // 
            this.p1nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1nameLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1nameLabel.ForeColor = System.Drawing.Color.White;
            this.p1nameLabel.Location = new System.Drawing.Point(280, 160);
            this.p1nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1nameLabel.Name = "p1nameLabel";
            this.p1nameLabel.Size = new System.Drawing.Size(185, 25);
            this.p1nameLabel.TabIndex = 6;
            this.p1nameLabel.Text = "p1nameLabel";
            this.p1nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1nameLabel.Visible = false;
            // 
            // p2nameLabel
            // 
            this.p2nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2nameLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2nameLabel.ForeColor = System.Drawing.Color.White;
            this.p2nameLabel.Location = new System.Drawing.Point(535, 160);
            this.p2nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2nameLabel.Name = "p2nameLabel";
            this.p2nameLabel.Size = new System.Drawing.Size(185, 25);
            this.p2nameLabel.TabIndex = 7;
            this.p2nameLabel.Text = "p2nameLabel";
            this.p2nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2nameLabel.Visible = false;
            // 
            // centLbl1
            // 
            this.centLbl1.BackColor = System.Drawing.Color.Transparent;
            this.centLbl1.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centLbl1.ForeColor = System.Drawing.Color.White;
            this.centLbl1.Location = new System.Drawing.Point(455, 240);
            this.centLbl1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.centLbl1.Name = "centLbl1";
            this.centLbl1.Size = new System.Drawing.Size(90, 25);
            this.centLbl1.TabIndex = 9;
            this.centLbl1.Text = "Character";
            this.centLbl1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centLbl1.Visible = false;
            // 
            // centLbl2
            // 
            this.centLbl2.BackColor = System.Drawing.Color.Transparent;
            this.centLbl2.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centLbl2.ForeColor = System.Drawing.Color.White;
            this.centLbl2.Location = new System.Drawing.Point(455, 320);
            this.centLbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.centLbl2.Name = "centLbl2";
            this.centLbl2.Size = new System.Drawing.Size(90, 25);
            this.centLbl2.TabIndex = 10;
            this.centLbl2.Text = "Result";
            this.centLbl2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centLbl2.Visible = false;
            // 
            // centLbl3
            // 
            this.centLbl3.BackColor = System.Drawing.Color.Transparent;
            this.centLbl3.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centLbl3.ForeColor = System.Drawing.Color.White;
            this.centLbl3.Location = new System.Drawing.Point(435, 400);
            this.centLbl3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.centLbl3.Name = "centLbl3";
            this.centLbl3.Size = new System.Drawing.Size(130, 25);
            this.centLbl3.TabIndex = 11;
            this.centLbl3.Text = "Damage Dealt";
            this.centLbl3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centLbl3.Visible = false;
            // 
            // centLbl4
            // 
            this.centLbl4.BackColor = System.Drawing.Color.Transparent;
            this.centLbl4.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centLbl4.ForeColor = System.Drawing.Color.White;
            this.centLbl4.Location = new System.Drawing.Point(430, 480);
            this.centLbl4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.centLbl4.Name = "centLbl4";
            this.centLbl4.Size = new System.Drawing.Size(140, 25);
            this.centLbl4.TabIndex = 12;
            this.centLbl4.Text = "Hp Remaining";
            this.centLbl4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centLbl4.Visible = false;
            // 
            // p1charLbl
            // 
            this.p1charLbl.BackColor = System.Drawing.Color.Transparent;
            this.p1charLbl.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1charLbl.ForeColor = System.Drawing.Color.White;
            this.p1charLbl.Location = new System.Drawing.Point(320, 240);
            this.p1charLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1charLbl.Name = "p1charLbl";
            this.p1charLbl.Size = new System.Drawing.Size(100, 25);
            this.p1charLbl.TabIndex = 13;
            this.p1charLbl.Text = "p1charLbl";
            this.p1charLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1charLbl.Visible = false;
            // 
            // p2charLbl
            // 
            this.p2charLbl.BackColor = System.Drawing.Color.Transparent;
            this.p2charLbl.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2charLbl.ForeColor = System.Drawing.Color.White;
            this.p2charLbl.Location = new System.Drawing.Point(580, 240);
            this.p2charLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2charLbl.Name = "p2charLbl";
            this.p2charLbl.Size = new System.Drawing.Size(100, 25);
            this.p2charLbl.TabIndex = 14;
            this.p2charLbl.Text = "p2charLbl";
            this.p2charLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2charLbl.Visible = false;
            // 
            // p1battleResult
            // 
            this.p1battleResult.BackColor = System.Drawing.Color.Transparent;
            this.p1battleResult.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1battleResult.ForeColor = System.Drawing.Color.White;
            this.p1battleResult.Location = new System.Drawing.Point(300, 320);
            this.p1battleResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1battleResult.Name = "p1battleResult";
            this.p1battleResult.Size = new System.Drawing.Size(145, 25);
            this.p1battleResult.TabIndex = 15;
            this.p1battleResult.Text = "p1battleResult";
            this.p1battleResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1battleResult.Visible = false;
            // 
            // p2battleResult
            // 
            this.p2battleResult.BackColor = System.Drawing.Color.Transparent;
            this.p2battleResult.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2battleResult.ForeColor = System.Drawing.Color.White;
            this.p2battleResult.Location = new System.Drawing.Point(555, 320);
            this.p2battleResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2battleResult.Name = "p2battleResult";
            this.p2battleResult.Size = new System.Drawing.Size(145, 25);
            this.p2battleResult.TabIndex = 16;
            this.p2battleResult.Text = "p2battleResult";
            this.p2battleResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2battleResult.Visible = false;
            // 
            // p1dmgLabel
            // 
            this.p1dmgLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1dmgLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1dmgLabel.ForeColor = System.Drawing.Color.White;
            this.p1dmgLabel.Location = new System.Drawing.Point(310, 400);
            this.p1dmgLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1dmgLabel.Name = "p1dmgLabel";
            this.p1dmgLabel.Size = new System.Drawing.Size(125, 25);
            this.p1dmgLabel.TabIndex = 17;
            this.p1dmgLabel.Text = "p1dmgLabel";
            this.p1dmgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1dmgLabel.Visible = false;
            // 
            // p2dmgLabel
            // 
            this.p2dmgLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2dmgLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2dmgLabel.ForeColor = System.Drawing.Color.White;
            this.p2dmgLabel.Location = new System.Drawing.Point(565, 400);
            this.p2dmgLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2dmgLabel.Name = "p2dmgLabel";
            this.p2dmgLabel.Size = new System.Drawing.Size(125, 25);
            this.p2dmgLabel.TabIndex = 18;
            this.p2dmgLabel.Text = "p2dmgLabel";
            this.p2dmgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2dmgLabel.Visible = false;
            // 
            // p1hpLabel
            // 
            this.p1hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1hpLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1hpLabel.ForeColor = System.Drawing.Color.White;
            this.p1hpLabel.Location = new System.Drawing.Point(310, 480);
            this.p1hpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1hpLabel.Name = "p1hpLabel";
            this.p1hpLabel.Size = new System.Drawing.Size(125, 25);
            this.p1hpLabel.TabIndex = 19;
            this.p1hpLabel.Text = "p1hpLabel";
            this.p1hpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1hpLabel.Visible = false;
            // 
            // p2hpLabel
            // 
            this.p2hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2hpLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2hpLabel.ForeColor = System.Drawing.Color.White;
            this.p2hpLabel.Location = new System.Drawing.Point(565, 480);
            this.p2hpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2hpLabel.Name = "p2hpLabel";
            this.p2hpLabel.Size = new System.Drawing.Size(125, 25);
            this.p2hpLabel.TabIndex = 20;
            this.p2hpLabel.Text = "p2hpLabel";
            this.p2hpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2hpLabel.Visible = false;
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
            this.mainPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox p2nameBox;
        private System.Windows.Forms.TextBox p1nameBox;
        private System.Windows.Forms.Label p2nameLabel;
        private System.Windows.Forms.Label p1nameLabel;
        private System.Windows.Forms.Label centLbl4;
        private System.Windows.Forms.Label centLbl3;
        private System.Windows.Forms.Label centLbl2;
        private System.Windows.Forms.Label centLbl1;
        private System.Windows.Forms.Label p2charLbl;
        private System.Windows.Forms.Label p1charLbl;
        private System.Windows.Forms.Label p2battleResult;
        private System.Windows.Forms.Label p1battleResult;
        private System.Windows.Forms.Label p1dmgLabel;
        private System.Windows.Forms.Label p2dmgLabel;
        private System.Windows.Forms.Label p2hpLabel;
        private System.Windows.Forms.Label p1hpLabel;
    }
}

