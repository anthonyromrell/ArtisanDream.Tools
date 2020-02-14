using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MatchId : MonoBehaviour
{
    [FormerlySerializedAs("ID")] public NameId id;
    [FormerlySerializedAs("OnMatch")] public UnityEvent onMatch;
    [FormerlySerializedAs("NoMatch")] public UnityEvent noMatch;
    public bool MatchMade { private get; set; }

    private void OnTriggerEnter(Collider other)
    {
        var otherId = other.GetComponent<MatchId>();
        if (otherId == null) return;
        
        if (otherId.id == id || otherId.MatchMade)
        {
            onMatch.Invoke();
        }
        else
        {
            noMatch.Invoke();
        }
    }
}