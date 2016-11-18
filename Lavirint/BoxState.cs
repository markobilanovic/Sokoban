using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public struct Box
    {
        #region Informacioni deo
        public int vrsta;
        public int kolona;
        #endregion
        
        

        public List<Box> ostaleKutije;

        public Box(DisplayPanel panel,int vrsta, int kolona)
        {
            
            ostaleKutije = null;
            this.vrsta = vrsta;
            this.kolona = kolona;
        }


        public ValidacijaIPozicijeKutija tryToMoveBox(DisplayPanel panel, int dI, int dJ, List<Box> trenutnaStanjaKutija)
        {
            ValidacijaIPozicijeKutija tmp = new ValidacijaIPozicijeKutija(true);
            
            ostaleKutije = new List<Box>(trenutnaStanjaKutija);
            foreach (Box b in ostaleKutije)
            {
                if (b.kolona == this.kolona && b.vrsta == this.vrsta)
                {
                    ostaleKutije.Remove(b);
                    break;
                }
            }
            
            int nI = vrsta + dI;
            int nJ = kolona + dJ;
            if (nI < 0)
                nI = 0;// brojVrsta - 1;
            if (nI > 7 - 1)
                nI = 7 - 1;// 0;
            if (nJ < 0)
                nJ = 0;// brojKolona - 1;
            if (nJ > 10 - 1)
                nJ = 10 - 1;//0;
            // ovaj deo je da se spreci prolazak kroz zidove
            if (panel.lavirint[nI][nJ] != 1)
            {         //AKO NIJE ZID
                foreach (Box b in ostaleKutije)   // PROVERITI DA LI SE NEKA OD KUTIJA NALAZI TU  
                {
                    if (b.kolona == nJ && b.vrsta == nI)
                    {
                        tmp.ok = false;
                        return tmp;
                    }
                }
            }
            else
            {
                tmp.ok = false;
                return tmp;
            }
            this.vrsta = dI + this.vrsta;
            this.kolona = dJ + this.kolona;
            ostaleKutije.Add(this);
            tmp.pozicijeKutija = new List<Box>(ostaleKutije);
            return tmp;
        }



        public String kljuc() {
            return vrsta + "-" + kolona; ;        
        }    
    }
}
