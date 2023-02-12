using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f,10f) ] float moveSpeed = 5f;
    [SerializeField] ParticleSystem particulas;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    Vector2 input;
    AudioManager audioManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if(input.x < 0 && !sprite.flipX)
        {
            sprite.flipX = true;
        }
        if(input.x > 0 && sprite.flipX)
        {
            sprite.flipX = false;
        }
        if(input == Vector2.zero)
        {
            particulas.Pause();
            animator.Play("Idle");
            audioManager.IsWaling = false;
        }
        else
        {
            particulas.Play();
            animator.Play("Caminar");
            audioManager.IsWaling = true;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }
}
