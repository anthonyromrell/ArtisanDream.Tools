using UnityEngine;
using UnityEngine.Events;

    [CreateAssetMenu(fileName = "WeaponData")]
    public class AvailableData: ScriptableObject
    {
        public Color activeColor = Color.yellow;
        public float powerLevel = 0.1f;
        public float useRate = 0.25f;
        public float totalAvailable = 1f;
        public UnityAction useAvailable;
        
        [HideInInspector]
        public AvailableObjectBehaviour availableObj;

        private void OnEnable()
        {
            totalAvailable = 1f;
        }

        private void OnDisable()
        {
            availableObj = null;
        }
    }
