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
            var name = Console.ReadLine();
            var id = workService.GetLastId();
            id++;
            workService.AddItem(new Work(id, name));
        }

        public void ShowWorkByID()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int choice);
            var work = workService.GetItemBy(choice);
            if (work != null)
            {
                Console.WriteLine($"{work.Name}");
                Console.WriteLine("Pracownicy:");
                foreach (var item in work.Workers)
                {
                    Console.WriteLine($"{item.Name} {item.Surname}");
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
            foreach (var item in workService.GetAllItems())
            {
                Console.WriteLine($"{item.ID}){item.Name}");
            }
            Console.ReadKey();
        }

        public Work DeleteWork()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int id);
            Work work = workService.GetItemBy(id);
            workService.DeleteItem(work);
            Console.ReadKey();
            return work;
        }
        
        public void AddWorker(Work work, Human worker)
        {
            workService.AddWorker(work, worker);
            Console.ReadKey();
        }

        public int DeleteWorker()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy zwalniającej: ");
            int.TryParse(Console.ReadLine(), out int Id);
            var work = workService.GetItemBy(Id);
            Console.Write("Podaj ID osoby zwalnianej: ");
            int.TryParse(Console.ReadLine(), out Id);
            workService.DeleteWorker(work, Id);
            return Id;
        }

        public void ShowAllWorkers()
        {
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int id);
            Work work = workService.GetItemBy(id);
            foreach (var item in work.Workers)
            {
                Console.Write($"{item.ID}) {item.Name}, {item.Surname}, pracuje w {item.WorkIn.Name} ");
            }
        }
        
        public Work GetWorkData()
        {
            Console.Clear();
            Console.Write("Podaj ID firmy: ");
            int.TryParse(Console.ReadLine(), out int choice);
            return workService.GetItemBy(choice);
        }
        
    }
}
