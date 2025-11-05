using UnityEngine;

[CreateAssetMenu(fileName = "AiStats", menuName = "AI/AiStats")]
public class AiStats : ScriptableObject
{
    //NavMeshAgent settings
    public float angularSpeed = 120f;
    public float acceleration = 8f;
    public float stoppingDistance = 0.5f;
    
    //Stats for AI characters
    public float health = 100f;
    public float speed = 3.5f;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
}