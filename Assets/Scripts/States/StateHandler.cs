﻿using System.Collections.Generic;
using UnityEngine;

namespace Game.States
{
    public abstract class StateHandler : MonoBehaviour
    {
        protected Dictionary<string, BaseState> States;
        protected BaseState CurrentState;

        protected abstract void Awake();

        protected virtual void Start()
        {
            foreach (var state in States)
            {
                state.Value.Init(this);
            }
        }

        protected virtual void Update()
        {
            CurrentState?.Execute();
        }

        public void SetState(string state)
        {
            if (!CurrentState.VerifyNextState(state)) return;
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