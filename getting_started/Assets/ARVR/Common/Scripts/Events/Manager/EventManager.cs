using System.Collections.Generic;
using ARVR.Patterns;
using UnityEngine;
using UnityEngine.Events;

namespace ARVR.Events
{
    public class EventManager : Singleton<MonoBehaviour>
    {
        private static Dictionary<string, UnityEvent> eventDictionary = new Dictionary<string, UnityEvent>();

        public static void RegisterListener(string eventName, UnityAction listener)
        {
            if (eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void UnregisterListener(string eventName, UnityAction listener)
        {
            if (Instance == null) return;
            if (eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Raise(string eventName)
        {
            if (eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}