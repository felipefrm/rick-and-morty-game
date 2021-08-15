using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// controla os diálogos e as cutscenes
public class CutsceneManager : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
            
        }
    }

    void StartDialogue() 
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else 
        {
            gameObject.SetActive(false);
            new WaitForSeconds(3f);

            if (!SceneManager.GetActiveScene().name.Equals("Ending")) // se não for a última cena
            {
	    	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // vai pra próxima
            }
            else    // senão
            {
	    	    SceneManager.LoadScene("Menu"); // volta para o menu
            }
        }
    }

}
