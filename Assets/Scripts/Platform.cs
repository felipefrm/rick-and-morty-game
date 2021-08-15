using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

	public Sprite blue;		// plataforma azul
	public Sprite green;	// plataforma verde
	private Sprite startSprite;

	public LayerMask blueMask;
	public LayerMask greenMask;
	private LayerMask startMask;

	public bool makeBlue;
	public bool makeGreen;

	SpriteRenderer sr;
	PlatformEffector2D effector;


	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		effector = GetComponent<PlatformEffector2D>();

		startSprite = sr.sprite;	
		if(effector != null)
			startMask = effector.colliderMask;
	}

	public void MakeBlue()
	{
		sr.sprite = blue;		// altera pra platafora azul
		gameObject.layer = LayerMask.NameToLayer("Blue");	
		if (effector != null)
			effector.colliderMask = blueMask;	// colider é setado somente pro azul
	}

	public void MakeGreen()
	{
		sr.sprite = green;	// altera pra platafora verde
		gameObject.layer = LayerMask.NameToLayer("Green");
		if (effector != null)
			effector.colliderMask = greenMask; // colider é setado somente pro verde
	}

	public void Uncolor()
	{
		sr.sprite = startSprite;	// inicia com a sprite padrão, sem cor
		gameObject.layer = LayerMask.NameToLayer("Platform");
		if (effector != null)
			effector.colliderMask = startMask;	// colider ativo tanto pra green quanto pra blue
	}

	private void OnTriggerEnter2D(Collider2D col)		// se algum dos collider entrar na plataforma aciona esta função
	{
			if (col.CompareTag("Rick"))		// se foi o collider de tag rick, plataforma fica azul
			{
				MakeBlue();
			}
			else if (col.CompareTag("Morty"))	// se foi o collider de tag morty, plataforma fica verde
			{
				MakeGreen();
		}
	}

}
