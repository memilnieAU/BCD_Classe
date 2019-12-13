using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPI;

namespace BCD_Classe
{
    public class Knap
    {
        public bool keyIsPressed = false;



        private static Key startStop;

        public Knap(RPi rpiref)
        {
            startStop = new RPI.Key(rpiref, Key.ID.P1);

        }

        public bool CheckKnap()
        {
            if (startStop.isPressed() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }


    }
}