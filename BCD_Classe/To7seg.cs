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

            for (int i = 0; i <= 99; i += testAdd)
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
                Thread.Sleep(testTime);
            }

            Close();


        }

        public void ShowNum(int pulse)
        {
            int bcdResult = 0;
            int shift = 0;
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
