using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlTest
{
    public partial class Form1 : Form
    {
        Rectangle p1Sprite, p2Sprite, platform;
        Rectangle p1hb, p1atkhb, p1spclhb; //hitboxes

        Graphics g; // declare the graphics object
        SolidBrush greenbrush = new SolidBrush(Color.Purple);
        SolidBrush purplebrush = new SolidBrush(Color.Green);

        int p1xv, p1yv, p1xa, p1ya;
        int p1atkCooltime, p1spclCooltime; //cooldown timers
        int p1hp, p1atk, p1def, p1dex, p1spd;
        bool falling, jumping;
        bool p1falling, p1jumping, p1atkActive, p1spclActive, p1invisFrame; //indicators if these things are active
        bool p1atkCool, p1sklCool; //skill cooldowns
        bool p1facingRight; //which side is the player facing


        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, mainPanel, new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p1Sprite = new Rectangle(400, 400, 50, 50);
            p1hp = 100; //how much damage they can take, ranges from 75 - 200
            p1atk = 25; //how much base damage they can deal, ranges from 10 - 25
            p1def = 4; //how much damage and knockback is negated, ranges from 2 - 10
            p1dex = 5; //skill and hit recovery time, lower the better, ranges from 20 - 5
            p1spd = 3; //base movement acceleration

            //the same stuff for player 2
            p2Sprite = new Rectangle(400, 400, 50, 50);
            p2hp = 100;
            p2atk = 25;
            p2def = 4;
            p2dex = 5;
            p2spd = 3;

            platform = new Rectangle(1, 600, 1000, 50);
            mainPanel.Invalidate();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //p1 movements
            if (p1xv < 10 && p1xv > -10)//velocity cap
            {
                if (e.KeyData == Keys.Right) { p1xa = p1spd; p1facingRight = true; }
                if (e.KeyData == Keys.Left) { p1xa = -p1spd; p1facingRight = false; }
            }
            if (jumping == false)
            {
                if (e.KeyData == Keys.Up && yv < 50 && yv > -50 && falling == false)//check is players on a platform and velocity cap
                {
                    ya = -10;
                    jumping = true;
                }
            }
            if (p1atkCool == false && p1spclActive == false && p1atkActive == false) //if no skill is currently active
            {
                if (e.KeyData == Keys.Enter) { p1Atk(); } //actives attack skill
            }




        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Left)
            { xa = 0; }
            if (e.KeyData == Keys.Up)
            { ya = 0; jumping = false; }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.FillRectangle(greenbrush, Cedric);
            g.FillRectangle(greenbrush, platform);

        }


        //----------------------------------\\
        //             Movement             \\
        //----------------------------------\\
        private void veloTmr_Tick(object sender, EventArgs e)
        {
            mainPanel.Invalidate();
            VeloX.Text = ya.ToString();
            p1hb.Y += yv;
            p1hb.X += xv;
            
            if (p1hb.IntersectsWith(platform))
            {
                if (falling == true)
                {
                    int place = (int)p1hb.Y;
                    ya = 0;
                    p1hb.Y -= place - 551;
                    yv = 0;
                    falling = false;
                }
            }
            else 
            {
                ya += 1;
                falling = true;
            }
            if (yv > 0)//y-velocity decay
            {
                yv -= 1;
            }
            if (yv < 0)
            {
                yv += 1;
            }
            if (yv < 20 && yv > -20)//velocity cap
            {
                yv += ya; //acceleration
            }


            if (xv < 10 && xv > -10)//velocity cap
            { 
                xv += xa; //acceleration
            }
            if (xv > 0)//coding for air resistance 
            { 
                xv -= 1;
            }
            if (xv < 0)
            {
                xv += 1;
            }
        }









        //----------------------------------\\
        //          Player Skills           \\
        //----------------------------------\\


        private void p1Atk()
        {
            p1atkCool = true;
            p1atkActive = true;
            p1atkTime.Enabled = true;
            p1atkCooltime = 0;
            switch (p1Character)
            {
                case "Cedric":
                    CedricAtk();
                    break;
                case "Riol":
                    RiolAtk();
                    break;
            }
        }
        private void p1atkTime_Tick(object sender, EventArgs e) //tracks cooldown time
        {
            if (p1atkCooltime > p1dex)
            {
                p1atkTime.Enabled = false;
                p1atkCool = false;
            }
            else
            {
                p1atkCooltime += 1;
            }
        }



        //----------------------------------\\
        //       Player Skills List         \\
        //----------------------------------\\

        //cool person :)
        private void CedricAtk()
        {
            int playerposX, playerposY;
            if (p1facingRight == true)
            {

                playerposX = p1Sprite.X + 130;
                playerposY = p1Sprite.Y + 70;
            }
            else
            {
                playerposX = p1Sprite.X;
                playerposY = p1Sprite.Y + 70;
            }

            p1atkhb = new Rectangle(playerposX, playerposY, 70, 40);
        }

        private void RiolAtk()
        {
        }

        }
}
