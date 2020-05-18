using System;
using System.Collections.Generic;
using System.Text;

namespace EndProject.Data
{
    class WorkItem
    {

        public int Id { get; set; }
        public string Task { get; set; }
        public string Person { get; set; }
        public string DueDate { get; set; }
        public bool Completed { get; set; }
                        
        
        public override string ToString()
        {
            return $"Darbas {Id} uzduotis: {Task} - paskirta: {Person} Atlikti iki: {DueDate} Atlikta: {Completed}";
        }
        
    }
}
