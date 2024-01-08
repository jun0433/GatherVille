using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ �����͸� �����ϴ� Ŭ����
[System.Serializable]
public class InventoryitemData
{
    public int uid; // ���� ID
    public int itemID; // ���̺� ID
    public int amount; // ����
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

    // �κ��丮�� �������� �߰��ϴ� �Լ�
    public void AddItem(InventoryitemData newItem)
    {
        int index = FindItemIndex(newItem); // �ߺ��� ���������� Ȯ��

        // ���̺� �����Ͱ� �����ϴ��� üũ
        if (index == -1)
        {
            // ó�� ����
            // �ߺ����� �ʵ��� �� ����
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


    // �κ��丮�� �ߺ��� �������� �ִ��� Ȯ���ϴ� �Լ�
    private int FindItemIndex(InventoryitemData newItem)
    {
        int result = -1;
        // �κ��丮�� ������ ����ŭ Ž��
        for(int i = items.Count -1; i>=0; i--)
        {
            // uid�� ���� ��� ��� ��ȯ
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

    // ������ �Ȱų�, �����⸦ �� �� ȣ��Ǵ� �Լ�
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
