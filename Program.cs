using EndProject.Data;
using EndProject.Visual;
using System;
using System.Collections.Generic;
using System.IO;

namespace EndProject
{
    class Program
    {
        static void Main()
        {
            //int Id = 1;

            List<WorkItem> allWorks = new List<WorkItem>()
        {
           //new WorkList() { Id = Id++, Task = "Pakeisti vonios lempute", Person = "Vilius", DueDate = "geguzes 12", Completed = false },
           // new WorkList() { Id = Id++, Task = "Pakeisti vonios ciaupa", Person = "Vilius", DueDate = "geguzes 12", Completed = false },
           // new WorkList() { Id = Id++, Task = "Pakeisti laida virtuvej", Person = "Vilius", DueDate = "geguzes 12", Completed = true },
           // new WorkList() { Id = Id++, Task = "Pakeisti sukuosena", Person = "Vilius", DueDate = "geguzes 12", Completed = false },
           // new WorkList() { Id = Id++, Task = "Nupirkti sviesto pyragui", Person = "Vilius", DueDate = "geguzes 12", Completed = true },
        };
            string file = "db.txt";

            if (File.Exists(file))
            {
                string[] lines = System.IO.File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    var values = line.Split(new string[] { "\t" }, StringSplitOptions.None);

                    allWorks.Add(new WorkItem
                    {
                        Id = Int32.Parse(values[0]),
                        Task = values[1],
                        Person = values[2],
                        DueDate = values[3],
                        Completed = Boolean.Parse(values[4]),
                    });
                }
            }
            else
            {
                //Jeigu nera DB failo, kuriam nauja.

                FileStream creatNewFile = File.Create(file);
            }

            

            //System.Console.WriteLine("Contents of WriteLines2.txt = ");


            

            //AdvencedWindow meniu2 = new AdvencedWindow();

            ActionControl StartUp = new ActionControl(allWorks);
            StartUp.StartProgram();
            

        }        
    }
}
