using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_EnemyScript : MonoBehaviour
{
    private SniperScirpt sniperScript = null;
    private SniperManager sniperManager = null;

    [SerializeField]
    private bool isSleep = false;

    [SerializeField]
    private float damageDistance = 0f;
    private float checkDamageDistance = 3f; 

    private Vector2 currentPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        sniperScript = FindObjectOfType<SniperScirpt>();
        sniperManager = FindObjectOfType<SniperManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.localPosition;

        GetDamageDistance();
        if(Input.GetKeyDown(KeyCode.A))
            ShootCheck();

        transform.localPosition = currentPosition;
    }
    void ShootCheck()
    {
        if (sniperManager.GetShootAble() != 0)
        {
            if (damageDistance <= checkDamageDistance && !isSleep)
            {
                isSleep = true;
                sniperManager.SetGameClear(isSleep);
            }
            else
            {
                int a = sniperManager.GetShootAble();
                a--;
                sniperManager.SetShooAble(a);
            }
        }
    }
    void GetDamageDistance()
    {
        damageDistance = Vector2.Distance(currentPosition, sniperScript.GetCurrentPosition());
    }
    public void OnclickButton()
    {
        ShootCheck();
    }
}
