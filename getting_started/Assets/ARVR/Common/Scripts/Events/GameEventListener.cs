using UnityEngine;
using UnityEngine.Events;

namespace ARVR.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;
        // public UnityAction<int, string> OnSomething = delegate { };

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response?.Invoke();
        }
    }
}