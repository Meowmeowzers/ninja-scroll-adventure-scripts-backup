using UnityEngine;

[RequireComponent(typeof(Transform), typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    Transform tf;
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float speed = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    void FixedUpdate(){
        rb.velocity = direction * speed;
    }

    public void SetMoveDirection(Vector2 input){
        direction = input;
    }
    public void Test(){
        rb.AddForceAtPosition(Vector2.down * speed * 10, tf.position);
    }
}
