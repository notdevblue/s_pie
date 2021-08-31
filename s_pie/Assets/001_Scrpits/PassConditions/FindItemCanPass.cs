using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//방에 들어갔을때 아이템을 사용해야 나올 수 있음
public class FindItemCanPass : MonoBehaviour
{
    [Header("지나가지 못하게 하는 콜라이더 넣기")]
    [SerializeField] private GameObject noPassCollider = null;
    [Header("사용해서 지나갈 수 있게 하는 아이템")]
    [SerializeField] private Item needItem = null;

    private Inventory inventory = null;
    private bool isCheck = false;
    private bool isUseItem = false;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //한번 지나가면 못지나가게 만드는 코드
            if (!isCheck)
            {
                isCheck = true;
                noPassCollider.layer = LayerMask.NameToLayer("NoPassing");
            }
            //아이템을 사용했다면 다시 지나갈 수 있게 하는 코드
            else if (!isUseItem)
            {
                if (inventory.UseItem(needItem.name))
                {
                    isUseItem = true;
                    noPassCollider.layer = LayerMask.NameToLayer("Default");
                }
            }
        }
    }
}
