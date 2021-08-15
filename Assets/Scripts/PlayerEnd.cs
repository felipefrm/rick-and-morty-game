using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
	public PlayerMovement movement;
	public Animator animator;

	private bool hasEnded = false;

    // Update is called once per frame
    void Update()
    {
		if (LevelManager.instance.levelComplete && !hasEnded)
		{
			animator.SetBool("hasEnded", true);	// seta parametro do animator para fazer a animação de fim de fase
			hasEnded = true;
			movement.enabled = false;		// bloqueia a movimentação do personagem
		}
	}
}
