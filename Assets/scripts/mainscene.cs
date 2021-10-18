using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainscene : MonoBehaviour {

	public void loadscene(string loadsc)
	{
		SceneManager.LoadScene(loadsc);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
