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

        

        // �����̽��� �Է��� �������� �� ����Ǵ� �ڵ�
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;  // Collider ������Ʈ ��Ȱ��ȭ
        }

        // ������ ������ �������� ������ Ȯ���Ͽ� ��ġ �� �ִϸ��̼� ����
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

        // �����̽��� �Է� �� �ִϸ��̼� ��� �� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;   // Collider ������Ʈ Ȱ��ȭ
            if (isRight)
            {
                nowAnimation = SwordAtk;
            }
            else
            {
                nowAnimation = SwordAtkL;
            }

            if (nowAnimation != oldAnimation)
            {
                GetComponent<Animator>().Play(nowAnimation);
                oldAnimation = nowAnimation;
            }
            else
            {
                GetComponent<Animator>().Play(nowAnimation, -1, 0f); // �ִϸ��̼��� ������ ó������ ���
            }
        }
    }

    void LateUpdate()
    {
        // �θ� ������Ʈ�� ��ġ�� ���󰡵��� �ڽ� ������Ʈ�� ��ġ�� ������Ʈ�մϴ�.
        // transform.position = parentTransform.position;
    }
}
