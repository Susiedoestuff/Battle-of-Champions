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
        string binPath = Application.StartupPath + @"\Highscore.txt";
        List<HighScores> highScores = new List<HighScores>();


        bool gameStarted, titleCleared, labels, fadeDone, gameOver, labelShown, lbDisplayed;
        string gameStatus;
        int smallDelay, Frame;


        //----------------------------------\\
        //           P1 Variables           \\
        //----------------------------------\\
        string P1playerName;//the players name
        int P1xv, P1yv, P1xa, P1ya; //velocity variables
        int P1atkCooltime, P1spclCooltime, P1stunTime; //cooldown timers
        bool P1falling, P1jumping, P1atkActive, P1spclActive, P1invince, P1stunned, P1trueInvince; //indicators if these things are active
        bool P1atkCool, P1sklCool; //skill cooldowns
        bool P1facingRight; //which side is the player facing
        string P1Character; //which character the player chose
        int P1currentHp, P1lives; // hp and lives
        Rectangle P1Sprite, P1hb, P1atkhb, P1spclhb; //P1hitboxes
        //P1 imported integers
        int P1hp, P1atk, P1def, P1dex, P1spd; //stats
        int P1atkLength; //attack specifications 
        int P1atkhbX, P1atkhbY, P1atkhbOffsetX, P1atkhbOffsetY; //attack hitbox sizes
        bool P1spclDoesHeal, P1spclDoesDmg, P1spclDoesDrop, P1spclDoesSpecial; //Special skill conditions
        int P1spclLength, P1spclCool, P1spclhbX, P1spclhbY, P1spclhbOffsetX, P1spclhbOffsetY; //Special skill specifications
        int P1spclDmg, P1spclStun; //special damage and stun values
        string P1fullName, P1desc; //values displayed in charsel
        bool P1dealKnockback = false;
        //P1 sprite works
        string P1spriteStatus; //sprite status
        int P1frame; //universal sprite frame int
        //all the sprites
        Image[] P1Idle = new Image[9];
        Image[] P1Taunt = new Image[10];
        Image[] P1Engarde = new Image[9];
        Image[] P1EngardeL = new Image[9];
        Image[] P1Run = new Image[5];
        Image[] P1RunL = new Image[5];
        Image[] P1Jump = new Image[5];
        Image[] P1JumpL = new Image[5];
        Image[] P1Regular = new Image[25];
        Image[] P1RegularL = new Image[25];
        Image[] P1RegularAtk = new Image[25];
        Image[] P1RegularAtkL = new Image[25];
        Image[] P1Special = new Image[25];
        Image[] P1SpecialL = new Image[25];
        Image[] P1Concede = new Image[4];
        Image[] P1ConcedeL = new Image[4];
        bool P1flash;
        //P1 CharSel stat works
        Rectangle P1hpbar, P1atkbar, P1defbar, P1dexbar, P1spdbar;
        Rectangle P1ChpBar, P1livesBar, P1spclBar;
        bool P1charChosen, P1nameEntered;
        //P1 Result Stats
        int P1damageDealt, P1hpleft;


        //----------------------------------\\
        //           P2 Variables           \\
        //----------------------------------\\
        string P2playerName;//the players name
        int P2xv, P2yv, P2xa, P2ya; //velocity variables
        int P2atkCooltime, P2spclCooltime, P2stunTime; //cooldown timers
        bool P2falling, P2jumping, P2atkActive, P2spclActive, P2invince, P2stunned, P2trueInvince; //indicators if these things are active
        bool P2atkCool, P2sklCool; //skill cooldowns
        bool P2facingRight; //which side is the player facing
        string P2Character; //which character the player chose
        int P2currentHp, P2lives; // hp and lives
        Rectangle P2Sprite, P2hb, P2atkhb, P2spclhb; //P2hitboxes
        //P2 imported integers
        int P2hp, P2atk, P2def, P2dex, P2spd; //stats
        int P2atkLength; //attack specifications 
        int P2atkhbX, P2atkhbY, P2atkhbOffsetX, P2atkhbOffsetY; //attack hitbox sizes
        bool P2spclDoesHeal, P2spclDoesDmg, P2spclDoesDrop, P2spclDoesSpecial; //Special skill conditions
        int P2spclLength, P2spclCool, P2spclhbX, P2spclhbY, P2spclhbOffsetX, P2spclhbOffsetY; //Special skill specifications
        int P2spclDmg, P2spclStun; //special damage and stun values
        string P2fullName, P2desc; //values displayed in charsel
        bool P2dealKnockback = false;
        //P2 sprite works
        string P2spriteStatus; //sprite status
        int P2frame; //universal sprite frame int
        //all the sprites
        Image[] P2Idle = new Image[9];
        Image[] P2Taunt = new Image[10];
        Image[] P2Engarde = new Image[9];
        Image[] P2EngardeL = new Image[9];
        Image[] P2Run = new Image[5];
        Image[] P2RunL = new Image[5];
        Image[] P2Jump = new Image[5];
        Image[] P2JumpL = new Image[5];
        Image[] P2Regular = new Image[25];
        Image[] P2RegularL = new Image[25];
        Image[] P2RegularAtk = new Image[25];
        Image[] P2RegularAtkL = new Image[25];
        Image[] P2Special = new Image[25];
        Image[] P2SpecialL = new Image[25];
        Image[] P2Concede = new Image[4];
        Image[] P2ConcedeL = new Image[4];
        bool P2flash;
        //P2 CharSel stat works
        Rectangle P2hpbar, P2atkbar, P2defbar, P2dexbar, P2spdbar;
        Rectangle P2ChpBar, P2livesBar, P2spclBar;
        bool P2charChosen, P2nameEntered;
        //P2 Result Stats
        int P2damageDealt, P2hpleft;


        //classes
        Title title = new Title();
        CharSel charsel = new CharSel();
        Rules rules = new Rules();
        Results results = new Results();

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, MainPanel, new object[] { true });
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
        private void GameStart()//starts game 
        {
            gameStarted = true;
            P1lives = 3;
            P2lives = 3;
            P1setChar();
            P2setChar();
            //reads char files
            P1loadChar(); 
            P2loadChar(); 
            //prepares all sprite works
            P1prepareSprite();
            P2prepareSprite();
            VeloTmr.Enabled = true;
            MainPanel.Invalidate();
        }
        private void P1setChar()//sets all the variables for P1 character, also responsible for reseting stats after respawn 
        {
            P1Sprite = new Rectangle(300, 300, 200, 150);
            P1hb = new Rectangle(300, 300, 60, 100);
            P1frame = 1;
            P1facingRight = true;
            P1currentHp = P1hp;
            P1ChpBar = new Rectangle(195, 629, (200 * P1currentHp / P1hp), 5);
            P1livesBar = new Rectangle(161, 658, 78 * P1lives, 5);
            P1spclTmr.Enabled = true;
            P1spclCooltime = 1;
            P1sklCool = true;
            P1invince = false;
            P1stunned = false;
            P1trueInvince = false;
        }
        private void P2setChar()//sets all the variables for P2 character, also responsible for reseting stats after respawn 
        {
            P2Sprite = new Rectangle(640, 300, 200, 150);
            P2hb = new Rectangle(640, 300, 60, 100);
            P2frame = 1;
            P2facingRight = false;
            P2currentHp = P2hp;
            P2ChpBar = new Rectangle(603, 629, (200 * P2currentHp / P2hp), 5);
            P2livesBar = new Rectangle(837 - (78 * P2lives), 658, 78 * P2lives, 5);
            P2spclTmr.Enabled = true;
            P2spclCooltime = 1;
            P2sklCool = true;
            P2invince = false;
            P2stunned = false;
            P2trueInvince = false;
        }

        //----------------------------------\\
        //        Loading Character         \\
        //----------------------------------\\

        //prepares sprites, but for charsel
        private void P1prepareSpritecharsel()
        {
            if (P1Character != "nocharacter")//if character isn't empty
            {
                for (int i = 1; i <= 8; i++)//creates the image files for animations
                {
                    P1Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Idle_(" + i.ToString() + ").png");
                }
                for (int i = 1; i <= 9; i++)//creates the image files for animations
                {
                    P1Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Taunt_(" + i.ToString() + ").png");
                }
                P1hpbar = new Rectangle(180, 310, P1hp, 4);
                P1atkbar = new Rectangle(180, 334, P1atk*7, 4);
                P1defbar = new Rectangle(180, 358, P1def * 15, 4);
                P1dexbar = new Rectangle(180, 382, (13-P1dex) * 15, 4);
                P1spdbar = new Rectangle(180, 406 , P1spd * 50, 4);
                P1Name.Text = P1fullName;
                P1spclDesc.Text = P1desc;
            }
        } 
        private void P2prepareSpritecharsel()
        {
            if (P2Character != "nocharacter")//if character isn't empty
            {
                for (int i = 1; i <= 8; i++)//creates the image files for animations
                {
                    P2Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Idle_(" + i.ToString() + ").png");
                }
                for (int i = 1; i <= 9; i++)//creates the image files for animations
                {
                    P2Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Taunt_(" + i.ToString() + ").png");
                }
                P2hpbar = new Rectangle(820 - P2hp, 310, P2hp, 4);
                P2atkbar = new Rectangle(820 - (P2atk * 7), 334, P2atk * 7, 4);
                P2defbar = new Rectangle(820 - (P2def * 15), 358, P2def * 15, 4);
                P2dexbar = new Rectangle(820 - ((13 - P2dex) * 15), 382, (13 - P2dex) * 15, 4);
                P2spdbar = new Rectangle(820 - (P2spd * 50), 406, P2spd * 50, 4);
                P2Name.Text = P2fullName;
                P2spclDesc.Text = P2desc;
            }
        }

        //reads character files and load in stats
        private void P1loadChar()
        {
            if (P1Character != "nocharacter")//if character isn't empty
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\characters\" + P1Character.ToString() + ".txt"); //selects the txt file matching the character
                int linenumber = 1;
                for (int i = 1; i <= 25; i++)
                {
                    try
                    {
                        string line = File.ReadLines(Application.StartupPath + @"\characters\" + P1Character.ToString() + ".txt").ElementAt(linenumber);
                        switch (linenumber)
                        {
                            case 1://displayed name
                                P1fullName = line;
                                break;
                            case 2://special description
                                P1desc = line;
                                break;
                            case 3://stats
                                P1hp = int.Parse(line);
                                break;
                            case 4:
                                P1atk = int.Parse(line);
                                break;
                            case 5:
                                P1def = int.Parse(line);
                                break;
                            case 6:
                                P1dex = int.Parse(line);
                                break;
                            case 7:
                                P1spd = int.Parse(line);
                                break;
                            case 8://attack time
                                P1atkLength = int.Parse(line);
                                break;
                            case 9://attack hitbox size(x)
                                P1atkhbX = int.Parse(line);
                                break;
                            case 10://attack hitbox size(y)
                                P1atkhbY = int.Parse(line);
                                break;
                            case 11://attack offset from hitbox(x)
                                P1atkhbOffsetX = int.Parse(line);
                                break;
                            case 12://attack offset from hitbox(y)
                                P1atkhbOffsetY = int.Parse(line);
                                break;
                            case 13://does special heal self?
                                if (line.Contains("y")) { P1spclDoesHeal = true; }
                                else { P1spclDoesHeal = false; }
                                break;
                            case 14://does special deal damage?
                                if (line.Contains("y")) { P1spclDoesDmg = true; }
                                else { P1spclDoesDmg = false; }
                                break;
                            case 15://does special drop stats?
                                if (line.Contains("y")) { P1spclDoesDrop = true; }
                                else { P1spclDoesDrop = false; }
                                break;
                            case 16://does special do anything else?
                                if (line.Contains("y")) { P1spclDoesSpecial = true; }
                                else { P1spclDoesSpecial = false; }
                                break;
                            case 17://special time
                                P1spclLength = int.Parse(line);
                                break;
                            case 18://special cooldown time
                                P1spclCool = int.Parse(line);
                                break;
                            case 19://special hitbox size(x)
                                P1spclhbX = int.Parse(line);
                                break;
                            case 20://special hitbox size(y)
                                P1spclhbY = int.Parse(line);
                                break;
                            case 21://special offset from hitbox(x)
                                P1spclhbOffsetX = int.Parse(line);
                                break;
                            case 22://special offset from hitbox(y)
                                P1spclhbOffsetY = int.Parse(line);
                                break;
                            case 23://special damage multiplier
                                P1spclDmg = int.Parse(line);
                                break;
                            case 24://special stun time
                                P1spclStun = int.Parse(line);
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
        private void P2loadChar()
        {
            if (P2Character != "nocharacter")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\characters\" + P2Character.ToString() + ".txt");//selects the txt file matching the character
                int linenumber = 1;
                for (int i = 1; i <= 25; i++)
                {
                    try
                    {
                        string line = File.ReadLines(Application.StartupPath + @"\characters\" + P2Character.ToString() + ".txt").ElementAt(linenumber);
                        switch (linenumber)
                        {
                            case 1://displayed name
                                P2fullName = line;
                                break;
                            case 2://special description
                                P2desc = line;
                                break;
                            case 3://stats
                                P2hp = int.Parse(line);
                                break;
                            case 4:
                                P2atk = int.Parse(line);
                                break;
                            case 5:
                                P2def = int.Parse(line);
                                break;
                            case 6:
                                P2dex = int.Parse(line);
                                break;
                            case 7:
                                P2spd = int.Parse(line);
                                break;
                            case 8://attack time
                                P2atkLength = int.Parse(line);
                                break;
                            case 9://attack hitbox size(x)
                                P2atkhbX = int.Parse(line);
                                break;
                            case 10://attack hitbox size(y)
                                P2atkhbY = int.Parse(line);
                                break;
                            case 11://attack offset from hitbox(x)
                                P2atkhbOffsetX = int.Parse(line);
                                break;
                            case 12://attack offset from hitbox(y)
                                P2atkhbOffsetY = int.Parse(line);
                                break;
                            case 13://does special heal self?
                                if (line.Contains("y")) { P2spclDoesHeal = true; }
                                else { P2spclDoesHeal = false; }
                                break;
                            case 14://does special deal damage?
                                if (line.Contains("y")) { P2spclDoesDmg = true; }
                                else { P2spclDoesDmg = false; }
                                break;
                            case 15://does special drop stats?
                                if (line.Contains("y")) { P2spclDoesDrop = true; }
                                else { P2spclDoesDrop = false; }
                                break;
                            case 16://does special do anything else?
                                if (line.Contains("y")) { P2spclDoesSpecial = true; }
                                else { P2spclDoesSpecial = false; }
                                break;
                            case 17://special time
                                P2spclLength = int.Parse(line);
                                break;
                            case 18://special cooldown time
                                P2spclCool = int.Parse(line);
                                break;
                            case 19://special hitbox size(x)
                                P2spclhbX = int.Parse(line);
                                break;
                            case 20://special hitbox size(y)
                                P2spclhbY = int.Parse(line);
                                break;
                            case 21://special offset from hitbox(x)
                                P2spclhbOffsetX = int.Parse(line);
                                break;
                            case 22://special offset from hitbox(y)
                                P2spclhbOffsetY = int.Parse(line);
                                break;
                            case 23://special damage multiplier
                                P2spclDmg = int.Parse(line);
                                break;
                            case 24://special stun time
                                P2spclStun = int.Parse(line);
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
        private void P1prepareSprite()
        {
            for (int i = 1; i <= 8; i++)//creates the image files for animations
            {
                P1Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Idle_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 9; i++)
            {
                P1Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Taunt_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 8; i++)
            {
                P1Engarde[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Engarde_(" + i.ToString() + ").png");
                P1EngardeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Engarde_(" + i.ToString() + ").png");
                P1EngardeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                P1Run[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Run_(" + i.ToString() + ").png");
                P1RunL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Run_(" + i.ToString() + ").png");
                P1RunL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                P1Jump[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Jump_(" + i.ToString() + ").png");
                P1JumpL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Jump_(" + i.ToString() + ").png");
                P1JumpL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= P1atkLength; i++)
            {
                P1Regular[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Regular_(" + i.ToString() + ").png");
                P1RegularL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Regular_(" + i.ToString() + ").png");
                P1RegularL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
                P1RegularAtk[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_AtkWeapon_(" + i.ToString() + ").png");
                P1RegularAtkL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_AtkWeapon_(" + i.ToString() + ").png");
                P1RegularAtkL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= P1spclLength; i++)
            {
                P1Special[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Special_(" + i.ToString() + ").png");
                P1SpecialL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Special_(" + i.ToString() + ").png");
                P1SpecialL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 3; i++)
            {
                P1Concede[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Concede_(" + i.ToString() + ").png");
                P1ConcedeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P1Character + "_Concede_(" + i.ToString() + ").png");
                P1ConcedeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
        }
        private void P2prepareSprite()
        {
            for (int i = 1; i <= 8; i++)//creates the image files for animations
            {
                P2Idle[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Idle_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 9; i++)
            {
                P2Taunt[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Taunt_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 8; i++)
            {
                P2Engarde[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Engarde_(" + i.ToString() + ").png");
                P2EngardeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Engarde_(" + i.ToString() + ").png");
                P2EngardeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                P2Run[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Run_(" + i.ToString() + ").png");
                P2RunL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Run_(" + i.ToString() + ").png");
                P2RunL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 4; i++)
            {
                P2Jump[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Jump_(" + i.ToString() + ").png");
                P2JumpL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Jump_(" + i.ToString() + ").png");
                P2JumpL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= P2atkLength; i++)
            {
                P2Regular[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Regular_(" + i.ToString() + ").png");
                P2RegularL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Regular_(" + i.ToString() + ").png");
                P2RegularL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
                P2RegularAtk[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_AtkWeapon_(" + i.ToString() + ").png");
                P2RegularAtkL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_AtkWeapon_(" + i.ToString() + ").png");
                P2RegularAtkL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= P2spclLength; i++)
            {
                P2Special[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Special_(" + i.ToString() + ").png");
                P2SpecialL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Special_(" + i.ToString() + ").png");
                P2SpecialL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
            for (int i = 1; i <= 3; i++)
            {
                P2Concede[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Concede_(" + i.ToString() + ").png");
                P2ConcedeL[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + P2Character + "_Concede_(" + i.ToString() + ").png");
                P2ConcedeL[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//flipping images that varies based on which way the character is facing
            }
        }

        private void DrawBars(Graphics g)//visualise stat bars in charsel 
        {
            //P1
            g.FillRectangle(whiteBrush, P1hpbar);
            g.FillRectangle(whiteBrush, P1atkbar);
            g.FillRectangle(whiteBrush, P1defbar);
            g.FillRectangle(whiteBrush, P1dexbar);
            g.FillRectangle(whiteBrush, P1spdbar);
            //P2
            g.FillRectangle(whiteBrush, P2hpbar);
            g.FillRectangle(whiteBrush, P2atkbar);
            g.FillRectangle(whiteBrush, P2defbar);
            g.FillRectangle(whiteBrush, P2dexbar);
            g.FillRectangle(whiteBrush, P2spdbar);
        } 
        private void DrawBarsGame(Graphics g)//visualise stat bars in game 
        {
            g.FillRectangle(whiteBrush, P1ChpBar);
            g.FillRectangle(whiteBrush, P2ChpBar);
            g.FillRectangle(whiteBrush, P1livesBar);
            g.FillRectangle(whiteBrush, P2livesBar);
            if(P1spclCooltime >= P1spclCool)
            {
                g.FillRectangle(blueBrush, P1spclBar);//if special is fully charged, the bar changes to light blue
            }
            else
            {
                g.FillRectangle(whiteBrush, P1spclBar);
            }
            if (P2spclCooltime >= P2spclCool)
            {
                g.FillRectangle(blueBrush, P2spclBar);//if special is fully charged, the bar changes to light blue
            }
            else
            {
                g.FillRectangle(whiteBrush, P2spclBar);
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
                    title.TriggerTransition();
                    P1Sprite = new Rectangle(90, 388, 400, 300);
                    P2Sprite = new Rectangle(510, 388, 400, 300);
                    P1spriteStatus = "Idle";
                    P2spriteStatus = "Idle";
                    P1Character = charsel.P1char();
                    P2Character = charsel.P2char();
                    P1loadChar();
                    P2loadChar();
                    P1prepareSpritecharsel();
                    P2prepareSpritecharsel();
                    P1charChosen = false;
                    P2charChosen = false;
                }
                else 
                {
                    if (gameStatus == "CharSel" && charsel.TransitionDone() == true) //charsel controls
                    {
                        if(P1charChosen == false) //if P1 character isn't chosen yet
                        {
                            if (e.KeyData == Keys.D) { charsel.MoveSelRight1(); }
                            if (e.KeyData == Keys.A) { charsel.MoveSelLeft1(); }
                            if (e.KeyData == Keys.W) { charsel.MoveSelUP1(); }
                            if (e.KeyData == Keys.S) { charsel.MoveSelDown1(); }
                            P1Character = charsel.P1char();
                            P1loadChar();
                            P1prepareSpritecharsel();
                            if(e.KeyData == Keys.G) //key to lock in character
                            {
                                if (P1Character != "nocharacter")
                                { 
                                    P1charChosen = true; 
                                    P1frame = 1;  
                                    P1spriteStatus = "Taunt";
                                    charsel.P1chosenChar();
                                } 
                            }
                        }
                        if(P2charChosen == false) //if P2 character isn't chosen yet
                        {
                            if (e.KeyData == Keys.Right) { charsel.MoveSelRight2(); }
                            if (e.KeyData == Keys.Left) { charsel.MoveSelLeft2(); }
                            if (e.KeyData == Keys.Up) { charsel.MoveSelUP2(); }
                            if (e.KeyData == Keys.Down) { charsel.MoveSelDown2(); }
                            P2Character = charsel.P2char();
                            P2loadChar();
                            P2prepareSpritecharsel();
                            if (e.KeyData == Keys.M) //key to lock in character
                            {
                                if (P2Character != "nocharacter")
                                { 
                                    P2charChosen = true; 
                                    P2frame = 1; 
                                    P2spriteStatus = "Taunt";
                                    charsel.P2chosenChar();
                                }
                            }

                        }
                        if (e.KeyData == Keys.R) //to rules page
                        { 
                            charsel.ToRules(); 
                            P1Name.Visible = false;
                            P1spclDesc.Visible = false;
                            P2Name.Visible = false;
                            P2spclDesc.Visible = false;
                            P1nameBox.Visible = false;
                            P2nameBox.Visible = false;
                        }
                    }
                    else if ( rules.TransitionDone() == true ) //this is to swap back form rules to charsel. because of some complications characters that are locked in will be reset
                    {
                        rules.ToCharsel();
                        P1charChosen = false;
                        P2charChosen = false;
                    }
                }
            }
            else if(fadeDone == true && gameOver == false)//controls for playing the game
            {
                //P1
                if (P1atkActive == false && P1stunned == false && P1spclActive == false && P1spriteStatus != "Concede")//checks every condition that won't allow the player to move
                {
                    if (P1xv < 10 && P1xv > -10)//velocity cap so the player can't infinitely accelerate
                    {
                        if (e.KeyData == Keys.D)
                        {
                            P1xa = P1spd; P1facingRight = true; P1spriteStatus = "Run";
                            if (P1frame >= 5)
                            {
                                P1frame = 1;
                            }
                        }
                        if (e.KeyData == Keys.A)
                        {
                            P1xa = -P1spd; P1facingRight = false; P1spriteStatus = "Run";
                            if (P1frame >= 5)
                            {
                                P1frame = 1;
                            }
                        }
                    }
                    if (e.KeyData == Keys.W && P1yv < 50 && P1yv > -50 && P1falling == false && P1jumping == false)//check is players on a platform and velocity cap
                    {
                        P1ya = -7;
                        P1jumping = true;
                        if (P1atkActive == false)
                        {
                            P1frame = 1;
                            P1spriteStatus = "Jump";
                        }
                    }
                    if (e.KeyData == Keys.G && P1atkCool == false && P1jumping == false) { P1Atk(); P1spriteStatus = "Regular"; P1frame = 1; } //actives attack skill
                    if (e.KeyData == Keys.H && P1sklCool == false && P1jumping == false) { P1spclAtk(); P1spriteStatus = "Special"; P1frame = 1; } //actives special skill

                    if (e.KeyData == Keys.F) { P1spriteStatus = "Taunt"; P1frame = 1; }
                }

                //P2
                if (P2atkActive == false && P2stunned == false && P2spclActive == false && P2spriteStatus != "Concede")//checks every condition that won't allow the player to move
                {
                    if (P2xv < 10 && P2xv > -10)//velocity cap so the player can't infinitely accelerate
                    {
                        if (e.KeyData == Keys.Right)
                        {
                            P2xa = P2spd; P2facingRight = true; P2spriteStatus = "Run"; if (P2frame >= 5)
                            {
                                P2frame = 1;
                            }
                        }
                        if (e.KeyData == Keys.Left)
                        {
                            P2xa = -P2spd; P2facingRight = false; P2spriteStatus = "Run"; if (P2frame >= 5)
                            {
                                P2frame = 1;
                            }
                        }
                    }
                    if (e.KeyData == Keys.Up && P2yv < 50 && P2yv > -50 && P2falling == false && P2jumping == false)//check is players on a platform and velocity cap
                    {
                        P2ya = -7;
                        P2jumping = true;
                        if (P2atkActive == false)
                        {
                            P2frame = 1;
                            P2spriteStatus = "Jump";
                        }
                    }
                    if (e.KeyData == Keys.M && P2atkCool == false && P2jumping == false) { P2Atk(); P2spriteStatus = "Regular"; P2frame = 1; } //actives attack skill
                    if (e.KeyData == Keys.N && P2sklCool == false && P2jumping == false) { P2spclAtk(); P2spriteStatus = "Special"; P2frame = 1; } //actives special skill

                    if (e.KeyData == Keys.B) { P2spriteStatus = "Taunt"; P2frame = 1; }
                }
            }
            else if(gameStatus == "Results")
            {
                if(lbDisplayed == false)
                {
                    //hides every label
                    lbDisplayed = true;
                    HideLabels();
                    LstBoxName.Visible = true;
                    LstBoxScore.Visible = true;
                    ReadHighScores();
                    SortHighScores();
                    DisplayHighScores();
                    SaveHighScores();
                    results.ResultShown();
                }
            }
        } 
        private void Form1_KeyUp(object sender, KeyEventArgs e)//stops some things when key is released 
        {
            if (gameStarted == true && fadeDone == true && gameOver == false)
            {
                //P1
                if (P1atkActive == false && P1stunned == false && P1spclActive == false && P1spriteStatus != "Concede") //checks everything that locks controls
                {
                    if (e.KeyData == Keys.D || e.KeyData == Keys.A)
                    {
                        P1xa = 0;
                        if (P1atkActive == false)
                        {
                            P1spriteStatus = "Engarde";
                            P1frame = 1;
                        }
                    }
                }

                //P2
                if (P2atkActive == false && P2stunned == false && P2spclActive == false && P2spriteStatus != "Concede") //checks everything that locks controls
                {
                    if (e.KeyData == Keys.Right || e.KeyData == Keys.Left)
                    {
                        P2xa = 0;
                        if (P2atkActive == false)
                        {
                            P2spriteStatus = "Engarde";
                            P2frame = 1;
                        }
                    }
                }
            }
        }


        //----------------------------------\\
        //          Entering Name           \\
        //----------------------------------\\

        private void P1nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                P1playerName = P1nameBox.Text;
                if (Regex.IsMatch(P1playerName, @"^[a-zA-Z]+$"))//checks playerName for letters
                {
                    P1nameBox.ReadOnly = true;
                    ActiveControl = null;
                    P1nameBox.ForeColor = Color.DimGray;
                    P1nameEntered = true;
                }
                else
                {
                    P1nameBox.Text = "letters only!";
                    P1nameBox.Focus();

                }
            }
        }
        private void P1nameBox_Click(object sender, EventArgs e)
        {
            if(P1nameBox.Text == "Enter name (letters only)")//clears the box when you click on it
            {
                P1nameBox.Clear();
            }
        }

        private void P2nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                P2playerName = P2nameBox.Text;
                if (Regex.IsMatch(P2playerName, @"^[a-zA-Z]+$"))//checks playerName for letters
                {
                    P2nameBox.ReadOnly = true;
                    ActiveControl = null;
                    P2nameEntered = true;
                    P2nameBox.ForeColor = Color.DimGray;
                }
                else
                {
                    P2nameBox.Text = "letters only!";
                    P2nameBox.Focus();

                }
            }
        }
        private void P2nameBox_Click(object sender, EventArgs e)
        {
            if (P2nameBox.Text == "Enter name (letters only)")//clears the box when you click on it
            {
                P2nameBox.Clear();
            }
        }

        //----------------------------------\\
        //             Movement             \\
        //----------------------------------\\

        private void VeloTmr_Tick(object sender, EventArgs e)//universal timer for player movement 
        {
            MainPanel.Invalidate();

            //----------------------------------\\
            //               P1                 \\
            //----------------------------------\\
            P1hb.Y += P1yv;//y velocity conversion 
            P1hb.X += P1xv;//x velocity conversion
            P1Sprite.Y = P1hb.Y - 50;//the sprite hitbox follows hitbox
            P1Sprite.X = P1hb.X - 70;
            if(P1hb.X <= 0)//doesn't allow players to move out of form
            {
                P1hb.X = 1;
                P1xa = 0;
                P1xv = 0;
            }
            if (P1hb.X >= 940)//doesn't allow players to move out of form 
            {
                P1hb.X = 939;
                P1xa = 0;
                P1xv = 0;
            }

            if (P1hb.IntersectsWith(platform))//if player is touching the ground
            {
                if (P1falling == true && P1hb.Y < 600)//if player hits the ground(therefore previously falling)
                {
                    int place = (int)P1hb.Y;
                    P1ya = 0;
                    P1hb.Y -= place - 441;//sets player on top of the ground
                    P1yv = 0;
                    P1falling = false;
                    P1jumping = false;
                    if (P1atkActive == false)
                    {
                        if(P1xa == 0)
                        {
                            P1spriteStatus = "Engarde";
                        }
                        else
                        {
                            P1spriteStatus = "Run";
                        }
                    }
                }
            }
            else //if the player isn't on the ground, gravity acceleration occurs
            {
                P1ya += 1;
                P1falling = true;
                if (P1atkActive == false)
                {
                    P1spriteStatus = "Jump";
                }
            }
            if (P1yv > 0)//y-velocity decay
            {
                P1yv -= 1;
            }
            if (P1yv < 0)
            {
                P1yv += 1;
            }
            if (P1yv < 20 && P1yv > -20)//velocity cap
            {
                P1yv += P1ya; //acceleration
            }

            if (P1xv < 10 && P1xv > -10)//velocity cap
            { 
                P1xv += P1xa; //acceleration
            }
            if (P1xv > 0)//x-velocity decay(right)
            { 
                P1xv -= 1;
            }
            if (P1xv < 0)//x-velocity decay(left)
            {
                P1xv += 1;
            }
            P1spclBar = new Rectangle(103, 719, (292 * P1spclCooltime / P1spclCool), 5);//refreshes special bar 
            if(P1currentHp <= 0)//start concede sequence
            {
                if (P1hb.IntersectsWith(platform) && P1spriteStatus != "TakingDamage")
                {
                    P1trueInvince = true;
                    if(P1spriteStatus != "Concede")//if this is the first time triggering this code, set frame to 1
                    {
                        P1frame = 1;
                    }
                    P1spriteStatus = "Concede";
                    if(P1lives == 1)
                    {
                        P2spriteStatus = "Engarde";
                        P1lives -= 1;
                        StopGame();
                    }
                }
                P1xv = 0;
                P1xa = 0;
            }


            //----------------------------------\\
            //               P2                 \\
            //----------------------------------\\
            P2hb.Y += P2yv;//y velocity conversion 
            P2hb.X += P2xv;//x velocity conversion
            P2Sprite.Y = P2hb.Y - 50;//the sprite hitbox follows hitbox
            P2Sprite.X = P2hb.X - 70;
            if (P2hb.X <= 0)//doesn't allow players to move out of form
            {
                P2hb.X = 1;
                P2xa = 0;
                P2xv = 0;
            }
            if (P2hb.X >= 940)//doesn't allow players to move out of form 
            {
                P2hb.X = 939;
                P2xa = 0;
                P2xv = 0;
            }

            if (P2hb.IntersectsWith(platform))//if player is touching the ground
            {
                if (P2falling == true && P2hb.Y < 600)//if player hits the ground(therefore previously falling)
                {
                    int place = (int)P2hb.Y;
                    P2ya = 0;
                    P2hb.Y -= place - 441;//sets player on top of the ground
                    P2yv = 0;
                    P2falling = false;
                    P2jumping = false;
                    if (P2atkActive == false)
                    {
                        if (P2xa == 0)
                        {
                            P2spriteStatus = "Engarde";
                        }
                        else
                        {
                            P2spriteStatus = "Run";
                        }
                    }
                }
            }
            else //if the player isn't on the ground, gravity acceleration occurs
            {
                P2ya += 1;
                P2falling = true;
                if (P2atkActive == false)
                {
                    P2spriteStatus = "Jump";
                }
            }
            if (P2yv > 0)//y-velocity decay
            {
                P2yv -= 1;
            }
            if (P2yv < 0)
            {
                P2yv += 1;
            }
            if (P2yv < 20 && P2yv > -20)//velocity cap
            {
                P2yv += P2ya; //acceleration
            }

            if (P2xv < 10 && P2xv > -10)//velocity cap
            {
                P2xv += P2xa; //acceleration
            }
            if (P2xv > 0)//x-velocity decay(right)
            {
                P2xv -= 1;
            }
            if (P2xv < 0)//x-velocity decay(left)
            {
                P2xv += 1;
            }
            P2spclBar = new Rectangle(895 - (292 * P2spclCooltime / P2spclCool), 719, (292 * P2spclCooltime / P2spclCool), 5);
            if (P2currentHp <= 0)//start concede sequence
            {
                if (P2hb.IntersectsWith(platform) && P2spriteStatus != "TakingDamage")
                {
                    P2trueInvince = true;
                    if (P2spriteStatus != "Concede")//if this is the first time triggering this code, set frame to 1
                    {
                        P2frame = 1;
                    }
                    P2spriteStatus = "Concede";
                    if (P2lives == 1)
                    {
                        P1spriteStatus = "Engarde";
                        P2lives -= 1;
                        StopGame();
                    }
                }
                P2xv = 0;
                P2xa = 0;
            }
        }
        private void P1stunTmr_Tick(object sender, EventArgs e)//controls stun time for P1 
        {
            P1stunned = true;
            P1stunTime -= 1;
            if (P1hb.IntersectsWith(P2atkhb) == false && P1hb.IntersectsWith(P2spclhb) == false)
            {
                if (P1dealKnockback == false)//dealing knockback
                {
                    P1frame = 1;
                    if (P2facingRight == true)
                    {
                        P1xv = 20 - P1def - (P1currentHp / P1hp) * 10; //knockback based on defence and current hp
                        P1yv = -5;
                    }
                    else
                    {
                        P1xv = -(20 - P1def - (P1currentHp / P1hp) * 10);
                        P1yv = -5;
                    }
                    P1invince = false;
                    P1dealKnockback = true;
                }
            }
            if (P1stunTime == 0)
            {
                P1dealKnockback = false;
                P1stunned = false;
                P1stunTmr.Enabled = false;
            }
        }
        private void P2stunTmr_Tick(object sender, EventArgs e)//controls stun time for P2 
        {
            P2stunned = true;
            P2stunTime -= 1;
            if (P2hb.IntersectsWith(P1atkhb) == false && P2hb.IntersectsWith(P1spclhb) == false)
            {
                if (P2dealKnockback == false)//dealing knockback
                {
                    P2frame = 1;
                    if (P1facingRight == true)
                    {
                        P2xv = 20 - P2def - (P2currentHp / P2hp) * 10; //knockback based on defence and current hp
                        P2yv = -5;
                    }
                    else
                    {
                        P2xv = -(20 - P2def - (P2currentHp / P2hp) * 10);
                        P2yv = -5;
                    }
                    P2invince = false;
                    P2dealKnockback = true;
                }
            }
            if(P2stunTime == 0)
            {
                P2dealKnockback = false;
                P2stunned = false;
                P2stunTmr.Enabled = false;
            }
        }


        //----------------------------------\\
        //            Aesthetics            \\
        //----------------------------------\\

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            switch (gameStatus)
            {
                case "title":
                    title.DrawTitle(g);//draws everything in title
                    break;
                case "CharSel":
                    charsel.DrawCharSel(g);//draws background in charsel
                    DrawBars(g);//draws stat bars
                    if (P1spriteStatus == "Idle")//draws P1 chosen character
                    {
                        g.DrawImage(P1Idle[P1frame], P1Sprite);
                    }
                    else
                    {
                        g.DrawImage(P1Taunt[P1frame], P1Sprite);
                    }
                    if (P2spriteStatus == "Idle")//draws P2 chosen character
                    {
                        g.DrawImage(P2Idle[P2frame], P2Sprite);
                    }
                    else
                    {
                        g.DrawImage(P2Taunt[P2frame], P2Sprite);
                    }
                    if (charsel.TransitionDone() != true)//draws fade in transiton
                    {
                        charsel.DrawFade(g);
                    }
                    charsel.DrawFadeout(g);//draws fade out transition
                    break;
                case "Rules":
                    rules.DrawRules(g);//draws rules screen 
                    if (rules.TransitionDone() != true)//draws fade in transition
                    {
                        rules.DrawFade(g);
                    }
                    else if (rules.RulesDone() != true)//draws fade out transition
                    {
                        rules.DrawFadeout(g);
                    }
                    break;
                case "Game":
                    g.DrawImage(arenaImage, Arena);//draws background
                    DrawBarsGame(g);//draws stat bars
                    if (fadeDone == false)//draws fade in 
                    {
                        g.DrawImage(fadeFrame[Frame], fadeSpace);
                    }
                    else
                    {
                        switch (P1spriteStatus)//draws P1 sprite
                        {
                            case "Engarde":
                                if (P1facingRight == true)
                                {
                                    g.DrawImage(P1Engarde[P1frame], P1Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P1EngardeL[P1frame], P1Sprite);
                                }
                                break;
                            case "Jump":
                                if (P1facingRight == true)
                                {
                                    g.DrawImage(P1Jump[P1frame], P1Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P1JumpL[P1frame], P1Sprite);
                                }
                                break;
                            case "Run":
                                if (P1facingRight == true)
                                {
                                    g.DrawImage(P1Run[P1frame], P1Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P1RunL[P1frame], P1Sprite);
                                }
                                break;
                            case "Regular":
                                if (P1facingRight == true)
                                {
                                    g.DrawImage(P1Regular[P1frame], P1Sprite);
                                    g.DrawImage(P1RegularAtk[P1frame], P1atkhb);
                                }
                                else
                                {
                                    g.DrawImage(P1RegularL[P1frame], P1Sprite);
                                    g.DrawImage(P1RegularAtkL[P1frame], P1atkhb);
                                }
                                break;
                            case "Taunt":
                                g.DrawImage(P1Taunt[P1frame], P1Sprite);
                                break;
                            case "TakingDamage":
                                if (P1facingRight == true)
                                {
                                    g.DrawImage(P1Jump[1], P1Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P1JumpL[1], P1Sprite);
                                }
                                break;
                            case "Special":
                                if (P1facingRight == true)
                                {
                                    g.DrawImage(P1Special[P1frame], P1Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P1SpecialL[P1frame], P1Sprite);
                                }
                                break;
                            case "Concede":
                                if (P1frame <= 3)
                                {
                                    if (P1facingRight == true)
                                    {
                                        g.DrawImage(P1Concede[P1frame], P1Sprite);
                                    }
                                    else
                                    {
                                        g.DrawImage(P1ConcedeL[P1frame], P1Sprite);
                                    }
                                }
                                if (gameOver == false)
                                {
                                    if (P1frame > 13)
                                    {
                                        if (P1facingRight == true)
                                        {
                                            if (P1flash == false)
                                            {
                                                g.DrawImage(P1Concede[3], P1Sprite);
                                                P1flash = true;
                                            }
                                            else
                                            {
                                                P1flash = false;
                                            }
                                        }
                                        else
                                        {
                                            if (P1flash == false)
                                            {
                                                g.DrawImage(P1ConcedeL[3], P1Sprite);
                                                P1flash = true;
                                            }
                                            else
                                            {
                                                P1flash = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (P1facingRight == true)
                                        {
                                            g.DrawImage(P1Concede[3], P1Sprite);
                                        }
                                        else
                                        {
                                            g.DrawImage(P1ConcedeL[3], P1Sprite);
                                        }
                                    }
                                }
                                else if (P2frame > 3)
                                {
                                    g.DrawImage(P1Concede[3], P1Sprite);
                                }
                                break;
                        }
                        switch (P2spriteStatus)//draws P2 sprite
                        {
                            case "Engarde":
                                if (P2facingRight == true)
                                {
                                    g.DrawImage(P2Engarde[P2frame], P2Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P2EngardeL[P2frame], P2Sprite);
                                }
                                break;
                            case "Jump":
                                if (P2facingRight == true)
                                {
                                    g.DrawImage(P2Jump[P2frame], P2Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P2JumpL[P2frame], P2Sprite);
                                }
                                break;
                            case "Run":
                                if (P2facingRight == true)
                                {
                                    g.DrawImage(P2Run[P2frame], P2Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P2RunL[P2frame], P2Sprite);
                                }
                                break;
                            case "Regular":
                                if (P2facingRight == true)
                                {
                                    g.DrawImage(P2Regular[P2frame], P2Sprite);
                                    g.DrawImage(P2RegularAtk[P2frame], P2atkhb);
                                }
                                else
                                {
                                    g.DrawImage(P2RegularL[P2frame], P2Sprite);
                                    g.DrawImage(P2RegularAtkL[P2frame], P2atkhb);
                                }
                                break;
                            case "Taunt":
                                g.DrawImage(P2Taunt[P2frame], P2Sprite);
                                break;
                            case "TakingDamage":
                                if (P2facingRight == true)
                                {
                                    g.DrawImage(P2Jump[1], P2Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P2JumpL[1], P2Sprite);
                                }
                                break;
                            case "Special":
                                if (P2facingRight == true)
                                {
                                    g.DrawImage(P2Special[P2frame], P2Sprite);
                                }
                                else
                                {
                                    g.DrawImage(P2SpecialL[P2frame], P2Sprite);
                                }
                                break;
                            case "Concede":
                                if (P2frame <= 3)
                                {
                                    if (P2facingRight == true)
                                    {
                                        g.DrawImage(P2Concede[P2frame], P2Sprite);
                                    }
                                    else
                                    {
                                        g.DrawImage(P2ConcedeL[P2frame], P2Sprite);
                                    }
                                }
                                if (gameOver == false)
                                {
                                    if (P2frame > 13)
                                    {
                                        if (P2facingRight == true)
                                        {
                                            if (P2flash == false)
                                            {
                                                g.DrawImage(P2Concede[3], P2Sprite);
                                                P2flash = true;
                                            }
                                            else
                                            {
                                                P2flash = false;
                                            }
                                        }
                                        else
                                        {
                                            if (P2flash == false)
                                            {
                                                g.DrawImage(P2ConcedeL[3], P2Sprite);
                                                P2flash = true;
                                            }
                                            else
                                            {
                                                P2flash = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (P2facingRight == true)
                                        {
                                            g.DrawImage(P2Concede[3], P2Sprite);
                                        }
                                        else
                                        {
                                            g.DrawImage(P2ConcedeL[3], P2Sprite);
                                        }
                                    }
                                }
                                else if (P2frame > 3)
                                {
                                    g.DrawImage(P2Concede[3], P2Sprite);
                                }
                                break;
                        }
                        if (gameOver == true)
                        {
                            g.DrawImage(fadeoutFrame[(Frame - 10)], fadeSpace);
                        }
                    }
                    break;
                case "Results":
                    results.DrawResults(g);//draws results screen 
                    if (P1spriteStatus == "Idle")//draws P1 chosen character
                    {
                        g.DrawImage(P1Idle[P1frame], P1Sprite);
                    }
                    else
                    {
                        g.DrawImage(P1Concede[3], P1Sprite);
                    }
                    if (P2spriteStatus == "Idle")//draws P2 chosen character
                    {
                        g.DrawImage(P2Idle[P2frame], P2Sprite);
                    }
                    else
                    {
                        g.DrawImage(P2Concede[3], P2Sprite);
                    }
                    if (results.TransitionDone() != true)//draws fade in transition
                    {
                        results.DrawFade(g);
                    }
                    else if (results.ResultsDone() != true)//draws fade out transition
                    {
                        results.DrawFadeout(g);
                    }
                    break;
            }
        }
        private void AniTmr_Tick(object sender, EventArgs e)//animation timer and universal timer for menus
        {
            MainPanel.Invalidate();//draws every tick(8fps)
            switch (gameStatus)
            {
                case "title":
                    title.AniTitle();
                    title.TransitionTitle();
                    if(title.TitleDone())
                    {
                        gameStatus = "CharSel";
                    }
                    break;
                case "CharSel":
                    charsel.AniCharSel();
                    if (charsel.TransitionDone() != true)
                    {
                        labels = false;
                        charsel.TransitionCharSel();
                    }
                    else
                    {
                        if (labels == false)
                        {
                            P1Name.Visible = true;
                            P1spclDesc.Visible = true;
                            P2Name.Visible = true;
                            P2spclDesc.Visible = true;
                            labels = true;
                            P1nameBox.Visible = true;
                            P2nameBox.Visible = true;
                        }
                    }
                    if(P1charChosen == true && P2charChosen == true && P1nameEntered == true && P2nameEntered == true)
                    {
                        smallDelay += 1;//theres a small delay after characters are chosen before the scene switches so the sprite changes can finish 
                        if(smallDelay >= 10)
                        {
                            charsel.ToGame();
                            P1Name.Visible = false;
                            P1spclDesc.Visible = false;
                            P2Name.Visible = false;
                            P2spclDesc.Visible = false;
                            P1nameBox.Visible = false;
                            P2nameBox.Visible = false;
                            if (charsel.CharselDone() != true)//starts fade out sequence
                            {
                                charsel.FadeoutCharSel();
                            }
                            else//empties and makes everything after fade out sequence
                            {
                                P1Sprite = Rectangle.Empty;
                                P2Sprite = Rectangle.Empty;
                                platform = new Rectangle(0, 540, 1000, 50);
                                Arena = new Rectangle(0, 0, 1000, 750);
                                fadeSpace = new Rectangle(0, 0, 1000, 750);
                                gameStatus = charsel.Statuscharsel();
                                charsel.CharselEmpty();
                                Frame = 1;
                                smallDelay = 1;
                                fadeDone = false;
                            }

                        }
                    }
                    else
                    {
                        if (charsel.CharselDone() != true)//starts fade to rules sequence
                        {
                            charsel.FadeoutCharSel();
                        }
                        else//empties everything in charsel
                        {
                            rules = new Rules();
                            P1Sprite = Rectangle.Empty;
                            P2Sprite = Rectangle.Empty;
                            gameStatus = charsel.Statuscharsel();
                            charsel.CharselEmpty();
                        }
                    }
                    break;
                case "Rules":
                    rules.AniRules();
                    if (rules.TransitionDone() != true)
                    {
                        rules.TransitionRules();
                    }
                    else if (rules.RulesDone() != true)
                    {
                        rules.FadeoutRules();
                    }
                    else//back to charsel
                    {
                        charsel = new CharSel();
                        gameStatus = "CharSel";
                        P1Sprite = new Rectangle(90, 388, 400, 300);
                        P2Sprite = new Rectangle(510, 388, 400, 300);
                        P1Character = charsel.P1char();
                        P2Character = charsel.P2char();
                        P1loadChar();
                        P2loadChar();
                        P1prepareSpritecharsel();
                        P2prepareSpritecharsel();
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
                        GameStart();
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
                                P1Sprite = new Rectangle(-66, 392, 400, 300);
                                P2Sprite = new Rectangle(666, 392, 400, 300);
                                P1frame = 1;
                                P2frame = 1;
                                if(P1lives > 0)
                                {
                                    P1spriteStatus = "Idle";
                                }
                                else
                                {
                                    P1spriteStatus = "Concede";
                                }
                                if (P2lives > 0)
                                {
                                    P2spriteStatus = "Idle";
                                }
                                else
                                {
                                    P2spriteStatus = "Concede";
                                }
                            }
                        }
                    }
                    break;
                case "Results":
                    results.AniResults();
                    if (results.TransitionDone() != true)
                    {
                        results.TransitionResults();
                    }
                    else if(labelShown == false)
                    {
                        ShowLabels();
                    }
                    if (results.ResultsDone() != true)
                    {
                        results.FadeoutResults();
                    }
                    break;
            }
            switch (P1spriteStatus)
            {
                case "Idle":
                    P1frame += 1;//cycles between frames
                    if (P1frame == 9)
                    {
                        P1frame = 1;
                    }
                    break;
                case "Taunt":
                    P1frame += 1;
                    if (P1frame == 10)
                    {
                        P1frame = 1; 
                        if(gameStarted == true)
                        {
                            P1spriteStatus = "Engarde";
                        }
                        else
                        {
                            P1spriteStatus = "Idle";
                        }
                    }
                    break;
                case "Engarde":
                    P1frame += 1;
                    if (P1frame == 9)
                    {
                        P1frame = 1;
                    }
                    break;
                case "Jump":
                    P1frame += 1;
                    if (P1frame == 5)
                    {
                        P1frame = 1;
                    }
                    break;
                case "Run":
                    P1frame += 1;
                    if (P1frame == 5)
                    {
                        P1frame = 1;
                    }
                    break;
                case "Regular":
                    P1frame += 1;
                    if (P1frame == P1atkLength + 1)
                    {
                        P1frame = 1; P1spriteStatus = "Engarde";
                    }
                    break;
                case "Special":
                    P1frame += 1;
                    if (P1frame == P1spclLength + 1)
                    {
                        P1frame = 1; P1spriteStatus = "Engarde";
                    }
                    break;
                case "Concede":
                    P1frame += 1;
                    if(P1frame == 15 && gameOver == false)
                    {
                        P1lives -= 1;
                        P1setChar();
                    }
                    break;
            }
            switch (P2spriteStatus)
            {
                case "Idle":
                    P2frame += 1;//cycles between frames
                    if (P2frame == 9)
                    {
                        P2frame = 1;
                    }
                    break;
                case "Taunt":
                    P2frame += 1;
                    if (P2frame == 10)
                    {
                        P2frame = 1;
                        if (gameStarted == true)
                        {
                            P2spriteStatus = "Engarde";
                        }
                        else
                        {
                            P2spriteStatus = "Idle";
                        }
                    }
                    break;
                case "Engarde":
                    P2frame += 1;
                    if (P2frame == 9)
                    {
                        P2frame = 1;
                    }
                    break;
                case "Jump":
                    P2frame += 1;
                    if (P2frame == 5)
                    {
                        P2frame = 1;
                    }
                    break;
                case "Run":
                    P2frame += 1;
                    if (P2frame == 5)
                    {
                        P2frame = 1;
                    }
                    break;
                case "Regular":
                    P2frame += 1;
                    if (P2frame == P2atkLength + 1)
                    {
                        P2frame = 1; P2spriteStatus = "Engarde";
                    }
                    break;
                case "Special":
                    P2frame += 1;
                    if (P2frame == P2spclLength + 1)
                    {
                        P2frame = 1; P2spriteStatus = "Engarde";
                    }
                    break;
                case "Concede":
                    P2frame += 1;
                    if (P2frame == 15 && gameOver == false)
                    {
                        P2lives -= 1;
                        P2setChar();
                    }
                    break;
            }
        }


        //----------------------------------\\
        //       Player Base attack         \\
        //----------------------------------\\

        private void P1Atk() //creates hitbox for P1 attack, fires once 
        {
            P1atkCool = true;
            P1atkActive = true;
            P1atkTime.Enabled = true;
            P1atkCooltime = 0;
            //sets momentum to 0
            P1xv = 0;
            P1yv = 0;
            P1xa = 0;
            P1ya = 0;
            int playerposX, playerposY;
            if (P1facingRight == true)
            {
                playerposX = P1hb.X + 30 + P1atkhbOffsetX;
                playerposY = P1hb.Y + P1atkhbOffsetY;
            }
            else
            {
                playerposX = P1hb.X + 30 - P1atkhbOffsetX - P1atkhbX;
                playerposY = P1hb.Y + P1atkhbOffsetY;
            }
            P1atkhb = new Rectangle(playerposX, playerposY, P1atkhbX, P1atkhbY);//sets hitbox position based on inputted values
        }
        private void P1atkTime_Tick(object sender, EventArgs e) //tracks P1 attack cooldown time and check for collison 
        {
            if (P1atkCooltime > P1atkLength + P1dex)//cooldown time is equal to player dex value
            {
                P1atkTime.Enabled = false;
                P1atkCool = false;
            }
            else
            {
                P1atkCooltime += 1;
            }
            if (P1atkCooltime > P1atkLength)//empties attack hitbox
            {
                P1atkhb = Rectangle.Empty;
                P1atkActive = false;
            }
            if (P2hb.IntersectsWith(P1atkhb) && P2trueInvince == false)//if hit player 2
            {
                P2spriteStatus = "TakingDamage";
                P2xv = 0;
                P2xa = 0;
                P2yv = 0;
                P2ya = 0;
                if (P1atk - P2def > 0 && P2invince == false)//triggers only once 
                {
                    P2currentHp -= (P1atk - P2def);
                    P1damageDealt += (P1atk - P2def);
                    P2ChpBar = new Rectangle(603 + 200 - (200 * P2currentHp / P2hp), 629, (200 * P2currentHp / P2hp), 5);
                }
                P2stunned = true;
                P2stunTime = P2dex;
                P2stunTmr.Enabled = true;//starts stun sequence
                P2dealKnockback = false;
                P2invince = true;
            }
        }

        private void P2Atk() //creates hitbox for P2 attack, fires once 
        {
            P2atkCool = true;
            P2atkActive = true;
            P2atkTime.Enabled = true;
            P2atkCooltime = 0;
            //sets momentum to 0
            P2xv = 0;
            P2yv = 0;
            P2xa = 0;
            P2ya = 0;
            int playerposX, playerposY;
            if (P2facingRight == true)
            {
                playerposX = P2hb.X + 30 + P2atkhbOffsetX;
                playerposY = P2hb.Y + P2atkhbOffsetY;
            }
            else
            {
                playerposX = P2hb.X + 30 - P2atkhbOffsetX - P2atkhbX;
                playerposY = P2hb.Y + P2atkhbOffsetY;
            }
            P2atkhb = new Rectangle(playerposX, playerposY, P2atkhbX, P2atkhbY);//sets hitbox position based on inputted values
        }
        private void P2atkTime_Tick(object sender, EventArgs e) //tracks P2 attack cooldown time and check for collison 
        {
            if (P2atkCooltime > P2atkLength + P2dex)//cooldown time is equal to player dex value
            {
                P2atkTime.Enabled = false;
                P2atkCool = false;
            }
            else
            {
                P2atkCooltime += 1;
            }
            if (P2atkCooltime > P2atkLength)//empties attack hitbox
            {
                P2atkhb = Rectangle.Empty;
                P2atkActive = false;
            }
            if (P1hb.IntersectsWith(P2atkhb) && P1trueInvince == false)//if hit player 2
            {
                P1spriteStatus = "TakingDamage";
                P1xv = 0;
                P1xa = 0;
                P1yv = 0;
                P1ya = 0;
                if (P2atk - P1def > 0 && P1invince == false)//triggers only once 
                {
                    P1currentHp -= (P2atk - P1def);
                    P2damageDealt += (P2atk - P1def);
                    P1ChpBar = new Rectangle(195, 629, (200 * P1currentHp / P1hp), 5);
                }
                P1stunned = true;
                P1stunTime = P1dex;
                P1stunTmr.Enabled = true;//starts stun sequence
                P1dealKnockback = false;
                P1invince = true;
            }
        }


        //----------------------------------\\
        //          Player Specials         \\
        //----------------------------------\\

        private void P1spclAtk() //set values for P1 special, fires once normally 
        {
            P1sklCool = true;
            P1spclActive = true;
            P1spclTmr.Enabled = true;
            P1spclCooltime = 0;
            if (P1spclDoesSpecial == true)//if special does anything special
            {
                switch (P1Character)
                {
                    case "Cedric":
                        P1trueInvince = true;//gives true invincibility
                        if (P1facingRight == true)//launches the player based on what direction they are facing
                        {
                            P1xv = 15;
                            P1xa = 0;
                        }
                        else
                        {
                            P1xv = -15;
                            P1xa = 0;
                        }
                        break;
                }
            }
            if (P1spclDoesDmg == true)//if special does damage; spawns attack hitboxes
            {
                P1xv = 0;
                P1xa = 0;
                P1ya = 0;
                P1yv = 0;
                int playerposX, playerposY;
                if (P1facingRight == true)
                {
                    playerposX = P1hb.X + 30 + P1spclhbOffsetX;
                    playerposY = P1hb.Y + P1spclhbOffsetY;
                }
                else
                {
                    playerposX = P1hb.X + 30 - P1spclhbOffsetX - P1spclhbX;
                    playerposY = P1hb.Y + P1spclhbOffsetY;
                }
                P1spclhb = new Rectangle(playerposX, playerposY, P1spclhbX, P1spclhbY);
            }
            if (P1spclDoesDrop == true)
            {

            }
            if (P1spclDoesHeal == true)//if special heals
            {
                P1currentHp += P1spclDmg * P1atk;//heal calc
                if(P1currentHp > P1hp)
                {
                    P1currentHp = P1hp;
                }
                P1ChpBar = new Rectangle(195, 629, (200 * P1currentHp / P1hp), 5);//refreshes hp bar
            }
        }
        private void P1spclTmr_Tick(object sender, EventArgs e) //tracks P1 special cooldown time and components that reqiure time .
        {
            if (P1spclCooltime >= P1spclCool)//if cooldown is over
            {
                P1spclTmr.Enabled = false;
                P1sklCool = false;
            }
            else
            {
                P1spclCooltime += 1;
            }
            if (P1spclActive == true)//if special is active
            {
                if (P1spclDoesSpecial == true)//if special does anything special
                {
                    switch (P1Character)
                    {
                        case "Cedric":
                            if (P1spclCooltime < 5)
                            {
                                P1spclDoesDmg = false;
                                if (P1spclCooltime == 3)//changes the way the player is facing to deliver the attack
                                {
                                    if (P1facingRight == true)
                                    {
                                        P1facingRight = false;
                                    }
                                    else
                                    {
                                        P1facingRight = true;
                                    }
                                }
                            }
                            if (P1spclCooltime == 5)
                            {
                                P1spclDoesDmg = true;
                                P1spclAtk();//fires the one-time code again to spawn attack hitboxes
                                P1spclCooltime = 5;//overrides spclAtk value changes to spclcooltime
                            }
                            if (P1spclCooltime == 18)//changes bool changes to default
                            {
                                P1spclDoesDmg = false;
                                P1trueInvince = false;
                            }
                            break;
                    }
                }
                if (P1spclDoesDmg == true)
                {
                    if (P1spclCooltime > P1spclLength)
                    {
                        P1spclhb = Rectangle.Empty;
                    }
                    if (P2hb.IntersectsWith(P1spclhb) && P2trueInvince == false)//checks for hits
                    {
                        P2spriteStatus = "TakingDamage";
                        P2xv = 0;
                        P2xa = 0;
                        P2yv = 0;
                        P2ya = 0;
                        if (P1spclDmg * P1atk - P2def > 0 && P2invince == false)//fires only once
                        {
                            P2currentHp -= P1spclDmg * P1atk;
                            P1damageDealt += P1spclDmg * P1atk;
                            P2ChpBar = new Rectangle(603 + 200 - (200 * P2currentHp / P2hp), 629, (200 * P2currentHp / P2hp), 5);
                        }
                        P2invince = true;
                        P2stunned = true;
                        P2stunTime = P1spclStun;
                        P2stunTmr.Enabled = true;
                        P2dealKnockback = false;
                    }
                }
                if (P1spclDoesDrop == true)
                {

                }
                if (P1spclCooltime > P1spclLength + 1)
                {
                    P1spclActive = false;
                }
            }
        }

        private void P2spclAtk() //set values for P2 special, fires once normally 
        {
            P2sklCool = true;
            P2spclActive = true;
            P2spclTmr.Enabled = true;
            P2spclCooltime = 0;
            if (P2spclDoesSpecial == true)
            {
                switch (P2Character)
                {
                    case "Cedric":
                        P1trueInvince = true;
                        if (P2facingRight == true)
                        {
                            P2xv = 10;
                            P2xa = 0;
                        }
                        else
                        {
                            P2xv = -10;
                            P2xa = 0;
                        }
                        break;
                }
            }
            if (P2spclDoesDmg == true)
            {
                P2xv = 0;
                P2xa = 0;
                P2ya = 0;
                P2yv = 0;
                int playerposX, playerposY;
                if (P2facingRight == true)
                {
                    playerposX = P2hb.X + 30 + P2spclhbOffsetX;
                    playerposY = P2hb.Y + P2spclhbOffsetY;
                }
                else
                {
                    playerposX = P2hb.X + 30 - P2spclhbOffsetX - P2spclhbX;
                    playerposY = P2hb.Y + P2spclhbOffsetY;
                }
                P2spclhb = new Rectangle(playerposX, playerposY, P2spclhbX, P2spclhbY);
            }
            if (P2spclDoesDrop == true)
            {

            }
            if (P2spclDoesHeal == true)
            {
                P2currentHp += P2spclDmg * P2atk;
                if (P2currentHp > P2hp)
                {
                    P2currentHp = P2hp;
                }
                P2ChpBar = new Rectangle(603 + 200 - (200 * P2currentHp / P2hp), 629, (200 * P2currentHp / P2hp), 5);
            }
        }
        private void P2spclTmr_Tick(object sender, EventArgs e) //tracks P2 special cooldown time and components that reqiure time 
        {
            if (P2spclCooltime >= P2spclCool)
            {
                P2spclTmr.Enabled = false;
                P2sklCool = false;
            }
            else
            {
                P2spclCooltime += 1;
            }
            if (P2spclActive == true)
            {
                if (P2spclDoesSpecial == true)
                {
                    switch (P2Character)
                    {
                        case "Cedric":
                            if (P2spclCooltime < 5)
                            {
                                P2spclDoesDmg = false;
                                if (P2spclCooltime == 3)
                                {
                                    if (P2facingRight == true)
                                    {
                                        P2facingRight = false;
                                    }
                                    else
                                    {
                                        P2facingRight = true;
                                    }
                                }
                            }
                            if (P2spclCooltime == 5)
                            {
                                P2spclDoesDmg = true;
                                P2spclAtk();
                                P2spclCooltime = 5;
                                if (P2facingRight == true)
                                {
                                    P2facingRight = false;
                                }
                                else
                                {
                                    P2facingRight = true;
                                }
                            }
                            if (P2spclCooltime == 18)
                            {
                                P2spclDoesDmg = false;
                                P2trueInvince = false;
                            }
                            break;
                    }
                }
                if (P2spclDoesDmg == true)
                {
                    if (P2spclCooltime > P2spclLength)
                    {
                        P2spclhb = Rectangle.Empty;
                    }
                    if (P1hb.IntersectsWith(P2spclhb) && P1trueInvince == false)
                    {
                        P1spriteStatus = "TakingDamage";
                        P1xv = 0;
                        P1xa = 0;
                        P1yv = 0;
                        P1ya = 0;
                        if (P2spclDmg * P2atk - P1def > 0 && P1invince == false)
                        {
                            P1currentHp -= P2spclDmg * P2atk;
                            P2damageDealt += P2spclDmg * P2atk;
                            P1ChpBar = new Rectangle(195, 629, (200 * P1currentHp / P1hp), 5);
                        }
                        P1invince = true;
                        P1stunned = true;
                        P1stunTime = P2spclStun;
                        P1stunTmr.Enabled = true;
                        P1dealKnockback = false;
                    }
                }
                if (P2spclDoesDrop == true)
                {

                }
                if (P2spclCooltime > P2spclLength + 1)
                {
                    P2spclActive = false;
                }
            }
        }


        //----------------------------------\\
        //            Stop Game             \\
        //----------------------------------\\

        private void StopGame()
        {
            VeloTmr.Enabled = false;
            gameOver = true;
        }


        //----------------------------------\\
        //           High Scores            \\
        //----------------------------------\\

        private void ShowLabels()
        {
            labelShown = true;
            P1nameLabel.Visible = true;
            P1nameLabel.Text = P1playerName;
            P2nameLabel.Visible = true;
            P2nameLabel.Text = P2playerName;
            P1charLbl.Visible = true;
            P1charLbl.Text = P1Character;
            P2charLbl.Visible = true;
            P2charLbl.Text = P2Character;
            P1battleResult.Visible = true;
            if (P1lives == 0)
            {
                P1battleResult.Text = "Lost";
            }
            else
            {
                P1battleResult.Text = "Won";
            }
            P2battleResult.Visible = true;
            if (P2lives == 0)
            {
                P2battleResult.Text = "Lost";
            }
            else
            {
                P2battleResult.Text = "Won";
            }
            P1dmgLabel.Visible = true;
            P1dmgLabel.Text = P1damageDealt.ToString();
            P2dmgLabel.Visible = true;
            P2dmgLabel.Text = P2damageDealt.ToString();
            if (P1currentHp < 0)
            {
                P1currentHp = 0;
            }
            if (P2currentHp < 0)
            {
                P2currentHp = 0;
            }
            if (P1lives > 0)
            {
                P1hpleft = (((P1lives - 1) * P1hp + P1currentHp) * 100) / (P1hp * 3);
            }
            else
            {
                P1hpleft = 0;
            }
            if (P2lives > 0)
            {
                P2hpleft = (((P2lives - 1) * P2hp + P2currentHp) * 100) / (P2hp * 3);
            }
            else
            {
                P2hpleft = 0;
            }
            P1hpLabel.Visible = true;
            P1hpLabel.Text = P1hpleft.ToString() + "%";
            P2hpLabel.Visible = true;
            P2hpLabel.Text = P2hpleft.ToString() + "%";
            centLbl1.Visible = true;
            centLbl2.Visible = true;
            centLbl3.Visible = true;
            centLbl4.Visible = true;
        }
        private void HideLabels()
        {
            P1nameLabel.Visible = false;
            P2nameLabel.Visible = false;
            P1charLbl.Visible = false;
            P2charLbl.Visible = false;
            P1battleResult.Visible = false;
            P2battleResult.Visible = false;
            P1dmgLabel.Visible = false;
            P2dmgLabel.Visible = false;
            P1hpLabel.Visible = false;
            P2hpLabel.Visible = false;
            centLbl1.Visible = false;
            centLbl2.Visible = false;
            centLbl3.Visible = false;
            centLbl4.Visible = false;
        }
        private void ReadHighScores()
        {
            var reader = new StreamReader(binPath);
            // While the reader still has something to read, this code will execute.
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                // Split into the name and the score.
                var values = line.Split(',');
                highScores.Add(new HighScores(values[0], Int32.Parse(values[1])));
            }
            reader.Close();
            int lowest_score = highScores[(highScores.Count - 1)].Score;
            if (P1battleResult.Text == "Won")
            {
                if (P1hpleft > lowest_score)
                {
                    highScores.Add(new HighScores(P1playerName, P1hpleft));
                    results.LbRefreshed();
                }
                else
                {
                    results.LbStatic();
                }
            }
            if (P2battleResult.Text == "Won")
            {
                if (P2hpleft > lowest_score)
                {
                    results.LbRefreshed();
                    highScores.Add(new HighScores(P2playerName, P2hpleft));
                }
                else
                {
                    results.LbStatic();
                }
            }
        }
        public void DisplayHighScores()
        {
            foreach (HighScores s in highScores)
            {
                LstBoxName.Items.Add(s.Name);
                LstBoxScore.Items.Add(s.Score);
                
            }
        }
        public void SortHighScores()
        {
            highScores = highScores.OrderByDescending(hs => hs.Score).Take(10).ToList();
        }
        public void SaveHighScores()
        {
            StringBuilder builder = new StringBuilder();
            foreach (HighScores score in highScores)
            {
                //{0} is for the Name, {1} is for the Score and {2} is for a new line
                builder.Append(string.Format("{0},{1}{2}", score.Name, score.Score, Environment.NewLine));
            }
            File.WriteAllText(binPath, builder.ToString());
        }

    }
}
