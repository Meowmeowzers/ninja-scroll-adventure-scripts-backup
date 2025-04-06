using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Transform _tf;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    [SerializeField] private float _speed = 2f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tf = GetComponent<Transform>();
    }

    void FixedUpdate(){
        _rb.velocity = _direction * _speed;
    }

    public void SetMoveDirection(Vector2 input){
        _direction = input;
    }
    public void Test(){
        _rb.AddForceAtPosition(Vector2.down * _speed * 10, _tf.position);
    }
}
