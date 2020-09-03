using Helper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Domain.Entity
{
    public class Work : BaseEntity
    {
        public List<Human> Workers { get; set; }

        public Work(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
