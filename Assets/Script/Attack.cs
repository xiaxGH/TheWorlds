using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public SpriteRenderer renderer;
    Rigidbody2D player;
    Transform parentTransform;
    private Vector3 lastPosition;
    Collider2D Weapons;

    public GameObject childMotion1;
    public GameObject childMotion2;

    private bool isRight = true;

    public string SwordAtk = "sword";
    public string SwordAtkL = "swordL";
    public string SwordAfk = "swordAfk";
    public string SwordAfkL = "swordAfkL";

    string nowAnimation = "";
    string oldAnimation = "";

    // Start is called before the first frame update
    void Start()
    {
        //childMotion1 = parentTransform.Find("AttackEffect_R");
        //childMotion2 = parentTransform.Find("AttackEffect_L");

        lastPosition = transform.position;
        parentTransform = transform.parent.transform;
        renderer = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Rigidbody2D>();
        Weapons = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 rightPos = new Vector3(0.25f, 0, 0);
        Vector3 rightPosReverse = new Vector3(-0.25f, 0, 0);
        Vector2 rightoffset = new Vector2(0.3f, 0);
        Vector2 leftoffset = new Vector2(-0.3f, 0);

        

        // 스페이스바 입력이 해제됐을 때 실행되는 코드
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;  // Collider 컴포넌트 비활성화
        }

        // 왼쪽을 보는지 오른쪽을 보는지 확인하여 위치 및 애니메이션 설정
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isRight = false;
            transform.position = parentTransform.position + rightPosReverse;
            Weapons.offset = leftoffset;
            GetComponent<Animator>().Play(SwordAfkL);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRight = true;
            transform.position = parentTransform.position + rightPos;
            Weapons.offset = rightoffset;
            GetComponent<Animator>().Play(SwordAfk);  
        }

        // 스페이스바 입력 시 애니메이션 재생 및 설정
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider 컴포넌트 활성화
            if (isRight)
            {
                nowAnimation = SwordAtk;
                childMotion1.SetActive(true);
            }
            else
            {
                nowAnimation = SwordAtkL;
                childMotion2.SetActive(true);
            }

            if (nowAnimation != oldAnimation)
            {
                GetComponent<Animator>().Play(nowAnimation);
                oldAnimation = nowAnimation;
            }
            else
            {
                GetComponent<Animator>().Play(nowAnimation, -1, 0f); // 애니메이션을 강제로 처음부터 재생
            }
        }
        if(childMotion1.activeSelf || childMotion2.activeSelf)
        {
            // 0.1초 후에 현재 게임 오브젝트를 비활성화
            Invoke("DeactivateObject", 0.2f);
        }
    }
    // 비활성화할 메서드
    private void DeactivateObject()
    {
        childMotion1.SetActive(false);
        childMotion2.SetActive(false);
    }
}
