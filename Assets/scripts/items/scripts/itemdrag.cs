using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class itemdrag : MonoBehaviour, IDragHandler, IEndDragHandler {
	public IInventoryItems Item { get; set; }
	public Sprite s;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnDrag(PointerEventData eventData)
	{
		s = transform.GetComponent<Image>().sprite;
		transform.position = Input.mousePosition;
	}

	
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.localPosition=Vector3.zero;
	}
}
