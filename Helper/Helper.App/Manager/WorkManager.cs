using Helper.App.Concrete;
using Helper.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.App.Manager
{
    public class WorkManager
    {
        private readonly WorkService workService;
        public WorkManager()
        {
            workService = new WorkService();
        }

        public void AddNewWork()
        {
            Console.Write("Jak nazwiesz swoją firmę?: ");
            var name = Console.ReadLine();           //pobieram imie do zmiennej
            var id = workService.GetLastId();        //pobieram największe aktualne ID z listy
            id++;                                    //Zwiększam je o jeden aby nie było takie samo 
            workService.AddItem(new Work(id, name)); //tworze nowy obiekt work i zapisuje go w liście za pomocą servicu
        }

        public void ShowWorkByID()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int choice);   //Pobieram ID z konsolki
            var work = workService.GetItemBy(choice);           //Pobieram obiekt work z metody servicu
            if (work != null)                                   //Jeśli otrzymany obiekt nie jest pusty
            {
                Console.WriteLine($"{work.Name}");              //wypisuje nazwe firmy
                Console.WriteLine("Pracownicy:");
                foreach (var item in work.Workers)
                {
                    Console.WriteLine($"{item.Name} {item.Surname}");  //i imię i nazwisko pracowników
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono takiej firmy");
            }
        }

        public void ShowAllWorks()
        {
            Console.Clear();
            Console.WriteLine("Lista zarejestrowanych działalności:");
            foreach (var item in workService.GetAllItems())             //pobieram całą liste z service metodą
            {
                Console.WriteLine($"{item.ID}){item.Name}");            //i wypisuje na konsolke
            }
            Console.ReadKey();
        }

        public Work DeleteWork()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int id);               //pobieram id z konsolki
            Work work = workService.GetItemBy(id);                      //pobieram obiekt work z metody service
            workService.DeleteItem(work);                               //wysyłam wyszukany obiekt do usunięcia
            Console.ReadKey();
            return work;
        }
        
        public void AddWorker(Work work, Human worker)
        {
            workService.AddWorker(work, worker);                        //dodaje pracownika "worker" do pracy "work"
            Console.ReadKey();
        }

        public int DeleteWorker()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy zwalniającej: ");
            int.TryParse(Console.ReadLine(), out int Id);               //pobieram id z konsolki
            var work = workService.GetItemBy(Id);                       //pobieram obiekt z service metody
            Console.Write("Podaj ID osoby zwalnianej: ");
            int.TryParse(Console.ReadLine(), out Id);                   //pobieram id z konsolki
            workService.DeleteWorker(work, Id);                         //usuwam pracownika z danym id z pracy work
            return Id;                                                  //zwracam id pracownika
        }

        public void ShowAllWorkers()
        {
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int id);               //pobieram id z konsolki
            Work work = workService.GetItemBy(id);                      //pobieram obiekt z service metoody
            foreach (var item in work.Workers)                          //foreach listy pracowników tego work
            {
                Console.Write($"{item.ID}) {item.Name}," +              //Wypisuje imiona pracowników
                    $" {item.Surname}, pracuje w {item.WorkIn.Name} ");
            }
        }
        
        public Work GetWorkData()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int id);               //pobieram id z konsolki
            return workService.GetItemBy(id);                           //zwracam work z danym id
        }
        
    }
}
