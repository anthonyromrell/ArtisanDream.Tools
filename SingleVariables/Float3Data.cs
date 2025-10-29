using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Float3Data")]
public class Float3Data : NameId
{
    [SerializeField] private Vector3 value;

    public Vector3 Vector3Value
    {
        get => value;
        set => this.value = value;
    }

    // This method is used to update `value` Vector3 value with given x, y, z coordinates.
    public void UpdateVector3(float x, float y, float z)
    {
        Vector3Value = new Vector3(x, y, z);
    }

    // Updates the `value` Vector3 value directly supplying a Vector3 instance.
    public void UpdateVector3(Vector3 newVector)
    {
        Vector3Value = newVector;
    }
}