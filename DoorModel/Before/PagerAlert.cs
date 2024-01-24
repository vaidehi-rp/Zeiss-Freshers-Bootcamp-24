using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorEvent
{
    public class PagerAlert : SmartFeature
    {
        public PagerAlert(IDoor door) : base(door) { }

        public override void Notify(Door.State state)
        {
            base.Notify(state);
            //Console.WriteLine("Pager alert activated");
        }
    }
}
