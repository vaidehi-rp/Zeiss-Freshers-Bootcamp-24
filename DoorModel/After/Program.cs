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
            Door door = new Door();
            Operator operatorInstance = new Operator(door);

            BuzzerAlert buzzerAlert = new BuzzerAlert(door);
            Action<Door.State> buzzerNotifier = new Action<Door.State>(buzzerAlert.Notify);

            PagerAlert pagerAlert = new PagerAlert(door);
            Action<Door.State> pagerNotifier = new Action<Door.State>(pagerAlert.Notify);

            AutoClose autoClose = new AutoClose(door);
            Action<Door.State> autoCloseNotifier = new Action<Door.State>(autoClose.Notify);

            door.Changed += buzzerNotifier;
            door.Changed += pagerNotifier;
            door.Changed += autoCloseNotifier;

            operatorInstance.OpenDoor();

            // Set timer for 20 seconds
            System.Timers.Timer timer = new System.Timers.Timer(20000);
            timer.Elapsed += (source, e) => {
                // If the door is still open after 20 seconds, notify the observers
                if (door.state == Door.State.OPENED)
                {
                    buzzerNotifier(door.state);
                    pagerNotifier(door.state);
                    autoCloseNotifier(door.state);
                }
            };
            timer.Start();

            operatorInstance.CloseDoor();
        }

    }

}
