using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // HP
    public int hp = 3;

    //�̵��ӵ�
    public float speed = 0.5f;

    //User ������Ʈ���� �����Ÿ�
    public float reactionDistance = 4.0f;

    //�ִϸ��̼� �̸�
    public string idleAnime = "EnemyIdle";      // ���Ͱ� ������ ���� �� �ִϸ��̼� Ŭ���� �̸�
    public string rightAnime = "EnemyRight1";   // ���Ͱ� ���������� �̵����� �� �ִϸ��̼� Ŭ���� �̸�
    public string leftAnime = "EnemyLeft1";     // ���Ͱ� �������� �̵����� �� �ִϸ��̼� Ŭ���� �̸�
    public string RhitAnime = "EnemyRhit1";     // ���Ͱ� �¾��� �� �ִϸ��̼� Ŭ���� �̸�
    public string LhitAnime = "EnemyLhit1";

    string nowAnimation = "";
    string oldAnimation = "";
    string hitAnimation = "";

    float axisH;
    float axisV;

    Rigidbody2D rbody;
    public SpriteRenderer renderer;

    bool isActive = false;

    public int arrangeId = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        GameObject WP = GameObject.FindGameObjectWithTag("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<SpriteRenderer>();
        if (player != null)
        {
            if (isActive)
            {
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float rad = Mathf.Atan2(dy, dx);
                float angle = rad * Mathf.Rad2Deg;

                //������ ���� �ִϸ��̼� Ŭ�� ���� (������)
                if (angle > -45.0f && angle <= 45.0f)
                {

                    //renderer.flipX = true;
                    nowAnimation = "rightAnime";
                    if (nowAnimation == "rightAnime")
                    {
                        // �������� �ٶ󺸰� �ִ� ���¿��� �ǰݴ����� �� �ִϸ��̼� Ŭ�� ����
                        hitAnimation = "RhtiAnime";
                    }
                }
                //������ ���� �ִϸ��̼� Ŭ�� ���� (����)
                else
                {
                    nowAnimation = "leftAnime";
                    if (nowAnimation == "leftAnime")
                    {
                        //������ �ٶ󺸰� �ִ� ���¿��� �ǰݴ����� �� �ִϸ��̼� Ŭ�� ����
                        LhitAnime = "LhhitAnime";
                    }
                }

                //�̵��� ���� �����
                axisH = Mathf.Cos(rad) * speed;
                axisV = Mathf.Sin(rad) * speed;
            }
            else
            {
                //�÷��̾���� �Ÿ� Ȯ��
                float dist = Vector2.Distance(transform.position, player.transform.position);
                if (dist < reactionDistance)
                {
                    isActive = true;
                }
            }
        }
        else if (isActive)
        {
            isActive = false;
            rbody.velocity = Vector2.zero;
        }
    }

    // ������ ������ ����Ǵ� �Լ�
    void FixedUpdate()
    {
        if(isActive && hp > 0)
        {
            rbody.velocity = new Vector2(axisH, axisV);

            // ���� �ִϸ��̼��� ���
            if(nowAnimation != oldAnimation)
            {
                oldAnimation = nowAnimation;
                Animator animator = GetComponent<Animator>();
                animator.Play(nowAnimation);
            }
        }
    }
    
    // Enemy ������Ʈ�� �浹 �̺�Ʈ
    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("HP�� " + hp + "���ҽ��ϴ�.");
        // Weapon �±׸� ������ �ִ� ������Ʈ�� �浹�� Enemy ������Ʈ�� hp ����
        if(collision.gameObject.tag == "Weapon")
        {
            hp--;
            // �̸� ������ ���� hp�� 0�̵Ǹ� Enemy ������Ʈ ��Ȱ��ȭ
            if(hp <= 0)
            {
                gameObject.SetActive(false);
                //renderer.enabled = false;
                //GetComponent<CircleCollider2D>().enabled = false;
                //Destroy(gameObject, 0.5f);
            }
        }
    }
}
