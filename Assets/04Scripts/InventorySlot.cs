using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    private bool isEmpty;
    public bool ISEMPTY
    {
        get => isEmpty;
    }

    private int slotIndex;
    public int SLOTINDEX
    {
        get => slotIndex;
        set => slotIndex = value;
    }

    private Image icon;
    private GameObject focus;
    private TextMeshProUGUI amount;
    private Button button;

    private bool isSelect;

    private void Awake()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        focus = transform.GetChild(1).gameObject;
        amount = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick_SelectButton);
    }


    // 슬롯의 정보를 갱신하는 함수
    public void DrawItem(InventoryitemData newItem)
    {
        if(GameManager.Inst.GetItemData(newItem.itemID, out ItemData_Entity itemData))
        {
            //Resources 폴더에서 가져옴
            icon.sprite = Resources.Load<Sprite>(itemData.iconImg);
            ChangeAmount(newItem.amount);
            isEmpty = false;
            icon.enabled = true;
            
        }
    }

    // 슬롯의 아이콘을 빈칸 처리하는 함수
    public void ClearSlot()
    {
        focus.SetActive(false);
        isSelect = false;
        amount.enabled = false;
        isEmpty = true;
        icon.enabled = false;
    }

    // 보유 개수를 변경해주는 함수
    public void ChangeAmount(int newAmount)
    {
        amount.text = newAmount.ToString();
    }

    public void SelectSlot(bool isSelect)
    {
        focus.SetActive(isSelect);
    }

    public void OnClick_SelectButton()
    {
        if (!isEmpty)
        {
            isSelect = true;
            SelectSlot(isSelect);
        }
    }
}
