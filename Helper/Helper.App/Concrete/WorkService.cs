using Helper.App.Common;
using Helper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper.App.Concrete
{
    public class WorkService : BaseService<Work>
    {

        public List<Human> GetWorkers(int workID)
        {
            var work = ItemList.Where(i => i.ID == workID).FirstOrDefault();
            return work.Workers;
        }

        public void DeleteWorker(Work work, int humanId)
        {
            foreach (var works in ItemList)
            {
                if (works.ID == work.ID)
                {
                    Human human = works.Workers.Where(w => w.ID == humanId).FirstOrDefault();
                    works.Workers.Remove(human);
                }
            }
        }
        public void AddWorker(Work work, Human human)
        {
            foreach (var item in ItemList)
            {
                if (item.ID == work.ID)
                {
                    item.Workers.Add(human);
                }
            }
        }
        public Human GetWorker(int workId, int humanId)
        {
            var work = GetItemBy(workId);
            return work.Workers.Where(w => w.ID == humanId).FirstOrDefault();
        }

    }
}
