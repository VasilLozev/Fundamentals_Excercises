using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> renovators = new List<Renovator>();
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count{ get { return renovators.Count; } }

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        
        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null)
            {
               return "Invalid renovator's information.";
            }
            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Name == name)
                {
                    renovators.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Type == type)
                {
                    count++;
                    renovators.RemoveAt(i);
                }
            }
            return count;
        }
        public Renovator HireRenovator(string name)
        {
            foreach (var item in renovators)
            {
                if (item.Name == name)
                {
                    item.Hired = true;
                    return item;
                }
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> list = new List<Renovator>();
            foreach (var item in renovators)
            {
                if (item.Days >= days)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators)
            {
                if (item.Hired == false)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
