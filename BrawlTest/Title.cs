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
    class Title
    {
        //loads assets for the animated components of the title screen
        public Image[] fadeFrame = new Image[5];
        public Image[] titleFrame = new Image[22];
        public Image[] txtFrame = new Image[22];
        public Rectangle titleSpace, txtSpace, fadeSpace;
        public int Frame, Frame2, Fade, Fade2;
        public bool Clicked, Flash, fadeStart;

        public Title()
        {
            titleSpace = new Rectangle(0, 0, 1000, 750);//sets image size
            txtSpace = new Rectangle(0, 0, 1000, 750);
            fadeSpace = new Rectangle(0, 0, 1000, 750);
            Flash = true;//sets default values
            Frame = 1;
            Frame2 = 1;
            Fade = 1;
            Fade2 = 1;
            Clicked = false;
            for (int i = 1; i <= 21; i++)//creates the image files for animations
            {
                titleFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\Title_(" + i.ToString() + ").png");
                txtFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\TitleTxt_(" + i.ToString() + ").png");
            }
            for (int i = 1; i <= 4; i++)
            {
                fadeFrame[i] = Image.FromFile(Application.StartupPath + @"\Assets\FadeBlc_(" + i.ToString() + ").png");
            }
        }

        public void aniTitle()
        {
            Frame += 1;//cycles between frames
            if (Frame == 22)
            {
                Frame = 1;
            }

            if (Clicked == false)//normal cycle of text
            {
                Frame2 += 1;
                if (Frame2 == 22)
                {
                    Frame2 = 1;
                }
            }
            else//text flashes after key is pressed
            {
                if(Flash == true)
                {
                    Frame2 = 1;
                    Flash = false;
                }
                else
                {
                    Frame2 = 11;
                    Flash = true;
                }
            }
        }

        public void drawTitle(Graphics g)//draws everything
        {
            g.DrawImage(titleFrame[Frame], titleSpace);
            g.DrawImage(txtFrame[Frame2], txtSpace);
            if (fadeStart == true)
            {
                g.DrawImage(fadeFrame[Fade2], fadeSpace);
            }
        }

        public void transitionTitle()//processes transition to character selection
        {
            if(Clicked == true)
            {
                if(Fade >= 4 && Fade <= 8)
                {
                    fadeStart = true;
                    Fade2 += 1;
                }
                Fade += 1;
                if(Fade == 8)
                {
                    Clicked = false;
                    fadeStart = false;
                    titleSpace = Rectangle.Empty;
                    txtSpace = Rectangle.Empty;
                    fadeSpace = Rectangle.Empty;
                }
            }
        }
        
        public bool titleDone()//returns bool to Form1 to change screens
        {
            if(Fade == 8)
            { 
                return true; 
            }
            else
            {
                return false;
            }
        }

        public void triggerTransition()//starts transition process
        {
            Clicked = true;
        }


    }
}
