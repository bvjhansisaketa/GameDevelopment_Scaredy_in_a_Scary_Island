using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class itemdrop : MonoBehaviour,IDropHandler
{
	public Inventory Inventory;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnDrop(PointerEventData eventData)
	{
		RectTransform invPanel = transform as RectTransform;
		if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
		{
			String p = transform.GetChild(0).GetComponent<Image>().sprite.name;
			for (int i = 0; i < Inventory.mItems.Count; i++)
			{
				if (Equals(Inventory.mItems[i].Name, p))
				{
					Inventory.RemoveItem(Inventory.mItems[i]);
				}
			}

			//inventory.RemoveItem();
		}
	}
}
