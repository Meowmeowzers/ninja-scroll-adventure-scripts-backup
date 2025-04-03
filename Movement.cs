using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // rb.MovePosition((Vector2) tf.position + (direction * speed));
        // rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public void SetMove(Vector2 input){
        direction = input;
    }
    public void Test(){
        Debug.Log("asdf");
        rb.AddForceAtPosition(Vector2.down * speed * 10, tf.position);
    }
}
