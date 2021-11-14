using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private const int SLOTS = 9;
	public List<IInventoryItems> mItems = new List<IInventoryItems>();
	public event EventHandler<InventoryEventArgs> ItemAdded;
	public event EventHandler<InventoryEventArgs> ItemRemoved;

	public void AddItem(IInventoryItems item)
	{
		if (mItems.Count < SLOTS)
		{
			Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
			if (collider!= null && collider.enabled)
			{
				//collider.enabled = false;
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

	public void RemoveItem(IInventoryItems item)
	{
		if (mItems.Contains(item))
		{
			//collider.enabled = true;
			mItems.Remove(item);
			item.Ondrop();
			Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
			if (collider != null)
			{
				collider.enabled = true;
			}

			if (ItemRemoved != null)
			{
				ItemRemoved(this, new InventoryEventArgs(item));
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
