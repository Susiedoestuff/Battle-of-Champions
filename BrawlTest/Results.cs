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
    class Results
    { //loads assets for the animated components of the character selection screen
        public Image[] resultsFrame = new Image[22];
        public Image[] fadeFrame = new Image[6];
        public Image[] fadeoutFrame = new Image[6];
        public Image[] txtFrame = new Image[22];
        public Image leaderboard = Image.FromFile(Application.StartupPath + @"\Assets\Leaderboard.png");
        public Image result = Image.FromFile(Application.StartupPath + @"\Assets\Result.png");
        public Rectangle resultsSpace, fadeSpace, text, txtSpace;
        public int Frame, Fade, Fade2;
        public bool Clicked, fadeStart, fadeComplete, resultsShown;

        public Results()
        {
            resultsSpace = new Rectangle(0, 0, 1000, 750);//default sizes and values
            fadeSpace = new Rectangle(0, 0, 1000, 750);
            txtSpace = new Rectangle(-10, 50, 1000, 750);
            text = new Rectangle(326, 50, 348, 52);
            Frame = 1;
            Fade = 1;
            Fade2 = 1;
            for (int i = 1; i <= 21; i++)//creates the image files for animations
            {
                resultsFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\Results_(" + i.ToString() + ").png");
                txtFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\TitleTxt_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 5; i++)
            {
                fadeFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeSc_(" + i.ToString() + ").png");
                fadeoutFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeBlc_(" + i.ToString() + ").png");
            }
        }


        public void aniResults()
        {
            Frame += 1;//cycles between frames
            if (Frame == 22)
            {
                Frame = 1;
            }
        }
        public void transitionResults()
        {
            if (Fade <= 5)//fade in transition
            {
                Fade += 1;
            }
            else
            {
                fadeComplete = true;
                fadeSpace = Rectangle.Empty;
            }

        }
        public void fadeoutResults()
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
                    Clicked = false;
                    fadeStart = false;
                    fadeSpace = Rectangle.Empty;
                    resultsSpace = Rectangle.Empty;

                }
            }
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
        public bool resultsDone()//returns bool to Form1 to change screens
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


        public void drawResults(Graphics g)//draws background
        {
            g.DrawImage(resultsFrame[Frame], resultsSpace);
            g.DrawImage(txtFrame[Frame], txtSpace);
            if (resultsShown == false)
            {
                g.DrawImage(leaderboard, text);
            }
            else
            {
                g.DrawImage(result, text);
            }
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
        }
    }
}
