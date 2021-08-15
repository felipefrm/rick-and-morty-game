using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	public float jumpSpeed = 5f;

	public Vector2 groundCheckPosition;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public string horizontalInput;
	public string jumpInput;

	public Animator animator;

	public AudioSource jumpSound;

	Rigidbody2D rb;

	private float direction;
	private Vector3 facingRight;
	private Vector3 facingLeft;

	private float movement;
	private bool jump;

	private bool isGrounded;

    void Start()
    {
			rb = GetComponent<Rigidbody2D>();
			facingRight = transform.localScale;
			facingLeft = transform.localScale;
			facingLeft.x = facingLeft.x * -1;
    }

	// Update is called once per frame
	void Update()
	{
		movement = Input.GetAxisRaw(horizontalInput) * speed;	// movimento horizontal
		if (Input.GetButtonDown(jumpInput) && isGrounded)		// se apertou pra pular e está no chão é permitido pular
			jump = true;

		animator.SetFloat("Speed", Mathf.Abs(movement));	// seta parametro de velocidade para fazer animação de corrida

		Collider2D collider = Physics2D.OverlapCircle(rb.position + groundCheckPosition, groundCheckRadius, whatIsGround);	// colisor do personagem
		if (collider != null)
		{
			if (rb.velocity.y < 0f)		// se a velocidade vertical é 0, está no chão
			{
				isGrounded = true;
				animator.SetBool("IsGrounded", isGrounded);
			}
		} else
		{
			isGrounded = false;
			animator.SetBool("IsGrounded", isGrounded);
		}

			direction = Input.GetAxisRaw(horizontalInput);	// pega a direção do personagem
			
			if (direction > 0) // se maior que 0, o personagem olha para a direita
					transform.localScale = facingRight;
			else if (direction < 0)	// se maior que 0, o personagem olha para a esquerda
					transform.localScale = facingLeft;

			rb.velocity = new Vector2(direction * speed, rb.velocity.y);	// seta a velocidade

			if (jump)	
			{
				jumpSound.Play();	
				Vector2 vel = rb.velocity;
				vel.y = jumpSpeed;
				rb.velocity = vel;	
				jump = false;
				isGrounded = false;
				animator.SetBool("IsGrounded", isGrounded);
				animator.SetTrigger("Jump");
			}
	}

}
