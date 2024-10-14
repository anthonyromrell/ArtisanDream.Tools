using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class DraggableBehaviour : MonoBehaviour
    {
        private Vector3 offsetPosition;
        private Vector3 newPosition;
        private Camera cam;

        public bool CanDrag { get; set; }
        public UnityEvent onDrag, onUp;

        private void OnEnable()
        {
            cam = Camera.main;
        }

        public IEnumerator OnMouseDown()
        {
            onDrag.Invoke();
            if (cam == null) yield break;
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
            if (!CanDrag)
            {
                onUp.Invoke();
            }
        }
    }
