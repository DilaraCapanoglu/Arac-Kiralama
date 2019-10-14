using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracGaleri
{
    class AracFactory
    {
        public static Object createArac(String arac)
        {
            if (arac == "Otomobil" )
             return new Otomobil();
            else if (arac == "Motosiklet")
                return new Motosiklet();
            else
                return null;

        }

    }

}


