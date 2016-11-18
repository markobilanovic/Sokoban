using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class Robot
    {

        #region Informacioni deo
        public int vrsta;
        public int kolona;
        public List<Box> trenutnePozicijeKutija;
        #endregion

        #region deo za stablo pretrazivanja
        public Robot parent;
        public int nivo = 0;
        
        #endregion

        public Robot(List<Box> pozicijeKutija)
        {
            trenutnePozicijeKutija = new List<Box>(pozicijeKutija);
        }


        public List<Robot> mogucaSledecaStanja(DisplayPanel panel)
        {
            List<Robot> retVal = new List<Robot>();
            int[] ii = { 0, 1, 0, -1 }; // vrste
            int[] jj = { 1, 0, -1, 0 }; // kolone
            // desno, dole, levo, gore
            for (int c = 0; c < ii.Length; c++)
            {
                Robot ns = null;
                ValidacijaIPozicijeKutija validation;
                int iT = vrsta + ii[c];
                int jT = kolona + jj[c];
                if (iT == -1)
                    iT = 0;// panel.brojVrsta - 1;
                if (iT == panel.brojVrsta)
                    iT = panel.brojVrsta - 1; ;// 0;

                if (jT == -1)
                    jT = 0;//  panel.brojKolona - 1;
                if (jT == panel.brojKolona)
                    jT = panel.brojKolona - 1; //0;


                int tt = panel.lavirint[iT][jT];
                bool ok = true;
                
                

                if (tt != 1)
                { // NIJE ZID    
                    foreach (Box b in trenutnePozicijeKutija)   // PROVERITI DA LI SE NEKA OD KUTIJA NALAZI TU  
                    {
                        if (b.kolona == jT && b.vrsta == iT)
                        {
                            //da vrati listu
                            validation = b.tryToMoveBox(panel, ii[c], jj[c], trenutnePozicijeKutija);
                            if (validation.ok == false)
                            {
                                ok= false;
                                break;      //ako kutija ne moze da se pomeri
                            }
                            else
                            {
                                ns = new Robot(validation.pozicijeKutija);
                                break;
                            }
                        }
                    }
                    if (ok)
                    {
                        if (ns == null)
                            ns = new Robot(trenutnePozicijeKutija);
                        ns.vrsta = iT;
                        ns.kolona = jT;
                        ns.parent = this;
                        ns.nivo = this.nivo + 1;
                        retVal.Add(ns);
                    }
                }
            }
            return retVal;
        }

        public String kljuc()
        {
            string key = "";
            key += vrsta + "-" + kolona;
            foreach (Box b in trenutnePozicijeKutija)
            {
                key += "-" + b.kolona + "-" + b.vrsta;
            }
            return key; 
        }    
    }
}
