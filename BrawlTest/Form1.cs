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

        Rectangle platform, Arena, fadeSpace;
        Rectangle p1Sprite, p1hb, p1atkhb, p1spclhb; //hitboxes
        Rectangle p2Sprite, p2hb, p2atkhb, p2spclhb; //hitboxes

        Graphics g; // declare the graphics object
        SolidBrush blueBrush = new SolidBrush(Color.LightSkyBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Image arenaImage = Image.FromFile(Application.StartupPath + @"\Assets\Arena.png");
        Image[] fadeFrame = new Image[6];

        bool gameStarted, titleCleared, labels, fadeDone;
        string gameStatus;
        int smallDelay, Frame;


        //p1
        int p1xv, p1yv, p1xa, p1ya;
        int p1atkCooltime, p1spclCooltime, p1stunTime; //cooldown timers
        bool p1falling, p1jumping, p1atkActive, p1spclActive, p1invince, p1stunned, p1trueInvince; //indicators if these things are active
        bool p1atkCool, p1sklCool; //skill cooldowns
        bool p1facingRight; //which side is the player facing
        string p1Character;
        int p1currentHp, p1lives;
        //p1 imported integers
        int p1hp, p1atk, p1def, p1dex, p1spd; //stats
        int p1atkLength; //attack specifications 
        int p1atkhbX, p1atkhbY, p1atkhbOffsetX, p1atkhbOffsetY; //attack hitbox sizes
        bool p1spclDoesHeal, p1spclDoesDmg, p1spclDoesDrop, p1spclDoesSpecial; //Special skill conditions
        int p1spclLength, p1spclCool, p1spclhbX, p1spclhbY, p1spclhbOffsetX, p1spclhbOffsetY; //Special skill specifications
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
        Image[] p1RegularAtk = new Image[25];
        Image[] p1RegularAtkL = new Image[25];
        Image[] p1Special = new Image[25];
        Image[] p1SpecialL = new Image[25];
        Image[] p1Concede = new Image[4];
        Image[] p1ConcedeL = new Image[4];
        bool p1flash;
        //p1 CharSel stat works
        Rectangle p1hpbar, p1atkbar, p1defbar, p1dexbar, p1spdbar;
        Rectangle p1ChpBar, p1livesBar, p1spclBar;
        bool p1charChosen;
        //p1 Result Stats
        int p1damageDealt, p1damageTaken;


        //p2
        int p2xv, p2yv, p2xa, p2ya;
        int p2atkCooltime, p2spclCooltime, p2stunTime; //cooldown timers
        bool p2falling, p2jumping, p2atkActive, p2spclActive, p2invince, p2stunned, p2trueInvince; //indicators if these things are active
        bool p2atkCool, p2sklCool; //skill cooldowns
        bool p2facingRight; //which side is the player facing
        string p2Character;
        int p2currentHp, p2lives;
        //p2 imported integers
        int p2hp, p2atk, p2def, p2dex, p2spd; //stats
        int p2atkLength; //attack specifications 
        int p2atkhbX, p2atkhbY, p2atkhbOffsetX, p2atkhbOffsetY; //attack hitbox sizes
        bool p2spclDoesHeal, p2spclDoesDmg, p2spclDoesDrop, p2spclDoesSpecial; //Special skill conditions
        int p2spclLength, p2spclCool, p2spclhbX, p2spclhbY, p2spclhbOffsetX, p2spclhbOffsetY; //Special skill specifications
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
        Image[] p2RegularAtk = new Image[25];
        Image[] p2RegularAtkL = new Image[25];
        Image[] p2Special = new Image[25];
        Image[] p2SpecialL = new Image[25];
        Image[] p2Concede = new Image[4];
        Image[] p2ConcedeL = new Image[4];
        bool p2flash;
        //p2 CharSel stat works
        Rectangle p2hpbar, p2atkbar, p2defbar, p2dexbar, p2spdbar;
        Rectangle p2ChpBar, p2livesBar, p2spclBar;
        bool p2charChosen;
        //p2 Result Stats
        int p2damageDealt, p2damageTaken;



        Title title = new Title();
        CharSel charsel = new CharSel();
        Rules rules = new Rules();

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, mainPanel, new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameStarted = false;
            gameStatus = "title";
            smallDelay = 1;
            for (int i = 1; i <= 5; i++)
            {
                fadeFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeSc_(" + i.ToString() + ").png");
            }
        }

        //----------------------------------\\
        //           Game Startup           \\
        //----------------------------------\\
        private void gameStart()
        {
            gameStarted = true;
            p1lives = 3;
            p2lives = 3;
            p1setChar();
            p2setChar();
            p1loadChar();
            p2loadChar();
            p1prepareSprite();
            p2prepareSprite();
            veloTmr.Enabled = true;
            mainPanel.Invalidate();
        }

        private void p1setChar()
        {
            p1Sprite = new Rectangle(300, 300, 200, 150);
            p1hb = new Rectangle(300, 300, 60, 100);
            p1frame = 1;
            p1facingRight = true;
            p1currentHp = p1hp;
            p1ChpBar = new Rectangle(195, 629, (200 * p1currentHp / p1hp), 5);
            p1livesBar = new Rectangle(161, 658, 78 * p1lives, 5);
            p1spclTmr.Enabled = true;
            p1spclCooltime = 1;
            p1sklCool = true;
            p1invince = false;
            p1stunned = false;
            p1trueInvince = false;
        }
        private void p2setChar()
        {
            p2Sprite = new Rectangle(640, 300, 200, 150);
            p2hb = new Rectangle(640, 300, 60, 100);
            p2frame = 1;
            p2facingRight = false;
            p2currentHp = p2hp;
            p2ChpBar = new Rectangle(603, 629, (200 * p2currentHp / p2hp), 5);
            p2livesBar = new Rectangle(837 - (78 * p2lives), 658, 78 * p2lives, 5);
            p2spclTmr.Enabled = true;
            p2spclCooltime = 1;
            p2sklCool = true;
            p2invince = false;
            p2stunned = false;
            p2trueInvince = false;
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
                p1dexbar = new Rectangle(180, 382, (13-p1dex) * 15, 4);
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
                p2dexbar = new Rectangle(820 - ((13 - p2dex) * 15), 382, (13 - p2dex) * 15, 4);
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
                for (int i = 1; i <= 25; i++)
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
                                p1atkhbOffsetX = int.Parse(line);
                                break;
                            case 12:
                                p1atkhbOffsetY = int.Parse(line);
                                break;
                            case 13://special spefications
                                if (line.Contains("y")) { p1spclDoesHeal = true; }
                                else { p1spclDoesHeal = false; }
                                break;
                            case 14:
                                if (line.Contains("y")) { p1spclDoesDmg = true; }
                                else { p1spclDoesDmg = false; }
                                break;
                            case 15:
                                if (line.Contains("y")) { p1spclDoesDrop = true; }
                                else { p1spclDoesDrop = false; }
                                break;
                            case 16:
                                if (line.Contains("y")) { p1spclDoesSpecial = true; }
                                else { p1spclDoesSpecial = false; }
                                break;
                            case 17:
                                p1spclLength = int.Parse(line);
                                break;
                            case 18:
                                p1spclCool = int.Parse(line);
                                break;
                            case 19:
                                p1spclhbX = int.Parse(line);
                                break;
                            case 20:
                                p1spclhbY = int.Parse(line);
                                break;
                            case 21:
                                p1spclhbOffsetX = int.Parse(line);
                                break;
                            case 22:
                                p1spclhbOffsetY = int.Parse(line);
                                break;
                            case 23:
                                p1spclDmg = int.Parse(line);
                                break;
                            case 24:
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
                for (int i = 1; i <= 25; i++)
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
                                p2atkhbOffsetX = int.Parse(line);
                                break;
                            case 12:
                                p2atkhbOffsetY = int.Parse(line);
                                break;
                            case 13://special spefications
                                if (line.Contains("y")) { p2spclDoesHeal = true; }
                                else { p2spclDoesHeal = false; }
                                break;
                            case 14:
                                if (line.Contains("y")) { p2spclDoesDmg = true; }
                                else { p2spclDoesDmg = false; }
                                break;
                            case 15:
                                if (line.Contains("y")) { p2spclDoesDrop = true; }
                                else { p2spclDoesDrop = false; }
                                break;
                            case 16:
                                if (line.Contains("y")) { p2spclDoesSpecial = true; }
                                else { p2spclDoesSpecial = false; }
                                break;
                            case 17:
                                p2spclLength = int.Parse(line);
                                break;
                            case 18:
                                p2spclCool = int.Parse(line);
                                break;
                            case 19:
                                p2spclhbX = int.Parse(line);
                                break;
                            case 20:
                                p2spclhbY = int.Parse(line);
                                break;
                            case 21:
                                p2spclhbOffsetX = int.Parse(line);
                                break;
                            case 22:
                                p2spclhbOffsetY = int.Parse(line);
                                break;
                            case 23:
                                p2spclDmg = int.Parse(line);
                                break;
                            case 24:
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
                p1RegularAtk[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p1RegularAtkL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p1RegularAtkL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
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
                p1ConcedeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Concede_(" + i.ToString() + ").png");
                p1ConcedeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
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
                p2RegularAtk[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p2RegularAtkL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p2RegularAtkL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
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
                p2ConcedeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Concede_(" + i.ToString() + ").png");
                p2ConcedeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
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
        private void drawBarsGame(Graphics g)
        {
            g.FillRectangle(whiteBrush, p1ChpBar);
            g.FillRectangle(whiteBrush, p2ChpBar);
            g.FillRectangle(whiteBrush, p1livesBar);
            g.FillRectangle(whiteBrush, p2livesBar);
            if(p1spclCooltime >= p1spclCool)
            {
                g.FillRectangle(blueBrush, p1spclBar);
            }
            else
            {
                g.FillRectangle(whiteBrush, p1spclBar);
            }
            if (p2spclCooltime >= p2spclCool)
            {
                g.FillRectangle(blueBrush, p2spclBar);
            }
            else
            {
                g.FillRectangle(whiteBrush, p2spclBar);
            }
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
                            if (e.KeyData == Keys.M)
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
            else if(fadeDone == true)
            {
                //p1
                if (p1atkActive == false && p1stunned == false && p1spclActive == false && p1spriteStatus != "Concede")
                {
                    if (p1xv < 10 && p1xv > -10)//velocity cap
                    {
                        if (e.KeyData == Keys.D)
                        {
                            p1xa = p1spd; p1facingRight = true; p1spriteStatus = "Run";
                            if (p1frame >= 5)
                            {
                                p1frame = 1;
                            }
                        }
                        if (e.KeyData == Keys.A)
                        {
                            p1xa = -p1spd; p1facingRight = false; p1spriteStatus = "Run";
                            if (p1frame >= 5)
                            {
                                p1frame = 1;
                            }
                        }
                    }
                    if (e.KeyData == Keys.W && p1yv < 50 && p1yv > -50 && p1falling == false && p1jumping == false)//check is players on a platform and velocity cap
                    {
                        p1ya = -7;
                        p1jumping = true;
                        if (p1atkActive == false)
                        {
                            p1frame = 1;
                            p1spriteStatus = "Jump";
                        }
                    }
                    if (e.KeyData == Keys.G && p1atkCool == false && p1jumping == false) { p1Atk(); p1spriteStatus = "Regular"; p1frame = 1; } //actives attack skill
                    if (e.KeyData == Keys.H && p1sklCool == false && p1jumping == false) { p1spclAtk(); p1spriteStatus = "Special"; p1frame = 1; } //actives attack skill

                    if (e.KeyData == Keys.J) { p1spriteStatus = "Taunt"; p1frame = 1; }
                }

                //p2
                if (p2atkActive == false && p2stunned == false && p2spclActive == false && p2spriteStatus != "Concede")
                {
                    if (p2xv < 10 && p2xv > -10)//velocity cap
                    {
                        if (e.KeyData == Keys.Right)
                        {
                            p2xa = p2spd; p2facingRight = true; p2spriteStatus = "Run"; if (p2frame >= 5)
                            {
                                p2frame = 1;
                            }
                        }
                        if (e.KeyData == Keys.Left)
                        {
                            p2xa = -p2spd; p2facingRight = false; p2spriteStatus = "Run"; if (p2frame >= 5)
                            {
                                p2frame = 1;
                            }
                        }
                    }
                    if (e.KeyData == Keys.Up && p2yv < 50 && p2yv > -50 && p2falling == false && p2jumping == false)//check is players on a platform and velocity cap
                    {
                        p2ya = -7;
                        p2jumping = true;
                        if (p2atkActive == false)
                        {
                            p2frame = 1;
                            p2spriteStatus = "Jump";
                        }
                    }
                    if (e.KeyData == Keys.M && p2atkCool == false && p2jumping == false) { p2Atk(); p2spriteStatus = "Regular"; p2frame = 1; } //actives attack skill
                    if (e.KeyData == Keys.N && p2sklCool == false && p2jumping == false) { p2spclAtk(); p2spriteStatus = "Special"; p2frame = 1; } //actives attack skill

                    if (e.KeyData == Keys.B) { p2spriteStatus = "Taunt"; p2frame = 1; }
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameStarted == true && fadeDone == true)
            {
                //p1
                if (p1atkActive == false && p1stunned == false && p1spclActive == false && p1spriteStatus != "Concede")
                {
                    if (e.KeyData == Keys.D || e.KeyData == Keys.A)
                    {
                        p1xa = 0;
                        if (p1atkActive == false)
                        {
                            p1spriteStatus = "Engarde";
                            p1frame = 1;
                        }
                    }
                }

                //p2
                if (p2atkActive == false && p2stunned == false && p2spclActive == false && p2spriteStatus != "Concede")
                {
                    if (e.KeyData == Keys.Right || e.KeyData == Keys.Left)
                    {
                        p2xa = 0;
                        if (p2atkActive == false)
                        {
                            p2spriteStatus = "Engarde";
                            p2frame = 1;
                        }
                    }
                }
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
            if(p1hb.X <= 0)
            {
                p1hb.X = 1;
                p1xa = 0;
                p1xv = 0;
            }
            if (p1hb.X >= 940)
            {
                p1hb.X = 939;
                p1xa = 0;
                p1xv = 0;
            }

            if (p1hb.IntersectsWith(platform))
            {
                if (p1falling == true && p1hb.Y < 600)
                {
                    int place = (int)p1hb.Y;
                    p1ya = 0;
                    p1hb.Y -= place - 441;
                    p1yv = 0;
                    p1falling = false;
                    p1jumping = false;
                    if (p1atkActive == false)
                    {
                        if(p1xa == 0)
                        {
                            p1spriteStatus = "Engarde";
                        }
                        else
                        {
                            p1spriteStatus = "Run";
                        }
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
            p1spclBar = new Rectangle(103, 719, (292 * p1spclCooltime / p1spclCool), 5);
            if(p1currentHp <= 0)
            {
                if (p1hb.IntersectsWith(platform) && p1spriteStatus != "TakingDamage")
                {
                    p1trueInvince = true;
                    if(p1spriteStatus != "Concede")
                    {
                        p1frame = 1;
                    }
                    p1spriteStatus = "Concede";
                }
                p1xv = 0;
                p1xa = 0;
            }


            //----------------------------------\\
            //               P2                 \\
            //----------------------------------\\
            p2hb.Y += p2yv;
            p2hb.X += p2xv;
            p2Sprite.Y = p2hb.Y - 50;
            p2Sprite.X = p2hb.X - 70;
            if (p2hb.X <= 0)
            {
                p2hb.X = 1;
                p2xa = 0;
                p2xv = 0;
            }
            if (p2hb.X >= 940)
            {
                p2hb.X = 939;
                p2xa = 0;
                p2xv = 0;
            }

            if (p2hb.IntersectsWith(platform))
            {
                if (p2falling == true && p2hb.Y < 600)
                {
                    int place = (int)p2hb.Y;
                    p2ya = 0;
                    p2hb.Y -= place - 441;
                    p2yv = 0;
                    p2falling = false;
                    p2jumping = false;
                    if (p2atkActive == false)
                    {
                        if (p2xa == 0)
                        {
                            p2spriteStatus = "Engarde";
                        }
                        else
                        {
                            p2spriteStatus = "Run";
                        }
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
            p2spclBar = new Rectangle(895 - (292 * p2spclCooltime / p2spclCool), 719, (292 * p2spclCooltime / p2spclCool), 5);
            if (p2currentHp <= 0)
            {
                if (p2hb.IntersectsWith(platform) && p2spriteStatus != "TakingDamage")
                {
                    p2trueInvince = true;
                    if (p2spriteStatus != "Concede")
                    {
                        p2frame = 1;
                    }
                    p2spriteStatus = "Concede";
                }
                p2xv = 0;
                p2xa = 0;
            }
        }

        private void p1stunTmr_Tick(object sender, EventArgs e)
        {
            p1stunned = true;
            p1stunTime -= 1;
            if (p1hb.IntersectsWith(p2atkhb) == false && p1hb.IntersectsWith(p2spclhb) == false)
            {
                if (p1dealKnockback == false)//dealing knockback
                {
                    p1frame = 1;
                    if (p2facingRight == true)
                    {
                        p1xv = 20 - p1def - (p1currentHp / p1hp) * 10; //knockback based on defence and current hp
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
            if (p2hb.IntersectsWith(p1atkhb) == false && p2hb.IntersectsWith(p1spclhb) == false)
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
                    g.DrawImage(arenaImage, Arena);
                    drawBarsGame(g);
                    if (fadeDone == false)
                    {
                        g.DrawImage(fadeFrame[Frame], fadeSpace);
                    }
                    else
                    {
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
                                    g.DrawImage(p1RegularAtk[p1frame], p1atkhb);
                                }
                                else
                                {
                                    g.DrawImage(p1RegularL[p1frame], p1Sprite);
                                    g.DrawImage(p1RegularAtkL[p1frame], p1atkhb);
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
                            case "Special":
                                if (p1facingRight == true)
                                {
                                    g.DrawImage(p1Special[p1frame], p1Sprite);
                                }
                                else
                                {
                                    g.DrawImage(p1SpecialL[p1frame], p1Sprite);
                                }
                                break;
                            case "Concede":
                                if (p1frame <= 3)
                                {
                                    if (p1facingRight == true)
                                    {
                                        g.DrawImage(p1Concede[p1frame], p1Sprite);
                                    }
                                    else
                                    {
                                        g.DrawImage(p1ConcedeL[p1frame], p1Sprite);
                                    }
                                }
                                else if (p1frame > 13)
                                {
                                    if (p1facingRight == true)
                                    {
                                        if (p1flash == false)
                                        {
                                            g.DrawImage(p1Concede[3], p1Sprite);
                                            p1flash = true;
                                        }
                                        else
                                        {
                                            p1flash = false;
                                        }
                                    }
                                    else
                                    {
                                        if (p1flash == false)
                                        {
                                            g.DrawImage(p1ConcedeL[3], p1Sprite);
                                            p1flash = true;
                                        }
                                        else
                                        {
                                            p1flash = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (p1facingRight == true)
                                    {
                                        g.DrawImage(p1Concede[3], p1Sprite);
                                    }
                                    else
                                    {
                                        g.DrawImage(p1ConcedeL[3], p1Sprite);
                                    }
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
                                    g.DrawImage(p2RegularAtk[p2frame], p2atkhb);
                                }
                                else
                                {
                                    g.DrawImage(p2RegularL[p2frame], p2Sprite);
                                    g.DrawImage(p2RegularAtkL[p2frame], p2atkhb);
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
                            case "Special":
                                if (p2facingRight == true)
                                {
                                    g.DrawImage(p2Special[p2frame], p2Sprite);
                                }
                                else
                                {
                                    g.DrawImage(p2SpecialL[p2frame], p2Sprite);
                                }
                                break;
                            case "Concede":
                                if (p2frame <= 3)
                                {
                                    if (p2facingRight == true)
                                    {
                                        g.DrawImage(p2Concede[p2frame], p2Sprite);
                                    }
                                    else
                                    {
                                        g.DrawImage(p2ConcedeL[p2frame], p2Sprite);
                                    }
                                }
                                else if (p2frame > 13)
                                {
                                    if (p2facingRight == true)
                                    {
                                        if (p2flash == false)
                                        {
                                            g.DrawImage(p2Concede[3], p2Sprite);
                                            p2flash = true;
                                        }
                                        else
                                        {
                                            p2flash = false;
                                        }
                                    }
                                    else
                                    {
                                        if (p2flash == false)
                                        {
                                            g.DrawImage(p2ConcedeL[3], p2Sprite);
                                            p2flash = true;
                                        }
                                        else
                                        {
                                            p2flash = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (p2facingRight == true)
                                    {
                                        g.DrawImage(p2Concede[3], p2Sprite);
                                    }
                                    else
                                    {
                                        g.DrawImage(p2ConcedeL[3], p2Sprite);
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
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
                                platform = new Rectangle(0, 540, 1000, 50);
                                Arena = new Rectangle(0, 0, 1000, 750);
                                fadeSpace = new Rectangle(0, 0, 1000, 750);
                                gameStatus = charsel.statuscharsel();
                                charsel.charselEmpty();
                                Frame = 1;
                                fadeDone = false;
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
                case "Game":
                    if(Frame < 10)
                    {
                        Frame += 1;
                        if(Frame == 5)
                        {
                            fadeDone = true;
                            fadeSpace = Rectangle.Empty;
                        }
                    }
                    else if (Frame == 10)
                    {
                        gameStart();
                        Frame = 11;
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
                    if (p1frame == p1atkLength + 1)
                    {
                        p1frame = 1; p1spriteStatus = "Engarde";
                    }
                    break;
                case "Special":
                    p1frame += 1;
                    if (p1frame == p1spclLength + 1)
                    {
                        p1frame = 1; p1spriteStatus = "Engarde";
                    }
                    break;
                case "Concede":
                    p1frame += 1;
                    if(p1frame == 15)
                    {
                        p1lives -= 1;
                        p1setChar();
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
                    if (p2frame == p2atkLength + 1)
                    {
                        p2frame = 1; p2spriteStatus = "Engarde";
                    }
                    break;
                case "Special":
                    p2frame += 1;
                    if (p2frame == p2spclLength + 1)
                    {
                        p2frame = 1; p2spriteStatus = "Engarde";
                    }
                    break;
                case "Concede":
                    p2frame += 1;
                    if (p2frame == 15)
                    {
                        p2lives -= 1;
                        p2setChar();
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
            int playerposX, playerposY;
            if (p1facingRight == true)
            {
                playerposX = p1hb.X + 30 + p1atkhbOffsetX;
                playerposY = p1hb.Y + p1atkhbOffsetY;
            }
            else
            {
                playerposX = p1hb.X + 30 - p1atkhbOffsetX - p1atkhbX;
                playerposY = p1hb.Y + p1atkhbOffsetY;
            }
            p1atkhb = new Rectangle(playerposX, playerposY, p1atkhbX, p1atkhbY);
        }
        private void p1atkTime_Tick(object sender, EventArgs e) //tracks cooldown time
        {
            if (p1atkCooltime > p1atkLength + p1dex)
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
            if (p2hb.IntersectsWith(p1atkhb) && p2trueInvince == false)
            {
                p2spriteStatus = "TakingDamage";
                p2xv = 0;
                p2xa = 0;
                p2yv = 0;
                p2ya = 0;
                if (p1atk - p2def > 0 && p2invince == false)
                {
                    p2currentHp -= (p1atk - p2def);
                    p2damageTaken += (p1atk - p2def);
                    p1damageDealt += (p1atk - p2def);
                    p2ChpBar = new Rectangle(603 + 200 - (200 * p2currentHp / p2hp), 629, (200 * p2currentHp / p2hp), 5);
                }
                p2stunned = true;
                p2stunTime = p2dex;
                p2stunTmr.Enabled = true;
                p2dealKnockback = false;
                p2invince = true;
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
            int playerposX, playerposY;
            if (p2facingRight == true)
            {
                playerposX = p2hb.X + 30 + p2atkhbOffsetX;
                playerposY = p2hb.Y + p2atkhbOffsetY;
            }
            else
            {
                playerposX = p2hb.X + 30 - p2atkhbOffsetX - p2atkhbX;
                playerposY = p2hb.Y + p2atkhbOffsetY;
            }
            p2atkhb = new Rectangle(playerposX, playerposY, p2atkhbX, p2atkhbY);
        }
        private void p2atkTime_Tick(object sender, EventArgs e) //tracks cooldown time
        {
            if (p2atkCooltime > p2atkLength + p2dex)
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
            if (p1hb.IntersectsWith(p2atkhb) && p1trueInvince == false)
            {
                p1spriteStatus = "TakingDamage";
                p1xv = 0;
                p1xa = 0;
                p1yv = 0;
                p1ya = 0;
                if (p2atk - p1def > 0 && p1invince == false)
                {
                    p1currentHp -= (p2atk - p1def);
                    p1damageTaken += (p2atk - p1def);
                    p2damageDealt += (p2atk - p1def);
                    p1ChpBar = new Rectangle(195, 629, (200 * p1currentHp / p1hp), 5);
                }
                p1stunned = true;
                p1stunTime = p1dex;
                p1stunTmr.Enabled = true;
                p1dealKnockback = false;
                p1invince = true;
            }
        }


        //----------------------------------\\
        //          Player Specials         \\
        //----------------------------------\\

        private void p1spclAtk()
        {
            p1sklCool = true;
            p1spclActive = true;
            p1spclTmr.Enabled = true;
            p1spclCooltime = 0;
            if (p1spclDoesSpecial == true)
            {
                switch (p1Character)
                {
                    case "Cedric":
                        p1trueInvince = true;
                        if (p1facingRight == true)
                        {
                            p1xv = 15;
                            p1xa = 0;
                        }
                        else
                        {
                            p1xv = -15;
                            p1xa = 0;
                        }
                        break;
                }
            }
            if (p1spclDoesDmg == true)
            {
                p1xv = 0;
                p1xa = 0;
                p1ya = 0;
                p1yv = 0;
                int playerposX, playerposY;
                if (p1facingRight == true)
                {
                    playerposX = p1hb.X + 30 + p1spclhbOffsetX;
                    playerposY = p1hb.Y + p1spclhbOffsetY;
                }
                else
                {
                    playerposX = p1hb.X + 30 - p1spclhbOffsetX - p1spclhbX;
                    playerposY = p1hb.Y + p1spclhbOffsetY;
                }
                p1spclhb = new Rectangle(playerposX, playerposY, p1spclhbX, p1spclhbY);
            }
            if (p1spclDoesDrop == true)
            {

            }
            if (p1spclDoesHeal == true)
            {
                p1currentHp += p1spclDmg * p1atk;
                if(p1currentHp > p1hp)
                {
                    p1currentHp = p1hp;
                }
                p1ChpBar = new Rectangle(195, 629, (200 * p1currentHp / p1hp), 5);
            }
        }
        private void p1spclTmr_Tick(object sender, EventArgs e)
        {
            if (p1spclCooltime >= p1spclCool)
            {
                p1spclTmr.Enabled = false;
                p1sklCool = false;
            }
            else
            {
                p1spclCooltime += 1;
            }
            if (p1spclActive == true)
            {
                if (p1spclDoesSpecial == true)
                {
                    switch (p1Character)
                    {
                        case "Cedric":
                            if (p1spclCooltime < 5)
                            {
                                p1spclDoesDmg = false;
                                if (p1spclCooltime == 3)
                                {
                                    if (p1facingRight == true)
                                    {
                                        p1facingRight = false;
                                    }
                                    else
                                    {
                                        p1facingRight = true;
                                    }
                                }
                            }
                            if (p1spclCooltime == 5)
                            {
                                p1spclDoesDmg = true;
                                p1spclAtk();
                                p1spclCooltime = 5;
                            }
                            if (p1spclCooltime == 18)
                            {
                                p1spclDoesDmg = false;
                                p1trueInvince = false;
                            }
                            break;
                    }
                }
                if (p1spclDoesDmg == true)
                {
                    if (p1spclCooltime > p1spclLength)
                    {
                        p1spclhb = Rectangle.Empty;
                    }
                    if (p2hb.IntersectsWith(p1spclhb) && p2trueInvince == false)
                    {
                        p2spriteStatus = "TakingDamage";
                        p2xv = 0;
                        p2xa = 0;
                        p2yv = 0;
                        p2ya = 0;
                        if (p1spclDmg * p1atk - p2def > 0 && p2invince == false)
                        {
                            p2currentHp -= p1spclDmg * p1atk;
                            p2damageTaken += p1spclDmg * p1atk;
                            p1damageDealt += p1spclDmg * p1atk;
                            p2ChpBar = new Rectangle(603 + 200 - (200 * p2currentHp / p2hp), 629, (200 * p2currentHp / p2hp), 5);
                        }
                        p2invince = true;
                        p2stunned = true;
                        p2stunTime = p1spclStun;
                        p2stunTmr.Enabled = true;
                        p2dealKnockback = false;
                    }
                }
                if (p1spclDoesDrop == true)
                {

                }
                if (p1spclCooltime > p1spclLength + 1)
                {
                    p1spclActive = false;
                }
            }
        }

        private void p2spclAtk()
        {
            p2sklCool = true;
            p2spclActive = true;
            p2spclTmr.Enabled = true;
            p2spclCooltime = 0;
            if (p2spclDoesSpecial == true)
            {
                switch (p2Character)
                {
                    case "Cedric":
                        p1trueInvince = true;
                        if (p2facingRight == true)
                        {
                            p2xv = 10;
                            p2xa = 0;
                        }
                        else
                        {
                            p2xv = -10;
                            p2xa = 0;
                        }
                        break;
                }
            }
            if (p2spclDoesDmg == true)
            {
                p2xv = 0;
                p2xa = 0;
                p2ya = 0;
                p2yv = 0;
                int playerposX, playerposY;
                if (p2facingRight == true)
                {
                    playerposX = p2hb.X + 30 + p2spclhbOffsetX;
                    playerposY = p2hb.Y + p2spclhbOffsetY;
                }
                else
                {
                    playerposX = p2hb.X + 30 - p2spclhbOffsetX - p2spclhbX;
                    playerposY = p2hb.Y + p2spclhbOffsetY;
                }
                p2spclhb = new Rectangle(playerposX, playerposY, p2spclhbX, p2spclhbY);
            }
            if (p2spclDoesDrop == true)
            {

            }
            if (p2spclDoesHeal == true)
            {
                p2currentHp += p2spclDmg * p2atk;
                if (p2currentHp > p2hp)
                {
                    p2currentHp = p2hp;
                }
                p2ChpBar = new Rectangle(603 + 200 - (200 * p2currentHp / p2hp), 629, (200 * p2currentHp / p2hp), 5);
            }
        }
        private void p2spclTmr_Tick(object sender, EventArgs e)
        {
            if (p2spclCooltime >= p2spclCool)
            {
                p2spclTmr.Enabled = false;
                p2sklCool = false;
            }
            else
            {
                p2spclCooltime += 1;
            }
            if (p2spclActive == true)
            {
                if (p2spclDoesSpecial == true)
                {
                    switch (p2Character)
                    {
                        case "Cedric":
                            if (p2spclCooltime < 5)
                            {
                                p2spclDoesDmg = false;
                                if (p2spclCooltime == 3)
                                {
                                    if (p2facingRight == true)
                                    {
                                        p2facingRight = false;
                                    }
                                    else
                                    {
                                        p2facingRight = true;
                                    }
                                }
                            }
                            if (p2spclCooltime == 5)
                            {
                                p2spclDoesDmg = true;
                                p2spclAtk();
                                p2spclCooltime = 5;
                                if (p2facingRight == true)
                                {
                                    p2facingRight = false;
                                }
                                else
                                {
                                    p2facingRight = true;
                                }
                            }
                            if (p2spclCooltime == 18)
                            {
                                p2spclDoesDmg = false;
                                p2trueInvince = false;
                            }
                            break;
                    }
                }
                if (p2spclDoesDmg == true)
                {
                    if (p2spclCooltime > p2spclLength)
                    {
                        p2spclhb = Rectangle.Empty;
                    }
                    if (p1hb.IntersectsWith(p2spclhb) && p1trueInvince == false)
                    {
                        p1spriteStatus = "TakingDamage";
                        p1xv = 0;
                        p1xa = 0;
                        p1yv = 0;
                        p1ya = 0;
                        if (p2spclDmg * p2atk - p1def > 0 && p1invince == false)
                        {
                            p1currentHp -= p2spclDmg * p2atk;
                            p1damageTaken += p2spclDmg * p2atk;
                            p2damageDealt += p2spclDmg * p2atk;
                            p1ChpBar = new Rectangle(195, 629, (200 * p1currentHp / p1hp), 5);
                        }
                        p1invince = true;
                        p1stunned = true;
                        p1stunTime = p2spclStun;
                        p1stunTmr.Enabled = true;
                        p1dealKnockback = false;
                    }
                }
                if (p2spclDoesDrop == true)
                {

                }
                if (p2spclCooltime > p2spclLength + 1)
                {
                    p2spclActive = false;
                }
            }
        }

    }
}
