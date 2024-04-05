using UnityEngine;
using UnityEngine.Events;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private UnityEvent onObjectCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("earth"))
        {
            onObjectCollision.Invoke();
        }
    }
}
