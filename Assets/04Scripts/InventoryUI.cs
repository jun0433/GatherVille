using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]
    private ScrollRect scrollRect;


    List<InventorySlot> slotList = new List<InventorySlot>();

    [SerializeField]
    private GameObject slotPrefabs;
    [SerializeField]
    RectTransform contentTrans;

    InventorySlot slot;
    GameObject obj;
    List<InventoryitemData> dataList;

    private void Awake()
    {
        inventory = GameManager.Inst.Inven;
        //슬롯생성
        InitSlot();
    }


    // slot 초기화
    private void InitSlot()
    {
        for(int i = 0; i < inventory.MAXITEMCOUNT; i++)
        {
            slot = Instantiate(slotPrefabs, contentTrans).GetComponent<InventorySlot>();
            slot.SLOTINDEX = i;
            slot.gameObject.name = slot.gameObject.name + i + 1;
            slotList.Add(slot);
        }
    }


    // 슬롯 정보 최신화
    public void RefreshIcon()
    {
        // inventory 정보 갱신
        inventory = GameManager.Inst.Inven;
        dataList = inventory.GetItemList();
        inventory.CURITEMCOUNT = dataList.Count;

        for(int i = 0; i < inventory.MAXITEMCOUNT; i++)
        {
            if(i < inventory.CURITEMCOUNT && -1 < dataList[i].itemID)
            {
                slotList[i].DrawItem(dataList[i]);
            }
            else
            {
                slotList[i].ClearSlot();
            }


            slotList[i].SelectSlot(false);
        }
    }

}
