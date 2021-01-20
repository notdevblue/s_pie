using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseAchievementScript : MonoBehaviour
{
    // 이 스크립트는 Base스크립트로, 각 패널에는 다른 AchievementScript가 들어가야하며, 그 스크립트들은 각각 이 Base를 상속받는다.
    // protected를 제외한 다른 함수 혹은 변수는 이 스크립트가 들어가는 패널마다 다른 정보를 적어둔다
    // (표시해둔 곳이 수정해야할 곳이다)
    #region 내용을 담을 그릇
    [Header("해당하는 도전과제의 image")]
    [SerializeField]
    protected Image achievementImage = null;
    [Header("해당하는 도전과제의 achievementName")]
    [SerializeField]
    protected Text achievementNameText = null;
    [Header("해당하는 도전과제의 achievementExplanation")]
    [SerializeField]
    protected Text achievementExplanationText = null;
    #endregion

    #region 실질적인 내용
    [Header("도전과제 완료했을 때 achievementImage에 들어갈 sprite")]
    [SerializeField]
    protected Sprite achievementImageSprite = null;
    [Header("도전과제 완료했을 때 achievementName에 들어갈 내용")]
    [SerializeField]
    protected string achievementName = "";
    [Header("도전과제 완료했을 때 achievementExplanation에 들어갈 내용")]
    [SerializeField]
    protected string achievementExplanation = "";

    [Header("도전과제 완료가 아닐 때 achievementImage에 들어갈 sprite")]
    [SerializeField]
    protected Sprite failedSprite = null;
    [Header("도전과제 완료가 아닐 때 achievementName에 들어갈 내용")]
    [SerializeField]
    protected string failedAchievementName = "";
    [Header("도전과제 완료가 아닐 때 achievementExplanation에 들어갈 내용")]
    [SerializeField]
    protected string failedAchievementExplanation = "";
    #endregion
    protected GameManager gameManager = null;
    protected ChallengeSaveData challengeSaveData = null;

    protected void Start()
    {
        gameManager = GameManager.Instance;
        challengeSaveData = gameManager.GetChallengeSaveData();
        SetAchievement();
    }
    void SetAchievement()
    {
       if(challengeSaveData.challengeClear[0]) //
       {
            achievementImage.sprite = achievementImageSprite;
            achievementNameText.text = achievementName;
            achievementExplanationText.text = achievementExplanation;
       }
       else
       {
            achievementImage.sprite = failedSprite;
            achievementNameText.text = failedAchievementName;
            achievementExplanationText.text = failedAchievementExplanation;
       }
    }
}
