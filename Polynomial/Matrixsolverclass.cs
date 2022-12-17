using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial
{
    class Matrixsolverclass
    {
        public static float[] Vandermonde(string[] x,string[]y,int count)
        {
            float a11=0, a12 = 0, a13 = 0, a21 = 0, a22 = 0, a23 = 0, a31 = 0, a32 = 0, a33 = 0, b1 = 0, b2 = 0, b3 = 0;
            if (count == 1)
            {
                 a12 = Convert.ToInt32(x[0]);
                 a11 = a12 * a12;
                 a13 = 1;
                 b1 = Convert.ToInt32(y[0]);
            }
            else if (count == 2)
            {
                 a12 = Convert.ToInt32(x[0]);
                 a11 = a12*a12;
                 a13 = 1;
                 b1 = Convert.ToInt32(y[0]);

                 a21 = Convert.ToInt32(x[1]);
                 a22 = a21*a21;
                 a23 = 1;
                 b2 = Convert.ToInt32(y[1]);

            }
            else if (count == 3)
            {
                 a12 = Convert.ToInt32(x[0]);
                 a11 = a12 * a12;
                 a13 = 1;
                 b1 = Convert.ToInt32(y[0]);

                 a22 = Convert.ToInt32(x[1]);
                 a21 = a22 * a22;
                 a23 = 1;
                 b2 = Convert.ToInt32(y[1]);

                 a32 = Convert.ToInt32(x[2]);
                a31 = a32 * a32;
                 a33 = 1;
                 b3 = Convert.ToInt32(y[2]);
            }
            else
                Console.WriteLine("ERROR");
            float[,] A = { { a11, a12, a13 }, { a21, a22, a23 }, { a31, a32, a33 }};
            float[] B = { b1, b2, b3 };
            float[,] matrix = A;
            float[] value = B;
            for (int i = 0; i < count; i++)
            {

                float tempfirst = matrix[i, i];// köşegen matrisin seçilmesi             
                if (tempfirst == 0)
                {
                    float temp;
                    for (int z = 0; z < count; z++)
                    {
                        temp = matrix[i, z];
                        matrix[i, z] = matrix[i + 1, z];
                        matrix[i + 1, z] = temp;
                    }
                    temp = value[i];
                    value[i] = value[i + 1];
                    value[i + 1] = temp;
                    tempfirst = matrix[i, i];
                }

                for (int k = 0; k < count; k++)
                {
                    matrix[i, k] /= tempfirst;// mk1 
                }
                value[i] /= tempfirst; //mk1
                for (int j = i + 1; j < count; j++)//geçici ilkten sonraki elemandan başlıyor!
                {
                    float carpim = matrix[j, i] / matrix[i, i]; //mk1

                    for (int l = 0; l < count; l++)
                    {
                        matrix[j, l] = matrix[j, l] - (carpim * matrix[i, l]); // satır eşelon
                    }
                    value[j] = value[j] - (carpim * value[i]); //satır eşelon                    
                }
            }

            float[] results = new float[count];
            results[count - 1] = value[count - 1];

            for (int i = count - 2; i >= 0; i--)
            {
                float toplam = 0;
                for (int j = i + 1; j < count; j++)
                {
                    toplam = toplam + matrix[i, j] * results[j];
                }
                results[i] = value[i] - toplam;
            }

            for (int i = 0; i < count; i++)
            {
                string s = "";
                for (int j = 0; j < count; j++)
                {
                    s = s + matrix[i, j] + " ";
                }
            }
            return results;
        }
    }
}

