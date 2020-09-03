using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.App.Abstract
{
    public interface IItemService<T>
    {
        List<T> ItemList { get; set; }

        List<T> GetAllItems();
        T GetItemBy(int ID);
        void AddItem(T Item);
        void DeleteItem(T Item);
        int GetLastId();

    }
}
