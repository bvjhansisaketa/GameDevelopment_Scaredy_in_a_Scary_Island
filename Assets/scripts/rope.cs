using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
	private int count;
	// Use this for initialization
	void Start()
	{
		count = 0;
	}

	// Update is called once per frame
	void Update()
	{
		int layermaskno = LayerMask.GetMask("drag");
		Collider2D col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, layermaskno);
		if (col != null && col.tag == "ship" && count==0)
		{
		Debug.Log("shippppp");
//		col.GetComponent<Rigidbody2D>().constraints & 
		//	col.GetComponent<RigidbodyConstraints2D>().
		col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		col.gameObject.transform.position += Vector3.forward * Time.deltaTime * 2;
		col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		count = 1;
		}
	}

}
