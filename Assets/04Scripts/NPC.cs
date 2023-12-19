using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPC_TYPE
{
    NT_Ludo,
    NT_Luna,
}

public class NPC : MonoBehaviour
{

    [SerializeField]
    private NPC_TYPE type;
    private bool isOn = false;
    private Collider2D col;

    [SerializeField]
    private IDialog dialog;

    private GameObject obj;


    private void Awake()
    {
        if (!TryGetComponent<Collider2D>(out col))
        {
            Debug.Log("NPC.cs - Awake() - col 참조 실패");
        }
        else
        {
            col.isTrigger = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider other)
    {
        if(!isOn && other.CompareTag("NPC"))
        {
            isOn = true;
            dialog.DialogOpen();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(isOn && other.CompareTag("NPC"))
        {
            isOn = false;
            dialog.DialogClose();
        }
    }*/
}
