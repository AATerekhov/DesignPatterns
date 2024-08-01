using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    internal class MachineBuilder<T,P>
        where T : IPartCollection<P>, new()
    {
        public readonly string Description = "Сборщик различных механизмов.";
        readonly T _machine;
        public MachineBuilder()
        {
            _machine = new T();
        }

        public void Add(P part) 
        {
            _machine.Add(part);
        }        
        public T GetValue() { return _machine; }
    }
}
