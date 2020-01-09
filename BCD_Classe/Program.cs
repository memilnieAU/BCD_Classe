using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPI;
using System.Threading;

namespace BCD_Classe
{
    class Program
    {
        private static RPi Resp;
        private static Key startStop;
        private static RPI.Controller.PWM _pwm;
        private static RPI.Heart_Rate_Monitor.Puls puls_;

        static void Main(string[] args)
        {
            Resp = new RPi();
            puls_ = new RPI.Heart_Rate_Monitor.Puls(Resp); //PULS MÅLER
            To7seg to7Seg = new To7seg(Resp);
            startStop = new RPI.Key(Resp, Key.ID.P1);

            to7Seg.HwTestMode(); //Denne kode kan skrives hvis man vil teste alle cifre

            //Denne komando er den eneste der skal bruges hvis der skal skrives noget til Display
            //to7Seg.ShowNum(Convert.ToInt32(Console.ReadLine()));
            //to7Seg.Close();
            //public bool keyIsPressed = false;
            
            
            ///*
                     

            _pwm = new RPI.Controller.PWM(Resp);
            _pwm.InitPWM();
            Thread.Sleep(1000);
            // Set dutycycle to 75%
            Console.WriteLine("start med 75%");
           _pwm.SetPWM(75);
           
            for (int i = 0; i <= 10; i++)
            {
                _pwm.SetPWM(10*i);
                // Wait 2.5 seconds
                Console.WriteLine(10*i+"%");
                //Thread.Sleep(2500);
                Console.ReadLine();
            }
            //*/

            DateTime starttime = DateTime.Now;
            Console.WriteLine("Start tid " + starttime);
            DateTime stoptime = DateTime.Now;
            TimeSpan deltatid = stoptime - starttime;
            double delaytid = 5; //Den kan kun kører i 5 sekunder
            while (deltatid.TotalSeconds <= delaytid) 
            {
                
                _pwm.SetPWM(25);
                Thread.Sleep(250);
                _pwm.SetPWM(100);
                Thread.Sleep(250);
                stoptime = DateTime.Now;
                Console.WriteLine("ny stoptid " + stoptime);
                deltatid = stoptime - starttime;
                Console.WriteLine("ny Delta " + deltatid);


            }
            _pwm.StopPWM();
           
            while (!Console.KeyAvailable)
            {
                if (startStop.isPressed() == true)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("false");
                }
                
            }

            while (true)
            {
                Console.WriteLine("Pulsprint test \n tryk enter for at starte testen");
                Console.ReadLine();
                puls_.StartPuls();
                Console.WriteLine("Pulstesteten er startet, vent 10 sek før den slukke automatisk");
                

                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                    

                }
                Console.WriteLine("Din puls er: "+(puls_.ReadPuls()*2).ToString()) ;
                Console.WriteLine("Din puls er: " + (puls_.ReadPuls()).ToString());

                Thread.Sleep(1000);
                
            }

        }




    }
}



