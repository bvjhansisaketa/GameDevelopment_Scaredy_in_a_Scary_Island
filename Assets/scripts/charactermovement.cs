using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;



public class charactermovement : MonoBehaviour
{
	[SerializeField] private Text timer;
	[SerializeField] private Image img;
	[SerializeField] private AudioSource background;
	[SerializeField] public  List<Image> items;
	public int[] i = {0,0,0,0,0} ;
	[SerializeField]  public List<GameObject> dragable;
	private float bound = 50f;
	public Inventory inventory;

	public static float time;
	// Use this for initialization
	void Start () {
		background.Play();
		background.loop = true;
		time = 5*60f;
	}

	private void FixedUpdate()
	{
		if (time > 0)
		{
			timer.text = "TIMER : " + time.ToString();
			time -= Time.deltaTime;
		}
		if(time<0.3)
		{
			Debug.Log("gameover");
			SceneManager.LoadScene("Scenes/Gameover");
		}
	}
	
	

	// Update is called once per frame
	void Update ()
	{
		
	//Vector2 mousePos = Input.mousePosition;
	//Vector3 f = Camera.main.ScreenToWorldPoint(mousePos);
	if (Input.GetKey(KeyCode.LeftArrow))
	{
		transform.position += Time.deltaTime*4f*Vector3.left;
	}
	if (Input.GetKey(KeyCode.RightArrow))
	{
		transform.position += Time.deltaTime*4f*Vector3.right;
	}
	if (Input.GetKey(KeyCode.DownArrow))
	{
		transform.position += Time.deltaTime*4f*Vector3.down;
	}
	if (Input.GetKey(KeyCode.UpArrow))
	{
		transform.position += Time.deltaTime*4f*Vector3.up;
	}
	//transform.position = Vector3.MoveTowards(transform.position,new Vector3(f.x,f.y,transform.position.z),Time.deltaTime*2);
	Vector2 f1 = Camera.main.WorldToScreenPoint(transform.position);
	//Debug.Log(f1);
	//Debug.Log("mousepos relat"+Camera.main.ScreenToWorldPoint(mousePos));
	//Debug.Log("Camera pos"+Camera.main.transform.position);
	//Vector2 camerapos = Camera.main.WorldToScreenPoint(transform.position);
	//Debug.Log(Screen.width);
	//Debug.Log(Screen.height);
	//Debug.Log(mousePos);
	if (f1.x >= Screen.width-bound|| f1.y >= Screen.height - bound || f1.x <= bound || f1.y<= bound)
	{ 
		//Debug.Log("f"+f); 
		Camera.main.transform.position = new Vector3(transform.position.x,transform.position.y,Camera.main.transform.position.z);
	}
	int layermaskno = LayerMask.GetMask("Default");
	Collider2D col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f,layermaskno);
	// if (col != null)
	// {
	// 	print(col.name);
	// }

	if (Input.GetMouseButtonDown(0))
	{
		if (col != null && col.tag=="candrag")
		{
			//Debug.Log(col.name);
			IInventoryItems item = col.GetComponent<IInventoryItems>();
			if (item != null)
			{
				Debug.Log(item);
				inventory.AddItem(item);
			}
			//Debug.Log(col.GetComponent<SpriteRenderer>().sprite.name);
			//spr_items.Add(col.GetComponent<SpriteRenderer>().sprite);
			//Debug.Log(spr_items.Count);
			// if (spr_items.Contains(col.GetComponent<SpriteRenderer>().sprite) == false ) 
			// {
			// 	Debug.Log("entered item");
			// 	spr_items.Add(col.GetComponent<SpriteRenderer>().sprite);
			// 	items[spr_items.IndexOf(col.GetComponent<SpriteRenderer>().sprite)].sprite = col.GetComponent<SpriteRenderer>().sprite;
			// 	items[spr_items.IndexOf(col.GetComponent<SpriteRenderer>().sprite)].name = col.name;
			// }
			//Debug.Log(dragable.Count);
			// for(int j = 0;j<i.Length-1;j++){
			// 	if (i[j] != 1 && col.gameObject==dragable[j])
			// 	{
			// 		items[j].sprite = col.GetComponent<SpriteRenderer>().sprite;
			// 		col.gameObject.SetActive(false);
			// 		i[j] = 1;
			// 		break;
			// 	}
			// 	

			//}

			
			
			
		}
		if (col != null && col.gameObject.tag == "gun")
		{
			Debug.Log("gun");
			SceneManager.LoadScene("Scenes/SampleScene");
		}
	}
	}


}
