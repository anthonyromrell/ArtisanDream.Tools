using UnityEngine;
using UnityEngine.Events;

public class AvailableObjectBehaviour : MonoBehaviour
{
    public AvailableData availableDataObj;
    public GameAction getAttach, sendAvailable;
    private Transform attachPoint;
    public IntData availableNum;
    public UnityEvent fireEvent;

    private void Awake()
    {
        getAttach.raise += AttachHandler;
        availableDataObj.availableObj = this;
    }

    private void Fire()
    {
        fireEvent.Invoke();
    }

    private void OnTriggerEnter(Collider obj)
    {
        availableDataObj.useAvailable += Fire;
        sendAvailable.raise(availableDataObj);
        availableNum.value++;
        GetComponent<BoxCollider>().enabled = false;
        transform.parent = attachPoint.transform;
        Invoke(nameof(Attach), 0.25f);
    }

    private void AttachHandler(object obj)
    {
        var newObj = (Transform) obj;
        attachPoint = newObj;
    }

    private void Attach()
    {
        var transform1 = transform;
        transform1.localPosition = Vector3.zero;
        transform1.localRotation = Quaternion.identity;
    }

    private void OnApplicationQuit()
    {
        availableNum.value = 0;
    }
}