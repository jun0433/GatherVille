using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup_NPC01 : PopupBase
{
    [SerializeField]
    private GameObject SellPrefab;

    [SerializeField]
    private RectTransform equipRect;
    [SerializeField]
    private RectTransform fishRect;
    [SerializeField]
    private RectTransform fruitRect;
    [SerializeField]
    private RectTransform vegeRect;

    private GameObject obj;


    private ItemShopSlot shopSlot;

    List<ItemShopSlot> equipSlotList = new List<ItemShopSlot>();
    List<ItemShopSlot> fishSlotList = new List<ItemShopSlot>();
    List<ItemShopSlot> fruitSlotList = new List<ItemShopSlot>();
    List<ItemShopSlot> vegeSlotList = new List<ItemShopSlot>();

    private GameObject equipView;
    private GameObject fishView;
    private GameObject fruitView;
    private GameObject vegeView;

    private GameObject checkPopup;
    private TextMeshProUGUI count;

    private Button equipBtn;
    private Button fishBtn;
    private Button fruitBtn;
    private Button vegeBtn;

    private Button buyBtn;
    private Button sellBtn;
    private Button tradeBtn;



    private void Awake()
    {
        equipView = GameObject.Find("EquipmentView");
        fishView = GameObject.Find("FishView");
        fruitView = GameObject.Find("FruitView");
        vegeView = GameObject.Find("VegeView");


        equipBtn = GameObject.Find("EquipBtn").GetComponent<Button>();
        equipBtn.onClick.AddListener(OnClick_Equip);
        fishBtn = GameObject.Find("FishBtn").GetComponent<Button>();
        fishBtn.onClick.AddListener(OnClick_Fish);
        fruitBtn = GameObject.Find("FruitBtn").GetComponent<Button>();
        fruitBtn.onClick.AddListener(OnClick_Fruit);
        vegeBtn = GameObject.Find("VegeBtn").GetComponent<Button>();
        vegeBtn.onClick.AddListener(OnClick_Vege);

        for (int i = 0; i < 7; i++)
        {
            obj = Instantiate(SellPrefab, equipRect);
            shopSlot = obj.GetComponent<ItemShopSlot>();
            shopSlot.CreateSlot(this, i);
            obj.name = "EquipSlot_" + i;
            equipSlotList.Add(shopSlot);
        }

        for (int i = 0; i < 7; i++)
        {
            obj = Instantiate(SellPrefab, fishRect);
            shopSlot = obj.GetComponent<ItemShopSlot>();
            shopSlot.CreateSlot(this, i);
            obj.name = "FishSlot_" + i;
            fishSlotList.Add(shopSlot);
        }

        for (int i = 0; i < 16; i++)
        {
            obj = Instantiate(SellPrefab, fruitRect);
            shopSlot = obj.GetComponent<ItemShopSlot>();
            shopSlot.CreateSlot(this, i);
            obj.name = "FruitSlot_" + i;
            fruitSlotList.Add(shopSlot);
        }

        for (int i = 0; i < 24; i++)
        {
            obj = Instantiate(SellPrefab, vegeRect);
            shopSlot = obj.GetComponent<ItemShopSlot>();
            shopSlot.CreateSlot(this, i);
            obj.name = "VegeSlot_" + i;
            vegeSlotList.Add(shopSlot);
        }

        OnClick_Equip();
    }

    

    InventoryitemData data = new InventoryitemData();

    private void RefreshEquipList()
    {
        for(int i = 0; i < 7; i++)
        {
            data.itemID = 10001 + i;

            equipSlotList[i].RefreshSlot(data);
        }
    }

    private void RefreshFishList()
    {
        for (int i = 0; i < 7; i++)
        {
            data.itemID = 1001 + i;

            fishSlotList[i].RefreshSlot(data);
        }
    }

    private void RefreshFruitList()
    {
        for (int i = 0; i < 16; i++)
        {
            data.itemID = 2001 + i;

            fruitSlotList[i].RefreshSlot(data);
        }
    }

    private void RefreshVegeList()
    {
        for (int i = 0; i < 24; i++)
        {
            data.itemID = 3001 + i;

            vegeSlotList[i].RefreshSlot(data);
        }
    }

    public void OnClick_Equip()
    {
        RefreshEquipList();
        equipView.SetActive(true);
        fishView.SetActive(false);
        fruitView.SetActive(false);
        vegeView.SetActive(false);
    }

    public void OnClick_Fish()
    {
        RefreshFishList();
        equipView.SetActive(false);
        fishView.SetActive(true);
        fruitView.SetActive(false);
        vegeView.SetActive(false);
    }

    public void OnClick_Fruit()
    {
        RefreshFruitList();
        equipView.SetActive(false);
        fishView.SetActive(false);
        fruitView.SetActive(true);
        vegeView.SetActive(false);
    }

    public void OnClick_Vege()
    {
        RefreshVegeList();
        equipView.SetActive(false);
        fishView.SetActive(false);
        fruitView.SetActive(false);
        vegeView.SetActive(true);
    }
}
