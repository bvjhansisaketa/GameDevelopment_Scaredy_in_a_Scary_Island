using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovel : MonoBehaviour
{
	private int count;

	[SerializeField] private GameObject p;
	// Use this for initialization
	void Start()
	{
		count = 0;
	}

	// Update is called once per frame
	void Update()
	{
		int layermaskno = LayerMask.GetMask("soil");
		Collider2D col =
			Physics2D.OverlapCircle(transform.position, 0.1f, layermaskno);
		if (col != null && col.tag == "soil" && count == 0)
		{
			Debug.Log("ship");
			col.gameObject.SetActive(false);
			p.GetComponent<charactermovement>().dragable[2].SetActive(true);
			count = 1;
			
		}

		if (count==1)
		{
			gameObject.SetActive(false);
		}
		
	}
}
