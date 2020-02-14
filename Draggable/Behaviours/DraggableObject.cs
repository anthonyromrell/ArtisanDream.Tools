using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class DraggableObject : MonoBehaviour
    {
        private Vector3 offsetPosition;
        private Vector3 newPosition;
        private Camera cam;

        public bool CanDrag { get; set; }
        [FormerlySerializedAs("OnDrag")] public UnityEvent onDrag;
        [FormerlySerializedAs("OnUp")] public UnityEvent onUp;
        public bool Draggable { get; set; }

        private void Start()
        {
            cam = Camera.main;
            Draggable = true;
        }

        public IEnumerator OnMouseDown()
        {
            onDrag.Invoke();
            offsetPosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
            yield return new WaitForFixedUpdate();
            CanDrag = true;
            while (CanDrag)
            {
                yield return new WaitForFixedUpdate();
                newPosition = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
                transform.position = newPosition;
            }
        }

        private void OnMouseUp()
        {
            CanDrag = false;
            if (Draggable)
            {
                onUp.Invoke();
            }
        }
    }
