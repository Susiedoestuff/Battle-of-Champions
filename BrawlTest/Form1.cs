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
        Rectangle Cedric, platform;
        Graphics g; // declare the graphics object
        SolidBrush greenbrush = new SolidBrush(Color.Purple);
        int xv, yv, xa, ya;
        bool falling, jumping;
        //player stats
        int hp, atk, def, dex, spd;


        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, mainPanel, new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cedric = new Rectangle(400, 400, 50, 50);
            hp = 100; //how much damage they can take, ranges from 75 - 200
            atk = 20; //how much base damage they can deal, ranges from 10 - 25
            def = 4; //how much damage and knockback is negated, ranges from 2 - 10
            dex = 5; //skill and hit recovery time, lower the better, ranges from 20 - 5
            spd = 7; //base movement acceleration, ranges from 3 - 7
            platform = new Rectangle(1, 600, 1000, 50);
            mainPanel.Invalidate();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (xv < 10 && xv > -10)//velocity cap
            {
                if (e.KeyData == Keys.Right) { xa = spd; }
                if (e.KeyData == Keys.Left) { xa = -spd; }
            }
            if (jumping == false)
            {
                if (e.KeyData == Keys.Up && yv < 50 && yv > -50 && falling == false)//check is players on a platform and velocity cap
                {
                    ya = -10;
                    jumping = true;
                }
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

        private void veloTmr_Tick(object sender, EventArgs e)
        {
            mainPanel.Invalidate();
            VeloX.Text = ya.ToString();
            Cedric.Y += yv;
            Cedric.X += xv;
            
            if (Cedric.IntersectsWith(platform))
            {
                if (falling == true)
                {
                    int place = (int)Cedric.Y;
                    ya = 0;
                    Cedric.Y -= place - 551;
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
    }
}
