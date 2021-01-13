using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;


public class interactionScript : MonoBehaviour
{
	//public enum Type { Customize, Mission, Emergency };
	//public Type type;
	GameObject Line; //테두리
	public int curInteractionNum;


	void Start()
	{
		//Line = transform.GetChild(0).gameObject;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{ 
			//Line.SetActive(true);
			UM.SetInteractionBtn(curInteractionNum, true);
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			//Line.SetActive(false);
			UM.SetInteractionBtn(0, false);
		}
	}

}
