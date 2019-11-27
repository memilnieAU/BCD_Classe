using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPI;
using System.Threading;

namespace BCD_Classe
{

    /// <summary>
    /// Denne klasse er for at konvetere og gøre det simpelt at skrive ud til 7-seg-displayet
    /// De eneste 2 ting der skal oprettet i hoved programmet er:
    /// 
    /// To7seg to7Seg = new To7seg(Resp);
    /// og 
    /// to7Seg.ShowNum(int puls);
    /// 
    /// Men der udover er der en HwTestMode() som kan teste Hw ved hjælp af console
    /// 
    /// </summary>


    public class To7seg
    {
        
        private static RPI.Display.SevenSeg display;
        private static Led led100;

        public To7seg(RPi rpiref)
        {
            display = new RPI.Display.SevenSeg(rpiref);
            led100 = new RPI.Led(rpiref, Led.ID.LD1);

            display.Init_SevenSeg();
            led100.off();
            ShowNum(88);
            Close();
            


        }

        public void Test(string typeTest)
        
        {
            int testAdd = 0;
            int testTime = 0;
            if (typeTest == "t")
            {
                testAdd = 11;
                testTime = 500;
            }
            else
            {
                testAdd = 1;
                testTime = 75;
            }

            for (int i = 0; i <= 199; i += testAdd)
            {
                int bcdResult = 0;
                int shift = 0;
                int testTal = 0;
             
             
                testTal = i;

                led100.off();
                if (testTal >= 100)
                {
                    led100.on();
                }
                while (testTal > 0)
                {

                    bcdResult |= (testTal % 10) << (shift++ * 4);


                    testTal /= 10;



                }
                
                display.Disp_SevenSeg((short)bcdResult);
                Thread.Sleep(testTime);
            }

            Close();


        }

        public void ShowNum(int pulse)
        {
            int bcdResult = 0;
            int shift = 0;
           
            led100.off();
            if (pulse >= 100)
            {
                led100.on();
            }
            
            while (pulse > 0)
            {
                
                bcdResult |= (pulse % 10) << (shift++ * 4);


                pulse /= 10;



            }




            //short sPulse = Convert.ToInt16(pulse);
            display.Disp_SevenSeg((short)bcdResult);
        }

        public void Close()
        {
            display.Close_SevenSeg();
            led100.off();
        }


        public void HwTestMode()
        {
            bool brydUd = false;
            while (!brydUd)
            {
                Console.WriteLine("Tast et tal eller t(Test) eller q(Break)");
                string input = Console.ReadLine();
                try
                {
                    if (input == "t" || input == "tt")
                    {
                        Test(input);
                    }
                    else if (input == "q")
                    {
                        Close();
                        brydUd = true;
                    }
                    else
                    {
                        short tal = Convert.ToInt16(input);
                        ShowNum(tal);
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Tast en gyldig værdi");
                }
            }

        }
    }
}
