using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // ������ �̵��ӵ�
    public float speed = 3.0f;

    // ������ HP
    public int hp = 6;
    public int currentHealth;
    public Image healthUI;

    // �ִϸ��̼� Ŭ�� �̸�
    public string afkPlayer = "PlayerMove";    // �÷��̾ ���� ���� �� �ִϸ��̼� Ŭ���� �̸�
    public string afkPlayerL = "PlayerMoveL";  // �÷��̾ �������� �̵��ϴٰ� ���� ���� �� �ִϸ��̼� Ŭ���� �̸� 
    public string RightP = "PlayerRight";      // �÷��̾ ���������� �̵����� �� �ִϸ��̼� Ŭ���� �̸�
    public string LeftP = "PlayerLeft";        // �÷��̾ �������� �̵����� �� �ִϸ��̼� Ŭ���� �̸�
    public string HitP = "PlayerHit";          // �÷��̾ �������� �ǰ� ������ �� �ִϸ��̼� Ŭ���� �̸�
    public string HitPL = "PlayerHitL";         // �÷��̾ �������� ���ʿ��� �ǰ� ������ �� �ִϸ��̼� Ŭ���� �̸�

    // ������ �� �ִϸ��̼�
    string nowAnimation = "";
    string oldAnimation = "";
    string HitAnimation = "";

    float axisH;
    float axisV;

    Rigidbody2D rbody;
    bool isMoving = false;

    public SpriteRenderer renderer;

    // �̵� ���� ���� ����
    private int direction;


    void Start()
    {
        // User������Ʈ���� ������ ������Ʈ ��ü �Ҵ�
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = afkPlayer;
        renderer = GetComponent<SpriteRenderer>();
        currentHealth = hp;
    }

    void Update()
    {
        // User ������Ʈ �̵��� ��ǥ��
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
            
        }

        if (axisH > 0)
        {
            direction = 1; // ���������� �̵� ��
        }
        else if (axisH < 0)
        {
            direction = -1; // �������� �̵� ��
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


        // ���� �ִϸ��̼��� ���
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }

    }

    void FixedUpdate()
    {
        // User ������Ʈ�� �̵� �ڵ�
        rbody.velocity = new Vector2(axisH, axisV) * speed;

    }

    // ���� �浹���� �� ����Ǵ� �̺�Ʈ
    void OnCollisionEnter2D(Collision2D o)
    {
        int randNum = Random.Range(0, 101);
        Debug.Log("���� : " + randNum);
        if(o.gameObject.CompareTag("Boss") && randNum <= 20)
        {
            SceneManager.LoadScene(3);
        }
        if (o.gameObject.tag == "Enemy" || o.gameObject.tag == "Boss")
        {
            Debug.Log("�÷��̾� HP : " + hp + "Player.CS");
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

            // �����ص� User ������Ʈ�� hp�� 0�϶� Field Scene���� �̵�
            if (hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // ü�� ���� �� ü�� UI ������Ʈ
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        // ü�� UI �̹��� ����
        healthUI.sprite = GetHealthSprite();
    }
    private Sprite GetHealthSprite()
    {
        // ���� ü�¿� ���� ü�� UI �̹��� ��ȯ
        // ���÷� ü���� 1�� ���� ù ��° �̹���, 2�� ���� �� ��° �̹��� ���� ��ȯ�ϵ��� ����
        // ���� ���ӿ����� ������ ü�� �̹����� ��ȯ�ϵ��� �����ؾ� �մϴ�.
        // ��������Ʈ �̸��� "Health1", "Health2" ������ �Ǿ� �ִٰ� �����մϴ�.
        string spriteName = "Health" + currentHealth;
        return Resources.Load<Sprite>(spriteName);
    }


}
