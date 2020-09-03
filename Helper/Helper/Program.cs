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
                        humanManager.AddNewHuman();
                        break;
                    case 2:
                        workManager.AddNewWork();
                        break;
                    case 3:
                        humanManager.ShowAllHumans();
                        break;
                    case 4:
                        workManager.ShowAllWorks();
                        break;
                    case 5:
                        int humanID = workManager.DeleteWorker();
                        humanManager.DeleteWork(humanID);
                        break;
                    case 6:
                        Work work = workManager.DeleteWork();
                        humanManager.DeleteWork(work);
                        break;
                    case 7:
                        humanManager.AddWork(workManager.GetWorkData());
                        break;
                    case 8:
                        humanManager.DeleteWork(workManager.DeleteWorker());
                        break;
                    case 9:
                        workManager.ShowAllWorkers();
                        break;
                    case 10:
                        loop = false;
                        break;
                    default:
                        break;
                }

            } while (loop);
        }
    }
}
