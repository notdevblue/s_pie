using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour
{
    private Vector2 currentPosition = Vector2.zero;
    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        transform.SetParent(gameManager.GetCanvas().transform);

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
