using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    internal class Part:ICloneable, IMyCloneable<Part>
    {
        private readonly string Description = "Деталь, которую можгут содержать любые механизмы.";
        public string Name { get; set; }
        public double Weight { get; set; }
        public Part(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public virtual object Clone()
        {
            return FullClone();
        }

        public virtual Part FullClone()
        {
            return new Part(Name, Weight);
        }
        public override string ToString()
        {
            return $"{Name} - {Weight} кг.";
        }        
    }
}
