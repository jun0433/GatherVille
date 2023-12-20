using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownManager : MonoBehaviour
{
    private TextMeshProUGUI dialogText;
    private GameObject obj;

    private void Awake()
    {
        obj = GameObject.Find("DialogText");
        dialogText = obj.GetComponent<TextMeshProUGUI>();
    }


    public void Action(GameObject scan)
    {
        obj = scan;
        dialogText.text = obj.name;
    }
}
