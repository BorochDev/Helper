using Helper.App.Concrete;
using Helper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.App.Manager
{
    public class HumanManager
    {
        private readonly HumanService humanService;

        public HumanManager()
        {
            humanService = new HumanService();
        }

        public void AddNewHuman()
        {
            Console.Clear();
            Console.Write("Podaj imię: ");
            var name = Console.ReadLine();          //pobieram imie do zmiennej
            Console.Write("Podaj nazwisko: ");
            var surname = Console.ReadLine();       //pobieram nazwisko do zmiennej

            var id = humanService.GetLastId();      //pobieram ostatnie id i zwiększam je o 1
            id++;
            humanService.AddItem(new Human(id, name, surname));     //dodaje nowy obiekt Human do listy
            Console.ReadKey();
        }

        public void ShowAllHumans()
        {
            Console.Clear();
            var Humans = humanService.GetAllItems();        //pobieram całą liste 
            foreach (var item in Humans)                    //wypisuje dane 
            {
                Console.Write($"{item.ID}) {item.Name}, {item.Surname}, pracuje w {item.WorkIn.Name} ");
            }
            Console.ReadKey();
        }

        public void ShowHumanByID()
        {
            Console.Clear();
            Console.Write("Podaj ID człowieka: ");
            int.TryParse(Console.ReadLine(), out int id);       //pobieram id z konsolki

            Human human = humanService.GetItemBy(id);           //pobranie obiektu z danym id
            Console.Write($"{human.ID}) {human.Name}, {human.Surname}, pracuje w {human.WorkIn.Name} ");
            Console.ReadKey();
        }

        public void DeleteHuman()
        {
            Console.Clear();
            Console.Write("Podaj ID człowieka do usunięcia: ");
            int.TryParse(Console.ReadLine(), out int id);           //pobranie id z konsolki

            Human toDelete = humanService.GetItemBy(id);            //pobranie obiektu z listy 
            if (toDelete !=null)
            {
                humanService.DeleteItem(toDelete);                  //usunięcie jeśli istnieje
            }
            else
            {
                Console.WriteLine("Nie ma człowieka o takim ID");
            }
            Console.ReadKey();
            
        }

        public Human AddWork(Work work)
        {
            Console.Write("Podaj ID osoby zatrudnianej: ");
            int.TryParse(Console.ReadLine(), out int id);
            Human human = humanService.GetItemBy(id);

            humanService.AddWork(human, work);

            Console.ReadKey();
            return human;

        }

        public void DeleteWork(Work work)
        {
            humanService.DeleteWork(work);          //zmiana na bezrobotnych osób pracujących w work
        }
        public void DeleteWork(int HumanId)
        {
            humanService.DeleteWork(HumanId);       //usunięcie pracy człowiekowi z danym id
        }
    }
}
