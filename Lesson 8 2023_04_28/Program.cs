using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms; //не работает, а должен

// DelegateExemple

namespace Lesson_8_2023_04_28
{
    delegate void output(params object[] values);
    internal class Program
    {
        static void NameOfObj(object[] _arr)
        {
            string output = string.Empty;
            foreach(var item in _arr)
            {
                output += $"{item.GetType()}\n";
            }
            //MassageBox.Show(output); // тоже не работает
        }
        static void Main(string[] args)
        {
            output myPrint = (object[] _arr) =>
            {
                foreach (var item in _arr)
                {
                    Console.WriteLine(item);
                }
            };
            myPrint += NameOfObj;
            myPrint += (object[] _arr) =>
            {
                using (var sw = new StreamWriter("output.txt"))
                {
                    foreach (var item in _arr)
                    {
                        sw.WriteLine(item.ToString(), true);
                    }
                }
            };
            myPrint(1, "too", 3.5F, 'f');

        }
    }
}
