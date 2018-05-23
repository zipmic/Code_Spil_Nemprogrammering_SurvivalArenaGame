using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

    public Text TidText;

    private float counter = 0;

    private bool RunTimer = false;
    public GameObject EndScreen;

    public int DifficultyLevel = 1;

    public Slider BaseHealth;

    public BaseHealth BaseHealthScript;

    public GameObject EndExplosion;

    private float CounterForDifficulty = 0;


    public void BaseDestroyed()
    {
        StartCoroutine(EndOfGameBase());
    }

    IEnumerator EndOfGameBase()
    {
        EndExplosion.SetActive(true);

        yield return new WaitForSeconds(3);

        GameOver();
    }

	// Use this for initialization
	void Start () {
		
        RunTimer = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (RunTimer)
        {
            CounterForDifficulty += Time.deltaTime;
            counter += Time.deltaTime;
            TidText.text = "Time: "+((int)(counter));


            if (BaseHealth == null)
            {
                BaseHealth.value = 0;
            }
            else
            {
                BaseHealth.value = BaseHealthScript.Health;
            }
           

            if (CounterForDifficulty > 30)
            {
                DifficultyLevel += 1;
                CounterForDifficulty = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

     

		
	}

    public void GameOver()
    {
        RunTimer = false;
        PlayerPrefs.SetString("score", "" + ((int)(counter)));
        EndScreen.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
