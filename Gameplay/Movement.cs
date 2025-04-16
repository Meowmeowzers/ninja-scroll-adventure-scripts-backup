using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    Rigidbody2D _rb;
    Animator _anim;
    Vector2 _movingDirection;
    Vector2 _facingDirection = Vector2.down;
    bool _canMove = true;
    bool _isMoving = false;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        // if(_unitState.GetCurrentState() == CharacterState.Attacking || !_canMove){
        if(!_canMove){
            _rb.velocity = Vector2.zero;
            return;
        }
        _rb.velocity = _movingDirection * _speed;
    }

    public void SetMoveDirection(Vector2 input){
        // if(!_canMove) return;
        
        if(input != Vector2.zero){
            _facingDirection = input;
            _isMoving = true;
        }
        else{
            _isMoving = false;
        }

        _movingDirection = input;
        _anim.SetFloat("Speed", input.sqrMagnitude);
        _anim.SetFloat("MoveX", _movingDirection.x);
        _anim.SetFloat("MoveY", _movingDirection.y);
        _anim.SetFloat("FaceX", _facingDirection.x);
        _anim.SetFloat("FaceY", _facingDirection.y);
    }

    public void SetFacingDirection(Vector2 input){
        _facingDirection = input;
        _anim.SetFloat("FaceX", _facingDirection.x);
        _anim.SetFloat("FaceY", _facingDirection.y);
    }
    public void SetCanMove(bool i){
        _canMove = i;
    }
    public Vector2 GetFacingDirection(){
        return _facingDirection;
    }

    public bool GetIsMoving(){
        return _isMoving;
    }

	void OnDisable()
	{
        _canMove = false;
        _anim.SetFloat("Speed", 0f);
        _anim.SetFloat("MoveX", 0f);
        _anim.SetFloat("MoveY", 0f);
        _rb.velocity = Vector2.zero;
	}
}
