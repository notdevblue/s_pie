using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementScript1 : BaseAchievementScript
{
    void SetAchievement()
    {
        if (challengeSaveData.challengeClear[0]) //
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
