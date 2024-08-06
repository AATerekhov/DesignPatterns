using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    internal class RobotPart : Part, IMyCloneable<RobotPart>
    {
        private new readonly string Description = "Специальная деталь, которую могут содержать роботы.";
        public bool IsElectric { get; set; }
        public bool IsMobile { get; set; }
        public RobotPart(string name, double weight, bool isElectric, bool isMobile) : base(name, weight)
        {
            IsElectric = isElectric;
            IsMobile = isMobile;
        }
        public override object Clone()
        {
            return this.FullClone();
        }
        public override RobotPart FullClone()
        {
            return new RobotPart(Name, Weight, IsElectric, IsMobile);
        }
    }
}
