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


    // ������ ������ �����ϴ� �Լ�
    public void DrawItem(InventoryitemData newItem)
    {
        if(GameManager.Inst.GetItemData(newItem.itemID, out ItemData_Entity itemData))
        {
            //Resources �������� ������
            icon.sprite = Resources.Load<Sprite>(itemData.iconImg);
            ChangeAmount(newItem.amount);
            isEmpty = false;
            icon.enabled = true;
            
        }
    }

    // ������ �������� ��ĭ ó���ϴ� �Լ�
    public void ClearSlot()
    {
        focus.SetActive(false);
        isSelect = false;
        amount.enabled = false;
        isEmpty = true;
        icon.enabled = false;
    }

    // ���� ������ �������ִ� �Լ�
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
