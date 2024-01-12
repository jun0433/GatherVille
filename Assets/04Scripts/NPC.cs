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
    private CapsuleCollider2D col;

    [SerializeField]
    private IDialog dialog;

    private GameObject obj;
    private string popupObjName = "None";

    private void Awake()
    {
        if (!TryGetComponent<CapsuleCollider2D>(out col))
        {
            Debug.Log("NPC.cs - Awake() - col 참조 실패");
        }

        obj = GameObject.Find(popupObjName);
        if(obj != null)
        {
            if(!obj.TryGetComponent<IDialog>(out dialog))
            {
                Debug.Log("NPC.cs - Awake() - dialog 참조 실패");
            }

        }
        else
        {
            Debug.Log("NPC.cs - Awake() - 팝업 오브젝트를 찾지 못함");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("NPC"))
        {
            isOn = true;
            dialog.DialogOpen();
        }
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isOn && collision.gameObject.CompareTag("NPC"))
        {
            isOn = false;
            dialog.DialogClose();
        }
    }

}
