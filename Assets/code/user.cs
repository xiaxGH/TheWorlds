using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user : MonoBehaviour
{
    public Vector2 inputmove;
    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        inputmove.x = Input.GetAxisRaw("Horizontal");
        inputmove.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputmove.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
}
