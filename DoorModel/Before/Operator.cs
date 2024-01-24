using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorEvent
{
    public class Operator
    {
        private IDoor _door;

        public Operator(IDoor door)
        {
            _door = door;
        }

        public void OpenDoor()
        {
            _door.Open();
        }

        public void CloseDoor()
        {
            _door.Close();
        }
    }

}
