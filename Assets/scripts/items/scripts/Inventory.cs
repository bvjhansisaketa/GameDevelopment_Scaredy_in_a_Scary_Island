using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private const int SLOTS = 9;
	private List<IInventoryItems> mItems = new List<IInventoryItems>();
	public event EventHandler<InventoryEventArgs> ItemAdded;

	public void AddItem(IInventoryItems item)
	{
		Debug.Log("hi");
		if (mItems.Count < SLOTS)
		{
			Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
				Debug.Log(collider);
			if (collider!= null && collider.enabled)
			{
				
				collider.enabled = false;
				mItems.Add(item);
				item.OnPickup();
				if (ItemAdded != null)
				{
					ItemAdded(this, new InventoryEventArgs(item));
				}
			}
			Debug.Log("item added");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
