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
            

            while (true)
            {
                Console.WriteLine("Tast et tal eller t(Test) eller q(Break)");
                string input = Console.ReadLine() ;
                if (input != "q" && input != "t")
                {
                    short tal = Convert.ToInt16(input);
                    to7Seg.ShowNum(tal);
                }
                else if (input == "q")
                {
                    break;
                }
                else if (input == "t")
                {
                    to7Seg.Test();
                }
                
                

            
            

            }

           
        
        }
    }
}
