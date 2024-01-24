using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartDoor door = new SmartDoor(Door.State.CLOSED);
            Operator operatorInstance = new Operator(door);

            BuzzerAlert buzzerAlert = new BuzzerAlert(door);
            PagerAlert pagerAlert = new PagerAlert(door);
            AutoClose autoClose = new AutoClose(door);

            User user = new User();
            user.Subscribe(buzzerAlert, door);
            user.Subscribe(pagerAlert, door);
            user.Subscribe(autoClose, door);

            operatorInstance.OpenDoor();

            // Set timer for 20 seconds
            System.Timers.Timer timer = new System.Timers.Timer(20000);
            timer.Elapsed += (source, e) => {
                // If the door is still open after 20 seconds, notify the observers
                if (door.CurrentState == Door.State.OPENED)
                {
                    buzzerAlert.Notify(Door.State.OPENED);
                    pagerAlert.Notify(Door.State.OPENED);
                    autoClose.Notify(Door.State.OPENED);
                }
            };
            timer.Start();

            operatorInstance.CloseDoor();
        }
    }
}
