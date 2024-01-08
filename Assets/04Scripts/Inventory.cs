using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 아이템 데이터를 관리하는 클래스
[System.Serializable]
public class InventoryitemData
{
    public int uid; // 고유 ID
    public int itemID; // 테이블 ID
    public int amount; // 갯수
}


[System.Serializable]
public class Inventory
{
    private int maxItemCount = 28;
    public int MAXITEMCOUNT
    {
        get => maxItemCount;
    }

    private int curItemCount;
    public int CURITEMCOUNT
    {
        get => curItemCount;
        set => curItemCount = value;
    }


    [SerializeField]
    private List<InventoryitemData> items = new List<InventoryitemData>();

    // 인벤토리에 아이템을 추가하는 함수
    public void AddItem(InventoryitemData newItem)
    {
        int index = FindItemIndex(newItem); // 중복된 아이템인지 확인

        // 테이블 데이터가 존재하는지 체크
        if (index == -1)
        {
            // 처음 습득
            // 중복되지 않도록 값 생성
            newItem.uid = GameManager.Inst.PlayerUID;
            items.Add(newItem);
            curItemCount++;
        }
        else
        {
            items[index].amount += newItem.amount;
        }
    }

    public void UpdateItemInfo()
    {

    }

    public bool ISFull()
    {
        return curItemCount >= maxItemCount;
    }


    // 인벤토리에 중복된 아이템이 있는지 확인하는 함수
    private int FindItemIndex(InventoryitemData newItem)
    {
        int result = -1;
        // 인벤토리의 아이템 수많큼 탐색
        for(int i = items.Count -1; i>=0; i--)
        {
            // uid가 같은 경우 결과 반환
            if(items[i].itemID == newItem.itemID)
            {
                result = i;
                break;
            }
        }
        return result;
    }

    public List<InventoryitemData> GetItemList()
    {
        CURITEMCOUNT = items.Count;
        return items;
    }

    // 상점에 팔거나, 버리기를 할 때 호출되는 함수
    public void DeleteItem(InventoryitemData deleteItem)
    {
        int index = FindItemIndex(deleteItem);

        if(index > -1)
        {
            items[index].amount -= deleteItem.amount;
            if(items[index].amount < 1)
            {
                items.RemoveAt(index);
                curItemCount--;
            }
        }
    }
    
}
