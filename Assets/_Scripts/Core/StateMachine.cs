using System.Collections.Generic;
using _Scripts.Base;

namespace _Scripts.Core
{
    public class StateMachine<T>
    {
        private IState _currentState;
        private Dictionary<T, IState> _states = new();

        public void AddState(T key, IState state)
        {
            _states[key] = state;
        }
        public void ChangeState(T key)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = _states[key];
            _currentState.Enter();
        }
        public void Update()
        {
            _currentState.Update();
        }
    }
}