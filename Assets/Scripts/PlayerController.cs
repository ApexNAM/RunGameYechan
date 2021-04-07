using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    // 점프수
    private int jumpCount = 0;
    // boolean문
    private bool isGrounded = false;
    private bool isDead = false;
    // 리지드바디와 애니메이터, 오디오소스
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>(); //리지드바디 컴포넌트 가져오기
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
        playerAudio = GetComponent<AudioSource>(); // 오디오소스 컴포넌트 가져오기
    }

    void Update()
    {
        if (isDead) // 죽으면 반환
            return;

        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DeadZone" && !isDead)
            Die();
    }

    private void Die()
    {
        animator.SetTrigger("die"); // die 트리거를 활성화
        playerAudio.clip = deathClip;
        playerAudio.Play(); // 오디오 플레이
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
