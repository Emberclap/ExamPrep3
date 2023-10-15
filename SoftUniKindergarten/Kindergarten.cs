using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private string name;
        private int capacity;
        private List<Child> registry;
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List <Child> Registry { get; set; }
        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string fullName)
        {
            string[] childName = fullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (Child child in Registry)
            {
                if (childName[0] == child.FirstName && childName[1] == child.LastName)
                {
                    Registry.Remove(child);
                    return true;
                }
            }
            return false;
        } //=> this.Registry.Remove(this.Registry.FirstOrDefault(x => x.FirstName == fullName.Split(" ")[0] && x.LastName == fullName.Split(" ")[1]));
        public Child GetChild(string fullName) => 
            Registry.FirstOrDefault(x => x.FirstName == fullName.Split(" ")[0] && x.LastName == fullName.Split(" ")[1]);
        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry.OrderByDescending(x=>x.Age).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
