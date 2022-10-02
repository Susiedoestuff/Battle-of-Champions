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

        Rectangle platform;
        Rectangle p1Sprite, p1hb, p1atkhb, p1spclhb; //hitboxes
        Rectangle p2Sprite, p2hb, p2atkhb, p2spclhb; //hitboxes

        Graphics g; // declare the graphics object
        SolidBrush greenbrush = new SolidBrush(Color.Purple);
        SolidBrush purplebrush = new SolidBrush(Color.Green);
        SolidBrush blackbrush = new SolidBrush(Color.Gray);

        bool gameStarted, titleCleared, charSelected;
        string gameStatus;




        //p1
        int p1xv, p1yv, p1xa, p1ya;
        int p1atkCooltime, p1spclCooltime, p1stunTime; //cooldown timers
        bool p1falling, p1jumping, p1atkActive, p1spclActive, p1invince, p1stunned; //indicators if these things are active
        bool p1atkCool, p1sklCool; //skill cooldowns
        bool p1facingRight; //which side is the player facing
        string p1Character;
        int p1currentHp, p1lives;
        //p1 imported integers
        int p1hp, p1atk, p1def, p1dex, p1spd; //stats
        int p1atkLength; //attack specifications 
        int p1atkhbX, p1atkhbY, p1atkhbOffset; //attack hitbox sizes
        bool p1spclDoesHeal, p1spclDoesDmg, p1spclDoesDrop, p1spclDoesSpecial; //Special skill conditions
        int p1spclLength, p1spclCool, p1spclhbX, p1spclhbY, p1spclhbOffset; //Special skill specifications
        int p1spclDmg, p1spclStun;
        string p1desc;
        bool p1dealKnockback = false;
        //p1 sprite works
        string p1spriteStatus;
        int p1frame;
        Image[] p1Idle = new Image[9];


        //p2
        int p2xv, p2yv, p2xa, p2ya;
        int p2atkCooltime, p2spclCooltime, p2stunTime; //cooldown timers
        bool p2falling, p2jumping, p2atkActive, p2spclActive, p2invince, p2stunned; //indicators if these things are active
        bool p2atkCool, p2sklCool; //skill cooldowns
        bool p2facingRight; //which side is the player facing
        string p2Character;
        int p2currentHp, p2lives;
        //p2 imported integers
        int p2hp, p2atk, p2def, p2dex, p2spd; //stats
        int p2atkLength; //attack specifications 
        int p2atkhbX, p2atkhbY, p2atkhbOffset; //attack hitbox sizes
        bool p2spclDoesHeal, p2spclDoesDmg, p2spclDoesDrop, p2spclDoesSpecial; //Special skill conditions
        int p2spclLength, p2spclCool, p2spclhbX, p2spclhbY, p2spclhbOffset; //Special skill specifications
        int p2spclDmg, p2spclStun;
        string p2desc;
        bool p2dealKnockback = false;
        //p2 sprite works
        string p2spriteStatus;
        int p2frame;
        Image[] p2Idle = new Image[9];





        Title title = new Title();
        CharSel charsel = new CharSel();
        Rules rules = new Rules();

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
            gameStarted = false;
            charSelected = false;
            gameStatus = "title";
        }

        //----------------------------------\\
        //           Game Startup           \\
        //----------------------------------\\
        private void gameStart()
        {
            p1Sprite = new Rectangle(400, 400, 200, 150);
            p1hb = new Rectangle(400, 400, 60, 100);
            p1loadChar();
            p1lives = 3;

            //the same stuff for player 2
            p2Sprite = new Rectangle(400, 400, 200, 150);
            p2hb = new Rectangle(400, 400, 60, 100);
            p2loadChar();
            p2lives = 3;

            platform = new Rectangle(1, 600, 600, 50);
            mainPanel.Invalidate();

            //bools defaults
            p1invince = false;
            p1stunned = false;
            p2invince = false;
            p2stunned = false;
            veloTmr.Enabled = true;
        }

        //----------------------------------\\
        //       Selecting Character        \\
        //----------------------------------\\





        //----------------------------------\\
        //        Loading Character         \\
        //----------------------------------\\

        private void p1prepareSprite()
        {
            if (p1Character != "nocharacter")
            {
                for (int i = 1; i <= 8; i++)//creates the image files for animations
                {
                    p1Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_" + p1spriteStatus + "_(" + i.ToString() + ").png");
                }
            }
        }
        private void p2prepareSprite()
        {
            if (p2Character != "nocharacter")
            {
                for (int i = 1; i <= 8; i++)//creates the image files for animations
                {
                    p2Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_" + p2spriteStatus + "_(" + i.ToString() + ").png");
                }
            }
        }
        private void p1loadChar()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\characters\" + p1Character.ToString() + ".txt");
            int linenumber = 1;
            for (int i = 1; i <= 21; i++)
            {
                try
                {
                    string line = File.ReadLines(Application.StartupPath + @"\characters\" + p1Character.ToString() + ".txt").ElementAt(linenumber);
                    switch (linenumber)
                    {
                        case 1://character description
                            p1desc = line;
                            break;
                        case 2://stats
                            p1hp = int.Parse(line);
                            break;
                        case 3:
                            p1atk = int.Parse(line);
                            break;
                        case 4:
                            p1def = int.Parse(line);
                            break;
                        case 5:
                            p1dex = int.Parse(line);
                            break;
                        case 6:
                            p1spd = int.Parse(line);
                            break;
                        case 7://attack specifications
                            p1atkLength = int.Parse(line);
                            break;
                        case 8:
                            p1atkhbX = int.Parse(line);
                            break;
                        case 9:
                            p1atkhbY = int.Parse(line);
                            break;
                        case 10:
                            p1atkhbOffset = int.Parse(line);
                            break;
                        case 11://special spefications
                            if (line.Contains("y")) { p1spclDoesHeal = true; }
                            else { p1spclDoesHeal = false; }
                            break;
                        case 12:
                            if (line.Contains("y")) { p1spclDoesDmg = true; }
                            else { p1spclDoesDmg = false; }
                            break;
                        case 13:
                            if (line.Contains("y")) { p1spclDoesDrop = true; }
                            else { p1spclDoesDrop = false; }
                            break;
                        case 14:
                            if (line.Contains("y")) { p1spclDoesSpecial = true; }
                            else { p1spclDoesSpecial = false; }
                            break;
                        case 15:
                            p1spclLength = int.Parse(line);
                            break;
                        case 16:
                            p1spclCool = int.Parse(line);
                            break;
                        case 17:
                            p1spclhbX = int.Parse(line);
                            break;
                        case 18:
                            p1spclhbY = int.Parse(line);
                            break;
                        case 19:
                            p1spclhbOffset = int.Parse(line);
                            break;
                        case 20:
                            p1spclDmg = int.Parse(line);
                            break;
                        case 21:
                            p1spclStun = int.Parse(line);
                            break;
                    }
                    linenumber += 1;
                }
                catch (Exception)
                {
                    file.Close();
                }
            }
        }
        private void p2loadChar()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\characters\" + p2Character.ToString() + ".txt");
            int linenumber = 1;
            for (int i = 1; i <= 21; i++)
            {
                try
                {
                    string line = File.ReadLines(Application.StartupPath + @"\characters\" + p2Character.ToString() + ".txt").ElementAt(linenumber);
                    switch (linenumber)
                    {
                        case 1://character description
                            p2desc = line;
                            break;
                        case 2://stats
                            p2hp = int.Parse(line);
                            break;
                        case 3:
                            p2atk = int.Parse(line);
                            break;
                        case 4:
                            p2def = int.Parse(line);
                            break;
                        case 5:
                            p2dex = int.Parse(line);
                            break;
                        case 6:
                            p2spd = int.Parse(line);
                            break;
                        case 7://attack specifications
                            p2atkLength = int.Parse(line);
                            break;
                        case 8:
                            p2atkhbX = int.Parse(line);
                            break;
                        case 9:
                            p2atkhbY = int.Parse(line);
                            break;
                        case 10:
                            p2atkhbOffset = int.Parse(line);
                            break;
                        case 11://special spefications
                            if (line.Contains("y")) { p2spclDoesHeal = true; }
                            else { p2spclDoesHeal = false; }
                            break;
                        case 12:
                            if (line.Contains("y")) { p2spclDoesDmg = true; }
                            else { p2spclDoesDmg = false; }
                            break;
                        case 13:
                            if (line.Contains("y")) { p2spclDoesDrop = true; }
                            else { p2spclDoesDrop = false; }
                            break;
                        case 14:
                            if (line.Contains("y")) { p2spclDoesSpecial = true; }
                            else { p2spclDoesSpecial = false; }
                            break;
                        case 15:
                            p2spclLength = int.Parse(line);
                            break;
                        case 16:
                            p2spclCool = int.Parse(line);
                            break;
                        case 17:
                            p2spclhbX = int.Parse(line);
                            break;
                        case 18:
                            p2spclhbY = int.Parse(line);
                            break;
                        case 19:
                            p2spclhbOffset = int.Parse(line);
                            break;
                        case 20:
                            p2spclDmg = int.Parse(line);
                            break;
                        case 21:
                            p2spclStun = int.Parse(line);
                            break;
                    }
                    linenumber += 1;
                }
                catch (Exception)
                {
                    file.Close();
                }
            }
            file.Close();
        }

        //----------------------------------\\
        //             Controls              \\
        //----------------------------------\\
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameStarted == false)
            {
                if (titleCleared == false)
                {
                    titleCleared = true;
                    title.triggerTransition();
                    p1Sprite = new Rectangle(90, 388, 400, 300);
                    p2Sprite = new Rectangle(510, 388, 400, 300);
                    p1spriteStatus = "Idle";
                    p2spriteStatus = "Idle";
                    p1Character = charsel.p1char();
                    p2Character = charsel.p2char();
                    p1prepareSprite();
                    p2prepareSprite();
                }
                else 
                {
                    if (gameStatus == "CharSel" && charsel.transitionDone() == true)
                    {
                        if (e.KeyData == Keys.Right) { charsel.moveSelRight1(); }
                        if (e.KeyData == Keys.Left) { charsel.moveSelLeft1(); }
                        if (e.KeyData == Keys.Up) { charsel.moveSelUp1(); }
                        if (e.KeyData == Keys.Down) { charsel.moveSelDown1(); }
                        if (e.KeyData == Keys.D) { charsel.moveSelRight2(); }
                        if (e.KeyData == Keys.A) { charsel.moveSelLeft2(); }
                        if (e.KeyData == Keys.W) { charsel.moveSelUp2(); }
                        if (e.KeyData == Keys.S) { charsel.moveSelDown2(); }
                        p1Character = charsel.p1char();
                        p2Character = charsel.p2char();
                        p1prepareSprite();
                        p2prepareSprite();
                        if (e.KeyData == Keys.R) { charsel.toRules(); }
                    }
                    else if ( rules.transitionDone() == true )
                    {
                        rules.toCharsel();
                    }
                }
            }
            else
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

            if (p1hb.IntersectsWith(platform))
            {
                if (p1falling == true && p1hb.Y < 600)
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

            if (p2hb.IntersectsWith(platform))
            {
                if (p2falling == true && p2hb.Y < 600) 
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

        private void p1stunTmr_Tick(object sender, EventArgs e)
        {
            p1stunned = true;
            p1stunTime -= 1;
            if (p1stunTime < p1dex - 2)
            {
                if (p1dealKnockback == false)//dealing knockback
                {
                    if (p2facingRight == true)
                    {
                        p1xv = p1hp/3 - p1def - p1currentHp / 5; //knockback based on defence and current hp
                        p1yv = -5;
                    }
                    else
                    {
                        p1xv = -p1hp/3 + p1def + p1currentHp / 5;
                        p1yv = -5;
                    }
                    p1invince = false;
                    p1dealKnockback = true;
                }
            }
            if (p1stunTime == 0)
            {
                p1dealKnockback = false;
                p1stunned = false;
                p1stunTmr.Enabled = false;
            }
        }

        private void p2stunTmr_Tick(object sender, EventArgs e)
        {
            p2stunned = true;
            p2stunTime -= 1;
            if (p2stunTime < p2dex - 2)
            {
                if (p2dealKnockback == false)//dealing knockback
                {
                    if (p1facingRight == true)
                    {
                        p2xv = p2hp/3 - p2def - p2currentHp / 5; //knockback based on defence and current hp
                        p2yv = -5;
                    }
                    else
                    {
                        p2xv = -p2hp/3 + p2def + p2currentHp / 5;
                        p2yv = -5;
                    }
                    p2invince = false;
                    p2dealKnockback = true;
                }
            }
            if(p2stunTime == 0)
            {
                p2dealKnockback = false;
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
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            switch (gameStatus)
            {
                case "title":
                    title.drawTitle(g);
                    break;
                case "CharSel":
                    charsel.drawCharSel(g);
                    g.DrawImage(p1Idle[p1frame], p1Sprite);
                    g.DrawImage(p2Idle[p2frame], p2Sprite);
                    if (charsel.transitionDone() != true)
                    {
                        charsel.drawFade(g);
                    }
                    charsel.drawFadeout(g);
                    break;
                case "Rules":
                    rules.drawRules(g);
                    if (rules.transitionDone() != true)
                    {
                        rules.drawFade(g);
                    }
                    else if (rules.rulesDone() != true)
                    {
                        rules.drawFadeout(g);
                    }
                    break;
            }

            g.FillRectangle(purplebrush, p1hb);
            g.FillRectangle(purplebrush, p1atkhb);

            g.FillRectangle(greenbrush, p2hb);
            g.FillRectangle(greenbrush, p2atkhb);

            g.FillRectangle(blackbrush, platform);

        }

        private void aniTmr_Tick(object sender, EventArgs e)
        {
            mainPanel.Invalidate();
            switch (gameStatus)
            {
                case "title":
                    title.aniTitle();
                    title.transitionTitle();
                    if(title.titleDone())
                    {
                        gameStatus = "CharSel";
                    }
                    break;
                case "CharSel":
                    charsel.aniCharSel();
                    if (charsel.transitionDone() != true)
                    {
                        charsel.transitionCharSel();
                    }
                    else if (charsel.charselDone() != true)
                    {
                        charsel.fadeoutCharSel();
                    }
                    else
                    {
                        rules = new Rules();
                        p1Sprite = Rectangle.Empty;
                        p2Sprite = Rectangle.Empty;
                        gameStatus = charsel.statuscharsel();
                        charsel.charselEmpty();
                    }
                    break;
                case "Rules":
                    rules.aniRules();
                    if (rules.transitionDone() != true)
                    {
                        rules.transitionRules();
                    }
                    else if (rules.rulesDone() != true)
                    {
                        rules.fadeoutRules();
                    }
                    else
                    {
                        charsel = new CharSel();
                        gameStatus = "CharSel";
                        p1Sprite = new Rectangle(90, 388, 400, 300);
                        p2Sprite = new Rectangle(510, 388, 400, 300);
                        p1Character = charsel.p1char();
                        p2Character = charsel.p2char();
                        p1prepareSprite();
                        p2prepareSprite();
                    }
                    break;
            }
            switch (p1spriteStatus)
            {
                case "Idle":
                    p1frame += 1;//cycles between frames
                    if (p1frame == 9)
                    {
                        p1frame = 1;
                    }
                    break;
            }
            switch (p2spriteStatus)
            {
                case "Idle":
                    p2frame += 1;//cycles between frames
                    if (p2frame == 9)
                    {
                        p2frame = 1;
                    }
                    break;
            }
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

                    playerposX = p1hb.X + 60;
                    playerposY = p1hb.Y + p1atkhbOffset;
                }                 
                else              
                {                 
                    playerposX = p1hb.X - p1atkhbX;
                    playerposY = p1hb.Y + p1atkhbOffset;
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
                    p2currentHp -= (p1atk - p2def);
                }
                p2invince = true;
                p2stunned = true;
                p2stunTime = p2dex;
                p2stunTmr.Enabled = true;
            }
        }

        private void p2Atk()
        {
            p2atkCool = true;
            p2atkActive = true;
            p2atkTime.Enabled = true;
            p2atkCooltime = 0;
            p2xv = 0;
            p2yv = 0;
            p2xa = 0;
            p2ya = 0;
            if (p2atkActive == true)
            {
                int playerposX, playerposY;
                if (p2facingRight == true)
                {
                    playerposX = p2hb.X + 60;
                    playerposY = p2hb.Y + p2atkhbOffset;
                }
                else
                {
                    playerposX = p2hb.X - p2atkhbX;
                    playerposY = p2hb.Y + p2atkhbOffset;
                }

                p2atkhb = new Rectangle(playerposX, playerposY, p2atkhbX, p2atkhbY);
            }
        }
        private void p2atkTime_Tick(object sender, EventArgs e) //tracks cooldown time
        {
            if (p2atkCooltime > p2dex)
            {
                p2atkTime.Enabled = false;
                p2atkCool = false;
            }
            else
            {
                p2atkCooltime += 1;
            }
            if (p2atkCooltime > p2atkLength)
            {
                p2atkhb = Rectangle.Empty;
                p2atkActive = false;
            }
            if (p1hb.IntersectsWith(p2atkhb))
            {
                p1xv = 0;
                p1xa = 0;
                p1yv = 0;
                p1ya = 0;
                if (p2atk - p1def > 0 && p1invince == false)
                {
                    p1currentHp -= (p2atk - p1def);
                }
                p1invince = true;
                p1stunned = true;
                p1stunTime = p1dex;
                p1stunTmr.Enabled = true;
            }
        }


        //----------------------------------\\
        //          Player Specials         \\
        //----------------------------------\\


    }
}
