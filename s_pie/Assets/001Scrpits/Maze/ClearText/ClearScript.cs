using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour
{
    private Vector2 currentPosition = Vector2.zero;
    private MazeManager mazeManager = null;
    // Start is called before the first frame update
    void Start()
    {
        mazeManager = FindObjectOfType<MazeManager>();
        transform.SetParent(mazeManager.GetCanvas().transform);

        currentPosition.x = 320;
        currentPosition.y = 200;
        transform.localPosition = currentPosition;

        StartCoroutine(DestroyIt());
    }
    private IEnumerator DestroyIt()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
