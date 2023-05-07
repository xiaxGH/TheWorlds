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
        //�����̽��ٰ� �Է� ���� �� ����Ǵ� �ڵ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider ������Ʈ Ȱ��ȭ
            renderer.flipY = true;
        }
        // �����̽����� �Է��� ���� ���� �� ����Ǵ� �ڵ�
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;  // Collider ������Ʈ ��Ȱ��ȭ
            renderer.flipY = false;
        }
    }
    
}
