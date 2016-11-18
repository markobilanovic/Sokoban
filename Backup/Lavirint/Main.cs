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

namespace Lavirint
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            btnLoad_Click(null, null);
            inicijalizacijaPretrage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("../../lavirint.txt");            
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
            TextReader tw = new StreamReader("../../lavirint.txt");
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

        State pocetnoStanje = null;
        State krajnjeStanje = null;
        
        private void inicijalizacijaPretrage() {
            displayPanel1.resetLavirintPoruke();
            for (int i = 0; i < displayPanel1.brojVrsta; i++)
            {
                for (int j = 0; j < displayPanel1.brojKolona; j++)
                { 
                    int tt = displayPanel1.lavirint[i][j];
                    if (tt == 2) { // POCETNO STANJE
                        pocetnoStanje = new State();
                        pocetnoStanje.vrsta = i;
                        pocetnoStanje.kolona = j;
                        displayPanel1.iconI = i;
                        displayPanel1.iconJ = j;
                    }else if (tt == 3)
                    { // KRAJNJE STANJE
                        krajnjeStanje = new State();
                        krajnjeStanje.vrsta = i;
                        krajnjeStanje.kolona = j;
                    }
                }
            }
        }

        List<State> resenje = new List<State>();
        private void btnResenje_Click(object sender, EventArgs e)
        {
            displayPanel1.resetLavirintPoruke();
            // nacrtati resenje
            int i = 0;
            foreach (State r in resenje)
            {
                displayPanel1.lavirintPoruke[r.vrsta][r.kolona] = "" + i;
                i++;
            }
            displayPanel1.Refresh();
        }

        private void btnPrviUDubinu_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            Hashtable obradjeni = new Hashtable();
            List<State> zaObradu = new List<State>();
            obradjeni.Add(pocetnoStanje.kljuc(), pocetnoStanje);
            zaObradu.Add(pocetnoStanje);
            lblStatus.Text = "Resavanje u toku!";
            int korak = 0;
            while (zaObradu.Count > 0)
            {
                State top = zaObradu[0];
                zaObradu.RemoveAt(0);
                List<State> mogucaSledecaStanja = top.mogucaSledecaStanja(displayPanel1);
                foreach (State st in mogucaSledecaStanja)
                {
                    if (st.vrsta == krajnjeStanje.vrsta && 
                        st.kolona == krajnjeStanje.kolona)
                    {
                        resenje = new List<State>();
                        State tekuci = st;
                        while (tekuci != null)
                        {
                            resenje.Insert(0, tekuci);
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
                        korak++;
                        displayPanel1.lavirintPoruke[st.vrsta][st.kolona] = "" + korak + "/" + st.nivo;
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
            List<State> zaObradu = new List<State>();
            obradjeni.Add(pocetnoStanje.kljuc(), pocetnoStanje);
            zaObradu.Add(pocetnoStanje);
            lblStatus.Text = "Resavanje u toku!";
            int korak = 0;
            while (zaObradu.Count > 0)
            {
                korak++;
                State top = zaObradu[0];
                displayPanel1.lavirintPoruke[top.vrsta][top.kolona] = "" + korak + "/" + top.nivo;
                zaObradu.RemoveAt(0);
                List<State> mogucaSledecaStanja = top.mogucaSledecaStanja(displayPanel1);
                foreach (State st in mogucaSledecaStanja)
                {
                    if (st.vrsta == krajnjeStanje.vrsta &&
                        st.kolona == krajnjeStanje.kolona)
                    {
                        resenje = new List<State>();
                        State tekuci = st;
                        while (tekuci != null)
                        {
                            resenje.Insert(0, tekuci);
                            tekuci = tekuci.parent;
                        }

                        lblStatus.Text = "Reseno!";
                        displayPanel1.Refresh();
                        return;
                    }

                    if (!obradjeni.ContainsKey(st.kljuc()))
                    {
                        obradjeni.Add(st.kljuc(), st);
                        //zaObradu.Insert(0, st);
                        zaObradu.Add(st);
                    }
                }
            }
            displayPanel1.Refresh();
            lblStatus.Text = "Nije reseno!";
        }

        private void btnBidirekciona_Click(object sender, EventArgs e)
        {
            inicijalizacijaPretrage();
            Hashtable obradjeni = new Hashtable();
            List<State> zaObradu = new List<State>();


            Hashtable obradjeniK = new Hashtable();
            List<State> zaObraduK = new List<State>();


            obradjeni.Add(pocetnoStanje.kljuc(), pocetnoStanje);
            zaObradu.Add(pocetnoStanje);

            obradjeniK.Add(krajnjeStanje.kljuc(), krajnjeStanje);
            zaObraduK.Add(krajnjeStanje);

            
            lblStatus.Text = "Resavanje u toku!";
            int korak = 0;
            while (zaObradu.Count > 0 || zaObraduK.Count>0)
            {
                korak++;
                #region obrada od pocetnog prema krajnjem stanju 
                if (zaObradu.Count > 0)
                {
                    State top = zaObradu[0];
                    displayPanel1.lavirintPoruke[top.vrsta][top.kolona] = "" + korak + "/" + top.nivo;
                    zaObradu.RemoveAt(0);
                    List<State> mogucaSledecaStanja = top.mogucaSledecaStanja(displayPanel1);
                    foreach (State st in mogucaSledecaStanja)
                    {
                        if (obradjeniK.ContainsKey(st.kljuc()))
                        {
                            resenje = new List<State>();
                            State tekuci = st;
                            // ispis od zajednickog do pocetnog
                            while (tekuci != null)
                            {
                                resenje.Insert(0, tekuci);
                                tekuci = tekuci.parent;
                            }// while
                            tekuci = (State)obradjeniK[st.kljuc()];
                            // ispis od tekuceg do krajnjeg
                            while (tekuci != null)
                            {
                                resenje.Add(tekuci);
                                tekuci = tekuci.parent;
                            }//while
                            lblStatus.Text = "Reseno!";
                            displayPanel1.Refresh();
                            return;
                        }// if reseno

                        if (!obradjeni.ContainsKey(st.kljuc()))
                        {
                            obradjeni.Add(st.kljuc(), st);
                            //zaObradu.Insert(0, st);
                            zaObradu.Add(st);
                        }// if !obradjeno
                    }// foreach moguca sledeca stanja
                }// if
                #endregion

                #region obrada od krajnjeg prema pocetnom stanju
                if (zaObraduK.Count > 0)
                {
                    State top = zaObraduK[0];
                    displayPanel1.lavirintPoruke[top.vrsta][top.kolona] = "" + korak + "/" + top.nivo;
                    zaObraduK.RemoveAt(0);
                    List<State> mogucaSledecaStanja = top.mogucaSledecaStanja(displayPanel1);
                    foreach (State st in mogucaSledecaStanja)
                    {
                        if (obradjeni.ContainsKey(st.kljuc()))
                        {
                            resenje = new List<State>();
                            State tekuci = st;
                            // ispis od zajednickog do krajnjeg
                            while (tekuci != null)
                            {
                                resenje.Add(tekuci);
                                tekuci = tekuci.parent;
                            }// while
                            tekuci = (State)obradjeni[st.kljuc()];
                            // ispis od tekuceg do pocetnog
                            while (tekuci != null)
                            {
                                resenje.Insert(0, tekuci);
                                tekuci = tekuci.parent;
                            }//while
                            lblStatus.Text = "Reseno!";
                            displayPanel1.Refresh();
                            return;
                        }// if reseno

                        if (!obradjeniK.ContainsKey(st.kljuc()))
                        {
                            obradjeniK.Add(st.kljuc(), st);
                            //zaObradu.Insert(0, st);
                            zaObraduK.Add(st);
                        }// if !obradjeno
                    }// foreach moguca sledeca stanja
                }// if
                #endregion
            
            }
            displayPanel1.Refresh();
            lblStatus.Text = "Nije reseno!";

        }
    
    
    }
}
