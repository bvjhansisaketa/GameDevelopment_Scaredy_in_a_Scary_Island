using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour, IInventoryItems
{
	[SerializeField] private Animation shipmove;
	private int count;
	// Use this for initialization
	void Start()
	{
		count = 0;
	}

	// Update is called once per frame
	void Update()
	{
		// int layermaskno = LayerMask.GetMask("drag");
		// Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, layermaskno);
		// if (col != null && col.tag == "ship" && count == 0)
		// {
		// 	
		// 	Debug.Log("ship");
		// 	col.GetComponent<Animation>().Play();
		// 	count = 1;
		// 	gameObject.SetActive(false);
		// }
		//
		// if (count == 1)
		// {
		// 	//Destroy(gameObject);
		// 	gameObject.SetActive(false);
		// }
		//

	}

	public string Name
	{
		get
		{
			return "Rope";
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
}
