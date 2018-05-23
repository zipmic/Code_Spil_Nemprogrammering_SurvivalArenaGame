using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public Text TextForScore;

	// Use this for initialization
	void Start () {


        TextForScore.text = "Final Time:\n"+PlayerPrefs.GetString("score");
		
	}
	
	// Update is called once per frame
	public void restart () {

        SceneManager.LoadScene(1);
		
	}


}
