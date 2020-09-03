using Helper.App.Common;
using Helper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper.App.Concrete
{
    public class HumanService : BaseService<Human>
    {
        public void AddWork(Human human, Work work)
        {
            foreach (var item in ItemList)
            {
                if (item == human)
                {
                    human.WorkIn = work;
                }
            }
        }
        public void DeleteWork(Work work)
        {
            foreach (var item in ItemList)
            {
                if (item.WorkIn.ID == work.ID)
                {
                    ItemList.Remove(item);
                }
            }
        }
        public void DeleteWork(int HumanId)
        {
            foreach (var item in ItemList)
            {
                if (item.ID == HumanId)
                {
                    item.WorkIn = null;
                }
            }
        }
    }
}
