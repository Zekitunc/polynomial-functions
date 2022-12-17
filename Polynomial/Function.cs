using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial
{
    class Function
    {
        public static float getvalueof(float value,float[] res)
        {
            int count = 0;
            for(int i =0;i<res.Length;i++)
                if (res[count] != null)
                    count++;
            if (count == 1)
            {
                return res[0];
            }
            else if (count == 2)
            {
                float result = res[0] * value + res[1];
                return result;
            }
            else if (count == 3)
            {
                float result = res[0] * value * value + res[1] * value + res[2];
                return result;
            }
            else
                return 0;
        }
    }
}
