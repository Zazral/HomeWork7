using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository rep = new Repository("workers.txt");
            while(true)
            {
                Console.WriteLine("1-вывести данные\n2-записать данные\n3-удалить сотрудника\n" +
                    "enter-выход\n");
                string doing = Console.ReadLine();
                //вывод данных
                if (doing == "1")
                {
                    Console.Clear();
                    rep.Print();
                    
                }
                //ввод данных
                else if (doing == "2")
                {
                    try
                    {
                        Console.WriteLine("введите фамилию, имя, возраст, рост, дату и место рождения через пробел");
                        string[] w = Console.ReadLine().Split(' ');
                        
                        rep.Write(w);
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Была допущена ошибка!\nПопробуйте снова");
                        continue;
                    }
                }
                //удаление сотрудника
                else if (doing =="3")
                {
                    Console.WriteLine("введите id сотрудника которого хотите удалить");
                    int del = Convert.ToInt32(Console.ReadLine());
                    rep.Del(del);
                }
                //выход из программы
                else break;
            }
            
        }
    }
}
