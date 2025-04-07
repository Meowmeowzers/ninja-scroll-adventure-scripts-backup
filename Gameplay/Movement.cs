using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    Transform _tf;
    Rigidbody2D _rb;
    Animator _anim;
    Vector2 _movingDirection;
    Vector2 _facingDirection = Vector2.down;
    [SerializeField] float _speed = 2f;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _tf = GetComponent<Transform>();
    }

    void FixedUpdate(){
        _rb.velocity = _movingDirection * _speed;
    }

    public void SetMoveDirection(Vector2 input){
        _movingDirection = input;
        if(input != Vector2.zero) _facingDirection = input;
        _anim.SetFloat("Speed", input.sqrMagnitude);
        _anim.SetFloat(Animator.StringToHash("MoveX"), _movingDirection.x);
        _anim.SetFloat(Animator.StringToHash("MoveY"), _movingDirection.y);
        _anim.SetFloat(Animator.StringToHash("FaceX"), _facingDirection.x);
        _anim.SetFloat(Animator.StringToHash("FaceY"), _facingDirection.y);
        _anim.Play("Walk");
    }
    public void Test(){
        _rb.AddForceAtPosition(Vector2.down * _speed * 10, _tf.position);
    }
}
