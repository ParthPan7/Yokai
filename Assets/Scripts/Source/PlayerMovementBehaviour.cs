using UnityEngine;
using UnityEngine.AI;

namespace Actor
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Rigidbody _rigidBody;

        void Awake()
        {
        }

        void FixedUpdate()
        {

        }
    }
}
