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
    class CharSel
    {
        //loads assets for the animated components of the character selection screen
        public Image[] charSelFrame = new Image[22];
        public Image[] fadeFrame = new Image[6];
        public Image[] fadeoutFrame = new Image[6];
        public Image[] selFrame1 = new Image[7];
        public Image[] selFrame2 = new Image[7];
        public Image[] charIcons = new Image[17];
        public Rectangle charSelSpace, fadeSpace, selSpace1, selSpace2, blackSpace;
        public Rectangle[] charIconSpace = new Rectangle[17];
        public int Frame, Fade, Fade2, Choser;
        public int charNum1, charNum2;
        public string[] Char = new string[17];
        public bool Clicked, Flash, fadeStart, fadeComplete;
        public string status;

        public CharSel()
        {
            charSelSpace = new Rectangle(0, 0, 1000, 750);//default sizes and values
            fadeSpace = new Rectangle(0, 0, 1000, 750);
            selSpace2 = new Rectangle(188, 76, 124, 124);
            Frame = 1;
            Fade = 1;
            Fade2 = 1;
            Choser = 1;
            charNum1 = 1;
            charNum2 = 2;
            fadeComplete = false;

            if (charNum1 <= 8 ) { selSpace1 = new Rectangle(charNum1 * 100 - 12 , 76, 124, 124);  }
            else {  selSpace1 = new Rectangle((charNum1-8) * 100 - 12, 176, 124, 124); }
            if (charNum2 <= 8) { selSpace2 = new Rectangle(charNum2 * 100 - 12, 76, 124, 124); }
            else { selSpace2 = new Rectangle((charNum2 - 8) * 100 - 12, 176, 124, 124); }

            for (int i = 1; i <= 21; i++)//creates the image files for animations
            {
                charSelFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\CharSel_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 5; i++)
            {
                fadeFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeSc_(" + i.ToString() + ").png");
                fadeoutFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeBlc_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 6; i++)
            {
                selFrame1[i] = Image.FromFile(Application.StartupPath + @"\Assets\Choser1_(" + i.ToString() + ").png");
                selFrame2[i] = Image.FromFile(Application.StartupPath + @"\Assets\Choser2_(" + i.ToString() + ").png");
            }
            readCharlist();
            for (int i = 1; i <= 16; i++)
            {
                try
                {
                    charIcons[i] = Image.FromFile(Application.StartupPath + @"\Sprites\" + Char[i].ToString() + "_Icon.png");
                }
                catch (Exception)
                {
                    charIcons[i] = Image.FromFile(Application.StartupPath + @"\Assets\ComingSoon_Icon.png");
                }
            }
            for (int i = 1; i <= 8; i++)
            {
                charIconSpace[i] = new Rectangle(i*100, 88, 100, 100);
            }
            for (int i = 9; i <= 16; i++)
            {
                charIconSpace[i] = new Rectangle((i-8) * 100, 188, 100, 100);
            }

        }

        public string p1char()
        {
            return Char[charNum1];
        }
        public string p2char()
        {
            return Char[charNum2];
        }

        public void aniCharSel()
        {
            Frame += 1;//cycles between frames
            Choser += 1;
            if (Frame == 22)
            {
                Frame = 1;
            }
            if (Choser == 7)
            {
                Choser = 1;
            }
        }
        public void transitionCharSel()
        {
            if (Fade <= 5)//fade in transition
            {
                Fade += 1;
            }
            else
            {
                fadeComplete = true;
            }

        }
        public void fadeoutCharSel()
        {
            if (Clicked == true)
            {
                if (Fade2 <= 5)
                {
                    Fade2 += 1;
                    fadeStart = true; 
                }
                if (Fade2 == 5)
                {
                    blackSpace = new Rectangle(0, 0, 1000, 750);
                    Clicked = false;
                    fadeStart = false;
                }
            }
        }

        public void toRules()
        {
            fadeSpace = new Rectangle(0, 0, 1000, 750);
            status = "Rules";
            Clicked = true;
        }
        public void charselEmpty()
        {
            charSelSpace = Rectangle.Empty;
            selSpace1 = Rectangle.Empty;
            selSpace2 = Rectangle.Empty;
            for (int i = 1; i <= 16; i++)
            {
                charIconSpace[i] = Rectangle.Empty;
            }
            fadeSpace = Rectangle.Empty;
            blackSpace = Rectangle.Empty;
        }


        public string statuscharsel()
        {
            return status;
        }


        public bool transitionDone()//returns bool to Form1 to change screens
        {
            if (fadeComplete == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool charselDone()//returns bool to Form1 to change screens
        {
            if (Fade2 == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void readCharlist()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\Characters\Champions.txt");
            for (int i = 1; i <= 16; i++)
            {
                try
                {
                    string line = File.ReadLines(Application.StartupPath + @"\Characters\Champions.txt").ElementAt(i);
                    Char[i] = line;
                }
                catch (Exception)
                {
                    file.Close();
                }
                if (Char[i] == null)
                {
                    Char[i] = "nocharacter";
                }
            }
        }

        public void drawCharSel(Graphics g)//draws background
        {
            g.DrawImage(charSelFrame[Frame], charSelSpace);
            for (int i = 1; i <= 16; i++)
            {
                g.DrawImage(charIcons[i], charIconSpace[i]);
            }
            g.DrawImage(selFrame1[Choser], selSpace1);
            g.DrawImage(selFrame2[Choser], selSpace2);
        }
        public void drawFade(Graphics g)//draws fade
        {
            if (Fade <= 5)
            {
                g.DrawImage(fadeFrame[Fade], fadeSpace);
            }
        }
        public void drawFadeout(Graphics g)//draws fade
        {
            if (Fade2 <= 5 && fadeStart == true)
            {
                g.DrawImage(fadeoutFrame[Fade2], fadeSpace);
            }
            g.DrawImage(fadeoutFrame[5], blackSpace);
        }


        //moving the selection box
        public void moveSelLeft1()
        {
            if(selSpace1.X > 88)
            { selSpace1.X -= 100; charNum1 -= 1; }
            else if( selSpace1.X == 88 && selSpace1.Y == 176)
            { selSpace1 = new Rectangle(788, 76, 124, 124); charNum1 -= 1; }

        }
        public void moveSelRight1()
        {
            if (selSpace1.X < 788)
            { selSpace1.X += 100; charNum1 += 1; }
            else if (selSpace1.X == 788 && selSpace1.Y == 76)
            { selSpace1 = new Rectangle(88, 176, 124, 124); charNum1 += 1; }
        }
        public void moveSelUp1()
        { 
            if(selSpace1.Y == 176)
            { selSpace1.Y -= 100; charNum1 -= 8; }
        }
        public void moveSelDown1()
        {
            if (selSpace1.Y == 76)
            { selSpace1.Y += 100; charNum1 += 8; }
        }

        public void moveSelLeft2()
        {
            if (selSpace2.X > 88)
            { selSpace2.X -= 100; charNum2 -= 1; }
            else if (selSpace2.X == 88 && selSpace2.Y == 176)
            { selSpace2 = new Rectangle(788, 76, 124, 124); charNum2 -= 1; }

        }
        public void moveSelRight2()
        {
            if (selSpace2.X < 788)
            { selSpace2.X += 100; charNum2 += 1; }
            else if (selSpace2.X == 788 && selSpace2.Y == 76)
            { selSpace2 = new Rectangle(88, 176, 124, 124); charNum2 += 1; }
        }
        public void moveSelUp2()
        {
            if (selSpace2.Y == 176)
            { selSpace2.Y -= 100; charNum2 -= 8; }
        }
        public void moveSelDown2()
        {
            if (selSpace2.Y == 76)
            { selSpace2.Y += 100; charNum2 += 8; }
        }
    }
}
