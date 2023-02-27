using System.Collections.Generic;

namespace Utils
{
    public class StateMachine
    {
        public delegate void OnStateChanged(State to, State from);
        public OnStateChanged StateChanged = delegate{};
        
        public interface IDecision
        {
            State decide(State currentState);
        }

        public abstract class State
        {
            public List<IDecision> Decisions { get; } = new List<IDecision>();

            public virtual void EnterState(State from)
            {
            }

            public virtual void ExitState(State to)
            {
            }

            public virtual State UpdateState()
            {
                return null;
            }
        }

        private State _currentState;

        public State CurrentState
        {
            get => _currentState;

            set
            {
                if (_currentState != value)
                {
                    State oldState = _currentState;
                    if (_currentState != null)
                        _currentState.ExitState(value);

                    _currentState = value;
                    if (_currentState != null)
                        _currentState.EnterState(oldState);
                    StateChanged(_currentState, oldState);
                }
            }
        }

        public void Update()
        {
            if (_currentState != null)
            {
                State newState = _currentState.UpdateState();
                if (newState != null)
                {
                    _currentState = newState;
                }
                else
                {
                    foreach (IDecision decision in _currentState.Decisions)
                    {
                        if (decision != null)
                        {
                            newState = decision.decide(_currentState);
                            if (newState != null)
                            {
                                _currentState = newState;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}