using System.Collections.Generic;

namespace Game.States.AI.Substates.Core
{
    public class SubstatesChain
    {
        private List<AISubstate> _substates;
        private int _current;

        public SubstatesChain()
        {
            _substates = new List<AISubstate>(4);
            IsFinished = false;
            _current = 0;
        }

        public bool IsFinished{ get; private set; }
        private void UpdateCurrentCounter()
        {
            while (_substates[_current].IsFinished)
            {
                _substates[_current].Exit();
                _current++;
                if (_current >= _substates.Count)
                {
                    IsFinished = true;
                    return;
                }
                _substates[_current].Enter();
            }
        }
        public void ExecuteCurrent()
        {
            UpdateCurrentCounter();
            if (IsFinished) return;
            _substates[_current].Execute();
        }

        public SubstatesChain Add(AISubstate substate)
        {
            _substates.Add(substate);
            return this;
        }
        
        public void Reset()
        {
            if(!IsFinished) _substates[_current].Exit();
            else IsFinished = false;
            _current = 0;
        }

        public void EnterState(int i)
        {
            if(!IsFinished) _substates[_current].Exit();
            else IsFinished = false;
            _current = i;
        }
    }
}