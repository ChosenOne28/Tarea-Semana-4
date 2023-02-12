using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void vercontroles(){
		SceneManager.LoadScene("Controles");
	}

	public void Salir()
	{
		Application.Quit();
	}
}
