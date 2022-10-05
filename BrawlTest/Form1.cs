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
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        bool gameStarted, titleCleared, charSelected, labels;
        string gameStatus;
        int smallDelay;


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
        string p1fullName, p1desc;
        bool p1dealKnockback = false;
        //p1 sprite works
        string p1spriteStatus;
        int p1frame;
        Image[] p1Idle = new Image[9];
        Image[] p1Taunt = new Image[10];
        Image[] p1Engarde = new Image[9];
        Image[] p1EngardeL = new Image[9];
        Image[] p1Run = new Image[5];
        Image[] p1RunL = new Image[5];
        Image[] p1Jump = new Image[5];
        Image[] p1JumpL = new Image[5];
        Image[] p1Regular = new Image[25];
        Image[] p1RegularL = new Image[25];
        Image[] p1Special = new Image[25];
        Image[] p1SpecialL = new Image[25];
        Image[] p1Concede = new Image[4];
        //p1 CharSel stat works
        Rectangle p1hpbar, p1atkbar, p1defbar, p1dexbar, p1spdbar;
        bool p1charChosen;


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
        string p2fullName, p2desc;
        bool p2dealKnockback = false;
        //p2 sprite works
        string p2spriteStatus;
        int p2frame;
        Image[] p2Idle = new Image[9];
        Image[] p2Taunt = new Image[10];
        Image[] p2Engarde = new Image[9];
        Image[] p2EngardeL = new Image[9];
        Image[] p2Run = new Image[5];
        Image[] p2RunL = new Image[5];
        Image[] p2Jump = new Image[5];
        Image[] p2JumpL = new Image[5];
        Image[] p2Regular = new Image[25];
        Image[] p2RegularL = new Image[25];
        Image[] p2Special = new Image[25];
        Image[] p2SpecialL = new Image[25];
        Image[] p2Concede = new Image[4];
        //p2 CharSel stat works
        Rectangle p2hpbar, p2atkbar, p2defbar, p2dexbar, p2spdbar;
        bool p2charChosen;



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
            smallDelay = 1;
        }

        //----------------------------------\\
        //           Game Startup           \\
        //----------------------------------\\
        private void gameStart()
        {
            p1Sprite = new Rectangle(400, 400, 200, 150);
            p1hb = new Rectangle(400, 400, 60, 100);
            p1loadChar();
            p1prepareSprite();
            p1lives = 3;
            p1frame = 1;
            p1facingRight = true;

            //the same stuff for player 2
            p2Sprite = new Rectangle(400, 400, 200, 150);
            p2hb = new Rectangle(400, 400, 60, 100);
            p2loadChar();
            p2prepareSprite();
            p2lives = 3;
            p2frame = 1;
            p2facingRight = false;

            platform = new Rectangle(1, 600, 1000, 50);
            mainPanel.Invalidate();

            //bools defaults
            p1invince = false;
            p1stunned = false;
            p2invince = false;
            p2stunned = false;
            veloTmr.Enabled = true;
        }


        //----------------------------------\\
        //        Loading Character         \\
        //----------------------------------\\

        private void p1prepareSpritecharsel()
        {
            if (p1Character != "nocharacter")
            {
                for (int i = 1; i <= 8; i++)//creates the image files for animations
                {
                    p1Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Idle_(" + i.ToString() + ").png");
                }
                for (int i = 1; i <= 9; i++)//creates the image files for animations
                {
                    p1Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Taunt_(" + i.ToString() + ").png");
                }
                p1hpbar = new Rectangle(180, 310, p1hp, 4);
                p1atkbar = new Rectangle(180, 334, p1atk*7, 4);
                p1defbar = new Rectangle(180, 358, p1def * 15, 4);
                p1dexbar = new Rectangle(180, 382, (20-p1dex) * 15, 4);
                p1spdbar = new Rectangle(180, 406 , p1spd * 50, 4);
                p1Name.Text = p1fullName;
                p1spclDesc.Text = p1desc;
            }
        }
        private void p2prepareSpritecharsel()
        {
            if (p2Character != "nocharacter")
            {
                for (int i = 1; i <= 8; i++)//creates the image files for animations
                {
                    p2Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Idle_(" + i.ToString() + ").png");
                }
                for (int i = 1; i <= 9; i++)//creates the image files for animations
                {
                    p2Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Taunt_(" + i.ToString() + ").png");
                }
                p2hpbar = new Rectangle(820 - p2hp, 310, p2hp, 4);
                p2atkbar = new Rectangle(820 - (p2atk * 7), 334, p2atk * 7, 4);
                p2defbar = new Rectangle(820 - (p2def * 15), 358, p2def * 15, 4);
                p2dexbar = new Rectangle(820 - ((20 - p2dex) * 15), 382, (20 - p2dex) * 15, 4);
                p2spdbar = new Rectangle(820 - (p2spd * 50), 406, p2spd * 50, 4);
                p2Name.Text = p2fullName;
                p2spclDesc.Text = p2desc;
            }
        }
        private void p1loadChar()
        {
            if (p1Character != "nocharacter")
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
                            case 1:
                                p1fullName = line;
                                break;
                            case 2://character description
                                p1desc = line;
                                break;
                            case 3://stats
                                p1hp = int.Parse(line);
                                break;
                            case 4:
                                p1atk = int.Parse(line);
                                break;
                            case 5:
                                p1def = int.Parse(line);
                                break;
                            case 6:
                                p1dex = int.Parse(line);
                                break;
                            case 7:
                                p1spd = int.Parse(line);
                                break;
                            case 8://attack specifications
                                p1atkLength = int.Parse(line);
                                break;
                            case 9:
                                p1atkhbX = int.Parse(line);
                                break;
                            case 10:
                                p1atkhbY = int.Parse(line);
                                break;
                            case 11:
                                p1atkhbOffset = int.Parse(line);
                                break;
                            case 12://special spefications
                                if (line.Contains("y")) { p1spclDoesHeal = true; }
                                else { p1spclDoesHeal = false; }
                                break;
                            case 13:
                                if (line.Contains("y")) { p1spclDoesDmg = true; }
                                else { p1spclDoesDmg = false; }
                                break;
                            case 14:
                                if (line.Contains("y")) { p1spclDoesDrop = true; }
                                else { p1spclDoesDrop = false; }
                                break;
                            case 15:
                                if (line.Contains("y")) { p1spclDoesSpecial = true; }
                                else { p1spclDoesSpecial = false; }
                                break;
                            case 16:
                                p1spclLength = int.Parse(line);
                                break;
                            case 17:
                                p1spclCool = int.Parse(line);
                                break;
                            case 18:
                                p1spclhbX = int.Parse(line);
                                break;
                            case 19:
                                p1spclhbY = int.Parse(line);
                                break;
                            case 20:
                                p1spclhbOffset = int.Parse(line);
                                break;
                            case 21:
                                p1spclDmg = int.Parse(line);
                                break;
                            case 22:
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
        }
        private void p2loadChar()
        {
            if (p2Character != "nocharacter")
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
                            case 1:
                                p2fullName = line;
                                break;
                            case 2://character description
                                p2desc = line;
                                break;
                            case 3://stats
                                p2hp = int.Parse(line);
                                break;
                            case 4:
                                p2atk = int.Parse(line);
                                break;
                            case 5:
                                p2def = int.Parse(line);
                                break;
                            case 6:
                                p2dex = int.Parse(line);
                                break;
                            case 7:
                                p2spd = int.Parse(line);
                                break;
                            case 8://attack specifications
                                p2atkLength = int.Parse(line);
                                break;
                            case 9:
                                p2atkhbX = int.Parse(line);
                                break;
                            case 10:
                                p2atkhbY = int.Parse(line);
                                break;
                            case 11:
                                p2atkhbOffset = int.Parse(line);
                                break;
                            case 12://special spefications
                                if (line.Contains("y")) { p2spclDoesHeal = true; }
                                else { p2spclDoesHeal = false; }
                                break;
                            case 13:
                                if (line.Contains("y")) { p2spclDoesDmg = true; }
                                else { p2spclDoesDmg = false; }
                                break;
                            case 14:
                                if (line.Contains("y")) { p2spclDoesDrop = true; }
                                else { p2spclDoesDrop = false; }
                                break;
                            case 15:
                                if (line.Contains("y")) { p2spclDoesSpecial = true; }
                                else { p2spclDoesSpecial = false; }
                                break;
                            case 16:
                                p2spclLength = int.Parse(line);
                                break;
                            case 17:
                                p2spclCool = int.Parse(line);
                                break;
                            case 18:
                                p2spclhbX = int.Parse(line);
                                break;
                            case 19:
                                p2spclhbY = int.Parse(line);
                                break;
                            case 20:
                                p2spclhbOffset = int.Parse(line);
                                break;
                            case 21:
                                p2spclDmg = int.Parse(line);
                                break;
                            case 22:
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
        }

        private void p1prepareSprite()
        {
            for (int i = 1; i <= 8; i++)//creates the image files for animations
            {
                p1Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Idle_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 9; i++)
            {
                p1Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Taunt_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 8; i++)
            {
                p1Engarde[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Engarde_(" + i.ToString() + ").png");
                p1EngardeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Engarde_(" + i.ToString() + ").png");
                p1EngardeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= 4; i++)
            {
                p1Run[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Run_(" + i.ToString() + ").png");
                p1RunL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Run_(" + i.ToString() + ").png");
                p1RunL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= 4; i++)
            {
                p1Jump[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Jump_(" + i.ToString() + ").png");
                p1JumpL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Jump_(" + i.ToString() + ").png");
                p1JumpL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= p1atkLength; i++)
            {
                p1Regular[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Regular_(" + i.ToString() + ").png");
                p1RegularL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Regular_(" + i.ToString() + ").png");
                p1RegularL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= p1spclLength; i++)
            {
                p1Special[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Special_(" + i.ToString() + ").png");
                p1SpecialL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Special_(" + i.ToString() + ").png");
                p1SpecialL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= 3; i++)
            {
                p1Concede[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Concede_(" + i.ToString() + ").png");
            }
        }
        private void p2prepareSprite()
        {
            for (int i = 1; i <= 8; i++)//creates the image files for animations
            {
                p2Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Idle_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 9; i++)
            {
                p2Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Taunt_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 8; i++)
            {
                p2Engarde[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Engarde_(" + i.ToString() + ").png");
                p2EngardeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Engarde_(" + i.ToString() + ").png");
                p2EngardeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= 4; i++)
            {
                p2Run[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Run_(" + i.ToString() + ").png");
                p2RunL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Run_(" + i.ToString() + ").png");
                p2RunL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= 4; i++)
            {
                p2Jump[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Jump_(" + i.ToString() + ").png");
                p2JumpL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Jump_(" + i.ToString() + ").png");
                p2JumpL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= p2atkLength; i++)
            {
                p2Regular[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Regular_(" + i.ToString() + ").png");
                p2RegularL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Regular_(" + i.ToString() + ").png");
                p2RegularL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= p2spclLength; i++)
            {
                p2Special[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Special_(" + i.ToString() + ").png");
                p2SpecialL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Special_(" + i.ToString() + ").png");
                p2SpecialL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            for (int i = 1; i <= 3; i++)
            {
                p2Concede[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Concede_(" + i.ToString() + ").png");
            }
        }

        private void drawBars(Graphics g)
        {
            g.FillRectangle(whiteBrush, p1hpbar);
            g.FillRectangle(whiteBrush, p1atkbar);
            g.FillRectangle(whiteBrush, p1defbar);
            g.FillRectangle(whiteBrush, p1dexbar);
            g.FillRectangle(whiteBrush, p1spdbar);
            g.FillRectangle(whiteBrush, p2hpbar);
            g.FillRectangle(whiteBrush, p2atkbar);
            g.FillRectangle(whiteBrush, p2defbar);
            g.FillRectangle(whiteBrush, p2dexbar);
            g.FillRectangle(whiteBrush, p2spdbar);
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
                    p1loadChar();
                    p2loadChar();
                    p1prepareSpritecharsel();
                    p2prepareSpritecharsel();
                    p1charChosen = false;
                    p2charChosen = false;
                }
                else 
                {
                    if (gameStatus == "CharSel" && charsel.transitionDone() == true)
                    {
                        if(p1charChosen == false)
                        {
                            if (e.KeyData == Keys.D) { charsel.moveSelRight1(); }
                            if (e.KeyData == Keys.A) { charsel.moveSelLeft1(); }
                            if (e.KeyData == Keys.W) { charsel.moveSelUp1(); }
                            if (e.KeyData == Keys.S) { charsel.moveSelDown1(); }
                            p1Character = charsel.p1char();
                            p1loadChar();
                            p1prepareSpritecharsel();
                            if(e.KeyData == Keys.G)
                            {
                                if (p1Character != "nocharacter")
                                { 
                                    p1charChosen = true; 
                                    p1frame = 1;  
                                    p1spriteStatus = "Taunt";
                                    charsel.p1chosenChar();
                                } 
                            }
                        }
                        if(p2charChosen == false)
                        {
                            if (e.KeyData == Keys.Right) { charsel.moveSelRight2(); }
                            if (e.KeyData == Keys.Left) { charsel.moveSelLeft2(); }
                            if (e.KeyData == Keys.Up) { charsel.moveSelUp2(); }
                            if (e.KeyData == Keys.Down) { charsel.moveSelDown2(); }
                            p2Character = charsel.p2char();
                            p2loadChar();
                            p2prepareSpritecharsel();
                            if (e.KeyData == Keys.Enter)
                            {
                                if (p2Character != "nocharacter")
                                { 
                                    p2charChosen = true; 
                                    p2frame = 1; 
                                    p2spriteStatus = "Taunt";
                                    charsel.p2chosenChar();
                                }
                            }

                        }
                        if (e.KeyData == Keys.R) { 
                            charsel.toRules(); 
                            p1Name.Visible = false;
                            p1spclDesc.Visible = false;
                            p2Name.Visible = false;
                            p2spclDesc.Visible = false;
                        }
                    }
                    else if ( rules.transitionDone() == true )
                    {
                        rules.toCharsel();
                        p1charChosen = false;
                        p2charChosen = false;
                    }
                }
            }
            else
            {
                //p1
                if (p1atkActive == false && p1stunned == false && p1spclActive == false)
                {
                    if (p1xv < 10 && p1xv > -10)//velocity cap
                    {
                        if (e.KeyData == Keys.D) { p1xa = p1spd; p1facingRight = true; p1spriteStatus = "Run"; p1frame = 1; }
                        if (e.KeyData == Keys.A) { p1xa = -p1spd; p1facingRight = false; p1spriteStatus = "Run"; p1frame = 1; }
                    }
                    if (p1jumping == false)
                    {
                        if (e.KeyData == Keys.W && p1yv < 50 && p1yv > -50 && p1falling == false)//check is players on a platform and velocity cap
                        {
                            p1ya = -10;
                            p1jumping = true;
                            if (p1atkActive == false)
                            {
                                p1frame = 1;
                                p1spriteStatus = "Jump";
                            }
                        }
                    }
                    if (e.KeyData == Keys.G) { p1Atk(); p1spriteStatus = "Regular"; p1frame = 1; } //actives attack skill
                    if (e.KeyData == Keys.H) { p1spriteStatus = "Taunt"; p1frame = 1; }
                }

                //p2
                if (p2atkActive == false && p2stunned == false && p2spclActive == false)
                {
                    if (p2xv < 10 && p2xv > -10)//velocity cap
                    {
                        if (e.KeyData == Keys.Right) { p2xa = p2spd; p2facingRight = true; p2spriteStatus = "Run"; p2frame = 1; }
                        if (e.KeyData == Keys.Left) { p2xa = -p2spd; p2facingRight = false; p2spriteStatus = "Run"; p2frame = 1; }
                    }
                    if (p2jumping == false)
                    {
                        if (e.KeyData == Keys.Up && p2yv < 50 && p2yv > -50 && p2falling == false)//check is players on a platform and velocity cap
                        {
                            p2ya = -10;
                            p2jumping = true;
                            if (p2atkActive == false)
                            {
                                p2frame = 1;
                                p2spriteStatus = "Jump";
                            }
                        }
                    }
                    if (e.KeyData == Keys.Enter) { p2Atk(); p2spriteStatus = "Regular"; p2frame = 1; } //actives attack skill
                    if (e.KeyData == Keys.Space) { p2spriteStatus = "Taunt"; p2frame = 1; }
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameStarted == true)
            {
                //p1
                if (e.KeyData == Keys.D || e.KeyData == Keys.A)
                {
                    p1xa = 0;
                    if (p1atkActive == false)
                    {
                        p1spriteStatus = "Engarde";
                        p1frame = 1;
                    }
                }
                if (e.KeyData == Keys.W)
                { p1ya = 0; p1jumping = false; }

                //p2
                if (e.KeyData == Keys.Right || e.KeyData == Keys.Left)
                {
                    p2xa = 0;
                    if (p2atkActive == false)
                    {
                        p2spriteStatus = "Engarde";
                        p2frame = 1;
                    }
                }
                if (e.KeyData == Keys.Up)
                { p2ya = 0; p2jumping = false; }
            }
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
                    if (p1atkActive == false)
                    {
                        p1spriteStatus = "Engarde";
                    }
                }
            }
            else 
            {
                p1ya += 1;
                p1falling = true;
                if (p1atkActive == false)
                {
                    p1spriteStatus = "Jump";
                }
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
                    if (p2atkActive == false)
                    {
                        p2spriteStatus = "Engarde";
                    }
                }
            }
            else
            {
                p2ya += 1;
                p2falling = true;
                if (p2atkActive == false)
                {
                    p2spriteStatus = "Jump";
                }
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
                    p1frame = 1;
                    if (p2facingRight == true)
                    {
                        p1xv = 20 - p1def - (p1currentHp/p1hp)*10; //knockback based on defence and current hp
                        p1yv = -5;
                    }
                    else
                    {
                        p1xv = -(20 - p1def - (p1currentHp / p1hp) * 10);
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
                    p2frame = 1;
                    if (p1facingRight == true)
                    {
                        p2xv = 20 - p2def - (p2currentHp / p2hp) * 10; //knockback based on defence and current hp
                        p2yv = -5;
                    }
                    else
                    {
                        p2xv = -(20 - p2def - (p2currentHp / p2hp) * 10);
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
                    drawBars(g);
                    if (p1spriteStatus == "Idle")
                    {
                        g.DrawImage(p1Idle[p1frame], p1Sprite);
                    }
                    else
                    {
                        g.DrawImage(p1Taunt[p1frame], p1Sprite);
                    }
                    if (p2spriteStatus == "Idle")
                    {
                        g.DrawImage(p2Idle[p2frame], p2Sprite);
                    }
                    else
                    {
                        g.DrawImage(p2Taunt[p2frame], p2Sprite);
                    }
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
                case "Game":
                    switch (p1spriteStatus)
                    {
                        case "Engarde":
                            if (p1facingRight == true)
                            {
                                g.DrawImage(p1Engarde[p1frame], p1Sprite);
                            }
                            else
                            {
                                g.DrawImage(p1EngardeL[p1frame], p1Sprite);
                            }
                            break;
                        case "Jump":
                            if (p1facingRight == true)
                            {
                                g.DrawImage(p1Jump[p1frame], p1Sprite);
                            }
                            else
                            {
                                g.DrawImage(p1JumpL[p1frame], p1Sprite);
                            }
                            break;
                        case "Run":
                            if (p1facingRight == true)
                            {
                                g.DrawImage(p1Run[p1frame], p1Sprite);
                            }
                            else
                            {
                                g.DrawImage(p1RunL[p1frame], p1Sprite);
                            }
                            break;
                        case "Regular":
                            if (p1facingRight == true)
                            {
                                g.DrawImage(p1Regular[p1frame], p1Sprite);
                            }
                            else
                            {
                                g.DrawImage(p1RegularL[p1frame], p1Sprite);
                            }
                            break;
                        case "Taunt":
                            g.DrawImage(p1Taunt[p1frame], p1Sprite);
                            break;
                        case "TakingDamage":
                            if (p1facingRight == true)
                            {
                                g.DrawImage(p1Jump[1], p1Sprite);
                            }
                            else
                            {
                                g.DrawImage(p1JumpL[1], p1Sprite);
                            }
                            break;
                    }
                    switch (p2spriteStatus)
                    {
                        case "Engarde":
                            if (p2facingRight == true)
                            {
                                g.DrawImage(p2Engarde[p2frame], p2Sprite);
                            }
                            else
                            {
                                g.DrawImage(p2EngardeL[p2frame], p2Sprite);
                            }
                            break;
                        case "Jump":
                            if (p2facingRight == true)
                            {
                                g.DrawImage(p2Jump[p2frame], p2Sprite);
                            }
                            else
                            {
                                g.DrawImage(p2JumpL[p2frame], p2Sprite);
                            }
                            break;
                        case "Run":
                            if (p2facingRight == true)
                            {
                                g.DrawImage(p2Run[p2frame], p2Sprite);
                            }
                            else
                            {
                                g.DrawImage(p2RunL[p2frame], p2Sprite);
                            }
                            break;
                        case "Regular":
                            if (p2facingRight == true)
                            {
                                g.DrawImage(p2Regular[p2frame], p2Sprite);
                            }
                            else
                            {
                                g.DrawImage(p2RegularL[p2frame], p2Sprite);
                            }
                            break;
                        case "Taunt":
                            g.DrawImage(p2Taunt[p2frame], p2Sprite);
                            break;
                        case "TakingDamage":
                            if (p2facingRight == true)
                            {
                                g.DrawImage(p2Jump[1], p2Sprite);
                            }
                            else
                            {
                                g.DrawImage(p2JumpL[1], p2Sprite);
                            }
                            break;
                    }
                    break;
            }


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
                        labels = false;
                        charsel.transitionCharSel();
                    }
                    else
                    {
                        if (labels == false)
                        {
                            p1Name.Visible = true;
                            p1spclDesc.Visible = true;
                            p2Name.Visible = true;
                            p2spclDesc.Visible = true;
                            labels = true;
                        }
                    }
                    if(p1charChosen == true && p2charChosen == true)
                    {
                        smallDelay += 1;
                        if(smallDelay >= 10)
                        {
                            charsel.toGame();
                            p1Name.Visible = false;
                            p1spclDesc.Visible = false;
                            p2Name.Visible = false;
                            p2spclDesc.Visible = false;
                            if (charsel.charselDone() != true)
                            {
                                charsel.fadeoutCharSel();
                            }
                            else
                            {
                                p1Sprite = Rectangle.Empty;
                                p2Sprite = Rectangle.Empty;
                                gameStatus = charsel.statuscharsel();
                                charsel.charselEmpty();
                                gameStart();
                                gameStarted = true;
                            }

                        }
                    }
                    else
                    {
                        if (charsel.charselDone() != true)
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
                        p1loadChar();
                        p2loadChar();
                        p1prepareSpritecharsel();
                        p2prepareSpritecharsel();
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
                case "Taunt":
                    p1frame += 1;
                    if (p1frame == 10)
                    {
                        p1frame = 1; 
                        if(gameStarted == true)
                        {
                            p1spriteStatus = "Engarde";
                        }
                        else
                        {
                            p1spriteStatus = "Idle";
                        }
                    }
                    break;
                case "Engarde":
                    p1frame += 1;
                    if (p1frame == 9)
                    {
                        p1frame = 1;
                    }
                    break;
                case "Jump":
                    p1frame += 1;
                    if (p1frame == 5)
                    {
                        p1frame = 1;
                    }
                    break;
                case "Run":
                    p1frame += 1;
                    if (p1frame == 5)
                    {
                        p1frame = 1;
                    }
                    break;
                case "Regular":
                    p1frame += 1;
                    if (p1frame == 9)
                    {
                        p1frame = 1; p1spriteStatus = "Engarde";
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
                case "Taunt":
                    p2frame += 1;
                    if (p2frame == 10)
                    {
                        p2frame = 1;
                        if (gameStarted == true)
                        {
                            p2spriteStatus = "Engarde";
                        }
                        else
                        {
                            p2spriteStatus = "Idle";
                        }
                    }
                    break;
                case "Engarde":
                    p2frame += 1;
                    if (p2frame == 9)
                    {
                        p2frame = 1;
                    }
                    break;
                case "Jump":
                    p2frame += 1;
                    if (p2frame == 5)
                    {
                        p2frame = 1;
                    }
                    break;
                case "Run":
                    p2frame += 1;
                    if (p2frame == 5)
                    {
                        p2frame = 1;
                    }
                    break;
                case "Regular":
                    p2frame += 1;
                    if (p2frame == 9)
                    {
                        p2frame = 1; p2spriteStatus = "Engarde";
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
            {;
                p1atkCooltime += 1;
            }
            if (p1atkCooltime > p1atkLength)
            {
                p1atkhb = Rectangle.Empty;
                p1atkActive = false;
            }
            if (p2hb.IntersectsWith(p1atkhb))
            {
                p2spriteStatus = "TakingDamage";
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
                p1spriteStatus = "TakingDamage";
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
