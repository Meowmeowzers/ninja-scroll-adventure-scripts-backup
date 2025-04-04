
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AggroRange : MonoBehaviour
{
    public Vector2 targetDirection;
    public Vector3 target;
    public bool hasTarget = false;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            hasTarget = true;
            targetDirection = (collision.transform.position - transform.position).normalized;
            target = collision.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            hasTarget = false;
            targetDirection = Vector2.zero;
            target = Vector3.zero;
        }
    }
}
