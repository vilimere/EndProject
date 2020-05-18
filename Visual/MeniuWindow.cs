using System;
using System.Collections.Generic;
using System.Text;

namespace EndProject.Visual
{
    class MeniuWindow
    {

        public void MeniuPrint()
        {
            Console.Clear();

            Console.WriteLine("Darbu sarasas, 'To Do List'");
            Console.WriteLine();
            Console.WriteLine("Pasirinkite norima uzduoti:");
            Console.WriteLine();
            Console.WriteLine("Paspaudus F1 - Parodyti visas uzduotis");
            Console.WriteLine();
            Console.WriteLine("Paspaudus F2 - Parodyti atliktas uzduotis");
            Console.WriteLine("Paspaudus F3 - Parodyti neatliktas uzduotis");
            Console.WriteLine("Paspaudus F4 - Prideti nauja uzduoti");
            Console.WriteLine("Paspaudus F5 - Pabaigti esama uzduoti");
            Console.WriteLine();
            Console.WriteLine("Paspaudus F6 - Atidaryti papildomus pasirinkimus"); 
            Console.WriteLine();
            Console.WriteLine("Paspaudus Q - Uzdaroma programa");                 

        }
    }
}
