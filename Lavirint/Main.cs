using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Threading;
using System.Reflection;

namespace Sokoban
{
    public partial class Main : Form
    {
        private int forLoad;
        private string loadedFile;

        public Main()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(1500);

            InitializeComponent();
            t.Abort();
            forLoad = 0;
            btnLoad_Click(null, null);
            inicijalizacijaPretrage();
        }

        public void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter(loadedFile);            
            tw.WriteLine(displayPanel1.brojKolona);
            tw.WriteLine(displayPanel1.brojVrsta);
            for (int i = 0; i < displayPanel1.brojVrsta; i++)
            {
                for (int j = 0; j < displayPanel1.brojKolona; j++)
                {
                    tw.WriteLine(displayPanel1.lavirint[i][j]);
                }
            }
            tw.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {


            TextReader tw = null;
            if (forLoad != 0)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.txt)|*.txt";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    tw = new StreamReader(open.FileName);
                    loadedFile = open.FileName;
                }
                else
                {
                    tw = new StreamReader("../../lavirint.txt");
                    loadedFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    loadedFile = loadedFile.Remove(loadedFile.Length - 9);
                    loadedFile = loadedFile + "lavirint.txt";
                }
            }
            else
            {
                tw = new StreamReader("../../lavirint.txt");
                loadedFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                loadedFile = loadedFile.Remove(loadedFile.Length - 9);
                loadedFile = loadedFile + "lavirint.txt";
            }
            forLoad = 1;
            this.SuspendLayout();
            displayPanel1.brojKolona = Convert.ToInt32(tw.ReadLine());
            displayPanel1.brojVrsta = Convert.ToInt32(tw.ReadLine());
            for (int i = 0; i < displayPanel1.brojVrsta; i++)
            {
                for (int j = 0; j < displayPanel1.brojKolona; j++)
                {
                    int tt = Convert.ToInt32(tw.ReadLine());
                    displayPanel1.lavirint[i][j] = tt;
                }
            }
            tw.Close();
            this.ResumeLayout(false);
            displayPanel1.Refresh();
        }

        List<Box> pocetnoStanjeBox = new List<Box>();
        List<Box> krajnjeStanjeBox = new List<Box>();
        List<Box> trenutnaStanjaKutija = new List<Box>();
     
        Robot pocetnoStanjeRobot = null;
        int brPocetnihStanja = 0;
        List<Box> resenjeBox = new List<Box>();
        List<Robot> resenjeRobot = new List<Robot>();

        
       
        
        private void inicijalizacijaPretrage() {
            displayPanel1.resetLavirintPoruke();
            pocetnoStanjeBox.Clear();
            krajnjeStanjeBox.Clear();
            displayPanel1.boxIcons.Clear();
            for (int i = 0; i < displayPanel1.brojVrsta; i++)
            {
                for (int j = 0; j < displayPanel1.brojKolona; j++)
                { 
                    int tt = displayPanel1.lavirint[i][j];
                    if (tt == 2) { // POCETNO STANJE                //ZELENO POLJE
                        pocetnoStanjeBox.Add(new Box(displayPanel1,i,j));
                        
                        displayPanel1.boxIcons.Add(new BoxIcon(i, j));
                        brPocetnihStanja++;
                        
                    }else if (tt == 3)                      //CRVENO POLJE
                    { // KRAJNJE STANJE  
                        krajnjeStanjeBox.Add(new Box(displayPanel1,i,j));

                    }
                   
                }
            }

            for (int i = 0; i < displayPanel1.brojVrsta; i++)       //da bi robotu dodelio sva trenutna mesta kutija, mora da se u iteraciji kasnije dodeli
            {
                for (int j = 0; j < displayPanel1.brojKolona; j++)
                {
                    int tt = displayPanel1.lavirint[i][j];
                    if (tt == 4)
                    {                           //PLAVO POLJE
                        pocetnoStanjeRobot = new Robot(pocetnoStanjeBox);
                        pocetnoStanjeRobot.vrsta = i;
                        pocetnoStanjeRobot.kolona = j;
                        displayPanel1.robotIconI = i;
                        displayPanel1.robotIconJ = j;
                    }
                }
            }
        }



        public void moveRobot()
        {
            int i = 0;
            foreach (Robot r in resenjeRobot)
            {   
                if(i!=0)
                    displayPanel1.moveRobotIcon(r.vrsta - displayPanel1.robotIconI, r.kolona - displayPanel1.robotIconJ);
                    displayPanel1.lavirintPoruke[r.vrsta][r.kolona] = "" + i;
                    displayPanel1.Refresh();
                    System.Threading.Thread.Sleep(250);
                    i++;
            }
        }
        
        private void btnResenje_Click(object sender, EventArgs e)
        {
            displayPanel1.resetLavirintPoruke();
            int i = 0;
            foreach (Robot r in resenjeRobot)
            {
   //             displayPanel1.lavirintPoruke[r.vrsta][r.kolona] += " " + i;
                i++;
            }
            lblStatus.Text += " " + i.ToString() + " koraka";
            displayPanel1.Refresh();
            moveRobot();
            
        }

        private void btnPrviUDubinu_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Resavanje u toku!";
            inicijalizacijaPretrage();
            Hashtable obradjeni = new Hashtable();
            List<Robot> zaObradu = new List<Robot>();           //nalazi se front, tj one koji tek treba da se obradjuju
            obradjeni.Add(pocetnoStanjeRobot.kljuc(), pocetnoStanjeRobot);
            zaObradu.Add(pocetnoStanjeRobot);
            
            int korak = 0;
            while (zaObradu.Count > 0)
            {
                
                korak++;
                Robot top = zaObradu[0];        //skidamo sa vrha
                displayPanel1.lavirintPoruke[top.vrsta][top.kolona] = "" + korak + "/" + top.nivo;
                zaObradu.RemoveAt(0);
                List<Robot> mogucaSledecaStanja = top.mogucaSledecaStanja(displayPanel1);
                foreach (Robot st in mogucaSledecaStanja)
                {
                    int preostalihZavrsnihMesta = krajnjeStanjeBox.Count;
                    foreach (Box endBox in krajnjeStanjeBox)
                    {
                        foreach (Box currentBoxPosition in st.trenutnePozicijeKutija)
                        {
                            if (currentBoxPosition.vrsta == endBox.vrsta && currentBoxPosition.kolona == endBox.kolona)
                            {
                                preostalihZavrsnihMesta--;
                            }
                        }
                    }

                    if (preostalihZavrsnihMesta == 0)
                    {
                        resenjeRobot = new List<Robot>();
                        Robot tekuci = st;
                        while (tekuci != null)
                        {
                            resenjeRobot.Insert(0, tekuci);
                            tekuci = tekuci.parent;
                        }

                        lblStatus.Text = "Reseno!";
                        displayPanel1.Refresh();
                        return;
                    }

                    if (!obradjeni.ContainsKey(st.kljuc()))
                    {
                        obradjeni.Add(st.kljuc(), st);
                        zaObradu.Insert(0, st);
                       // zaObradu.Add(st);//ubacimo ga u listu za obradu
                    }
                }
            }
            displayPanel1.Refresh();
            lblStatus.Text = "Nije reseno!";
        }

        private void btnPrviUSirinu_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            Hashtable obradjeni = new Hashtable();
            List<Robot> zaObradu = new List<Robot>();           //nalazi se front, tj one koji tek treba da se obradjuju
            obradjeni.Add(pocetnoStanjeRobot.kljuc(), pocetnoStanjeRobot);
            zaObradu.Add(pocetnoStanjeRobot);
            lblStatus.Text = "Resavanje u toku!";
            int korak = 0;
            while (zaObradu.Count > 0)
            {

                korak++;
                Robot top = zaObradu[0];        //skidamo sa vrha
                displayPanel1.lavirintPoruke[top.vrsta][top.kolona] = "" + korak + "/" + top.nivo;
                zaObradu.RemoveAt(0);
                List<Robot> mogucaSledecaStanja = top.mogucaSledecaStanja(displayPanel1);
                foreach (Robot st in mogucaSledecaStanja)
                {
                    int preostalihZavrsnihMesta = krajnjeStanjeBox.Count;
                    foreach (Box endBox in krajnjeStanjeBox)
                    {
                        foreach (Box currentBoxPosition in st.trenutnePozicijeKutija)
                        {
                            if (currentBoxPosition.vrsta == endBox.vrsta && currentBoxPosition.kolona == endBox.kolona)
                            {
                                preostalihZavrsnihMesta--;
                            }
                        }
                    }

                    if (preostalihZavrsnihMesta == 0)
                    {
                        resenjeRobot = new List<Robot>();
                        Robot tekuci = st;
                        while (tekuci != null)
                        {
                            resenjeRobot.Insert(0, tekuci);
                            tekuci = tekuci.parent;
                        }

                        lblStatus.Text = "Reseno!";
                        displayPanel1.Refresh();
                        return;
                    }

                    if (!obradjeni.ContainsKey(st.kljuc()))
                    {
                        obradjeni.Add(st.kljuc(), st);
                       // zaObradu.Insert(0, st);
                        zaObradu.Add(st);//ubacimo ga u listu za obradu
                    }
                }
            }
            displayPanel1.Refresh();
            lblStatus.Text = "Nije reseno!";
        }

        private void oAutoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OAutoru autor = new OAutoru();
            autor.ShowDialog();
        }

    
    }
}
