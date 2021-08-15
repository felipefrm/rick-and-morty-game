using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public static LevelManager instance;

	public bool levelComplete = false;
	private int currentLevel;

	private void Start()
	{
		
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		instance = this;
	}

	private void Update() {	
				if (Input.GetKeyDown("space"))		// space para pular o nível
        {
            CompleteLevel();
        }
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);	// recarrega a mesma cena
	}


	public void CompleteLevel()
	{
		if (levelComplete)
			return;

		levelComplete = true;	// variavel necessaria pra iniciar a animação final
		StartCoroutine(LoadNextLevel());
	}

	IEnumerator LoadNextLevel()
	{
		yield return new WaitForSeconds(1f);
		Fader.instance.FadeOut();
		yield return new WaitForSeconds(0.6f);

		SceneManager.LoadScene(currentLevel + 1, LoadSceneMode.Single);	// carrega o proximo cenário
	
		Fader.instance.FadeIn();
	
		levelComplete = false;
	}

}
