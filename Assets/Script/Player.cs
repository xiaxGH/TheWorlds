using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // 유저의 이동속도
    public float speed = 3.0f;

    // 유저의 HP
    public int hp = 6;
    public int currentHealth;
    public Image healthUI;

    // 애니메이션 클립 이름
    public string afkPlayer = "PlayerMove";    // 플레이어가 멈춰 있을 때 애니메이션 클립의 이름
    public string afkPlayerL = "PlayerMoveL";  // 플레이어가 왼쪽으로 이동하다가 멈춰 있을 때 애니메이션 클립의 이름 
    public string RightP = "PlayerRight";      // 플레이어가 오른쪽으로 이동중일 때 애니메이션 클립의 이름
    public string LeftP = "PlayerLeft";        // 플레이어가 왼쪽으로 이동중일 때 애니메이션 클립의 이름
    public string HitP = "PlayerHit";          // 플레이어가 몬스터한테 피격 당했을 때 애니메이션 클립의 이름
    public string HitPL = "PlayerHitL";         // 플레이어가 몬스터한테 왼쪽에서 피격 당했을 때 애니메이션 클립의 이름

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
        currentHealth = hp;
    }

    void Update()
    {
        // User 오브젝트 이동시 좌표값
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
            
        }

        if (axisH > 0)
        {
            direction = 1; // 오른쪽으로 이동 중
        }
        else if (axisH < 0)
        {
            direction = -1; // 왼쪽으로 이동 중
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nowAnimation = LeftP;

        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            nowAnimation = afkPlayerL;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            nowAnimation = RightP;
            
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            nowAnimation = afkPlayer;
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

    // 적과 충돌했을 때 실행되는 이벤트
    void OnCollisionEnter2D(Collision2D o)
    {
        int randNum = Random.Range(0, 101);
        Debug.Log("난수 : " + randNum);
        if(o.gameObject.CompareTag("Boss") && randNum <= 20)
        {
            SceneManager.LoadScene(3);
        }
        if (o.gameObject.tag == "Enemy" || o.gameObject.tag == "Boss")
        {
            Debug.Log("플레이어 HP : " + hp + "Player.CS");
            hp--;
            if (direction == 1)
            {
                nowAnimation = HitP;
            }
            else
            {
                nowAnimation = HitPL;
            }
            if (nowAnimation != oldAnimation)
            {

                oldAnimation = nowAnimation;
                GetComponent<Animator>().Play(nowAnimation);

            }

            // 설정해둔 User 오브젝트의 hp가 0일때 Field Scene으로 이동
            if (hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // 체력 변경 시 체력 UI 업데이트
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        // 체력 UI 이미지 변경
        healthUI.sprite = GetHealthSprite();
    }
    private Sprite GetHealthSprite()
    {
        // 현재 체력에 따라 체력 UI 이미지 반환
        // 예시로 체력이 1일 때는 첫 번째 이미지, 2일 때는 두 번째 이미지 등을 반환하도록 설정
        // 실제 게임에서는 적절한 체력 이미지를 반환하도록 구현해야 합니다.
        // 스프라이트 이름이 "Health1", "Health2" 등으로 되어 있다고 가정합니다.
        string spriteName = "Health" + currentHealth;
        return Resources.Load<Sprite>(spriteName);
    }


}
