using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{

    public string itemName; // 아이템의 이름
    public Sprite itemImage; // 아이템의 이미지(인벤 토리 안에서 띄울)

}
