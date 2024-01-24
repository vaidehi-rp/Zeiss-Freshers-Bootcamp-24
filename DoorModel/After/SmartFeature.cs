using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorEvent
{
    public interface ISmartFeature
    {
        void Notify(Door.State state);
    }

    public abstract class SmartFeature : ISmartFeature
    {
        protected IDoor _door;

        public SmartFeature(IDoor door)
        {
            _door = door;
        }

        public virtual void Notify(Door.State state)//abstract --template design pattern
        {
            //Console.WriteLine("Activating the feature");
        }
    }
}
