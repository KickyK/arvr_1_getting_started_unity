using System.Collections.Generic;
using UnityEngine;

namespace ARVR.Events
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        [Header("Descriptive Information (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        public string Name;

        private List<GameEventListener> listeners = new List<GameEventListener>();

        [ContextMenu("Raise Event")]
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}