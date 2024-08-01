using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    internal class Robot : Machine<RobotPart>, IPartCollection<RobotPart>
    {
        public new readonly string Description = "Робот, который состоит из множества специальных деталей.";
        public Robot() { }
    }
}
