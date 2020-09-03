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

        public Human(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
            WorkIn = null;
        }

    }
}
