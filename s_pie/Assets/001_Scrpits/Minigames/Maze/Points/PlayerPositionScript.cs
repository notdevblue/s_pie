using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 currentPosition = Vector2.zero;

    private PlayerScript playerScript = null;
    private PlayerPositionScript thisScript = null;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.localPosition;
        playerScript = FindObjectOfType<PlayerScript>();
        thisScript = GetComponent<PlayerPositionScript>();

        playerScript.FirstPositionSet(thisScript);
    }
    public Vector2 GetCurrentPosition()
    {
        return currentPosition;
    }


}
