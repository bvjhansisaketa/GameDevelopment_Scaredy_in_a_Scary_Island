using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItems
{
	string Name { get; }
	Sprite Image { get; }
	void OnPickup();
	void Ondrop();
}

public class InventoryEventArgs : EventArgs
{
	public InventoryEventArgs(IInventoryItems item)
	{
		Item = item;
	}

	public IInventoryItems Item;
}
