using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class DisplayPanel : UserControl
    {
        public DisplayPanel()
        {
            InitializeComponent();
            lavirint = new int[brojVrsta][];
            lavirintPoruke = new String[brojVrsta][];
            for (int i = 0; i < brojVrsta; i++)
            {
                lavirint[i] = new int[brojKolona];
                lavirintPoruke[i] = new String[brojKolona];
            }
            boxIcons = new List<BoxIcon>();
            boxImg = Properties.Resources.garbage;
            robotImg = Properties.Resources.robot2;
        }

        int markI = 0;
        int markJ = 0;


        public int brojVrsta =10;
        public int brojKolona =10;
        public int[][] lavirint;        // 0- prazno, 1- zid, 2- zeleno, 3 - cilj - 4 - robot
        public String[][] lavirintPoruke;



        public List<BoxIcon> boxIcons;
        
        
        Image boxImg = null;
        
        public int robotIconI = 0;
        public int robotIconJ = 0;
        Image robotImg = null;

        public void resetLavirintPoruke() {
            lavirintPoruke = new String[brojVrsta][];
            for (int i = 0; i < brojVrsta; i++)
            {
                lavirintPoruke[i] = new String[brojKolona];
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            gr.FillRectangle(Brushes.White, this.ClientRectangle);

            Rectangle rec = this.ClientRectangle;

            // nacrtaj grid
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / brojKolona);
            int dy = (int)(height / brojVrsta);

            Color c = Color.FromArgb(40, Color.Gray);
            for (int j = 0; j < brojKolona; j++)
            {
                int xx = dx * j;
                int y0 = 0;
                int yH = height;
                gr.DrawLine(new Pen(c, 1), xx, y0, xx, yH);
            }
            c = Color.FromArgb(40, Color.Gray);
            for (int i = 0; i < brojVrsta; i++)
            {
                int yy = dy * i;
                int x0 = 0;
                int xH = width;
                gr.DrawLine(new Pen(c, 1), x0, yy, xH, yy);
            }

            for (int i = 0; i < brojVrsta; i++)
            {
                for (int j = 0; j < brojKolona; j++)
                {
                    int xx = (int)(dx / 2) + dx * j;
                    int yy = (int)(dy / 2) + dy * i;

                    Font f = new Font(FontFamily.GenericSerif, 8);
                    Rectangle r = new Rectangle(dx * j + 2, dy * i + 2, dx - 4, dy - 4);
                    Color cc1 = Color.FromArgb(100, Color.White);
                    Color cc2 = Color.FromArgb(100, Color.White);
                    if (i == markI && j == markJ)
                    {
                        cc1 = Color.FromArgb(100, Color.YellowGreen);
                        cc2 = Color.FromArgb(20, Color.YellowGreen);
                    }
                    int tt = lavirint[i][j];
                    switch (tt)
                    {
                        case 1:
                            cc2 = Color.FromArgb(100, Color.Gray);          //zid
                            break;
                        case 2:
                            cc2 = Color.FromArgb(100, Color.Green);     //pocetno stanje kutije
                            break;
                        case 3:
                            cc2 = Color.FromArgb(100, Color.Red);           //cilj kutije
                            break;
                        case 4:
                            cc2 = Color.FromArgb(100, Color.Blue);      //pocetno stanje robota
                            break;
                    }
                    String ttS = lavirintPoruke[i][j];
                    gr.FillRectangle(new SolidBrush(cc2), r);
                    gr.DrawRectangle(new Pen(cc1, 2), r);
                    SizeF sf = gr.MeasureString("" + ttS, f);
                    gr.DrawString("" + ttS, f, Brushes.Black, xx - sf.Width / 2, yy - sf.Height / 2);
                }
            }

            // nacrtati kutiju
            foreach (BoxIcon b in boxIcons)
            {
                gr.DrawImage(boxImg, dx * b.j + dx / 2 - boxImg.Width / 2, dy * b.i + dy / 2 - boxImg.Height / 2);
            }
            
            // nacrtati robota
            gr.DrawImage(robotImg, dx * robotIconJ + dx / 2 - boxImg.Width / 2, dy * robotIconI + dy / 2 - boxImg.Height / 2);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int eX = e.X;
            int eY = e.Y;
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / brojKolona);
            int dy = (int)(height / brojVrsta);

            int j = eX / dx;
            int i = eY / dy;

            if (markI != i || markJ != j)
            {
                int sMarkI = markI;
                int sMarkJ = markJ;
                markI = i;
                markJ = j;
                InvalidateAdv(markI, markJ);
                InvalidateAdv(sMarkI, sMarkJ);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int eX = e.X;
            int eY = e.Y;
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / brojKolona);
            int dy = (int)(height / brojVrsta);

            int j = eX / dx;
            int i = eY / dy;
            int tt = lavirint[i][j];
            switch (tt)
            {
                case 0:
                    tt = 1;
                    break;
                case 1:
                    tt = 2;
                    break;
                case 2:
                    tt = 3;
                    break;
                case 3:
                    tt = 4;
                    break;
                case 4:
                    tt = 0;
                    break;
            }                    

            lavirint[i][j] = tt;
            InvalidateAdv(i, j);
        }

        public bool moveBoxIcon(BoxIcon b,int dI, int dJ)
        {
            int nI = b.i + dI;
            int nJ = b.j + dJ;
            if (nI < 0)
                nI = 0;// brojVrsta - 1;
            if (nI > brojVrsta - 1)
                nI = brojVrsta - 1;// 0;
            if (nJ < 0)
                nJ = 0;// brojKolona - 1;
            if (nJ > brojKolona - 1)
                nJ = brojKolona - 1;//0;
            int sIconI = b.i;
            int sIconJ = b.j;
            // ovaj deo je da se spreci prolazak kroz zidove
            if (lavirint[nI][nJ] != 1) {
                b.i = nI;
                b.j = nJ;
                InvalidateAdv(b.i, b.j);
                InvalidateAdv(sIconI, sIconJ);
                return true;
            }
            return false;
        }

        public void moveRobotIcon(int dI, int dJ)
        {
            int nI = robotIconI + dI;
            int nJ = robotIconJ + dJ;
            if (nI < 0)
                nI = 0;// brojVrsta - 1;
            if (nI > brojVrsta - 1)
                nI = brojVrsta - 1;// 0;
            if (nJ < 0)
                nJ = 0;// brojKolona - 1;
            if (nJ > brojKolona - 1)
                nJ = brojKolona - 1;//0;
            int sIconI = robotIconI;
            int sIconJ = robotIconJ;
            // ovaj deo je da se spreci prolazak kroz zidove
            foreach (BoxIcon b in boxIcons)
            {
                if (nI == b.i && nJ == b.j)
                {
          //          if (moveBoxIcon(b,dI, dJ))
           //         {
                        moveBoxIcon(b, dI, dJ);
                        robotIconI = nI;
                        robotIconJ = nJ;
                        InvalidateAdv(robotIconI, robotIconJ);
                        InvalidateAdv(sIconI, sIconJ);
              //      }
                }
                else if (lavirint[nI][nJ] != 1)
                {
                    robotIconI = nI;
                    robotIconJ = nJ;
                    InvalidateAdv(robotIconI, robotIconJ);
                    InvalidateAdv(sIconI, sIconJ);
                }
            }
           
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           if (keyData == Keys.A) //robot left
            {
                moveRobotIcon(0, -1);
                return true;
            }
            else if (keyData == Keys.D)
            {
                moveRobotIcon(0, 1);
                return true;
            }
            else if (keyData == Keys.S)
            {
                moveRobotIcon(1, 0);
                return true;
            }
            else if (keyData == Keys.W)
            {
                moveRobotIcon(-1, 0);
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public void InvalidateAdv(int i, int j)
        {
            Rectangle rec = this.ClientRectangle;
            int width = rec.Width;
            int height = rec.Height;
            int dx = (int)(width / brojKolona);
            int dy = (int)(height / brojVrsta);
            Rectangle tt1 = new Rectangle(j * dx, i * dy, dx, dy);
            this.Invalidate(tt1);
        }


        

    }
}
