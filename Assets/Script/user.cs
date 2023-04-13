using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user : MonoBehaviour
{
    //public Vector2 inputmove;
    public float speed = 3.0f;

    public string afkPlayer = "PlayerMove";
    public string RightP = "PlayerRight";
    public string LeftP = "PlayerLeft";
    public string HitP = "PlayerHit";

    string nowAnimation = "";
    string oldAnimation = "";
    string HitAnimation = "";

    float axisH;
    float axisV;
    public float angleZ = -90.0f;

    Rigidbody2D rbody;
    bool isMoving = false;
    public SpriteRenderer renderer;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = afkPlayer;
        renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
        
        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = RightP;
            //renderer.sprite = char_1;
            renderer.flipX = false;

        }
        else
        { 
            nowAnimation = LeftP;
            renderer.flipX = true;

        }
        if (nowAnimation != oldAnimation)
        { 
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }
    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(axisH, axisV) * speed;
    }
    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            float rad = Mathf.Atan2(dy, dx);

            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
    }
}