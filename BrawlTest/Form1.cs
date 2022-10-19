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
using System.Text.RegularExpressions;


namespace BrawlTest
{
    public partial class Form1 : Form
    {

        //----------------------------------\\
        //            Variables             \\
        //----------------------------------\\

        Rectangle platform, Arena, fadeSpace;

        Graphics g; // declare the graphics object
        SolidBrush blueBrush = new SolidBrush(Color.LightSkyBlue); //some brushes that are used
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Image arenaImage = Image.FromFile(Application.StartupPath + @"\Assets\Arena.png"); //arena background
        Image[] fadeFrame = new Image[6]; //fade images 
        Image[] fadeoutFrame = new Image[6]; //fade images 

        bool gameStarted, titleCleared, labels, fadeDone, gameOver, labelShown;
        string gameStatus;
        int smallDelay, Frame;


        //----------------------------------\\
        //           P1 Variables           \\
        //----------------------------------\\
        string p1playerName;//the players name
        int p1xv, p1yv, p1xa, p1ya; //velocity variables
        int p1atkCooltime, p1spclCooltime, p1stunTime; //cooldown timers
        bool p1falling, p1jumping, p1atkActive, p1spclActive, p1invince, p1stunned, p1trueInvince; //indicators if these things are active
        bool p1atkCool, p1sklCool; //skill cooldowns
        bool p1facingRight; //which side is the player facing
        string p1Character; //which character the player chose
        int p1currentHp, p1lives; // hp and lives
        Rectangle p1Sprite, p1hb, p1atkhb, p1spclhb; //p1hitboxes
        //p1 imported integers
        int p1hp, p1atk, p1def, p1dex, p1spd; //stats
        int p1atkLength; //attack specifications 
        int p1atkhbX, p1atkhbY, p1atkhbOffsetX, p1atkhbOffsetY; //attack hitbox sizes
        bool p1spclDoesHeal, p1spclDoesDmg, p1spclDoesDrop, p1spclDoesSpecial; //Special skill conditions
        int p1spclLength, p1spclCool, p1spclhbX, p1spclhbY, p1spclhbOffsetX, p1spclhbOffsetY; //Special skill specifications
        int p1spclDmg, p1spclStun; //special damage and stun values
        string p1fullName, p1desc; //values displayed in charsel
        bool p1dealKnockback = false;
        //p1 sprite works
        string p1spriteStatus; //sprite status
        int p1frame; //universal sprite frame int
        //all the sprites
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
        bool p1charChosen, p1nameEntered;
        //p1 Result Stats
        int p1damageDealt, p1hpleft;


        //----------------------------------\\
        //           P2 Variables           \\
        //----------------------------------\\
        string p2playerName;//the players name
        int p2xv, p2yv, p2xa, p2ya; //velocity variables
        int p2atkCooltime, p2spclCooltime, p2stunTime; //cooldown timers
        bool p2falling, p2jumping, p2atkActive, p2spclActive, p2invince, p2stunned, p2trueInvince; //indicators if these things are active
        bool p2atkCool, p2sklCool; //skill cooldowns
        bool p2facingRight; //which side is the player facing
        string p2Character; //which character the player chose
        int p2currentHp, p2lives; // hp and lives
        Rectangle p2Sprite, p2hb, p2atkhb, p2spclhb; //p2hitboxes
        //p2 imported integers
        int p2hp, p2atk, p2def, p2dex, p2spd; //stats
        int p2atkLength; //attack specifications 
        int p2atkhbX, p2atkhbY, p2atkhbOffsetX, p2atkhbOffsetY; //attack hitbox sizes
        bool p2spclDoesHeal, p2spclDoesDmg, p2spclDoesDrop, p2spclDoesSpecial; //Special skill conditions
        int p2spclLength, p2spclCool, p2spclhbX, p2spclhbY, p2spclhbOffsetX, p2spclhbOffsetY; //Special skill specifications
        int p2spclDmg, p2spclStun; //special damage and stun values
        string p2fullName, p2desc; //values displayed in charsel
        bool p2dealKnockback = false;
        //p2 sprite works
        string p2spriteStatus; //sprite status
        int p2frame; //universal sprite frame int
        //all the sprites
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
        bool p2charChosen, p2nameEntered;
        //p2 Result Stats
        int p2damageDealt, p2hpleft;


        //classes
        Title title = new Title();
        CharSel charsel = new CharSel();
        Rules rules = new Rules();
        Results results = new Results();

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, mainPanel, new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameStarted = false;
            gameStatus = "title"; //starts on title screen
            smallDelay = 1;
            for (int i = 1; i <= 5; i++) //prepares fade images
            {
                fadeFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeSc_(" + i.ToString() + ").png");
                fadeoutFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeBlc_(" + i.ToString() + ").png");
            }
        }

        //----------------------------------\\
        //           Game Startup           \\
        //----------------------------------\\
        private void gameStart()//starts game 
        {
            gameStarted = true;
            p1lives = 3;
            p2lives = 3;
            p1setChar();
            p2setChar();
            //reads char files
            p1loadChar(); 
            p2loadChar(); 
            //prepares all sprite works
            p1prepareSprite();
            p2prepareSprite();
            veloTmr.Enabled = true;
            mainPanel.Invalidate();
        }
        private void p1setChar()//sets all the variables for p1 character, also responsible for reseting stats after respawn 
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
        private void p2setChar()//sets all the variables for p2 character, also responsible for reseting stats after respawn 
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

        //prepares sprites, but for charsel
        private void p1prepareSpritecharsel()
        {
            if (p1Character != "nocharacter")//if character isn't empty
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
            if (p2Character != "nocharacter")//if character isn't empty
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

        //reads character files and load in stats
        private void p1loadChar()
        {
            if (p1Character != "nocharacter")//if character isn't empty
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\characters\" + p1Character.ToString() + ".txt"); //selects the txt file matching the character
                int linenumber = 1;
                for (int i = 1; i <= 25; i++)
                {
                    try
                    {
                        string line = File.ReadLines(Application.StartupPath + @"\characters\" + p1Character.ToString() + ".txt").ElementAt(linenumber);
                        switch (linenumber)
                        {
                            case 1://displayed name
                                p1fullName = line;
                                break;
                            case 2://special description
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
                            case 8://attack time
                                p1atkLength = int.Parse(line);
                                break;
                            case 9://attack hitbox size(x)
                                p1atkhbX = int.Parse(line);
                                break;
                            case 10://attack hitbox size(y)
                                p1atkhbY = int.Parse(line);
                                break;
                            case 11://attack offset from hitbox(x)
                                p1atkhbOffsetX = int.Parse(line);
                                break;
                            case 12://attack offset from hitbox(y)
                                p1atkhbOffsetY = int.Parse(line);
                                break;
                            case 13://does special heal self?
                                if (line.Contains("y")) { p1spclDoesHeal = true; }
                                else { p1spclDoesHeal = false; }
                                break;
                            case 14://does special deal damage?
                                if (line.Contains("y")) { p1spclDoesDmg = true; }
                                else { p1spclDoesDmg = false; }
                                break;
                            case 15://does special drop stats?
                                if (line.Contains("y")) { p1spclDoesDrop = true; }
                                else { p1spclDoesDrop = false; }
                                break;
                            case 16://does special do anything else?
                                if (line.Contains("y")) { p1spclDoesSpecial = true; }
                                else { p1spclDoesSpecial = false; }
                                break;
                            case 17://special time
                                p1spclLength = int.Parse(line);
                                break;
                            case 18://special cooldown time
                                p1spclCool = int.Parse(line);
                                break;
                            case 19://special hitbox size(x)
                                p1spclhbX = int.Parse(line);
                                break;
                            case 20://special hitbox size(y)
                                p1spclhbY = int.Parse(line);
                                break;
                            case 21://special offset from hitbox(x)
                                p1spclhbOffsetX = int.Parse(line);
                                break;
                            case 22://special offset from hitbox(y)
                                p1spclhbOffsetY = int.Parse(line);
                                break;
                            case 23://special damage multiplier
                                p1spclDmg = int.Parse(line);
                                break;
                            case 24://special stun time
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
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\characters\" + p2Character.ToString() + ".txt");//selects the txt file matching the character
                int linenumber = 1;
                for (int i = 1; i <= 25; i++)
                {
                    try
                    {
                        string line = File.ReadLines(Application.StartupPath + @"\characters\" + p2Character.ToString() + ".txt").ElementAt(linenumber);
                        switch (linenumber)
                        {
                            case 1://displayed name
                                p2fullName = line;
                                break;
                            case 2://special description
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
                            case 8://attack time
                                p2atkLength = int.Parse(line);
                                break;
                            case 9://attack hitbox size(x)
                                p2atkhbX = int.Parse(line);
                                break;
                            case 10://attack hitbox size(y)
                                p2atkhbY = int.Parse(line);
                                break;
                            case 11://attack offset from hitbox(x)
                                p2atkhbOffsetX = int.Parse(line);
                                break;
                            case 12://attack offset from hitbox(y)
                                p2atkhbOffsetY = int.Parse(line);
                                break;
                            case 13://does special heal self?
                                if (line.Contains("y")) { p2spclDoesHeal = true; }
                                else { p2spclDoesHeal = false; }
                                break;
                            case 14://does special deal damage?
                                if (line.Contains("y")) { p2spclDoesDmg = true; }
                                else { p2spclDoesDmg = false; }
                                break;
                            case 15://does special drop stats?
                                if (line.Contains("y")) { p2spclDoesDrop = true; }
                                else { p2spclDoesDrop = false; }
                                break;
                            case 16://does special do anything else?
                                if (line.Contains("y")) { p2spclDoesSpecial = true; }
                                else { p2spclDoesSpecial = false; }
                                break;
                            case 17://special time
                                p2spclLength = int.Parse(line);
                                break;
                            case 18://special cooldown time
                                p2spclCool = int.Parse(line);
                                break;
                            case 19://special hitbox size(x)
                                p2spclhbX = int.Parse(line);
                                break;
                            case 20://special hitbox size(y)
                                p2spclhbY = int.Parse(line);
                                break;
                            case 21://special offset from hitbox(x)
                                p2spclhbOffsetX = int.Parse(line);
                                break;
                            case 22://special offset from hitbox(y)
                                p2spclhbOffsetY = int.Parse(line);
                                break;
                            case 23://special damage multiplier
                                p2spclDmg = int.Parse(line);
                                break;
                            case 24://special stun time
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

        //prepare sprites for chosen characters
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
                p1EngardeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                p1Run[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Run_(" + i.ToString() + ").png");
                p1RunL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Run_(" + i.ToString() + ").png");
                p1RunL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                p1Jump[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Jump_(" + i.ToString() + ").png");
                p1JumpL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Jump_(" + i.ToString() + ").png");
                p1JumpL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= p1atkLength; i++)
            {
                p1Regular[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Regular_(" + i.ToString() + ").png");
                p1RegularL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Regular_(" + i.ToString() + ").png");
                p1RegularL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
                p1RegularAtk[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p1RegularAtkL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p1RegularAtkL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= p1spclLength; i++)
            {
                p1Special[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Special_(" + i.ToString() + ").png");
                p1SpecialL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Special_(" + i.ToString() + ").png");
                p1SpecialL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 3; i++)
            {
                p1Concede[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Concede_(" + i.ToString() + ").png");
                p1ConcedeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p1Character + "_Concede_(" + i.ToString() + ").png");
                p1ConcedeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
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
                p2EngardeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                p2Run[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Run_(" + i.ToString() + ").png");
                p2RunL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Run_(" + i.ToString() + ").png");
                p2RunL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                p2Jump[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Jump_(" + i.ToString() + ").png");
                p2JumpL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Jump_(" + i.ToString() + ").png");
                p2JumpL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= p2atkLength; i++)
            {
                p2Regular[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Regular_(" + i.ToString() + ").png");
                p2RegularL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Regular_(" + i.ToString() + ").png");
                p2RegularL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
                p2RegularAtk[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p2RegularAtkL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_AtkWeapon_(" + i.ToString() + ").png");
                p2RegularAtkL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= p2spclLength; i++)
            {
                p2Special[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Special_(" + i.ToString() + ").png");
                p2SpecialL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Special_(" + i.ToString() + ").png");
                p2SpecialL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 3; i++)
            {
                p2Concede[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Concede_(" + i.ToString() + ").png");
                p2ConcedeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + p2Character + "_Concede_(" + i.ToString() + ").png");
                p2ConcedeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
        }

        private void drawBars(Graphics g)//visualise stat bars in charsel 
        {
            //p1
            g.FillRectangle(whiteBrush, p1hpbar);
            g.FillRectangle(whiteBrush, p1atkbar);
            g.FillRectangle(whiteBrush, p1defbar);
            g.FillRectangle(whiteBrush, p1dexbar);
            g.FillRectangle(whiteBrush, p1spdbar);
            //p2
            g.FillRectangle(whiteBrush, p2hpbar);
            g.FillRectangle(whiteBrush, p2atkbar);
            g.FillRectangle(whiteBrush, p2defbar);
            g.FillRectangle(whiteBrush, p2dexbar);
            g.FillRectangle(whiteBrush, p2spdbar);
        } 
        private void drawBarsGame(Graphics g)//visualise stat bars in game 
        {
            g.FillRectangle(whiteBrush, p1ChpBar);
            g.FillRectangle(whiteBrush, p2ChpBar);
            g.FillRectangle(whiteBrush, p1livesBar);
            g.FillRectangle(whiteBrush, p2livesBar);
            if(p1spclCooltime >= p1spclCool)
            {
                g.FillRectangle(blueBrush, p1spclBar);//if special is fully charged, the bar changes to light blue
            }
            else
            {
                g.FillRectangle(whiteBrush, p1spclBar);
            }
            if (p2spclCooltime >= p2spclCool)
            {
                g.FillRectangle(blueBrush, p2spclBar);//if special is fully charged, the bar changes to light blue
            }
            else
            {
                g.FillRectangle(whiteBrush, p2spclBar);
            }
        } 


        //----------------------------------\\
        //             Controls             \\
        //----------------------------------\\

        private void Form1_KeyDown(object sender, KeyEventArgs e)//all player controls 
        {
            if (gameStarted == false)//controls for navigating menus 
            {
                if (titleCleared == false)//pressing any keys on title would trigger this and transition to charsel
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
                    if (gameStatus == "CharSel" && charsel.transitionDone() == true) //charsel controls
                    {
                        if(p1charChosen == false) //if p1 character isn't chosen yet
                        {
                            if (e.KeyData == Keys.D) { charsel.moveSelRight1(); }
                            if (e.KeyData == Keys.A) { charsel.moveSelLeft1(); }
                            if (e.KeyData == Keys.W) { charsel.moveSelUp1(); }
                            if (e.KeyData == Keys.S) { charsel.moveSelDown1(); }
                            p1Character = charsel.p1char();
                            p1loadChar();
                            p1prepareSpritecharsel();
                            if(e.KeyData == Keys.G) //key to lock in character
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
                        if(p2charChosen == false) //if p2 character isn't chosen yet
                        {
                            if (e.KeyData == Keys.Right) { charsel.moveSelRight2(); }
                            if (e.KeyData == Keys.Left) { charsel.moveSelLeft2(); }
                            if (e.KeyData == Keys.Up) { charsel.moveSelUp2(); }
                            if (e.KeyData == Keys.Down) { charsel.moveSelDown2(); }
                            p2Character = charsel.p2char();
                            p2loadChar();
                            p2prepareSpritecharsel();
                            if (e.KeyData == Keys.M) //key to lock in character
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
                        if (e.KeyData == Keys.R) //to rules page
                        { 
                            charsel.toRules(); 
                            p1Name.Visible = false;
                            p1spclDesc.Visible = false;
                            p2Name.Visible = false;
                            p2spclDesc.Visible = false;
                            p1nameBox.Visible = false;
                            p2nameBox.Visible = false;
                        }
                    }
                    else if ( rules.transitionDone() == true ) //this is to swap back form rules to charsel. because of some complications characters that are locked in will be reset
                    {
                        rules.toCharsel();
                        p1charChosen = false;
                        p2charChosen = false;
                    }
                }
            }
            else if(fadeDone == true && gameOver == false)//controls for playing the game
            {
                //p1
                if (p1atkActive == false && p1stunned == false && p1spclActive == false && p1spriteStatus != "Concede")//checks every condition that won't allow the player to move
                {
                    if (p1xv < 10 && p1xv > -10)//velocity cap so the player can't infinitely accelerate
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
                    if (e.KeyData == Keys.H && p1sklCool == false && p1jumping == false) { p1spclAtk(); p1spriteStatus = "Special"; p1frame = 1; } //actives special skill

                    if (e.KeyData == Keys.F) { p1spriteStatus = "Taunt"; p1frame = 1; }
                }

                //p2
                if (p2atkActive == false && p2stunned == false && p2spclActive == false && p2spriteStatus != "Concede")//checks every condition that won't allow the player to move
                {
                    if (p2xv < 10 && p2xv > -10)//velocity cap so the player can't infinitely accelerate
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
                    if (e.KeyData == Keys.N && p2sklCool == false && p2jumping == false) { p2spclAtk(); p2spriteStatus = "Special"; p2frame = 1; } //actives special skill

                    if (e.KeyData == Keys.B) { p2spriteStatus = "Taunt"; p2frame = 1; }
                }
            }
        } 
        private void Form1_KeyUp(object sender, KeyEventArgs e)//stops some things when key is released 
        {
            if (gameStarted == true && fadeDone == true && gameOver == false)
            {
                //p1
                if (p1atkActive == false && p1stunned == false && p1spclActive == false && p1spriteStatus != "Concede") //checks everything that locks controls
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
                if (p2atkActive == false && p2stunned == false && p2spclActive == false && p2spriteStatus != "Concede") //checks everything that locks controls
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
        //          Entering Name           \\
        //----------------------------------\\

        private void p1nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                p1playerName = p1nameBox.Text;
                if (Regex.IsMatch(p1playerName, @"^[a-zA-Z]+$"))//checks playerName for letters
                {
                    p1nameBox.ReadOnly = true;
                    ActiveControl = null;
                    p1nameBox.ForeColor = Color.DimGray;
                    p1nameEntered = true;
                }
                else
                {
                    p1nameBox.Text = "letters only!";
                    p1nameBox.Focus();

                }
            }
        }
        private void p1nameBox_Click(object sender, EventArgs e)
        {
            if(p1nameBox.Text == "Enter name (letters only)")//clears the box when you click on it
            {
                p1nameBox.Clear();
            }
        }

        private void p2nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                p2playerName = p2nameBox.Text;
                if (Regex.IsMatch(p2playerName, @"^[a-zA-Z]+$"))//checks playerName for letters
                {
                    p2nameBox.ReadOnly = true;
                    ActiveControl = null;
                    p2nameEntered = true;
                    p2nameBox.ForeColor = Color.DimGray;
                }
                else
                {
                    p2nameBox.Text = "letters only!";
                    p2nameBox.Focus();

                }
            }
        }
        private void p2nameBox_Click(object sender, EventArgs e)
        {
            if (p2nameBox.Text == "Enter name (letters only)")//clears the box when you click on it
            {
                p2nameBox.Clear();
            }
        }

        //----------------------------------\\
        //             Movement             \\
        //----------------------------------\\

        private void veloTmr_Tick(object sender, EventArgs e)//universal timer for player movement 
        {
            mainPanel.Invalidate();

            //----------------------------------\\
            //               P1                 \\
            //----------------------------------\\
            p1hb.Y += p1yv;//y velocity conversion 
            p1hb.X += p1xv;//x velocity conversion
            p1Sprite.Y = p1hb.Y - 50;//the sprite hitbox follows hitbox
            p1Sprite.X = p1hb.X - 70;
            if(p1hb.X <= 0)//doesn't allow players to move out of form
            {
                p1hb.X = 1;
                p1xa = 0;
                p1xv = 0;
            }
            if (p1hb.X >= 940)//doesn't allow players to move out of form 
            {
                p1hb.X = 939;
                p1xa = 0;
                p1xv = 0;
            }

            if (p1hb.IntersectsWith(platform))//if player is touching the ground
            {
                if (p1falling == true && p1hb.Y < 600)//if player hits the ground(therefore previously falling)
                {
                    int place = (int)p1hb.Y;
                    p1ya = 0;
                    p1hb.Y -= place - 441;//sets player on top of the ground
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
            else //if the player isn't on the ground, gravity acceleration occurs
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
            if (p1xv > 0)//x-velocity decay(right)
            { 
                p1xv -= 1;
            }
            if (p1xv < 0)//x-velocity decay(left)
            {
                p1xv += 1;
            }
            p1spclBar = new Rectangle(103, 719, (292 * p1spclCooltime / p1spclCool), 5);//refreshes special bar 
            if(p1currentHp <= 0)//start concede sequence
            {
                if (p1hb.IntersectsWith(platform) && p1spriteStatus != "TakingDamage")
                {
                    p1trueInvince = true;
                    if(p1spriteStatus != "Concede")//if this is the first time triggering this code, set frame to 1
                    {
                        p1frame = 1;
                    }
                    p1spriteStatus = "Concede";
                    if(p1lives == 1)
                    {
                        p2spriteStatus = "Engarde";
                        p1lives -= 1;
                        stopGame();
                    }
                }
                p1xv = 0;
                p1xa = 0;
            }


            //----------------------------------\\
            //               P2                 \\
            //----------------------------------\\
            p2hb.Y += p2yv;//y velocity conversion 
            p2hb.X += p2xv;//x velocity conversion
            p2Sprite.Y = p2hb.Y - 50;//the sprite hitbox follows hitbox
            p2Sprite.X = p2hb.X - 70;
            if (p2hb.X <= 0)//doesn't allow players to move out of form
            {
                p2hb.X = 1;
                p2xa = 0;
                p2xv = 0;
            }
            if (p2hb.X >= 940)//doesn't allow players to move out of form 
            {
                p2hb.X = 939;
                p2xa = 0;
                p2xv = 0;
            }

            if (p2hb.IntersectsWith(platform))//if player is touching the ground
            {
                if (p2falling == true && p2hb.Y < 600)//if player hits the ground(therefore previously falling)
                {
                    int place = (int)p2hb.Y;
                    p2ya = 0;
                    p2hb.Y -= place - 441;//sets player on top of the ground
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
            else //if the player isn't on the ground, gravity acceleration occurs
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
            if (p2xv > 0)//x-velocity decay(right)
            {
                p2xv -= 1;
            }
            if (p2xv < 0)//x-velocity decay(left)
            {
                p2xv += 1;
            }
            p2spclBar = new Rectangle(895 - (292 * p2spclCooltime / p2spclCool), 719, (292 * p2spclCooltime / p2spclCool), 5);
            if (p2currentHp <= 0)//start concede sequence
            {
                if (p2hb.IntersectsWith(platform) && p2spriteStatus != "TakingDamage")
                {
                    p2trueInvince = true;
                    if (p2spriteStatus != "Concede")//if this is the first time triggering this code, set frame to 1
                    {
                        p2frame = 1;
                    }
                    p2spriteStatus = "Concede";
                    if (p2lives == 1)
                    {
                        p1spriteStatus = "Engarde";
                        p2lives -= 1;
                        stopGame();
                    }
                }
                p2xv = 0;
                p2xa = 0;
            }
        }
        private void p1stunTmr_Tick(object sender, EventArgs e)//controls stun time for p1 
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
        private void p2stunTmr_Tick(object sender, EventArgs e)//controls stun time for p2 
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

        private void mainPanel_Paint(object sender, PaintEventArgs e)//paints everything 
        {
            g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            switch (gameStatus)
            {
                case "title":
                    title.drawTitle(g);//draws everything in title
                    break;
                case "CharSel":
                    charsel.drawCharSel(g);//draws background in charsel
                    drawBars(g);//draws stat bars
                    if (p1spriteStatus == "Idle")//draws p1 chosen character
                    {
                        g.DrawImage(p1Idle[p1frame], p1Sprite);
                    }
                    else
                    {
                        g.DrawImage(p1Taunt[p1frame], p1Sprite);
                    }
                    if (p2spriteStatus == "Idle")//draws p2 chosen character
                    {
                        g.DrawImage(p2Idle[p2frame], p2Sprite);
                    }
                    else
                    {
                        g.DrawImage(p2Taunt[p2frame], p2Sprite);
                    }
                    if (charsel.transitionDone() != true)//draws fade in transiton
                    {
                        charsel.drawFade(g);
                    }
                    charsel.drawFadeout(g);//draws fade out transition
                    break;
                case "Rules":
                    rules.drawRules(g);//draws rules screen 
                    if (rules.transitionDone() != true)//draws fade in transition
                    {
                        rules.drawFade(g);
                    }
                    else if (rules.rulesDone() != true)//draws fade out transition
                    {
                        rules.drawFadeout(g);
                    }
                    break;
                case "Game":
                    g.DrawImage(arenaImage, Arena);//draws background
                    drawBarsGame(g);//draws stat bars
                    if (fadeDone == false)//draws fade in 
                    {
                        g.DrawImage(fadeFrame[Frame], fadeSpace);
                    }
                    else
                    {
                        switch (p1spriteStatus)//draws p1 sprite
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
                                if (gameOver == false)
                                {
                                    if (p1frame > 13)
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
                                }
                                else if (p2frame > 3)
                                {
                                    g.DrawImage(p1Concede[3], p1Sprite);
                                }
                                break;
                        }
                        switch (p2spriteStatus)//draws p2 sprite
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
                                if (gameOver == false)
                                {
                                    if (p2frame > 13)
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
                                }
                                else if (p2frame > 3)
                                {
                                    g.DrawImage(p2Concede[3], p2Sprite);
                                }
                                break;
                        }
                        if (gameOver == true)
                        {
                            g.DrawImage(fadeoutFrame[(Frame-10)], fadeSpace);
                        }
                    }
                    break;
                case "Results":
                    results.drawResults(g);//draws results screen 
                    if (p1spriteStatus == "Idle")//draws p1 chosen character
                    {
                        g.DrawImage(p1Idle[p1frame], p1Sprite);
                    }
                    else
                    {
                        g.DrawImage(p1Concede[3], p1Sprite);
                    }
                    if (p2spriteStatus == "Idle")//draws p2 chosen character
                    {
                        g.DrawImage(p2Idle[p2frame], p2Sprite);
                    }
                    else
                    {
                        g.DrawImage(p2Concede[3], p2Sprite);
                    }
                    if (results.transitionDone() != true)//draws fade in transition
                    {
                        results.drawFade(g);
                    }
                    else if (results.resultsDone() != true)//draws fade out transition
                    {
                        results.drawFadeout(g);
                    }
                    break;
            }
        }
        private void aniTmr_Tick(object sender, EventArgs e)//animation timer and universal timer for menus
        {
            mainPanel.Invalidate();//draws every tick(8fps)
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
                            p1nameBox.Visible = true;
                            p2nameBox.Visible = true;
                        }
                    }
                    if(p1charChosen == true && p2charChosen == true && p1nameEntered == true && p2nameEntered == true)
                    {
                        smallDelay += 1;//theres a small delay after characters are chosen before the scene switches so the sprite changes can finish 
                        if(smallDelay >= 10)
                        {
                            charsel.toGame();
                            p1Name.Visible = false;
                            p1spclDesc.Visible = false;
                            p2Name.Visible = false;
                            p2spclDesc.Visible = false;
                            p1nameBox.Visible = false;
                            p2nameBox.Visible = false;
                            if (charsel.charselDone() != true)//starts fade out sequence
                            {
                                charsel.fadeoutCharSel();
                            }
                            else//empties and makes everything after fade out sequence
                            {
                                p1Sprite = Rectangle.Empty;
                                p2Sprite = Rectangle.Empty;
                                platform = new Rectangle(0, 540, 1000, 50);
                                Arena = new Rectangle(0, 0, 1000, 750);
                                fadeSpace = new Rectangle(0, 0, 1000, 750);
                                gameStatus = charsel.statuscharsel();
                                charsel.charselEmpty();
                                Frame = 1;
                                smallDelay = 1;
                                fadeDone = false;
                            }

                        }
                    }
                    else
                    {
                        if (charsel.charselDone() != true)//starts fade to rules sequence
                        {
                            charsel.fadeoutCharSel();
                        }
                        else//empties everything in charsel
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
                    else//back to charsel
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
                    if (Frame < 10)//small pause before players spawn in 
                    {
                        Frame += 1;
                        if (Frame == 5)
                        {
                            fadeDone = true;
                            fadeSpace = Rectangle.Empty;
                        }
                    }
                    else if (Frame == 10)//starts the game here
                    {
                        gameStart();
                        Frame = 11;
                    }
                    if (gameOver == true)
                    {
                        smallDelay += 1;
                        if (smallDelay >= 15)
                        {
                            fadeSpace = new Rectangle(0, 0, 1000, 750);
                            Frame += 1;
                            if (smallDelay == 19)//switches to result screen
                            {
                                gameStatus = "Results";
                                p1Sprite = new Rectangle(-66, 392, 400, 300);
                                p2Sprite = new Rectangle(666, 392, 400, 300);
                                p1frame = 1;
                                p2frame = 1;
                                if(p1lives > 0)
                                {
                                    p1spriteStatus = "Idle";
                                }
                                else
                                {
                                    p1spriteStatus = "Concede";
                                }
                                if (p2lives > 0)
                                {
                                    p2spriteStatus = "Idle";
                                }
                                else
                                {
                                    p2spriteStatus = "Concede";
                                }
                            }
                        }
                    }
                    break;
                case "Results":
                    results.aniResults();
                    if (results.transitionDone() != true)
                    {
                        results.transitionResults();
                    }
                    else if(labelShown == false)
                    {
                        labelShown = true;
                        p1nameLabel.Visible = true;
                        p1nameLabel.Text = p1playerName;
                        p2nameLabel.Visible = true;
                        p2nameLabel.Text = p2playerName;
                        p1charLbl.Visible = true;
                        p1charLbl.Text = p1Character;
                        p2charLbl.Visible = true;
                        p2charLbl.Text = p2Character;
                        p1battleResult.Visible = true;
                        if(p1lives == 0)
                        {
                            p1battleResult.Text = "Lost";
                        }
                        else
                        {
                            p1battleResult.Text = "Won";
                        }
                        p2battleResult.Visible = true;
                        if (p2lives == 0)
                        {
                            p2battleResult.Text = "Lost";
                        }
                        else
                        {
                            p2battleResult.Text = "Won";
                        }
                        p1dmgLabel.Visible = true;
                        p1dmgLabel.Text = p1damageDealt.ToString();
                        p2dmgLabel.Visible = true;
                        p2dmgLabel.Text = p2damageDealt.ToString();
                        if(p1currentHp < 0)
                        {
                            p1currentHp = 0;
                        }
                        if (p2currentHp < 0)
                        {
                            p2currentHp = 0;
                        }
                        if(p1lives < 3)
                        {
                            p1hpleft = (((p1lives) * p1hp + p1currentHp) * 100) / (p1hp * 3);
                        }
                        else
                        {
                            p1hpleft = 100;
                        }
                        if (p2lives < 3)
                        {
                            p2hpleft = (((p2lives) * p2hp + p2currentHp) * 100) / (p2hp * 3);
                        }
                        else
                        {
                            p2hpleft = 100;
                        }
                        p1hpLabel.Visible = true;
                        p1hpLabel.Text = p1hpleft.ToString() + "%";
                        p2hpLabel.Visible = true;
                        p2hpLabel.Text = p2hpleft.ToString() + "%";
                        centLbl1.Visible = true;
                        centLbl2.Visible = true;
                        centLbl3.Visible = true;
                        centLbl4.Visible = true;
                    }
                    if (results.resultsDone() != true)
                    {
                        results.fadeoutResults();
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
                    if(p1frame == 15 && gameOver == false)
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
                    if (p2frame == 15 && gameOver == false)
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

        private void p1Atk() //creates hitbox for p1 attack, fires once 
        {
            p1atkCool = true;
            p1atkActive = true;
            p1atkTime.Enabled = true;
            p1atkCooltime = 0;
            //sets momentum to 0
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
            p1atkhb = new Rectangle(playerposX, playerposY, p1atkhbX, p1atkhbY);//sets hitbox position based on inputted values
        }
        private void p1atkTime_Tick(object sender, EventArgs e) //tracks p1 attack cooldown time and check for collison 
        {
            if (p1atkCooltime > p1atkLength + p1dex)//cooldown time is equal to player dex value
            {
                p1atkTime.Enabled = false;
                p1atkCool = false;
            }
            else
            {
                p1atkCooltime += 1;
            }
            if (p1atkCooltime > p1atkLength)//empties attack hitbox
            {
                p1atkhb = Rectangle.Empty;
                p1atkActive = false;
            }
            if (p2hb.IntersectsWith(p1atkhb) && p2trueInvince == false)//if hit player 2
            {
                p2spriteStatus = "TakingDamage";
                p2xv = 0;
                p2xa = 0;
                p2yv = 0;
                p2ya = 0;
                if (p1atk - p2def > 0 && p2invince == false)//triggers only once 
                {
                    p2currentHp -= (p1atk - p2def);
                    p1damageDealt += (p1atk - p2def);
                    p2ChpBar = new Rectangle(603 + 200 - (200 * p2currentHp / p2hp), 629, (200 * p2currentHp / p2hp), 5);
                }
                p2stunned = true;
                p2stunTime = p2dex;
                p2stunTmr.Enabled = true;//starts stun sequence
                p2dealKnockback = false;
                p2invince = true;
            }
        }

        private void p2Atk() //creates hitbox for p2 attack, fires once 
        {
            p2atkCool = true;
            p2atkActive = true;
            p2atkTime.Enabled = true;
            p2atkCooltime = 0;
            //sets momentum to 0
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
            p2atkhb = new Rectangle(playerposX, playerposY, p2atkhbX, p2atkhbY);//sets hitbox position based on inputted values
        }
        private void p2atkTime_Tick(object sender, EventArgs e) //tracks p2 attack cooldown time and check for collison 
        {
            if (p2atkCooltime > p2atkLength + p2dex)//cooldown time is equal to player dex value
            {
                p2atkTime.Enabled = false;
                p2atkCool = false;
            }
            else
            {
                p2atkCooltime += 1;
            }
            if (p2atkCooltime > p2atkLength)//empties attack hitbox
            {
                p2atkhb = Rectangle.Empty;
                p2atkActive = false;
            }
            if (p1hb.IntersectsWith(p2atkhb) && p1trueInvince == false)//if hit player 2
            {
                p1spriteStatus = "TakingDamage";
                p1xv = 0;
                p1xa = 0;
                p1yv = 0;
                p1ya = 0;
                if (p2atk - p1def > 0 && p1invince == false)//triggers only once 
                {
                    p1currentHp -= (p2atk - p1def);
                    p2damageDealt += (p2atk - p1def);
                    p1ChpBar = new Rectangle(195, 629, (200 * p1currentHp / p1hp), 5);
                }
                p1stunned = true;
                p1stunTime = p1dex;
                p1stunTmr.Enabled = true;//starts stun sequence
                p1dealKnockback = false;
                p1invince = true;
            }
        }


        //----------------------------------\\
        //          Player Specials         \\
        //----------------------------------\\

        private void p1spclAtk() //set values for p1 special, fires once normally 
        {
            p1sklCool = true;
            p1spclActive = true;
            p1spclTmr.Enabled = true;
            p1spclCooltime = 0;
            if (p1spclDoesSpecial == true)//if special does anything special
            {
                switch (p1Character)
                {
                    case "Cedric":
                        p1trueInvince = true;//gives true invincibility
                        if (p1facingRight == true)//launches the player based on what direction they are facing
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
            if (p1spclDoesDmg == true)//if special does damage; spawns attack hitboxes
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
            if (p1spclDoesHeal == true)//if special heals
            {
                p1currentHp += p1spclDmg * p1atk;//heal calc
                if(p1currentHp > p1hp)
                {
                    p1currentHp = p1hp;
                }
                p1ChpBar = new Rectangle(195, 629, (200 * p1currentHp / p1hp), 5);//refreshes hp bar
            }
        }
        private void p1spclTmr_Tick(object sender, EventArgs e) //tracks p1 special cooldown time and components that reqiure time .
        {
            if (p1spclCooltime >= p1spclCool)//if cooldown is over
            {
                p1spclTmr.Enabled = false;
                p1sklCool = false;
            }
            else
            {
                p1spclCooltime += 1;
            }
            if (p1spclActive == true)//if special is active
            {
                if (p1spclDoesSpecial == true)//if special does anything special
                {
                    switch (p1Character)
                    {
                        case "Cedric":
                            if (p1spclCooltime < 5)
                            {
                                p1spclDoesDmg = false;
                                if (p1spclCooltime == 3)//changes the way the player is facing to deliver the attack
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
                                p1spclAtk();//fires the one-time code again to spawn attack hitboxes
                                p1spclCooltime = 5;//overrides spclAtk value changes to spclcooltime
                            }
                            if (p1spclCooltime == 18)//changes bool changes to default
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
                    if (p2hb.IntersectsWith(p1spclhb) && p2trueInvince == false)//checks for hits
                    {
                        p2spriteStatus = "TakingDamage";
                        p2xv = 0;
                        p2xa = 0;
                        p2yv = 0;
                        p2ya = 0;
                        if (p1spclDmg * p1atk - p2def > 0 && p2invince == false)//fires only once
                        {
                            p2currentHp -= p1spclDmg * p1atk;
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

        private void p2spclAtk() //set values for p2 special, fires once normally 
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
        private void p2spclTmr_Tick(object sender, EventArgs e) //tracks p2 special cooldown time and components that reqiure time 
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


        //----------------------------------\\
        //            Stop Game             \\
        //----------------------------------\\

        private void stopGame()
        {
            veloTmr.Enabled = false;
            gameOver = true;
        }

    }
}
