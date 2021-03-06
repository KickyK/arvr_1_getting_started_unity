using System;
using System.Collections.Generic;

namespace ARVR.FiniteStateMachine
{
    public interface IState
    {
        void OnEnter();

        void Update();  //Tick()

        void OnExit();
    }

    public class StateMachine //: MonoBehaviour
    {
        private IState currentState;
        public String State => currentState.ToString();
        private Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
        private List<Transition> currentTransitions = new List<Transition>();
        private List<Transition> anyTransitions = new List<Transition>();
        private static List<Transition> EmptyTransitions = new List<Transition>(0);

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);

            //if(currentState != null)
            //    currentState.Update();

            currentState?.Update();
        }

        public void SetState(IState state)
        {
            if (state == currentState)
                return;

            currentState?.OnExit();
            currentState = state;

            transitions.TryGetValue(currentState.GetType(), out currentTransitions);
            if (currentTransitions == null)
                currentTransitions = EmptyTransitions;

            currentState.OnEnter();
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            if (transitions.TryGetValue(from.GetType(), out var transitionsList) == false)
            {
                transitionsList = new List<Transition>();
                transitions[from.GetType()] = transitionsList;   //Dictionary => [{StandingClosed, List[]}, {Opening, List[]}]
            }
            transitionsList.Add(new Transition(to, condition));//Dictionary => [{StandingClosed, List[Transition(Opening, HasReceivedOpenRequest)]}}]
        }

        public void AddAnyTransition(IState state, Func<bool> condition)
        {
            anyTransitions.Add(new Transition(state, condition));
        }

        private Transition GetTransition()
        {
            foreach (var transition in anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in currentTransitions)
                if (transition.Condition())
                    return transition;

            return null;
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }
    }
}