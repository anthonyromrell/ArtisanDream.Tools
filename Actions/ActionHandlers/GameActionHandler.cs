using ArtisanDream.Tools.Actions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class GameActionHandler : MonoBehaviour
    {
        [FormerlySerializedAs("Action")] public GameAction action;
        public UnityEvent Event;

        private void OnEnable()
        {
            action.raiseNoArgs += Respond;
        }

        private void Respond()
        {
            Event.Invoke();
        }
    }
