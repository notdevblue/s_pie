using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ChallengeSaveData
{
    public bool[] challengeClear = new bool[2]; // 업적의 총 갯수 == index값
    public int testNum = 0; // 저장, 로드 기능 테스트용. 삭제해도 됌.
}
public class ChallengeManager : MonoBehaviour
{
    private static ChallengeManager instance;
    private GameManager gameManager = null;
    [SerializeField] // 왠진 몰라도 세이브때 이거 필요함.
    private ChallengeSaveData challengeSaveData = null;

    public static ChallengeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ChallengeManager>();
                if (instance == null)
                {
                    GameObject temp = new GameObject("ChallengeManager");
                    instance = temp.AddComponent<ChallengeManager>();
                }
            }
            return instance;
        }
    }
    [SerializeField]
    private bool challenge1Clear = false;
    private bool challenge1Cleared = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        challengeSaveData = gameManager.GetChallengeSaveData();
    }

    // Update is called once per frame
    void Update()
    {
        Challenge1Check();
    }
    void Challenge1Check()
    {
        #region 채고의! 체신장비!

        if (challenge1Clear && !challenge1Cleared) // challenge1Clear는 첫 도전과제가 완료됬는지를 체크하는 bool값
                                                   // , challenge1Cleared는 이 함수가 중복으로 실행되는 것을 방지하는 bool값
        {
            challenge1Cleared = true;
            challengeSaveData.challengeClear[0] = true; // 도전과제 완료시 해당하는 도전과제 bool값을 true로 수정
            gameManager.ChallengeSave();
        }   

        #endregion
    }
    public void SetChallenge1(bool a)
    {
        challenge1Clear = a;
    } // 스테이지를 클리어했을 때 업적조건이 만족했으면 
                                         // 다른 스크립트에서 이 함수를 호출해서 값을 true로 변경
    public bool GetChallenge1()
    {
        return challenge1Clear;
    }

}
