using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public AudioClip jump;
	public AudioClip coin;
	
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isRun = false;
    private bool isJump = false;
    private bool isIdle = true;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
	private AudioSource soundEffect;
    private bool isGrounded = true;
    //private float animationTimer = 0f;

    //private float animationInterval = 0.1f;

    //private bool isRunningSprite1 = true;

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
		soundEffect = GetComponent<AudioSource>();
        //spriteRenderer.sprite = idleSprite;
    }

    void Update() {

        animator.SetBool("IsRun", isRun);
        animator.SetBool("IsJump", isJump);
        animator.SetBool("IsIdle", isIdle);
        Move();
        Jump();
        Animate();

    }

    private void Move() {
        float moveInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);

        if (moveInput > 0) {
            transform.localScale = new Vector3(3,3,3);
        }
        else if (moveInput < 0) {
            transform.localScale = new Vector3(-3,3,3);
        }
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			soundEffect.clip = jump;
			soundEffect.Play(0);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void Animate() {
        float moveInput = Input.GetAxis("Horizontal");
        if (!isGrounded) {
            //spriteRenderer.sprite = airSprite;
            isJump = true;
            isIdle = false;
            isRun = false;
        }
        else {
            if(Mathf.Approximately(moveInput, 0)) {
                //spriteRenderer.sprite = idleSprite;
                isJump = false;
                isIdle = true;
                isRun = false;
            }
            else {
                isJump = false;
                isIdle = false;
                isRun = true;

                //animationTimer += Time.deltaTime;
                //if (animationTimer >= animationInterval) {
                //    animationTimer = 0f;
                //    if (isRunningSprite1) {
                //spriteRenderer.sprite = runSprite1;

                //    }
                //    else {
                //spriteRenderer.sprite = runSprite2;
                //    }
                //    isRunningSprite1 = !isRunningSprite1;
            }
            }
        }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Coin")) {
				soundEffect.clip = coin;
				soundEffect.Play(0);
        }
    }

}
