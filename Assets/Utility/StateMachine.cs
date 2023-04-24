using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomStateMachine
{
    /*
    Реализация машины состояний.
    */
    public class StateMachine
    {
        private IState currentState;

        private Dictionary<Type, IState> states;

        public StateMachine()
        {
            states = new Dictionary<Type, IState>();
        }

        public void ChangeState<T>()
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            if (states.ContainsKey(typeof(T)))
            {
                currentState = states[typeof(T)];
                currentState.Enter();
            }
            else
            {
                throw new Exception("Didn't find state.");
            }
        }
        public void Update()
        {
            if (currentState != null) { currentState.Update(); }

        }
        public void AddState<T>(IState state)
        {
            state.Initialize(this);
            states[typeof(T)] = state;
        }
    }
}