using UnityEngine;
using UnityEngine.AI;

public class SimplerAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransformObj;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (playerTransformObj != null)
            agent.SetDestination(playerTransformObj.position);
    }

    public void SetPlayerTransform(Transform newTransform)
    {
        playerTransformObj = newTransform;
    }

    public void SetPlayerTransform(GameObject newGameObject)
    {
        if (newGameObject != null)
            SetPlayerTransform(newGameObject.transform);
    }

    public void SetPlayerTransform(Vector3 newPosition)
    {
        if (playerTransformObj != null)
            playerTransformObj.position = newPosition;
    }

    public void SetPlayerTransform(float x, float y, float z)
    {
        SetPlayerTransform(new Vector3(x, y, z));
    }

    public void SetPlayerTransform(float x, float y)
    {
        SetPlayerTransform(x, y, 0);
    }
}