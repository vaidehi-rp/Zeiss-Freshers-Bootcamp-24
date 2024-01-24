using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorEvent
{
    public interface IDoor
    {
        void Open();
        void Close();
    }

    public class Door : IDoor    //should be abstract. interface is fat. buffet example. if he wants simple door?
    {
        public enum State
        {
            OPENED,
            CLOSED
        }

        private State _state;

        public State state
        {
            get { return _state; }
            set { _state = value; }
        }

        public event Action<State> Changed;

        public void ChangeState(State state)
        {
            this._state = state;
            Changed?.Invoke(this._state);
        }

        public void Open()
        {
            ChangeState(State.OPENED);
        }

        public void Close()
        {
            ChangeState(State.CLOSED);
        }
    }
}
