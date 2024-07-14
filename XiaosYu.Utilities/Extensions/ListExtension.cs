using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaosYu.Utilities.Extensions
{
    static public partial class Extension
    {
        static public float Variance(this List<float> values) 
        {
            var mean = values.Average();
            var sum = values.Sum(s=>Math.Pow(s - mean, 2));
            return (float)(sum / values.Count);
        }

        static public float Median(this List<float> values)
        {
            var items = values.Order().ToList();
            int count = values.Count;
            return count % 2 == 0 ? (items[count / 2] + items[count / 2 + 1]) / 2 : items[count / 2];
        }

        static public float Kurtosis(this List<float> values)
        {
            var a = values;
            var b = new float[a.Count].ToList();
            int count;
            double exp = 0.0;//期望
            double sum2 = 0.0;
            double y = 0.0;//中心矩

            for (int i = 0; i < b.Count; i++)
            {
                b[i] = -1;
            }

            for (int i = 0; i < b.Count; i++)
            {
                count = 1;
                for (int j = i + 1; j < b.Count; j++)
                {
                    if (a[i] == a[j])
                    {
                        b[j] = 0;
                        count++;
                    }
                }

                if (b[i] != 0)
                {
                    b[i] = count;
                }
            }

            //输出每个数出现的次数
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] != 0)
                {
                    exp += a[i] * (b[i] / b.Count);
                }
            }

            //非传统方法：方差
            for (int i = 0; i < b.Count; i++)
            {
                sum2 += (a[i] * a[i]) * (b[i] / b.Count);
            }
            double var2 = sum2 - (exp * exp);

            //倾斜度
            //求中心矩y
            for (int i = 0; i < b.Count; i++)
            {
                y += ((a[i] - exp) * (a[i] - exp) * (a[i] - exp)) * (b[i] / b.Count);
            }
            double skew = y / (Math.Sqrt(var2) * var2);

            //峰度
            for (int i = 0; i < b.Count; i++)
            {
                y += ((a[i] - exp) * (a[i] - exp) * (a[i] - exp) * (a[i] - exp)) * (b[i] / b.Count);
            }
            double kurt = (y / (var2 * var2)) - 3;

            return (float)kurt;
        }

        static public float Skewness(this List<float> values)
        {
            var a = values;
            var b = new float[a.Count].ToList();
            int count;
            double exp = 0.0;//期望
            double sum2 = 0.0;
            double y = 0.0;//中心矩

            for (int i = 0; i < b.Count; i++)
            {
                b[i] = -1;
            }

            for (int i = 0; i < b.Count; i++)
            {
                count = 1;
                for (int j = i + 1; j < b.Count; j++)
                {
                    if (a[i] == a[j])
                    {
                        b[j] = 0;
                        count++;
                    }
                }

                if (b[i] != 0)
                {
                    b[i] = count;
                }
            }

            //输出每个数出现的次数
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] != 0)
                {
                    exp += a[i] * (b[i] / b.Count);
                }
            }

            //非传统方法：方差
            for (int i = 0; i < b.Count; i++)
            {
                sum2 += (a[i] * a[i]) * (b[i] / b.Count);
            }
            double var2 = sum2 - (exp * exp);


            for (int i = 0; i < b.Count; i++)
            {
                y += ((a[i] - exp) * (a[i] - exp) * (a[i] - exp)) * (b[i] / b.Count);
            }
            double skew = y / (Math.Sqrt(var2) * var2);

            return (float)skew;
        }
    }
}
