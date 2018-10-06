using UnityEngine;
using UnityEngine.Events;

namespace ArtisanDream.Tools.Legacy
{
    [CreateAssetMenu(fileName = "Object", menuName = "Object/Send And Get Object")]
    public class SendAndGetObject : ScriptableObject
    {
        public UnityEvent SendObject;
        public object Object { get; private set; }

        private void OnEnable()
        {
            Object = null;
        }

        private void SendObjectWork(object obj)
        {
            Object = obj;
            SendObject.Invoke();
        }

        //Overloads
        public void GetObject(Transform obj)
        {
            SendObjectWork(obj);
        }

        public void GetObject(GameObject obj)
        {
            SendObjectWork(obj);
        }

        public void GetObject(ScriptableObject obj)
        {
            SendObjectWork(obj);
        }

        public void GetObject(string obj)
        {
            SendObjectWork(obj);
        }
    }
}