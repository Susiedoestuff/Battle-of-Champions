﻿using System;
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

        //----------------------------------\\
        //            Variables             \\
        //----------------------------------\\

        Rectangle p1Sprite, p2Sprite, platform;
        Rectangle p1hb, p1atkhb, p1spclhb; //hitboxes
        Rectangle p2hb, p2atkhb, p2spclhb; //hitboxes

        Graphics g; // declare the graphics object
        SolidBrush greenbrush = new SolidBrush(Color.Purple);
        SolidBrush purplebrush = new SolidBrush(Color.Green);
        SolidBrush blackbrush = new SolidBrush(Color.Gray);

        //p1
        int p1xv, p1yv, p1xa, p1ya;
        int p1atkCooltime, p1spclCooltime, p1stunTime; //cooldown timers
        bool p1falling, p1jumping, p1atkActive, p1spclActive, p1invince, p1stunned; //indicators if these things are active
        bool p1atkCool, p1sklCool; //skill cooldowns
        bool p1facingRight; //which side is the player facing
        string p1Character;
        //p1 imported integers
        int p1hp, p1atk, p1def, p1dex, p1spd; //stats
        int p1atkLength; //attack specifications 
        int p1atkhbX, p1atkhbY, p1atkhbOffset; //attack hitbox sizes
        bool p1spclDoesHeal, p1spclDoesDmg, p1spclDoesDrop, p1spclDoesSpecial; //Special skill conditions
        int p1spclLength, p1spcllength, p1spclCool, p1spclhbX, p1spclhbY; //Special skill specifications
        int p1spclDmg, p1spclStun;
        bool p1dealKockback = false;

        //p2
        int p2xv, p2yv, p2xa, p2ya;
        int p2atkCooltime, p2spclCooltime, p2stunTime; //cooldown timers
        int p2hp, p2atk, p2def, p2dex, p2spd;
        bool p2falling, p2jumping, p2atkActive, p2spclActive, p2invince, p2stunned; //indicators if these things are active
        bool p2atkCool, p2sklCool; //skill cooldowns
        bool p2facingRight; //which side is the player facing
        string p2Character;
        bool p2dealKockback = false;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, mainPanel, new object[] { true });
        }




        //----------------------------------\\
        //             Loading              \\
        //----------------------------------\\
        private void Form1_Load(object sender, EventArgs e)
        {
            p1Sprite = new Rectangle(400, 400, 200, 150);
            p1hb = new Rectangle(400, 400, 60, 100);
            p1hp = 100; //how much damage they can take, ranges from 75 - 200
            p1atk = 18; //how much base damage they can deal, ranges from 5 - 20
            p1def = 4; //how much damage and knockback is negated, ranges from 2 - 10
            p1dex = 5; //skill and hit recovery time, lower the better, ranges from 20 - 5
            p1spd = 3; //base movement acceleration
            p1Character = "Cedric";


            //the same stuff for player 2
            p2Sprite = new Rectangle(400, 400, 200, 150);
            p2hb = new Rectangle(400, 400, 60, 100);
            p2hp = 100;
            p2atk = 18;
            p2def = 4;
            p2dex = 5;
            p2spd = 3;
            p2Character = "Cedric";

            platform = new Rectangle(1, 600, 1000, 50);
            mainPanel.Invalidate();

            //temp stats
            p1atkLength = 3;
            p1atkhbX = 70;
            p1atkhbY = 40;
            p1atkhbOffset = 70;

            //bools defaults
            p1invince = false;
            p1stunned = false;
            p2invince = false;
            p2stunned = false;
        }




        //----------------------------------\\
        //             Controls              \\
        //----------------------------------\\
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //p1
            if (p1atkActive == false && p1stunned == false)
            {
                if (p1xv < 10 && p1xv > -10)//velocity cap
                {
                    if (e.KeyData == Keys.Right) { p1xa = p1spd; p1facingRight = true; }
                    if (e.KeyData == Keys.Left) { p1xa = -p1spd; p1facingRight = false; }
                }
                if (p1jumping == false)
                {
                    if (e.KeyData == Keys.Up && p1yv < 50 && p1yv > -50 && p1falling == false)//check is players on a platform and velocity cap
                    {
                        p1ya = -10;
                        p1jumping = true;
                    }
                }
                if (p1atkCool == false && p1spclActive == false) //if no skill is currently active
                {
                    if (e.KeyData == Keys.Enter) { p1Atk(); } //actives attack skill
                }
            }

            //p2
            if (p2atkActive == false && p2stunned == false)
            {
                if (p2xv < 10 && p2xv > -10)//velocity cap
                {
                    if (e.KeyData == Keys.D) { p2xa = p2spd; p2facingRight = true; }
                    if (e.KeyData == Keys.A) { p2xa = -p2spd; p2facingRight = false; }
                }
                if (p2jumping == false)
                {
                    if (e.KeyData == Keys.W && p2yv < 50 && p2yv > -50 && p2falling == false)//check is players on a platform and velocity cap
                    {
                        p2ya = -10;
                        p2jumping = true;
                    }
                }
                if (p2atkCool == false && p2spclActive == false && p2atkActive == false) //if no skill is currently active
                {
                    if (e.KeyData == Keys.G) { p2Atk(); } //actives attack skill
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //p1
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Left)
            { p1xa = 0; }
            if (e.KeyData == Keys.Up)
            { p1ya = 0; p1jumping = false; }

            //p2
            if (e.KeyData == Keys.D || e.KeyData == Keys.A)
            { p2xa = 0; }
            if (e.KeyData == Keys.W)
            { p2ya = 0; p2jumping = false; }
        }




        //----------------------------------\\
        //             Movement             \\
        //----------------------------------\\
        private void veloTmr_Tick(object sender, EventArgs e) //universal timer
        {
            mainPanel.Invalidate();


            //----------------------------------\\
            //               P1                 \\
            //----------------------------------\\
            p1hb.Y += p1yv;
            p1hb.X += p1xv;
            p1Sprite.Y = p1hb.Y - 50;
            p1Sprite.X = p1hb.X - 70;

            p1hpdisplay.Text = p1hp.ToString();

            if (p1hb.IntersectsWith(platform))
            {
                if (p1falling == true)
                {
                    int place = (int)p1hb.Y;
                    p1ya = 0;
                    p1hb.Y -= place - 501;
                    p1yv = 0;
                    p1falling = false;
                }
            }
            else 
            {
                p1ya += 1;
                p1falling = true;
            }
            if (p1yv > 0)//y-velocity decay
            {
                p1yv -= 1;
            }
            if (p1yv < 0)
            {
                p1yv += 1;
            }
            if (p1yv < 20 && p1yv > -20)//velocity cap
            {
                p1yv += p1ya; //acceleration
            }

            if (p1xv < 10 && p1xv > -10)//velocity cap
            { 
                p1xv += p1xa; //acceleration
            }
            if (p1xv > 0)//coding for air resistance 
            { 
                p1xv -= 1;
            }
            if (p1xv < 0)
            {
                p1xv += 1;
            }

            p1atkhb.Y = p1Sprite.Y + p1atkhbOffset;//attack hitbox



            //----------------------------------\\
            //               P2                 \\
            //----------------------------------\\
            p2hb.Y += p2yv;
            p2hb.X += p2xv;
            p2Sprite.Y = p2hb.Y - 50;
            p2Sprite.X = p2hb.X - 70;

            p2hpdisplay.Text = p2hp.ToString();

            if (p2hb.IntersectsWith(platform))
            {
                if (p2falling == true)
                {
                    int place = (int)p2hb.Y;
                    p2ya = 0;
                    p2hb.Y -= place - 501;
                    p2yv = 0;
                    p2falling = false;
                }
            }
            else
            {
                p2ya += 1;
                p2falling = true;
            }
            if (p2yv > 0)//y-velocity decay
            {
                p2yv -= 1;
            }
            if (p2yv < 0)
            {
                p2yv += 1;
            }
            if (p2yv < 20 && p2yv > -20)//velocity cap
            {
                p2yv += p2ya; //acceleration
            }

            if (p2xv < 10 && p2xv > -10)//velocity cap
            {
                p2xv += p2xa; //acceleration
            }
            if (p2xv > 0)//coding for air resistance 
            {
                p2xv -= 1;
            }
            if (p2xv < 0)
            {
                p2xv += 1;
            }
        }
        private void p2stunTmr_Tick(object sender, EventArgs e)
        {
            p2stunned = true;
            p2stunTime -= 1;
            if (p2stunTime < p2dex - 2)
            {
                if (p2dealKockback == false)//dealing knockback
                {
                    if (p1facingRight == true)
                    {
                        p2xv = 30 - p2def - p2hp/5; //knockback based on defence and current hp
                        p2yv = -5;
                    }
                    else
                    {
                        p2xv = -30 + p2def + p2hp/5;
                        p2yv = -5;
                    }
                    p2invince = false;
                    p2dealKockback = true;
                }
            }
            if(p2stunTime == 0)
            {
                p2dealKockback = false;
                p2stunned = false;
                p2stunTmr.Enabled = false;
            }
        }



        //----------------------------------\\
        //            Aesthetics            \\
        //----------------------------------\\
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.FillRectangle(purplebrush, p1hb);
            g.FillRectangle(purplebrush, p1atkhb);

            g.FillRectangle(greenbrush, p2hb);
            g.FillRectangle(greenbrush, p2atkhb);


            g.FillRectangle(blackbrush, platform);

        }






        //----------------------------------\\
        //       Player Base attack         \\
        //----------------------------------\\

        private void p1Atk()
        {
            p1atkCool = true;
            p1atkActive = true;
            p1atkTime.Enabled = true;
            p1atkCooltime = 0;
            p1xv = 0;
            p1yv = 0;
            p1xa = 0;
            p1ya = 0;
            if (p1atkActive == true)
            {
                int playerposX, playerposY;
                if (p1facingRight == true)
                {

                    playerposX = p1Sprite.X + 130;
                    playerposY = p1Sprite.Y + p1atkhbOffset;
                }
                else
                {
                    playerposX = p1Sprite.X;
                    playerposY = p1Sprite.Y + p1atkhbOffset;
                }

                p1atkhb = new Rectangle(playerposX, playerposY, p1atkhbX, p1atkhbY);
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
            if (p1atkCooltime > p1atkLength)
            {
                p1atkhb = Rectangle.Empty;
                p1atkActive = false;
            }
            if (p2hb.IntersectsWith(p1atkhb))
            {
                p2xv = 0;
                p2xa = 0;
                p2yv = 0;
                p2ya = 0;
                if (p1atk - p2def > 0 && p2invince == false)
                {
                    p2hp -= (p1atk - p2def);
                }
                p2invince = true;
                p2stunned = true;
                p2stunTime = p2dex;
                p2stunTmr.Enabled = true;
            }
        }

        private void p2Atk()
        {
        }
        private void p2atkTime_Tick(object sender, EventArgs e) //tracks cooldown time
        {
            if (p1hb.IntersectsWith(p2atkhb))
            {
                if (p2atk - p1def > 0)
                {
                    p1hp -= (p2atk - p1def);
                }
            }
        }


        //----------------------------------\\
        //          Player Specials         \\
        //----------------------------------\\


    }
}
