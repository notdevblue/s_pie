using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;


public class interactionScript : MonoBehaviour
{

	GameObject Line; //테두리
	public Item item;

	public enum CurInterationName
    {
		Awl,
		Thur,
		Cat_01,
		Cat_02,
		EmptyBox,
		Clicker
	}

	public CurInterationName curInterationName;


	void Start()
	{
		//Line = transform.GetChild(0).gameObject;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{ 
			//Line.SetActive(true);
			if(item != null)
				UM.SetInteractionBtn(curInterationName.ToString(), true, item);
			else
				UM.SetInteractionBtn(curInterationName.ToString(), true);
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			//Line.SetActive(false);
			UM.SetInteractionBtn(null, false, null);
		}
	}

}
