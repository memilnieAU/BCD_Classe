using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPI;

namespace BCD_Classe
{
    class Program
    {
        private static RPi Resp;
        
      
        static void Main(string[] args)
        {
           Resp = new RPi();

            To7seg to7Seg = new To7seg(Resp);


            to7Seg.HwTestMode(); //Denne kode kan skrives hvis man vil teste alle cifre
            
            //Denne komando er den eneste der skal bruges hvis der skal skrives noget til Display
            //to7Seg.ShowNum(Convert.ToInt32(Console.ReadLine()));
            //to7Seg.Close();

            


            Console.ReadLine();
            






        }
    }
}
