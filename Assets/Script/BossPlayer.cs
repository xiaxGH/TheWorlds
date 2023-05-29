using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPlayer : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int jumpCount; // ���� ���� Ƚ��

    private bool canJump = true; // ���� ���� ���θ� �����ϴ� ����

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���� �����ϰ� �����̽��ٸ� ���� ���
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float axisH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisH * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (jumpCount < maxJumps) // �ִ� ���� Ƚ������ ���� ��쿡�� ���� ����
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged")) // ���� ������ ���� ���� ���·� ����
        {
            jumpCount = 0;
        }
        if(collision.gameObject.CompareTag("Potal"))
        {
            SceneManager.LoadScene(2);
        }
        
    }
}