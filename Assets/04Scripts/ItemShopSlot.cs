using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemShopSlot : MonoBehaviour
{

    private Popup_NPC01 shopPopup;

    private Image icon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemPrice;
    private TextMeshProUGUI itemAmount;

    private Button buyBtn;
    private Button sellBtn;

    private InventoryitemData data;

    private int slotIndex;

    public int SLOTINDEX
    {
        get => slotIndex;
    }

    // �ܰ� * ����
    private int totalgold;
    public int TOTALGOLD
    {
        get => totalgold;
    }

    private int tradeMaxCount;
    private int priceGold;
    private int curCount;

    private int itemID;

    private GameObject obj;

    private void Awake()
    {
        obj = transform.Find("IconBackground").GetChild(0).gameObject;
        if(obj != null)
        {
            if(!obj.TryGetComponent<Image>(out icon))
            {
                Debug.Log("ItemShopS;ot.cs - Awake() - icon ���� ����");
            }
        }

        obj = transform.Find("IconBackground").GetChild(1).gameObject;
        if (obj != null)
        {
            if (!obj.TryGetComponent<TextMeshProUGUI>(out itemName))
            {
                Debug.Log("ItemShopS;ot.cs - Awake() - itemName ���� ����");
            }
        }

        obj = transform.Find("ItemPrice").gameObject;
        if (obj != null)
        {
            if (!obj.TryGetComponent<TextMeshProUGUI>(out itemPrice))
            {
                Debug.Log("ItemShopS;ot.cs - Awake() - itemPrice ���� ����");
            }
        }

        obj = transform.Find("ItemAmount").gameObject;
        if (obj != null)
        {
            if (!obj.TryGetComponent<TextMeshProUGUI>(out itemAmount))
            {
                Debug.Log("ItemShopS;ot.cs - Awake() - itemAmount ���� ����");
            }
        }

        obj = transform.Find("BuyBtn").gameObject;
        if (obj != null)
        {
            if (!obj.TryGetComponent<Button>(out buyBtn))
            {
                Debug.Log("ItemShopS;ot.cs - Awake() - buyBtn ���� ����");
            }
            else
            {
                buyBtn.onClick.AddListener(OnClick_BuyBtn);
            }
        }

        obj = transform.Find("SellBtn").gameObject;
        if (obj != null)
        {
            if (!obj.TryGetComponent<Button>(out sellBtn))
            {
                Debug.Log("ItemShopS;ot.cs - Awake() - sellBtn ���� ����");
            }
            else
            {
                buyBtn.onClick.AddListener(OnClick_SellBtn);
            }
        }
    }

    public void CreateSlot(Popup_NPC01 shop, int index)
    {
        shopPopup = shop;
        slotIndex = index;
        gameObject.SetActive(false);
    }

    private Inventory inventory;
    List<InventoryitemData> dataList;
    int tradeTotalGold;

    private void RefreshData()
    {
        inventory = GameManager.Inst.Inven;

        dataList = inventory.GetItemList();

    }


    public void RefreshSlot(InventoryitemData data)
    {
        gameObject.SetActive(true);
        itemID = data.itemID;
        curCount = 0;
        // ���� ����
        itemAmount.text = data.amount.ToString();

        if(!GameManager.Inst.GetItemData(itemID, out ItemData_Entity itemData))
        {
            Debug.Log("ItemShopSlot.cs - RefreshSlot() - itemData ���� ����");
            return;
        }

        icon.sprite = Resources.Load<Sprite>(itemData.iconImg);
        icon.enabled = true;
        itemName.text = itemData.name;

        itemPrice.text = itemData.sellGold.ToString();
        priceGold = itemData.sellGold;
    }


    public void OnClick_BuyBtn()
    {

    }

    public void OnClick_SellBtn()
    {

    }



    // �ŷ��� ������ ��, �ŷ� ������ ID, �ŷ� Ƚ��, �� �ŷ� �ݾ��� ��ȯ
    public bool GetSellCount(out int _sellItemID, out int _sellCount, out int _SellGold)
    {
        _sellItemID = itemID;
        _sellCount = curCount;
        _SellGold = totalgold;
        return true;
    }


    public bool GetBuyCount(out int _buyItemID, out int _buyCount, out int _buyGold)
    {
        _buyItemID = itemID;
        _buyCount = curCount;
        _buyGold = totalgold;
        return true;
    }
}

