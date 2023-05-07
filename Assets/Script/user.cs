using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class user : MonoBehaviour
{
    // ������ �̵��ӵ�
    public float speed = 3.0f;

    // ������ HP
    public int hp = 3;

    // �ִϸ��̼� Ŭ�� �̸�
    public string afkPlayer = "PlayerMove"; // �÷��̾ ���� ���� �� �ִϸ��̼� Ŭ���� �̸�
    public string RightP = "PlayerRight";   // �÷��̾ ���������� �̵����� �� �ִϸ��̼� Ŭ���� �̸�
    public string LeftP = "PlayerLeft";     // �÷��̾ �������� �̵����� �� �ִϸ��̼� Ŭ���� �̸�
    public string HitP = "PlayerHit";       // �÷��̾ �������� �ǰ� ������ �� �ִϸ��̼� Ŭ���� �̸�

    // ������ �� �ִϸ��̼�
    string nowAnimation = "";
    string oldAnimation = "";
    string HitAnimation = "";

    float axisH;
    float axisV;

    Rigidbody2D rbody;
    bool isMoving = false;

    public SpriteRenderer renderer;

    // �̵� ���� ���� ����
    private int direction;

    void Start()
    {
        // User������Ʈ���� ������ ������Ʈ ��ü �Ҵ�
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = afkPlayer;
        renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
       
        //User ������Ʈ �̵��� ��ǥ��
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
            nowAnimation = afkPlayer;
        }

        if (axisH > 0) 
        {
            direction = 1; // ���������� �̵� ��
        } 
        else if (axisH < 0)
        {
            direction = -1; // �������� �̵� ��
        }
        
        // User ������Ʈ�� �̵������� ���� �� �ִϸ��̼� ����
        if (rbody.velocity.magnitude == 0)
        {
            nowAnimation = afkPlayer;
        }
        // User ������Ʈ�� �̵� �� �� �� �ִϸ��̼� ����
        else if(rbody.velocity.magnitude > 0)
        { 
            if(direction == 1)
            {
                // ���������� �̵� �� ���� �ִϸ��̼ǿ� ����
                nowAnimation = RightP;
            }
            else
            {
                // �������� �̵� �� ���� �ִϸ��̼ǿ� ����
                nowAnimation = LeftP;
            }

        }
        // ���� �ִϸ��̼��� ���
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }

    }
   
    void FixedUpdate()
    {
        // User ������Ʈ�� �̵� �ڵ�
        rbody.velocity = new Vector2(axisH, axisV) * speed;
        
    }

    // ���� �浹���� �� ����Ǵ� �̺�Ʈ
    void OnCollisionEnter2D(Collision2D o)
    {
        if(o.gameObject.tag == "Enemy")
        {
            hp--;
            // �����ص� User ������Ʈ�� hp�� 0�϶� Field Scene���� �̵�
            if(hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
    