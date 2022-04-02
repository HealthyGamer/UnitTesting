using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest
{
    public class System
    {
        public int LastResult { get; private set; }

        public int AddTwoNumbers(int num1, int num2)
        {
            if(num1 < 0 || num2 < 0)
            {
                throw new ArgumentException("Numbers must be positive");
            }

            var result = num1 + num2;

            LastResult = result;

            return result;
        }
        /*
        public int AddTwoNumbers(float num1, float num2)
        {
            return (int)Math.Round(num1 + num2);
        }*/
    }
}
