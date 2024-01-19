using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup_NPC01 : PopupBase
{
    [SerializeField]
    private GameObject EquipPrefab;
    [SerializeField]
    private GameObject SellPrefab;

    [SerializeField]
    private RectTransform equipRect;
    [SerializeField]
    private RectTransform fishRect;
    [SerializeField]
    private RectTransform fruitRect;
    [SerializeField]
    private RectTransform vegteRect;

    private GameObject obj;

    private GameObject equipView;
    private GameObject fishView;
    private GameObject fruitView;
    private GameObject vegeView;

    private GameObject checkPopup;
    private TextMeshProUGUI count;
    private Button buyBtn;
    private Button sellBtn;
    private Button tradeBtn;



    private void Awake()
    {
        for(int i = 0; i<7; i++)
        {
            obj = Instantiate(EquipPrefab, equipRect);

        }
    }
}
