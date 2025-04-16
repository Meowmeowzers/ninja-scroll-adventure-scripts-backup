using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AggroRange : MonoBehaviour
{
    [SerializeField] Vector2 _targetDirection;
    [SerializeField] Vector3 _target;
    [SerializeField] float _radius = 5f;
    bool _hasTarget = false;

	void Awake()
	{
		GetComponent<CircleCollider2D>().radius = _radius;
	}

	void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _hasTarget = true;
            _targetDirection = (collision.transform.position - transform.position).normalized;
            _target = collision.transform.position;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _hasTarget = false;
            _targetDirection = Vector2.zero;
            _target = Vector3.zero;
        }
    }

    public Vector2 GetTargetDirection(){
        return _targetDirection;
    }
    public Vector2 GetTarget(){
        return _target;
    }
    public bool DoesTargetExist(){
        return _hasTarget;
    }
}
