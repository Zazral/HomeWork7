using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork7
{
    struct Repository
    {
        private Worker[] workers;//массив сотрудников
        int index;
        private string patch;//название файла для записи
        public Repository(string patch)
        {
            this.patch = patch;
            this.index = 0;
            this.workers = new Worker[1];
        }
        /// <summary>
        /// выгрузка из файла сотрудников в массив
        /// </summary>
        public void Load()
        {
            //пробуем открыть файл
            index = 0;
            try
            {
                using (StreamReader sr = new StreamReader(this.patch))
                {
                    while (!sr.EndOfStream)
                    {
                        Resize(index >= workers.Length);
                        string[] ar = sr.ReadLine().Split('#');
                        workers[index] = new Worker(Convert.ToInt32(ar[0]), Convert.ToDateTime(ar[1]), ar[2], ar[3], Convert.ToInt32(ar[4]), Convert.ToDouble(ar[5]), Convert.ToDateTime(ar[6]), ar[7]);
                        index++;
                    }
                }
            }
            //если файл отсутствует, создаем его
            catch
            {
                StreamWriter reserv = new StreamWriter(patch, true);
                reserv.Close();
                Console.WriteLine("Файл создан");
            }
        }
        /// <summary>
        /// вывод данных из массива в консоль
        /// </summary>
        public void Print()
        {
            this.Load();
            for(int i = 0; i<workers.Length; i++)
            {
                Console.WriteLine(workers[i].Print());
            }
        }
        /// <summary>
        /// автоматическое увеличение массива сотрудников
        /// </summary>
        /// <param name="flag"></param>
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this.workers, this.workers.Length + 1);
            }
        }
        /// <summary>
        /// запись нового сотрудника в файл
        /// </summary>
        /// <param name="work">массив считаный с консоли для преобразования его в Worker</param>
        public void Write(string[] work)
        {
            this.Load();
            Resize(index >= workers.Length);
            workers[index] = new Worker(index, DateTime.Now, work[0], work[1], Convert.ToInt32(work[2]), Convert.ToDouble(work[3]), Convert.ToDateTime(work[4]), work[5]);
            StreamWriter sw = new StreamWriter(patch, true);
            sw.WriteLine(workers[index].PrintToFile());
            sw.Close();
        }
        /// <summary>
        /// удаление сотрудника
        /// </summary>
        /// <param name="id">id удаляемого сотрудника</param>
        public void Del(int id)
        {
            Worker[] NewWorkers = new Worker[workers.Length - 1];
            this.Load();
            //записываем новый массив с удаленным элементом
            for (int i = 0; i < workers.Length; i++)
            {
                if (id > i)
                {
                    NewWorkers[i] = workers[i];
                }
                else if (id == i) continue;
                else
                {
                    workers[i].id = workers[i].id - 1;
                    NewWorkers[i - 1] = workers[i];
                }
            }
            this.Rewrite(NewWorkers);
        }
        /// <summary>
        /// перезапись файла
        /// </summary>
        /// <param name="nworkers"></param>
        public void Rewrite(Worker[] nworkers)
        {  
            StreamWriter swNew = new StreamWriter("workers.txt", false);
            for(int i= 0; i < nworkers.Length; i++)
            {
                swNew.WriteLine(nworkers[i].PrintToFile());
            }
            swNew.Close();
            Array.Resize(ref workers, nworkers.Length);
        }
        /// <summary>
        /// редактирование сотрудника
        /// </summary>
        /// <param name="id"></param>
        public void Red()
        {
            Worker[] NewWorkers = new Worker[workers.Length];
            this.Load();
            while (true)
            {
                try
                {
                    Console.WriteLine("введите id сотрудника которого хотите редактировать");
                    int idred = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{workers[idred].Print()}\nвведите измененные данные");
                    string[] w = Console.ReadLine().Split(' ');
                    for (int i = 0; i < workers.Length; i++)
                    {
                        if (idred == i)
                        {
                            NewWorkers[i] = new Worker(workers[i].id, workers[i].DataInput, w[0], w[1], Convert.ToInt32(w[2]), Convert.ToDouble(w[3]), Convert.ToDateTime(w[4]), w[5]);
                        }
                        else NewWorkers[i] = workers[i];
                    }
                    this.Rewrite(NewWorkers);
                    break;
                }
                catch
                {
                    Console.WriteLine("Допущена ошибка, повторите ввод снова");
                    continue;
                }
            }
        }
        /// <summary>
        /// вывод сотрудников в указанном диапозоне дат добавления
        /// </summary>
        /// <param name="range">диапозон дат</param>
        public void range(string[] range)
        {
            DateTime[] r = new DateTime[2];
            r[0] = Convert.ToDateTime(range[0]);
            r[1] = Convert.ToDateTime(range[1]);
            this.Load();
            for(int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DataInput >= r[0] & workers[i].DataInput <= r[1])
                {
                    Console.WriteLine(workers[i].Print());
                }
            }
        }
        /// <summary>
        /// сортировка сотрудников по возрастанию и убыванию даты рождения
        /// </summary>
        /// <param name="flag">true-по возрастанию, false-по убыванию</param>
        public void sort(bool flag)
        {
            this.Load();
            Worker temp = new Worker();
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = i + 1; j < workers.Length; j++)
                {
                    if (workers[i].DateOfBirth > workers[j].DateOfBirth)
                    {
                        temp = workers[i];
                        workers[i] = workers[j];
                        workers[j] = temp;
                    }
                }
            }
            if(flag)
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    Console.WriteLine(workers[i].Print());
                }
            }
            else
            {
                for (int i = workers.Length-1; i >= 0; i--)
                {
                    Console.WriteLine(workers[i].Print());
                }
            }
            
        }
    }
}
