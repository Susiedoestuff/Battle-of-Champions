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
    class Rules
    {
        //loads assets for the animated components of the character selection screen
        public Image[] ruleFrame = new Image[22];
        public Image[] fadeFrame = new Image[6];
        public Image[] fadeoutFrame = new Image[6];
        public Rectangle ruleSpace, fadeSpace;
        public int Frame, Fade, Fade2;
        public bool Clicked, fadeStart, fadeComplete;

        public Rules()
        {
            ruleSpace = new Rectangle(0, 0, 1000, 750);//default sizes and values
            fadeSpace = new Rectangle(0, 0, 1000, 750);
            Frame = 1;
            Fade = 1;
            Fade2 = 1;
            for (int i = 1; i <= 21; i++)//creates the image files for animations
            {
                ruleFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\Rules_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 5; i++)
            {
                fadeFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeSc_(" + i.ToString() + ").png");
                fadeoutFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeBlc_(" + i.ToString() + ").png");
            }

        }



        public void AniRules()
        {
            Frame += 1;//cycles between frames
            if (Frame == 22)
            {
                Frame = 1;
            }
        }
        public void TransitionRules()
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
        public void FadeoutRules()
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
                    ruleSpace = Rectangle.Empty;

                }
            }
        }

        public void ToCharsel()
        {
            fadeSpace = new Rectangle(0, 0, 1000, 750);
            Clicked = true;
        }

        public bool TransitionDone()//returns bool to Form1 to change screens
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
        public bool RulesDone()//returns bool to Form1 to change screens
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


        public void DrawRules(Graphics g)//draws background
        {
            g.DrawImage(ruleFrame[Frame], ruleSpace);
        }
        public void DrawFade(Graphics g)//draws fade
        {
            if (Fade <= 5)
            {
                g.DrawImage(fadeFrame[Fade], fadeSpace);
            }
        }
        public void DrawFadeout(Graphics g)//draws fade
        {
            if (Fade2 <= 5 && fadeStart == true)
            {
                g.DrawImage(fadeoutFrame[Fade2], fadeSpace);
            }
        }
    }
}
