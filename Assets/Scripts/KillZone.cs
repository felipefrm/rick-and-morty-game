using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision) 	// esta função aciona quando o collider de um personagem entra no collider da killzone 
	{
		LevelManager.instance.RestartLevel();		// se colidir com a killzone restarta o nível
	}

}
