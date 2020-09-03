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
            var work = ItemList.Where(i => i.ID == workID).FirstOrDefault();   //pierwszy work z danym id
            return work.Workers;        //zwracam go
        }

        public void DeleteWorker(Work work, int humanId)
        {
            foreach (var works in ItemList)         //przeszukuje liste w poszukiwaniu konkretnej pracy
            {
                if (works.ID == work.ID)
                {
                    Human human = works.Workers.Where(w => w.ID == humanId).FirstOrDefault();  //zapisuje pracownika z danym id
                    works.Workers.Remove(human);            //usuwam go z listy pracujących
                }
            }
        }
        public void AddWorker(Work work, Human human)
        {
            foreach (var item in ItemList)      //szukam pracy z danym id
            {
                if (item.ID == work.ID)
                {
                    item.Workers.Add(human);        //dodaje człowieka do pracy
                }
            }
        }
        public Human GetWorker(int workId, int humanId)
        {
            var work = GetItemBy(workId);                   //pobieram work o danym id
            return work.Workers.Where(w => w.ID == humanId).FirstOrDefault();   //pobieram pracownika o tym id z tej pracy
        }

    }
}
