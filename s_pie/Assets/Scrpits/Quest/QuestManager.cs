using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Text questText;
    [SerializeField] private string[] content;
    private int questNum = 0;
    private bool questClear = false;

    private Slot[] slots;
    [SerializeField] private Item[] sharpItem;

    private void Awake()
    {
        slots = FindObjectsOfType<Slot>();
        ShowQuest();
    }
    
    public void QuestCheck()
    {
        ClearCheck();

        if(questClear == true)
        {
            questClear = false;
            questNum++;
            ShowQuest();
        }
    }

    private void ClearCheck()
    {
        switch (questNum)
        {
            case 0:
                for (int i = 0; i < slots.Length; i++)
                {
                    for (int j = 0; j < sharpItem.Length; j++)
                    {
                        if(slots[i].item == sharpItem[j])
                        {
                            questClear = true;
                            break;
                        }
                    }

                    if (questClear == true)
                        break;
                }
                break;
            case 1:
                if (playerPosition.localPosition.y > 6f)
                {
                    questClear = true;
                }
                break;
            case 2:
                if(GameManager.Instance.isPhotoDone == true)
                {
                    questClear = true;
                }
                break;
        }

    }

    private void ShowQuest()
    {
        questText.text = content[questNum];
    }
}
