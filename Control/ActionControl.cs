using EndProject.Data;
using EndProject.Visual;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EndProject
{
    class ActionControl
    {
        List<WorkItem> AllWorks = new List<WorkItem>();
       
        // ViewRender viewRenderer

        public ActionControl(List<WorkItem> allWorks)
        {
            AllWorks = allWorks;
        }

        string activeWindow;
        // public object AllWorks { get; private set; }

        public void StartProgram()
        {
            MeniuWindow meniu = new MeniuWindow();
            meniu.MeniuPrint();
            activeWindow = "meniuOpen";
            ReadInput();
        }

        public void SecondWindow()
        {
            AdvencedWindow advanced = new AdvencedWindow();
            advanced.AdvencePrint();
            activeWindow = "advancedOpen";
            ReadInput();
        }

        public void ShowToDoList()
        {
            Console.Clear();
            TopicForToDo();
            Console.WriteLine(String.Join(Environment.NewLine, AllWorks));
            Console.WriteLine();
            Console.WriteLine("Grizti i meniu paspauskite: Esc");
            //ReadInput();
        }

        public void ShowUndoneToDoList()
        {
            Console.Clear();
            TopicForToDo();
            Console.WriteLine(String.Join(Environment.NewLine, AllWorks.Where(status => status.Completed == false)));
            
           
        }

        public void ShowDoneToDoList()
        {
            Console.Clear();
            TopicForToDo();
            Console.WriteLine(String.Join(Environment.NewLine, AllWorks.Where(status => status.Completed == true)));
            Console.WriteLine();
            Console.WriteLine("Grizti i meniu paspauskite: Esc");
            
        }

        public void TopicForToDo()
        {
            Console.WriteLine();
            Console.WriteLine("Atidarytas visu darbu sarasas");
            Console.WriteLine();
            Console.WriteLine("Darbo ID            Darbo uzduotis             Kam Paskirta    Atlikimo terminas    Ar darbas yra atliktas");
            Console.WriteLine();
        }

        public void AddNewTaskToList()
        {
            Console.Clear();

            Console.Write("Iveskite nauja uzduoti: ");
            string NewTask = Console.ReadLine();

            Console.Write("Priskirkite atsakinga asmeni: ");
            string NewPerson = Console.ReadLine();

            Console.Write("Priskirkite iki kada atlikti uzduoti (pvz: Geguzes 13): ");
            string NewDueDate = Console.ReadLine();

            AllWorks.Add(new WorkItem
            {
                Id = AllWorks.Any() ? AllWorks.Max(x => x.Id)+1 : 1,
                Task = NewTask,
                Person = NewPerson,
                DueDate = NewDueDate,
                Completed = false

            });
            Console.WriteLine();
            Console.WriteLine("Ivestas darbas: ");
            int lastEntry = AllWorks.Count;         

            Console.WriteLine(AllWorks[lastEntry -1]);

            Console.WriteLine();
            Console.WriteLine("Grizti i meniu paspauskite: Esc");
            
        }


        public void SaveToFile()
        {                     
            Console.WriteLine("Duomenys issaugoti faile 'db.txt' failo vieta: ");
            

            var file = "db.txt";

            File.WriteAllText(file, string.Empty);
            using (StreamWriter w = File.AppendText(file))
            {
                foreach (var line in AllWorks)
                {
                    w.WriteLine($"{line.Id}\t{line.Task}\t{line.Person}\t{line.DueDate}\t{line.Completed}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Grizti i meniu paspauskite: Esc");
        }

        public void ChangeWorkToDone()
        {
            Console.Clear();
            TopicForToDo();
            Console.WriteLine(String.Join(Environment.NewLine, AllWorks.Where(status => status.Completed == false)));
            Console.WriteLine();

            Console.Write("Pasirinkite kuria uzduoti norite uzbaigti: ");          

            int result = 0;
            if (Int32.TryParse(Console.ReadLine(), out result))
            {
                var work = AllWorks.Where(x => x.Id == result && x.Completed == false).FirstOrDefault();

                if (work != null)
                {
                    work.Completed = true;
                    Console.WriteLine("statusas sekmingai pakeistas");
                    
                }
            }
            
            

        }

        public void DeleteTask()
        {
           
        }

        public void ReadInput()        {
            
            bool readKeyActive = true;

            while (readKeyActive == true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                
                if (keyInfo.Key != ConsoleKey.F1 && 
                    keyInfo.Key != ConsoleKey.F2 && 
                    keyInfo.Key != ConsoleKey.F3 && 
                    keyInfo.Key != ConsoleKey.F4 && 
                    keyInfo.Key != ConsoleKey.F5 && 
                    keyInfo.Key != ConsoleKey.F6 &&
                    keyInfo.Key != ConsoleKey.Escape &&
                    keyInfo.Key != ConsoleKey.Q)
                {
                    Console.WriteLine($"Jusu pasirinkimas {keyInfo.Key} negalimas, bandykite dar kart:");                    
                }
                else
                {
                    if (activeWindow == "meniuOpen")
                    {
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.F1:
                                //show full works list
                                ShowToDoList();
                                break;
                            case ConsoleKey.F2:
                                //show undone work
                                ShowUndoneToDoList();
                                break;
                            case ConsoleKey.F3:
                                //show done work
                                ShowDoneToDoList();
                                break;
                            case ConsoleKey.F4:
                                //prideti uzduoti 
                                AddNewTaskToList();
                                break;
                            case ConsoleKey.F5:
                                //pakeisti uzduoti i done                                
                                ChangeWorkToDone();
                                Console.WriteLine();
                                Console.WriteLine("Grizti i meniu paspauskite: Esc");
                                break;
                            case ConsoleKey.F6:
                                //advance meniu
                                SecondWindow();                                
                                break;
                            case ConsoleKey.Escape:
                                //Returns
                                StartProgram();
                                break;
                            case ConsoleKey.Q:
                                //turnes off program
                                readKeyActive = false;
                                break;                           
                        }

                    }
                    else
                    {
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.F1:
                                //Irasyti visas uzduotis i Faila                            
                                SaveToFile();
                                break;
                            case ConsoleKey.F2:
                                //Istrinti esama uzduoti
                                Console.WriteLine("Pasirinktas 2 variantas");
                                break;
                            case ConsoleKey.F3:
                                //main meniu
                                StartProgram();
                                break;
                            case ConsoleKey.Escape:
                                //turnes off program                            
                                SecondWindow();
                                break;
                        }

                    }
                }
                               

            } ;

        }


    }
}
