using Helper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Domain.Entity
{
    public class Human : BaseEntity
    {

        public string Surname { get; set; }
        public int Age { get; set; }
        public Work WorkIn { get; set; }

        /// <summary>
        /// Dodaje rzeczy bez których obiekt nie ma sensu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public Human(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
            WorkIn = null;
        }

    }
}
