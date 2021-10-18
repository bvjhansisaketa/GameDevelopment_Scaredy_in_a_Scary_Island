using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class instantiatebanana : MonoBehaviour {
    [SerializeField] private Text score;
    public static float scores = 0;
	[SerializeField] private GameObject banana;
	private float timer = 0;
	[SerializeField] private float duration=5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= duration )
		{
			//Debug.Log("banana");
			GameObject Instantiateban = Instantiate(banana, new Vector3(Random.Range(-30f,23.6f),Random.Range(-24.4f,13f),transform.position.z), Quaternion.identity);
			Instantiateban.transform.localScale = new Vector3(0.3f, 0.2f, 0f);
			Instantiateban.SetActive(true);
			timer = 0;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "banana")
		{
			other.gameObject.SetActive(false);
			scores += 5.0f;
			score.text = "SCORE : " + scores.ToString();
		}
	}
}
