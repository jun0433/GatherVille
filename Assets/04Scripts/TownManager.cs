using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownManager : DialogBase, IDialog
{
    private BoxCollider2D col;
    private TextMeshProUGUI action;
    private GameObject obj;

    private GameObject dialog;

    private GameObject player;
    public TextMeshProUGUI dialogText;
    List<InventoryitemData> dataList;

    private Inventory inventory;


    private void Awake()
    {
        inventory = GameManager.Inst.Inven;
        obj = GameObject.Find("DialogText");
        dialogText = obj.GetComponent<TextMeshProUGUI>();

        dialog = GameObject.Find("Dialog");
        if (dialog == null)
        {
            Debug.Log("TownManager.cs - Awake() - dialog 호출 실패");
        }
    }


    public void Communicate(InventoryitemData data)
    {
        int itemID = PlayerAction.Inst.ITEMID;
        // inventory 정보 갱신
        if (!GameManager.Inst.GetItemData(itemID, out ItemData_Entity itemData))
        {
            Debug.Log("TownManager.cs - communicate() - itemData 참조 실패");
            return;
        }


        DialogOpen();
        if (itemData.id < 2000)
        {
            dialogText.text = itemData.name + "를 잡았다." + "\n" + itemData.explain;
        }
        else if (itemData.id < 3000)
        {
            dialogText.text = itemData.name + "를 수확했다." + "\n" + itemData.explain;
        }
        else if (itemData.id < 4000)
        {
            dialogText.text = itemData.name + "를 채집했다." + "\n" + itemData.explain;
        }
        Invoke("DialogClose", 1.5f);
    }

    public void DialogOpen()
    {
        LeanTween.scale(dialog, Vector3.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
    }

    public void DialogClose()
    {
        LeanTween.scale(dialog, Vector3.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
    }




}
