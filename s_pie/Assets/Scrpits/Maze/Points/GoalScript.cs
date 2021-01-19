using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private Vector2 currentPosition = Vector2.zero;

    private PlayerScript playerScript = null;
    private GameManager gameManager = null;

    private SpriteRenderer spriteRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        playerScript = FindObjectOfType<PlayerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = playerScript.GetGoalSprite();

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.localPosition;

        ClearCheck();

        transform.localPosition = currentPosition;
    }
    void ClearCheck()
    {
        if (playerScript.GetCurrentPosition() == currentPosition)
            gameManager.SetIsClear(true);
    }
    public void SetCurrentPosition(Vector2 a)
    {
        currentPosition = a;
    }
    public Vector2 GetCurrentPosition()
    {
        return currentPosition;
    }
}
