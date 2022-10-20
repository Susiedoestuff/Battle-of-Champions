
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.LstBoxScore = new System.Windows.Forms.ListBox();
            this.LstBoxName = new System.Windows.Forms.ListBox();
            this.centLbl1 = new System.Windows.Forms.Label();
            this.centLbl2 = new System.Windows.Forms.Label();
            this.centLbl3 = new System.Windows.Forms.Label();
            this.centLbl4 = new System.Windows.Forms.Label();
            this.P2hpLabel = new System.Windows.Forms.Label();
            this.P1hpLabel = new System.Windows.Forms.Label();
            this.P2dmgLabel = new System.Windows.Forms.Label();
            this.P1dmgLabel = new System.Windows.Forms.Label();
            this.P2battleResult = new System.Windows.Forms.Label();
            this.P1battleResult = new System.Windows.Forms.Label();
            this.P2charLbl = new System.Windows.Forms.Label();
            this.P1charLbl = new System.Windows.Forms.Label();
            this.P2nameLabel = new System.Windows.Forms.Label();
            this.P1nameLabel = new System.Windows.Forms.Label();
            this.P2nameBox = new System.Windows.Forms.TextBox();
            this.P1nameBox = new System.Windows.Forms.TextBox();
            this.P2spclDesc = new System.Windows.Forms.Label();
            this.P2Name = new System.Windows.Forms.Label();
            this.P1spclDesc = new System.Windows.Forms.Label();
            this.P1Name = new System.Windows.Forms.Label();
            this.VeloTmr = new System.Windows.Forms.Timer(this.components);
            this.P1atkTime = new System.Windows.Forms.Timer(this.components);
            this.P2atkTime = new System.Windows.Forms.Timer(this.components);
            this.P1stunTmr = new System.Windows.Forms.Timer(this.components);
            this.P2stunTmr = new System.Windows.Forms.Timer(this.components);
            this.AniTmr = new System.Windows.Forms.Timer(this.components);
            this.P1spclTmr = new System.Windows.Forms.Timer(this.components);
            this.P2spclTmr = new System.Windows.Forms.Timer(this.components);
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.Controls.Add(this.LstBoxScore);
            this.MainPanel.Controls.Add(this.LstBoxName);
            this.MainPanel.Controls.Add(this.centLbl1);
            this.MainPanel.Controls.Add(this.centLbl2);
            this.MainPanel.Controls.Add(this.centLbl3);
            this.MainPanel.Controls.Add(this.centLbl4);
            this.MainPanel.Controls.Add(this.P2hpLabel);
            this.MainPanel.Controls.Add(this.P1hpLabel);
            this.MainPanel.Controls.Add(this.P2dmgLabel);
            this.MainPanel.Controls.Add(this.P1dmgLabel);
            this.MainPanel.Controls.Add(this.P2battleResult);
            this.MainPanel.Controls.Add(this.P1battleResult);
            this.MainPanel.Controls.Add(this.P2charLbl);
            this.MainPanel.Controls.Add(this.P1charLbl);
            this.MainPanel.Controls.Add(this.P2nameLabel);
            this.MainPanel.Controls.Add(this.P1nameLabel);
            this.MainPanel.Controls.Add(this.P2nameBox);
            this.MainPanel.Controls.Add(this.P1nameBox);
            this.MainPanel.Controls.Add(this.P2spclDesc);
            this.MainPanel.Controls.Add(this.P2Name);
            this.MainPanel.Controls.Add(this.P1spclDesc);
            this.MainPanel.Controls.Add(this.P1Name);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1000, 750);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // LstBoxScore
            // 
            this.LstBoxScore.BackColor = System.Drawing.Color.Black;
            this.LstBoxScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstBoxScore.Font = new System.Drawing.Font("Abel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBoxScore.ForeColor = System.Drawing.Color.White;
            this.LstBoxScore.FormattingEnabled = true;
            this.LstBoxScore.ItemHeight = 27;
            this.LstBoxScore.Location = new System.Drawing.Point(560, 240);
            this.LstBoxScore.Name = "LstBoxScore";
            this.LstBoxScore.Size = new System.Drawing.Size(160, 297);
            this.LstBoxScore.TabIndex = 22;
            this.LstBoxScore.TabStop = false;
            this.LstBoxScore.Visible = false;
            // 
            // LstBoxName
            // 
            this.LstBoxName.BackColor = System.Drawing.Color.Black;
            this.LstBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstBoxName.Font = new System.Drawing.Font("Abel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBoxName.ForeColor = System.Drawing.Color.White;
            this.LstBoxName.FormattingEnabled = true;
            this.LstBoxName.ItemHeight = 27;
            this.LstBoxName.Location = new System.Drawing.Point(285, 240);
            this.LstBoxName.Name = "LstBoxName";
            this.LstBoxName.Size = new System.Drawing.Size(160, 297);
            this.LstBoxName.TabIndex = 21;
            this.LstBoxName.TabStop = false;
            this.LstBoxName.Visible = false;
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
            // P2hpLabel
            // 
            this.P2hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2hpLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2hpLabel.ForeColor = System.Drawing.Color.White;
            this.P2hpLabel.Location = new System.Drawing.Point(565, 480);
            this.P2hpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2hpLabel.Name = "P2hpLabel";
            this.P2hpLabel.Size = new System.Drawing.Size(125, 25);
            this.P2hpLabel.TabIndex = 20;
            this.P2hpLabel.Text = "p2hpLabel";
            this.P2hpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P2hpLabel.Visible = false;
            // 
            // P1hpLabel
            // 
            this.P1hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1hpLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1hpLabel.ForeColor = System.Drawing.Color.White;
            this.P1hpLabel.Location = new System.Drawing.Point(310, 480);
            this.P1hpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1hpLabel.Name = "P1hpLabel";
            this.P1hpLabel.Size = new System.Drawing.Size(125, 25);
            this.P1hpLabel.TabIndex = 19;
            this.P1hpLabel.Text = "p1hpLabel";
            this.P1hpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P1hpLabel.Visible = false;
            // 
            // P2dmgLabel
            // 
            this.P2dmgLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2dmgLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2dmgLabel.ForeColor = System.Drawing.Color.White;
            this.P2dmgLabel.Location = new System.Drawing.Point(565, 400);
            this.P2dmgLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2dmgLabel.Name = "P2dmgLabel";
            this.P2dmgLabel.Size = new System.Drawing.Size(125, 25);
            this.P2dmgLabel.TabIndex = 18;
            this.P2dmgLabel.Text = "p2dmgLabel";
            this.P2dmgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P2dmgLabel.Visible = false;
            // 
            // P1dmgLabel
            // 
            this.P1dmgLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1dmgLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1dmgLabel.ForeColor = System.Drawing.Color.White;
            this.P1dmgLabel.Location = new System.Drawing.Point(310, 400);
            this.P1dmgLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1dmgLabel.Name = "P1dmgLabel";
            this.P1dmgLabel.Size = new System.Drawing.Size(125, 25);
            this.P1dmgLabel.TabIndex = 17;
            this.P1dmgLabel.Text = "p1dmgLabel";
            this.P1dmgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P1dmgLabel.Visible = false;
            // 
            // P2battleResult
            // 
            this.P2battleResult.BackColor = System.Drawing.Color.Transparent;
            this.P2battleResult.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2battleResult.ForeColor = System.Drawing.Color.White;
            this.P2battleResult.Location = new System.Drawing.Point(555, 320);
            this.P2battleResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2battleResult.Name = "P2battleResult";
            this.P2battleResult.Size = new System.Drawing.Size(145, 25);
            this.P2battleResult.TabIndex = 16;
            this.P2battleResult.Text = "p2battleResult";
            this.P2battleResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P2battleResult.Visible = false;
            // 
            // P1battleResult
            // 
            this.P1battleResult.BackColor = System.Drawing.Color.Transparent;
            this.P1battleResult.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1battleResult.ForeColor = System.Drawing.Color.White;
            this.P1battleResult.Location = new System.Drawing.Point(300, 320);
            this.P1battleResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1battleResult.Name = "P1battleResult";
            this.P1battleResult.Size = new System.Drawing.Size(145, 25);
            this.P1battleResult.TabIndex = 15;
            this.P1battleResult.Text = "p1battleResult";
            this.P1battleResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P1battleResult.Visible = false;
            // 
            // P2charLbl
            // 
            this.P2charLbl.BackColor = System.Drawing.Color.Transparent;
            this.P2charLbl.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2charLbl.ForeColor = System.Drawing.Color.White;
            this.P2charLbl.Location = new System.Drawing.Point(580, 240);
            this.P2charLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2charLbl.Name = "P2charLbl";
            this.P2charLbl.Size = new System.Drawing.Size(100, 25);
            this.P2charLbl.TabIndex = 14;
            this.P2charLbl.Text = "p2charLbl";
            this.P2charLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P2charLbl.Visible = false;
            // 
            // P1charLbl
            // 
            this.P1charLbl.BackColor = System.Drawing.Color.Transparent;
            this.P1charLbl.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1charLbl.ForeColor = System.Drawing.Color.White;
            this.P1charLbl.Location = new System.Drawing.Point(320, 240);
            this.P1charLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1charLbl.Name = "P1charLbl";
            this.P1charLbl.Size = new System.Drawing.Size(100, 25);
            this.P1charLbl.TabIndex = 13;
            this.P1charLbl.Text = "p1charLbl";
            this.P1charLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P1charLbl.Visible = false;
            // 
            // P2nameLabel
            // 
            this.P2nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2nameLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2nameLabel.ForeColor = System.Drawing.Color.White;
            this.P2nameLabel.Location = new System.Drawing.Point(535, 160);
            this.P2nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2nameLabel.Name = "P2nameLabel";
            this.P2nameLabel.Size = new System.Drawing.Size(185, 25);
            this.P2nameLabel.TabIndex = 7;
            this.P2nameLabel.Text = "p2nameLabel";
            this.P2nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P2nameLabel.Visible = false;
            // 
            // P1nameLabel
            // 
            this.P1nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1nameLabel.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1nameLabel.ForeColor = System.Drawing.Color.White;
            this.P1nameLabel.Location = new System.Drawing.Point(280, 160);
            this.P1nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1nameLabel.Name = "P1nameLabel";
            this.P1nameLabel.Size = new System.Drawing.Size(185, 25);
            this.P1nameLabel.TabIndex = 6;
            this.P1nameLabel.Text = "p1nameLabel";
            this.P1nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.P1nameLabel.Visible = false;
            // 
            // P2nameBox
            // 
            this.P2nameBox.BackColor = System.Drawing.Color.Black;
            this.P2nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P2nameBox.Font = new System.Drawing.Font("Abel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2nameBox.ForeColor = System.Drawing.Color.White;
            this.P2nameBox.Location = new System.Drawing.Point(590, 706);
            this.P2nameBox.Name = "P2nameBox";
            this.P2nameBox.Size = new System.Drawing.Size(250, 28);
            this.P2nameBox.TabIndex = 5;
            this.P2nameBox.TabStop = false;
            this.P2nameBox.Text = "Enter name (press enter to confirm)";
            this.P2nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P2nameBox.Visible = false;
            this.P2nameBox.Click += new System.EventHandler(this.P2nameBox_Click);
            this.P2nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.P2nameBox_KeyDown);
            // 
            // P1nameBox
            // 
            this.P1nameBox.BackColor = System.Drawing.Color.Black;
            this.P1nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P1nameBox.Font = new System.Drawing.Font("Abel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1nameBox.ForeColor = System.Drawing.Color.White;
            this.P1nameBox.Location = new System.Drawing.Point(160, 706);
            this.P1nameBox.Name = "P1nameBox";
            this.P1nameBox.Size = new System.Drawing.Size(250, 28);
            this.P1nameBox.TabIndex = 4;
            this.P1nameBox.TabStop = false;
            this.P1nameBox.Text = "Enter name (press enter to confirm)";
            this.P1nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P1nameBox.Visible = false;
            this.P1nameBox.Click += new System.EventHandler(this.P1nameBox_Click);
            this.P1nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.P1nameBox_KeyDown);
            // 
            // P2spclDesc
            // 
            this.P2spclDesc.BackColor = System.Drawing.Color.Transparent;
            this.P2spclDesc.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2spclDesc.ForeColor = System.Drawing.Color.White;
            this.P2spclDesc.Location = new System.Drawing.Point(530, 306);
            this.P2spclDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2spclDesc.Name = "P2spclDesc";
            this.P2spclDesc.Size = new System.Drawing.Size(130, 76);
            this.P2spclDesc.TabIndex = 3;
            this.P2spclDesc.Text = "p2spclDesc";
            this.P2spclDesc.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.P2spclDesc.Visible = false;
            // 
            // P2Name
            // 
            this.P2Name.BackColor = System.Drawing.Color.Transparent;
            this.P2Name.Font = new System.Drawing.Font("Abel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2Name.ForeColor = System.Drawing.Color.White;
            this.P2Name.Location = new System.Drawing.Point(500, 382);
            this.P2Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2Name.Name = "P2Name";
            this.P2Name.Size = new System.Drawing.Size(160, 38);
            this.P2Name.TabIndex = 2;
            this.P2Name.Text = "p2Name";
            this.P2Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.P2Name.Visible = false;
            // 
            // P1spclDesc
            // 
            this.P1spclDesc.BackColor = System.Drawing.Color.Transparent;
            this.P1spclDesc.Font = new System.Drawing.Font("Abel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1spclDesc.ForeColor = System.Drawing.Color.White;
            this.P1spclDesc.Location = new System.Drawing.Point(340, 330);
            this.P1spclDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1spclDesc.Name = "P1spclDesc";
            this.P1spclDesc.Size = new System.Drawing.Size(140, 90);
            this.P1spclDesc.TabIndex = 1;
            this.P1spclDesc.Text = "p1spclDesc";
            this.P1spclDesc.Visible = false;
            // 
            // P1Name
            // 
            this.P1Name.BackColor = System.Drawing.Color.Transparent;
            this.P1Name.Font = new System.Drawing.Font("Abel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Name.ForeColor = System.Drawing.Color.White;
            this.P1Name.Location = new System.Drawing.Point(340, 300);
            this.P1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1Name.Name = "P1Name";
            this.P1Name.Size = new System.Drawing.Size(160, 38);
            this.P1Name.TabIndex = 0;
            this.P1Name.Text = "p1Name";
            this.P1Name.Visible = false;
            // 
            // VeloTmr
            // 
            this.VeloTmr.Interval = 15;
            this.VeloTmr.Tick += new System.EventHandler(this.VeloTmr_Tick);
            // 
            // P1atkTime
            // 
            this.P1atkTime.Interval = 125;
            this.P1atkTime.Tick += new System.EventHandler(this.P1atkTime_Tick);
            // 
            // P2atkTime
            // 
            this.P2atkTime.Interval = 125;
            this.P2atkTime.Tick += new System.EventHandler(this.P2atkTime_Tick);
            // 
            // P1stunTmr
            // 
            this.P1stunTmr.Tick += new System.EventHandler(this.P1stunTmr_Tick);
            // 
            // P2stunTmr
            // 
            this.P2stunTmr.Tick += new System.EventHandler(this.P2stunTmr_Tick);
            // 
            // AniTmr
            // 
            this.AniTmr.Enabled = true;
            this.AniTmr.Interval = 125;
            this.AniTmr.Tick += new System.EventHandler(this.AniTmr_Tick);
            // 
            // P1spclTmr
            // 
            this.P1spclTmr.Interval = 125;
            this.P1spclTmr.Tick += new System.EventHandler(this.P1spclTmr_Tick);
            // 
            // P2spclTmr
            // 
            this.P2spclTmr.Interval = 125;
            this.P2spclTmr.Tick += new System.EventHandler(this.P2spclTmr_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(998, 746);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1014, 785);
            this.MinimumSize = new System.Drawing.Size(1014, 673);
            this.Name = "Form1";
            this.Text = "Battle of Champions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Timer VeloTmr;
        private System.Windows.Forms.Timer P1atkTime;
        private System.Windows.Forms.Timer P2atkTime;
        private System.Windows.Forms.Timer P1stunTmr;
        private System.Windows.Forms.Timer P2stunTmr;
        private System.Windows.Forms.Timer AniTmr;
        private System.Windows.Forms.Label P1Name;
        private System.Windows.Forms.Label P1spclDesc;
        private System.Windows.Forms.Label P2spclDesc;
        private System.Windows.Forms.Label P2Name;
        private System.Windows.Forms.Timer P1spclTmr;
        private System.Windows.Forms.Timer P2spclTmr;
        private System.Windows.Forms.TextBox P2nameBox;
        private System.Windows.Forms.TextBox P1nameBox;
        private System.Windows.Forms.Label P2nameLabel;
        private System.Windows.Forms.Label P1nameLabel;
        private System.Windows.Forms.Label centLbl4;
        private System.Windows.Forms.Label centLbl3;
        private System.Windows.Forms.Label centLbl2;
        private System.Windows.Forms.Label centLbl1;
        private System.Windows.Forms.Label P2charLbl;
        private System.Windows.Forms.Label P1charLbl;
        private System.Windows.Forms.Label P2battleResult;
        private System.Windows.Forms.Label P1battleResult;
        private System.Windows.Forms.Label P1dmgLabel;
        private System.Windows.Forms.Label P2dmgLabel;
        private System.Windows.Forms.Label P2hpLabel;
        private System.Windows.Forms.Label P1hpLabel;
        private System.Windows.Forms.ListBox LstBoxScore;
        private System.Windows.Forms.ListBox LstBoxName;
    }
}

