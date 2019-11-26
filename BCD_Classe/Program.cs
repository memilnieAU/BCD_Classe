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


            to7Seg.HwTestMode();




            Console.WriteLine("Er tilbage i main");
            Console.ReadLine();

            
            

            

           
        
        }
    }
}
