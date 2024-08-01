using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    internal class Machine<T> : IEnumerable<T>, IPartCollection<T>, ICloneable, IMyCloneable<Machine<T>>
        where T : Part
    {
        public readonly string Description = "Механизм, который состоит из множества деталей.";
        public string Name { get; set; }
        readonly List<T> _details = new List<T>();
        public Machine() { }

        public object Clone()
        {
            return FullClone();
        }
        public void Add(T newPart) 
        {
            _details.Add(newPart);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _details.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Machine<T> FullClone()
        {
            var result = new Machine<T>() { Name = this.Name};
            _details.ForEach(p => result.Add((T)p.FullClone()));
            return result;
        }
    }
}
