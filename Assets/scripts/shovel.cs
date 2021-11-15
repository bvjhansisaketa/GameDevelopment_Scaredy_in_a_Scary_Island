using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovel : MonoBehaviour, IInventoryItems
{
	
	[SerializeField] private GameObject p;
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		int layermaskno = LayerMask.GetMask("soil");
		Collider2D col =
			Physics2D.OverlapCircle(transform.position, 0.1f, layermaskno);
		if (col != null && col.tag == "soil")
		{
			Debug.Log("ship");
			p.SetActive(true);
			col.gameObject.SetActive(false);
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
		Debug.Log("pikup function");
		gameObject.SetActive(false);
	}

	public void Ondrop()
	{
		gameObject.SetActive(true);
		gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,transform.position.z);

	}
}
