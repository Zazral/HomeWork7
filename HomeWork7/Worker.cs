using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    /// <summary>
    /// сотрудник
    /// </summary>
    struct Worker
    {
        /// <summary>
        /// порядковый номер сторудника
        /// </summary>
        public int id;
        /// <summary>
        /// время добавления записи
        /// </summary>
        public DateTime DataInput;
        /// <summary>
        /// Имя
        /// </summary>
        private string FirstName;
        /// <summary>
        /// Фамилия
        /// </summary>
        private string LastName;
        /// <summary>
        /// возраст
        /// </summary>
        private int YeOld;
        /// <summary>
        /// рост
        /// </summary>
        private double Height;
        /// <summary>
        /// дата рождения
        /// </summary>
        public DateTime DateOfBirth;
        /// <summary>
        /// место рождения
        /// </summary>
        private string WhBorn;
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="DataInput">Дата добавления сотрудника</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="YeOld">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="DateOfBirth">День рождения</param>
        /// <param name="WhBorn">Место рождения</param>
        public Worker(int id, DateTime DataInput, string FirstName, string LastName, int YeOld, double Height, DateTime DateOfBirth, string WhBorn)
        {
            this.id = id;
            this.DataInput = DataInput;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.YeOld = YeOld;
            this.Height = Height;
            this.DateOfBirth = DateOfBirth;
            this.WhBorn = WhBorn;
        }
        /// <summary>
        /// Вывод сотрудника
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.id,5} {this.DataInput,15} {this.FirstName,15} {this.LastName,10} {this.YeOld,4} {this.Height,5} {this.DateOfBirth,15} {this.WhBorn}";
        }
        public string PrintToFile()
        {
            return $"{this.id}#{this.DataInput}#{this.FirstName}#{this.LastName}#{this.YeOld}#{this.Height}#{this.DateOfBirth}#{this.WhBorn}";
        }
    }
}
