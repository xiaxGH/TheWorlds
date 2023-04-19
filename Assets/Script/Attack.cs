using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //스페이스바가 입력 됐을 때 실행되는 코드
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider 컴포넌트 활성화
            renderer.flipY = true;
        }
        // 스페이스바의 입력이 해제 됐을 때 실행되는 코드
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;  // Collider 컴포넌트 비활성화
            renderer.flipY = false;
        }
    }
    
}
