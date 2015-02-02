using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousLights
{
    class LedStrip
    {
        public List<Led> Led { get; private set; }

        public LedStrip(int numberOfLeds)
        {
            Led = new List<Led>();
            for (int i = 1; i <= numberOfLeds; i++)
            {
                Led.Add(new Led(i));
            }
        }
    }

    class Led
    {
        private Color myColor;
        private int myNum;

        public Led(int num)
        {
            myNum = num;
            myColor = Color.Black;
        }

        public override string ToString()
        {
            return "Led " + myNum;
        }
    }
}
