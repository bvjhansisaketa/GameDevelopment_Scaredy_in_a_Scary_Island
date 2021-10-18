using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
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
		int layermaskno = LayerMask.GetMask("drag");
		Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, layermaskno);
		if (col != null && col.tag == "ship" && count == 0)
		{
			
			Debug.Log("ship");
			col.GetComponent<Animation>().Play();
			count = 1;
			
		}

		if (count == 1)
		{
			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
		
// 		Debug.Log("shippppp");
// 		shipmove.SetBool("moveship",true);
// 		Debug.Log(shipmove.GetBool("moveship"));
// //		col.GetComponent<Rigidbody2D>().constraints & 
// 		//	col.GetComponent<RigidbodyConstraints2D>().
// 		//col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
// 		//col.gameObject.transform.position =  Vector3.MoveTowards(col.gameObject.transform.position,col.gameObject.transform.position*2,Time.deltaTime*2);
// 		//col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		
// 		
// 		//shipmove.SetBool("moveship",false);
		
		// if (shipmove.GetBool("moveship"))
		// {
		// 	shipmove.SetBool("moved",true);
		// 	shipmove.SetBool("moveship",false);
		// }
		
		
	}
	
}
