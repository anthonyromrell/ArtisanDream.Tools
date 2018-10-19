using ArtisanDream.Tools.Actions;
using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.ActionHandlers
{
    public class GameActionHandler : MonoBehaviour
    {
        public GameAction Action;
        public UnityEvent Event;

        private void OnEnable()
        {
            Action.RaiseNoArgs += Respond;
        }

        private void Respond()
        {
            Event.Invoke();
        }
    }
}