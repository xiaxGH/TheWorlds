using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPlayer : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int jumpCount; // 현재 점프 횟수

    private bool canJump = true; // 점프 가능 여부를 저장하는 변수

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 점프 가능하고 스페이스바를 누른 경우
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
        if (jumpCount < maxJumps) // 최대 점프 횟수보다 작은 경우에만 점프 가능
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged")) // 땅에 닿으면 점프 가능 상태로 변경
        {
            jumpCount = 0;
        }
        if(collision.gameObject.CompareTag("Potal"))
        {
            SceneManager.LoadScene(2);
        }
        
    }
}