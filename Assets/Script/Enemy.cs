using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // HP
    public int hp = 3;
    //이동속도
    public float speed = 0.5f;
    //반응거리
    public float reactionDistance = 4.0f;
    //애니메이션 이름
    public string idleAnime = "EnemyIdle";
    public string rightAnime = "EnemyRight1";
    public string leftAnime = "EnemyLeft1";
    public string RhitAnime = "EnemyRhit1";
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

                if (angle > -45.0f && angle <= 45.0f)
                {

                    //renderer.flipX = true;
                    nowAnimation = "rightAnime";
                    if (nowAnimation == "rightAnime")
                    {
                        hitAnimation = "RhtiAnime";
                    }
                }
                else
                {
                    //renderer.flipX = false;
                    nowAnimation = "leftAnime";
                    if (nowAnimation == "leftAnime")
                    {
                        LhitAnime = "LhhitAnime";
                    }
                }
                //이동할 벡터 만들기
                axisH = Mathf.Cos(rad) * speed;
                axisV = Mathf.Sin(rad) * speed;
            }
            else
            {
                //플레이어와의 거리 확인
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
    void FixedUpdate()
    {
        if(isActive && hp > 0)
        {
            rbody.velocity = new Vector2(axisH, axisV);
            if(nowAnimation != oldAnimation)
            {
                oldAnimation = nowAnimation;
                Animator animator = GetComponent<Animator>();
                animator.Play(nowAnimation);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("HP가 " + hp + "남았습니다.");
        if(collision.gameObject.tag == "Weapon")
        {
            hp--;
            if(hp <= 0)
            {
                gameObject.SetActive(false);
                //renderer.enabled = false;
                //GetComponent<CircleCollider2D>().enabled = false;
                //Destroy(gameObject, 0.5f);
            }
        }
    }

    //private void OncollisionEnter2D(Collision collision)
    //{
    //    if(colision.gameObject.tag == "Arrow")
    //    {
    //        hp--;
    //        if(hp <= 0)
    //        {
    //            GetComponent<CircleCollider2D>().enabled = false;
    //            rbody.velocity = new Vector2(0, 0);
    //            Animator animator = Getcomponent<Animator>();
    //            animaor.Play(deadAnime);
    //            Destroy(gameObject, 0.5f);
    //        }
    //    }
    //}
}
