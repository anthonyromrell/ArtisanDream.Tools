using UnityEngine;
using UnityEngine.AI;

public class SimplerAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform playerTransformObj;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTransformObj.position);
    }
}
