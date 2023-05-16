using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public SpriteRenderer renderer;
    Rigidbody2D player;
    Transform parentTransform;
    private Vector3 lastPosition;

    public string SwordAtk = "sword";
    public string SwordAtkL = "swordL";

    string nowAnimation = "";
    string oldAnimation = "";

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        parentTransform = transform.parent.transform;
        renderer = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 rightPos = new Vector3(0.4f, 0, 0);
        Vector3 rightPosReverse = new Vector3(-0.4f, 0, 0);
        
        //스페이스바가 입력 됐을 때 실행되는 코드
        // 왼쪽을 보는지 오른쪽을 보는지 확인해서 그 조건식에 따른 애니메이션 출력하기 0516
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider 컴포넌트 활성화
            if(currentPosition.x >= transform.position.x)
            {
                nowAnimation = SwordAtk;
                GetComponent<Animator>().Play(nowAnimation);

            }
            else if(currentPosition.x <= transform.position.x)
            {
                nowAnimation = SwordAtkL;
                GetComponent<Animator>().Play(nowAnimation);
            }

            //renderer.flipY = true;
        }
        // 스페이스바의 입력이 해제 됐을 때 실행되는 코드
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;  // Collider 컴포넌트 비활성화
            //renderer.flipY = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = parentTransform.position + rightPosReverse;
            //renderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = parentTransform.position + rightPos;
            //renderer.flipX = false;
        }

        if(oldAnimation != nowAnimation)
        {
            nowAnimation = oldAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }
    }

    void LateUpdate() 
    {
        
        // 부모 오브젝트의 위치를 따라가도록 자식 오브젝트의 위치를 업데이트합니다.
        //transform.position = parentTransform.position;
    }
    
}
