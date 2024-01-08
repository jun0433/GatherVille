using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject invenObj;
    private InventoryUI inventoryUI;
    private TextMeshProUGUI gold;
    private TextMeshProUGUI ID;

    private Button invenBtn;

    private bool isOpenInventory;


    private void Awake()
    {
        gold = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
        ID = GameObject.Find("ID").GetComponent<TextMeshProUGUI>();
        invenObj = GameObject.Find("Inventory");
        inventoryUI = invenObj.GetComponent<InventoryUI>();
        isOpenInventory = false;


        invenBtn = GameObject.Find("InvenBtn").GetComponent<Button>();
        invenBtn.onClick.AddListener(OnClick_Inven);

        InitUI();
    }

    public void InitUI()
    {
        gold.text = "보유금액: " + GameManager.Inst.PlayerInfo.gold.ToString();
        ID.text = GameManager.Inst.PlayerInfo.userNickName.ToString();
        isOpenInventory = false;
        invenObj.LeanScale(Vector2.zero, 0.01f);
    }

    private void RefreshData()
    {

    }

    private void OnClick_Inven()
    {
        isOpenInventory = !isOpenInventory;
        if(isOpenInventory == true)
        {
            inventoryUI.RefreshIcon();
            invenObj.LeanScale(Vector2.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        }
        else
        {
            invenObj.LeanScale(Vector2.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        }
    }
    
}
