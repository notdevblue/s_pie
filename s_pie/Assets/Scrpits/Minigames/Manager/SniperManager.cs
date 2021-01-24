using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperManager : MonoBehaviour
{
    [SerializeField]
    private int shootAble = 3; // 이 int값 만큼 마취침 쏘기에 도전할 수 있음.
    private bool gameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameClear();
    }
    void GameClear()
    {
        if(gameClear)
        {
            // 미니게임 클리어 됐을 시의 이벤트
            Destroy(gameObject.GetComponentInParent<SniperScirpt>().gameObject);
        }
    }
    public int GetShootAble()
    {
        return shootAble;
    }
    public void SetShooAble(int a)
    {
        shootAble = a;
    }
    public bool GetGameClear()
    {
        return gameClear;
    }
    public void SetGameClear(bool a)
    {
        gameClear = a;
    }
}
