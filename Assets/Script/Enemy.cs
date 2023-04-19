using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // HP
    public int hp = 3;

    //이동속도
    public float speed = 0.5f;

    //User 오브젝트와의 반응거리
    public float reactionDistance = 4.0f;

    //애니메이션 이름
    public string idleAnime = "EnemyIdle";      // 몬스터가 가만히 있을 때 애니메이션 클립의 이름
    public string rightAnime = "EnemyRight1";   // 몬스터가 오른쪽으로 이동중일 때 애니메이션 클립의 이름
    public string leftAnime = "EnemyLeft1";     // 몬스터가 왼쪽으로 이동중일 때 애니메이션 클립의 이름
    public string RhitAnime = "EnemyRhit1";     // 몬스터가 맞았을 때 애니메이션 클립의 이름
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

                //각도에 따른 애니메이션 클립 설정 (오른쪽)
                if (angle > -45.0f && angle <= 45.0f)
                {

                    //renderer.flipX = true;
                    nowAnimation = "rightAnime";
                    if (nowAnimation == "rightAnime")
                    {
                        // 오른쪽을 바라보고 있는 상태에서 피격당했을 때 애니메이션 클립 설정
                        hitAnimation = "RhtiAnime";
                    }
                }
                //각도에 따른 애니메이션 클립 설정 (왼쪽)
                else
                {
                    nowAnimation = "leftAnime";
                    if (nowAnimation == "leftAnime")
                    {
                        //왼쪽을 바라보고 있는 상태에서 피격당했을 때 애니메이션 클립 설정
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

    // 프레임 단위로 실행되는 함수
    void FixedUpdate()
    {
        if(isActive && hp > 0)
        {
            rbody.velocity = new Vector2(axisH, axisV);

            // 현재 애니메이션을 출력
            if(nowAnimation != oldAnimation)
            {
                oldAnimation = nowAnimation;
                Animator animator = GetComponent<Animator>();
                animator.Play(nowAnimation);
            }
        }
    }
    
    // Enemy 오브젝트의 충돌 이벤트
    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("HP가 " + hp + "남았습니다.");
        // Weapon 태그를 가지고 있는 오브젝트와 충돌시 Enemy 오브젝트의 hp 감소
        if(collision.gameObject.tag == "Weapon")
        {
            hp--;
            // 미리 설정해 놓은 hp가 0이되면 Enemy 오브젝트 비활성화
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
