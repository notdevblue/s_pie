using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public int index = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectManager.LightOn(index);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SelectManager.LightOff(index);
    }
}
