using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    internal interface IPartCollection<in T>
    {
        void Add(T item);
    }
}
