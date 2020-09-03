using Helper.App.Abstract;
using Helper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper.App.Common
{
    /// <summary>
    /// Dodanie ciał do metod
    /// </summary>
    /// <typeparam name="T">musi dziedziczyć po BaseEntity</typeparam>
    public class BaseService<T> : IItemService<T> where T : BaseEntity
    {
        public List<T> ItemList { get; set; }

        public void AddItem(T Item)     //<T> zamienia się w concrete service na konkretną klase
        {
            ItemList.Add(Item);         //dodaje przedmiot do listy
        }

        public void DeleteItem(T Item)
        {
            ItemList.Remove(Item);      //usuwam podany item z listy
        }

        public List<T> GetAllItems()
        {
            return ItemList;            //pobieram całą liste
        }


        public T GetItemBy(int ID)
        {
            return ItemList.Where(i => i.ID == ID).FirstOrDefault();    //pobieram item o danym id
        }

        public int GetLastId()
        {
            var lastId = ItemList.OrderBy(i => i.ID).Select(i=>i.ID).LastOrDefault();   //pobieram największe id

            return lastId;      //zwracam je
        }
    }
}
