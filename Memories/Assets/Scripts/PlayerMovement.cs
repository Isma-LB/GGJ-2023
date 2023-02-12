using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f,10f) ] float moveSpeed = 5f;
    [SerializeField] ParticleSystem particulas;
    [SerializeField] bool enableMobileInput = true;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    Vector2 input;
    Vector2 rot;
    AudioManager audioManager;
    Gyroscope gyro;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
        if(enableMobileInput){
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if(enableMobileInput && gyro.enabled == true){
            rot.x += gyro.rotationRate.x;
            rot.y += gyro.rotationRate.y;
            const float verticalTreshold = 0.5f;
            const float horizontalTreshold = 0.5f;
            if (rot.x > horizontalTreshold)
            {
                input.x += 1;
            }
            if (rot.x < -horizontalTreshold)
            {
                input.x += -1;
            }
            if (rot.y > verticalTreshold)
            {
                input.y += 1;
            }
            if (rot.y < -verticalTreshold)
            {
                input.y += -1;
            }
            //input = new Vector2(gyro.rotationRate.x, gyro.rotationRate.y);
        }

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
