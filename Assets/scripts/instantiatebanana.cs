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
	[SerializeField] private GameObject skull;
	[SerializeField] private AudioSource scaredmin;
	private float timer = 0;
	private int count = 0;
	private float timers = 0;
	[SerializeField] private float duration=5f;

	[SerializeField] private Animator ani;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//ani.SetBool("scared",false);
		timer += Time.deltaTime;
		timers += Time.deltaTime;
		if (timer >= duration )
		{
			//Debug.Log("banana");
			GameObject Instantiateban = Instantiate(banana, new Vector3(Random.Range(-48f,8f),Random.Range(-38f,10.5f),transform.position.z), Quaternion.identity);
			Instantiateban.transform.localScale = new Vector3(0.3f, 0.2f, 0f);
			Instantiateban.SetActive(true);
			timer = 0;
		}
		
		if (timers >= 10 && count <= 5 )
		{
			
			GameObject Instantiateskull = Instantiate(skull, new Vector3(Random.Range(-48f,8f),Random.Range(-38f,10.5f),transform.position.z), Quaternion.identity);
			Instantiateskull.SetActive(true);
			count++;
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

		if ((other.gameObject.tag == "skull"))
		{
			Debug.Log("mini scared");
			ani.SetBool("scared",true);
			scaredmin.Play();
			
		}
		
		
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag=="skull")
		{
			Debug.Log("exit");
			ani.SetBool("scared",false);
			scaredmin.Stop();
		}
	}
}
