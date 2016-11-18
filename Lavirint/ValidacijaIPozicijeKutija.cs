using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public class ValidacijaIPozicijeKutija
    {
        public List<Box> pozicijeKutija;
        public bool ok;

        public ValidacijaIPozicijeKutija(bool ok)
        {
          //  this.pozicijeKutija = new List<Box>(pozicijeKutija);
            this.ok = ok;
        }
        
    }
}
