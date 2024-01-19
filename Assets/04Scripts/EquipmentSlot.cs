using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentSlot : MonoBehaviour
{

    private Popup_NPC01 shopPopup;

    private Image icon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemprice;

    private Button buyBtn;

    private InventoryitemData data;
    private int slotIndex;
    public int SLOTINDEX
    {
        get => slotIndex;
    }

    private int itemID;

    private GameObject obj;

    private void Awake()
    {
        
    }
}
