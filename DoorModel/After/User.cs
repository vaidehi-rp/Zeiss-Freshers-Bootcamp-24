using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorEvent
{
    public class User
    {
        public void Subscribe(ISmartFeature feature)
        {  
            Door door = feature as Door;
            if (door != null)
            {
                door.Changed += feature.Notify;
            }
        }

        public void Unsubscribe(ISmartFeature feature)
        {
            Door door = feature as Door;
            if (door != null)
            {
                door.Changed -= feature.Notify;
            }
        }
    }
}
