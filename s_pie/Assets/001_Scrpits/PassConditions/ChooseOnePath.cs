using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//길을 하나만 선택해서 갈 수 있음
public class ChooseOnePath : MonoBehaviour
{
    [Header("선택이 가능한 모든 길 넣기")]
    [SerializeField] private ChooseOnePath[] link = null;

    private bool noPass = false;

    //길을 지나갔다면 다른 길은 지나가지 못하게 하는 코드
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!noPass && collision.CompareTag("Player"))
        {
            for (int i = 0; i < link.Length; i++)
            {
                link[i].noPass = true;
                link[i].gameObject.layer = LayerMask.NameToLayer("NoPassing");
            }

            gameObject.SetActive(false);
        }
    }
}
