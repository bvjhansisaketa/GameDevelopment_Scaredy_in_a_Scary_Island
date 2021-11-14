using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hub : MonoBehaviour
{
	public Inventory Inventory;

	// Use this for initialization
	void Start()
	{
		Inventory.ItemAdded += InventoryScript_ItemAdded;
		Inventory.ItemRemoved += InventoryScript_ItemRemoved;
	}

	private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
	{
		Transform inventoryPanel = transform.Find("Grid");
		foreach (Transform slot in inventoryPanel)
		{
			Image image = slot.GetChild(0).GetComponent<Image>();
			itemdrag itemDragHandler = slot.GetChild(0).GetComponent<itemdrag>();
			if (!image.enabled)
			{
				Debug.Log("image in inve");
				image.enabled = true;
				image.sprite = e.Item.Image;
				itemDragHandler.Item = e.Item;
				break;
			}
		}
	}

	private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
	{
		Transform inventoryPanel = transform.Find("Grid");
		foreach (Transform slot in inventoryPanel)
		{
			Image image = slot.GetChild(0).GetComponent<Image>();
			itemdrag itemDragHandler = slot.GetChild(0).GetComponent<itemdrag>();
			if (itemDragHandler.Item.Equals(e.Item))
			{
				image.enabled = false;
				image.sprite = null;
				itemDragHandler.Item = null;
				break;
			}
		}
	}
// Update is called once per frame

}
