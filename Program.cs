using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void StringToDouble(string str)
            {
                str = str.Replace(" ", "");
                bool negativeCheck = false;
                bool negativeMultiplyCheck = false;

                int negativeCharCounter = 0;

                //проверка на отрицательное значение
                if (str[0] == '-')
                {
                    negativeCheck = true;
                }

                //проверка на количество минусов
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '-')
                    {
                        negativeCharCounter++;
                    }

                    if (negativeCharCounter > 1)
                    {
                        negativeMultiplyCheck = false;
                        break;
                    }
                    negativeMultiplyCheck = true;
                }

                str = str.Replace("-", "");

                int charCounter = 0;
                bool charChech = false; //проверка на цифры и запятую
                bool pointCountChech = false; //проверка количества запятых
                bool pointPositionCheck = false; //проверка на позицию запятой

                //проверка налачия запятой
                int checkPointExistence = str.IndexOf(",", 0, str.Length);

                //проверка на число и запятую
                foreach (char c1 in str)
                {
                    if (c1 != '1' && c1 != '2' && c1 != '3' && c1 != '4' && c1 != '5' && c1 != '6' && c1 != '6' && c1 != '7' && c1 != '8' && c1 != '9' && c1 != '0' && c1 != ',')
                    {
                        charChech = false;
                        break;
                    }
                    else
                    {
                        charChech = true;
                    }
                }

                //проверка на количество запятых
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',')
                    {
                        charCounter++;
                    }

                    if (charCounter > 1)
                    {
                        pointCountChech = false;
                        break;
                    }
                    pointCountChech = true;
                }

                int сharPosition = str.Length - str.IndexOf(",", 0, str.Length) - 1;

                //проверка позиция запятой
                if (сharPosition == 0 || сharPosition == str.Length - 1)
                {
                    pointPositionCheck = false;
                }
                else
                {
                    pointPositionCheck = true;
                }

                char[] c = new char[str.Length + 1];
                double k1 = 1;
                double numtemp = 0;
                double numtemp2 = 0;

                str = str.Replace(",", "");
                                
                if (charChech && pointCountChech && pointPositionCheck && negativeMultiplyCheck)
                {
                    for (int i = str.Length - 1; i >= 0; i--)
                    {
                        c[i] = str[i];
                        for (int j = 48; j <= 57; j++)
                        {
                            if (c[i] == j)
                            {
                                numtemp2 = j - 49 + 1;
                            }
                        }
                        numtemp = numtemp + numtemp2 * k1;
                        k1 = k1 * 10;
                    }

                    if (negativeCheck)
                    {
                        numtemp = numtemp * (-1);
                    }

                    if (numtemp < -1.7976931348623157E+308 && numtemp > 1.7976931348623157E+308)
                    {
                        Console.WriteLine("Неверный ввод, число за пределами диапазона double");
                    }
                    else
                    {
                        if (checkPointExistence < 0)
                        {
                            Console.WriteLine($"Число в формате double: {numtemp}");
                        }
                        else
                        {
                            Console.WriteLine($"Число в формате double: {numtemp / Math.Pow(10, сharPosition)}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }

            Console.Write("Введите число в формате double с разделителем запятая (можно без разделителя): ");

            StringToDouble(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
