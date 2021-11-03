using System.Collections.Generic;
using UnityEngine;
using Game.States;

namespace Game
{
    public abstract class StateHandler : MonoBehaviour
    {
        protected Dictionary<string, BaseState> States;
        protected BaseState CurrentState;

        private void Start()
        {
            InitializeDictionary();
            foreach (var state in States.Values)
            {
                state.Init(this);
            }
            SetStartState();
        }

        protected abstract void InitializeDictionary();
        protected abstract void SetStartState();

        private void Update()
        {
            CheckIfStateTransitionNeeded();
            CurrentState?.Execute();
        }

        protected abstract void CheckIfStateTransitionNeeded();

        public void SetState(string state)
        {
            if (CurrentState != null && !CurrentState.VerifyNextState(state)) return;
            BaseState newState = null;
            if (States.TryGetValue(state, out newState))
            {
                CurrentState?.Exit();
                newState.Enter();
                CurrentState = newState;
            }
        }
    }
}