using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hub : MonoBehaviour
{
	public Inventory Inventory;
	// Use this for initialization
	void Start ()
	{
		Inventory.ItemAdded += InventoryScript_ItemAdded;
	}

	private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
	{
		Transform inventoryPanel = transform.Find("Grid");
		foreach (Transform slot in inventoryPanel)
		{
			Debug.Log("hub cs ");
			Image image = slot.GetChild(0).GetComponent<Image>();
			Debug.Log(image.enabled);
			if (!image.enabled)
			{
				Debug.Log("image in inve");
				image.enabled = true;
				image.sprite = e.Item.Image;
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
