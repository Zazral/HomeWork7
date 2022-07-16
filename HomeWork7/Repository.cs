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
            Worker[] NewWorkers = new Worker[workers.Length-1];
            this.Load();
            //записываем новый массив с удаленным элементом
            for(int i = 0; i < workers.Length; i++)
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
            //перезаписываем файл 
            StreamWriter swNew = new StreamWriter("workers.txt", false);
            for(int i= 0; i < NewWorkers.Length; i++)
            {
                swNew.WriteLine(NewWorkers[i].PrintToFile());
            }
            swNew.Close();
            Array.Resize(ref workers, NewWorkers.Length);
        }
    }
}
