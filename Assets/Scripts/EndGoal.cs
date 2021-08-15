using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{

	public bool hasRick;
	public bool hasMorty;

	private void OnTriggerExit2D(Collider2D col)	// esta função aciona quando o collider sai do objetivo
	{
			if (col.CompareTag("Rick"))	
			{
				hasRick = false;
			}
			else if (col.CompareTag("Morty"))
			{
				hasMorty = false;
			}

	}

	private void OnTriggerStay2D(Collider2D col)	// esta função aciona quando o collider entra e permanece no objetivo
	{
			if (col.CompareTag("Rick"))
			{
				hasRick = true;
			}
			else if (col.CompareTag("Morty"))
			{
				hasMorty = true;
			}

		if (hasMorty && hasRick)	// Se Morty e Rick no objetivo, avança de nível
		{
			LevelManager.instance.CompleteLevel();
		}
	}

}
