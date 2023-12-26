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
    private TextMeshProUGUI dialogText;





    private void Awake()
    {

        obj = GameObject.Find("DialogText");
        dialogText = obj.GetComponent<TextMeshProUGUI>();

        dialog = GameObject.Find("Dialog");
        if (dialog == null)
        {
            Debug.Log("TownManager.cs - Awake() - dialog 호출 실패");
        }

    }

    private void Update()
    {

    }

    public void Action(GameObject scan)
    {

        Debug.Log(scan.name );
        if (CharacterController.Inst.isAction)
        {
            CharacterController.Inst.isAction = false;
            DialogClose();
        }
        else
        {
            CharacterController.Inst.isAction = true;
            DialogOpen();
            obj = scan;
            dialogText.text = obj.name;
        }
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
