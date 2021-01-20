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
		EmptyBox
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
			UM.SetInteractionBtn(curInterationName.ToString(), true, item);
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
