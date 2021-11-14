using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banansample : MonoBehaviour,IInventoryItems {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string Name
	{
		get
		{
			return "banana";
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
		//gameObject.SetActive(false);
	}

	public void Ondrop()
	{
		Debug.Log("banaana drop");
	}
}
