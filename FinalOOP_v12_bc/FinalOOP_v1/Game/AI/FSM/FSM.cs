using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class FSM<T>
    {
        //Encapsular el estado actual
        FSMState<T> _current;
        //Aca inicializamos la FSM con un estado inicial
        public void SetInit(FSMState<T> init)
        {
            _current = init;
            _current.Awake();
        }
        //Actualizar el estado
        public void OnUpdate()
        {
            if (_current != null)
                _current.Execute();
        }
        //Realizamos la transicion

        public void Transition(T input)
        {

            FSMState<T> newState = _current.GetTransition(input);
            if (newState == null) return;
            _current.Sleep();
            _current = newState;
            _current.Awake();

        }
    }
}
