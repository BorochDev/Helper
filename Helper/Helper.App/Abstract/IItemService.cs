using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.App.Abstract
{
    /// <summary>
    /// dodanie głównych metod dla wszystkich service
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
