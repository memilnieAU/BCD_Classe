using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPI;
using System.Threading;

namespace BCD_Classe
{
    

    

    public class To7seg
    {
        private static RPi Resp;
        private static RPI.Display.SevenSeg display;

        public To7seg(RPi rpiref)
        {
            display = new RPI.Display.SevenSeg(rpiref);

            display.Init_SevenSeg();
            ShowNum(88);
            display.Close_SevenSeg();
            

        }

        public void Test()
        {
            

            for (int i = 0; i < 99; i+=11)
            {
                int bcdResult = 0;
                int shift = 0;
                int testTal = 0;
                testTal = i;
                while (testTal > 0)
                {
                    
                    bcdResult |= (testTal % 10) << (shift++ * 4);


                    testTal /= 10;



                }
                display.Disp_SevenSeg((short)bcdResult);
                Thread.Sleep(500);
            }
            display.Close_SevenSeg();


        }

   public void ShowNum(int pulse)
        {
            int bcdResult = 0;
            int shift = 0;
            while (pulse > 0)
            {
                int i = 0;
                bcdResult |= (pulse % 10) << (shift++ * 4);


                pulse /= 10;



            }




            //short sPulse = Convert.ToInt16(pulse);
            display.Disp_SevenSeg((short)bcdResult);
        }

        public void Close()
        {
            display.Close_SevenSeg();
        }




    }
}
