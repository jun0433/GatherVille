using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject obj;

    private CharacterController characterController = new CharacterController();


    public void Action()
    {
        obj = characterController.SCANOBJ;
        dialogText.text = obj.name;
    }
}
