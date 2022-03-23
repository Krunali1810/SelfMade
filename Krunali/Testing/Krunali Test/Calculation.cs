using System;

namespace Krunali_Test
{
    public class Calculation
    {
        int result;
        public int Addition(int a,int b)
        {
            result = 0;
            result = a + b;
            return result;
        }

        public int substraction(int a,int b)
        {
            result = 0;
            result = a - b;
            return result;
        }
        
        public int Multiplication(int a,int b)
        {
            result = 0;
            result = a * b;
            return result;
        }

        public int Divison(int a, int b)
        {
            result = 0;
            result = a / b;
            return result;
        }
    }
}
