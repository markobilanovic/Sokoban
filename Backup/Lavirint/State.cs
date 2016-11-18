using System;
using System.Collections.Generic;
using System.Text;

namespace Lavirint
{
    public class State
    {
        #region Informacioni deo
        public int vrsta;
        public int kolona;
        #endregion

        #region deo za stablo pretrazivanja
        public State parent;
        public int nivo = 0;
        #endregion

        public List<State> mogucaSledecaStanja(DisplayPanel panel) {
            List<State> retVal = new List<State>();
            int[] ii = { 0, 1,  0, -1}; // vrste
            int[] jj = { 1, 0, -1,  0}; // kolone
            // desno, dole, levo, gore
            for (int c = 0; c < ii.Length; c++)
            {
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
                //if (iT > -1 && iT < panel.brojVrsta && jT > -1 && jT < panel.brojKolona)
                //{
                    int tt = panel.lavirint[iT][jT];
                    if (tt != 1) { // NIJE ZID
                        State ns = new State();
                        ns.vrsta = iT;
                        ns.kolona = jT;
                        ns.parent = this;
                        ns.nivo = this.nivo + 1;
                        retVal.Add(ns);
                    }
                //}
            }            
            return retVal;
        }

        public String kljuc() {
            return vrsta + "-" + kolona; ;        
        }    
    }
}
