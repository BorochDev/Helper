using Helper.App.Abstract;
using Helper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper.App.Common
{
    public class BaseService<T> : IItemService<T> where T : BaseEntity
    {
        public List<T> ItemList { get; set; }

        public void AddItem(T Item)
        {
            ItemList.Add(Item);
        }

        public void DeleteItem(T Item)
        {
            ItemList.Remove(Item);
        }

        public List<T> GetAllItems()
        {
            return ItemList;
        }


        public T GetItemBy(int ID)
        {
            return ItemList.Where(i => i.ID == ID).FirstOrDefault();
        }

        public int GetLastId()
        {
            var lastId = ItemList.OrderBy(i => i.ID).Select(i=>i.ID).LastOrDefault();

            return lastId;
        }
    }
}
