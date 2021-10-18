using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class draganddropitem : MonoBehaviour,IDragHandler
{
	private Sprite s;
	//[SerializeField] static GameObject player;
	[SerializeField] private Sprite img;
	public static List<string> j = new List<string>();
	[SerializeField] public GameObject p;
	public Boolean drop;

	private GameObject g1;
	//private charactermovement t = player.GetComponent<charactermovement>();
	// Use this for initialization
	void Start()
	{
		j.Add("item1");
		j.Add("item2");
		j.Add("item3");
		j.Add("item4");
		j.Add("item5");
	}

	// Update is called once per frame
	void Update()
	{
		// Debug.Log("inside pointer");
	
	}

	


	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log(gameObject.name);
		s = gameObject.GetComponent<Image>().sprite;
		drop = false;
		//p.GetComponent<charactermovement>().StartCoroutine("dropobj",s.name);
		StartCoroutine(move(s.name));
		gameObject.GetComponent<Image>().sprite = img;
		p.GetComponent<charactermovement>().i[j.IndexOf(gameObject.name)] = 0;
		//Debug.Log(name + " Game Object Clicked!");
	}

	IEnumerator move(string s)
	{
		for (int o = 0; o < p.GetComponent<charactermovement>().dragable.Count; o++)
		{
			if (s==p.GetComponent<charactermovement>().dragable[o].name && drop == false)
			{
				//Debug.Log(s);
				p.GetComponent<charactermovement>().dragable[o].SetActive(true);
				p.GetComponent<charactermovement>().dragable[o].transform.position = new Vector3(
				Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
				Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
				p.GetComponent<charactermovement>().dragable[o].transform.position.z);
			}

			if (Input.GetMouseButtonDown(1))
			{
				drop = true;
				StopCoroutine(move(s));
				break;
			}
		}

		yield return new WaitForSeconds(0f);
		StartCoroutine(move(s));
	}
	
	
}

