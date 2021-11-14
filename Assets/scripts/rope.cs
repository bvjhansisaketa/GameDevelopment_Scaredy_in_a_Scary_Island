using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour, IInventoryItems
{
	[SerializeField] private Animation shipmove;
	
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		int layermaskno = LayerMask.GetMask("drag");
		Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, layermaskno);
		if (col != null && col.tag == "ship")
		{
			Debug.Log("ship traced");
			col.GetComponent<Animation>().Play();
			gameObject.SetActive(false);
		}
	}

	public string Name
	{
		get
		{
			return gameObject.name;
		}
	}

	public Sprite _Image = null;

	public Sprite Image
	{
		get
		{
			return _Image;
		}
	}
	public void OnPickup()
	{
		Debug.Log("pivkup function");
		gameObject.SetActive(false);
	}

	public void Ondrop()
	{
		//gameObject.GetComponent<Collider>().enabled = true;
		gameObject.SetActive(true);
		gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,transform.position.z);
		
	}


}
