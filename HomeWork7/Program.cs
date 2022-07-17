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
                    "4-редактировать сотрудника\n5-вывести сотрудников в указанном диапазоне дат\nenter-выход\n");
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
                //редактирование сотрудника
                else if (doing =="4")
                {
                    Console.Clear();
                    rep.Red();
                }
                //вывод сотрудников в указанном диапозоне дат
                else if (doing =="5")
                {
                    //Console.Clear();
                    Console.WriteLine("введите диапозон дат добавления сотрудников " +
                        "в формаге ХХ.ХХ.ХХХХ-ХХ.ХХ.ХХХХ");
                    string[] r = Console.ReadLine().Split('-');
                    rep.range(r);
                }
                //сортировка массива по дате рождения по возрастанию
                else if (doing =="6")
                {
                    rep.sort(true);
                }
                //сортировка массива по дате рождения по убыванию
                else if (doing == "7")
                {
                    rep.sort(false);
                }
                //выход из программы
                else break;
            }
            
        }
    }
}
