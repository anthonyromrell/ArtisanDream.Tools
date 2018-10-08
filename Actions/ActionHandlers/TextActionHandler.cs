using UnityEngine.Events;

namespace ArtisanDream.Tools.ActionHandlers
{
    public class TextActionHandler : GameActionHandler
    {
        public new UnityEvent<string> Event;

        protected void Respond(object obj)
        {
            Event.Invoke((string) obj);
        }
    }
}