using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class user : MonoBehaviour
{
    // 유저의 이동속도
    public float speed = 3.0f;

    // 유저의 HP
    public int hp = 3;

    // 애니메이션 클립 이름
    public string afkPlayer = "PlayerMove"; // 플레이어가 멈춰 있을 때 애니메이션 클립의 이름
    public string RightP = "PlayerRight";   // 플레이어가 오른쪽으로 이동중일 때 애니메이션 클립의 이름
    public string LeftP = "PlayerLeft";     // 플레이어가 왼쪽으로 이동중일 때 애니메이션 클립의 이름
    public string HitP = "PlayerHit";       // 플레이어가 몬스터한테 피격 당했을 때 애니메이션 클립의 이름

    // 변수로 쓸 애니메이션
    string nowAnimation = "";
    string oldAnimation = "";
    string HitAnimation = "";

    float axisH;
    float axisV;

    Rigidbody2D rbody;
    bool isMoving = false;

    public SpriteRenderer renderer;

    // 이동 방향 저장 변수
    private int direction;

    void Start()
    {
        // User오브젝트에서 제어할 컴포넌트 객체 할당
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = afkPlayer;
        renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
       
        //User 오브젝트 이동시 좌표값
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
            nowAnimation = afkPlayer;
        }

        if (axisH > 0) 
        {
            direction = 1; // 오른쪽으로 이동 중
        } 
        else if (axisH < 0)
        {
            direction = -1; // 왼쪽으로 이동 중
        }
        
        // User 오브젝트가 이동중이지 않을 때 애니메이션 변경
        if (rbody.velocity.magnitude == 0)
        {
            nowAnimation = afkPlayer;
        }
        // User 오브젝트가 이동 중 일 때 애니메이션 변경
        else if(rbody.velocity.magnitude > 0)
        { 
            if(direction == 1)
            {
                // 오른쪽으로 이동 시 현재 애니메이션에 저장
                nowAnimation = RightP;
            }
            else
            {
                // 왼쪽으로 이동 시 현재 애니메이션에 저장
                nowAnimation = LeftP;
            }

        }
        // 현재 애니메이션을 출력
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }

    }
   
    void FixedUpdate()
    {
        // User 오브젝트의 이동 코드
        rbody.velocity = new Vector2(axisH, axisV) * speed;
        
    }

    // User의 체력이 없으면 Field Scene으로 이동
    void OnCollisionEnter2D(Collision2D o)
    {
        if(o.gameObject.tag == "Enemy")
        {
            hp--;
            if(hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
    