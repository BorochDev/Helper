using Helper.App.Manager;
using Helper.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Helper
{
    class Program
    {
        static void Main()
        {
            WorkManager workManager = new WorkManager();
            HumanManager humanManager = new HumanManager();
            bool loop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz akcje:");
                Console.WriteLine("1)Add Worker");
                Console.WriteLine("2)Add Work");
                Console.WriteLine("3)Show All Workers");
                Console.WriteLine("4)Show All Works");
                Console.WriteLine("5)Delete Worker");
                Console.WriteLine("6)Delete Work");
                Console.WriteLine("7)Add Worker to work");
                Console.WriteLine("8)Delete Worker");
                Console.WriteLine("9)show workers from 1 work");
                Console.WriteLine("10)end ");
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        humanManager.AddNewHuman();     //wywołanie managera
                        break;
                    case 2:
                        workManager.AddNewWork();       //wywołanie managera
                        break;
                    case 3:
                        humanManager.ShowAllHumans();   //wywołanie managera
                        break;
                    case 4:
                        workManager.ShowAllWorks();     //wywołanie managera
                        break;
                    case 5:
                        int humanID = workManager.DeleteWorker();   //usunięcie pracownika i zwrócenie jego ID
                        humanManager.DeleteWork(humanID);           //usunięcie pracy u pracownika o danym ID
                        break;
                    case 6:
                        Work work = workManager.DeleteWork();       //usunięcie pracy z listy i pobranie jej
                        humanManager.DeleteWork(work);              //zmiana na bezrobotych osób pracujących w tej firmie
                        break;
                    case 7:
                        humanManager.AddWork(workManager.GetWorkData());    //dodanie pracy pobranej z listy service i podanej przez manager
                        break;
                    case 8:
                        humanManager.DeleteWork(workManager.DeleteWorker());//usunięcie z pracy pracownika o danym id
                        break;
                    case 9:
                        workManager.ShowAllWorkers();           //pokazanie wszystkich pracowników danego zakładu
                        break;
                    case 10:
                        loop = false;               //koniec pętli
                        break;
                    default:
                        break;
                }

            } while (loop);
        }
    }
}
