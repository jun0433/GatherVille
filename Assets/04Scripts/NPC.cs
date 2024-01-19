using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum NPC_TYPE
{
    NT_Ludo,
    NT_Luna,
}

public class NPC : MonoBehaviour, IPopup, IDialog
{

    [SerializeField]
    private NPC_TYPE type;
    private bool isOn = false;
    private CapsuleCollider2D col;

    private GameObject scanObj;
    private GameObject obj;
    private TextMeshProUGUI dialogText;

    private Button exitBtn;
    private GameObject dialog;
    private bool talkNPC;

    [SerializeField]
    private GameObject popupObj;


    private TownManager town;

    private void Awake()
    {
        dialog = GameObject.Find("Dialog");
        if (dialog == null)
        {
            Debug.Log("TownManager.cs - Awake() - dialog 호출 실패");
        }
        town = GameObject.Find("TownManager").GetComponent<TownManager>();
        if (!TryGetComponent<CapsuleCollider2D>(out col))
        {
            Debug.Log("NPC.cs - Awake() - col 참조 실패");
        }
        obj = GameObject.Find("DialogText");
        dialogText = obj.GetComponent<TextMeshProUGUI>();

        exitBtn = GameObject.Find("ExitBtn").GetComponent<Button>();

        exitBtn.onClick.AddListener(OnClick_ExitBtn);

        talkNPC = false;

        
    }


    private void Update()
    {
        scanObj = CharacterController.Inst.SCANOBJ;
        /*if (scanObj.CompareTag("NPC") && Input.GetKeyDown(KeyCode.G))
        {
            if (scanObj.name == "NPC01")
            {

            }
        }*/
        if (Input.GetKeyDown(KeyCode.Y) && talkNPC)
        {
            PopupOpen();
        }
        else if (Input.GetKeyDown(KeyCode.N) && talkNPC)
        {
            DialogClose();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dialogText.text = "나한테 사거나 팔고 싶은 물건이 있어?\n" + "Press Key[Y/N]";
        DialogOpen();
    }

    public void PopupOpen()
    {
        LeanTween.scale(popupObj, Vector3.one, 0.7f).setEase(LeanTweenType.clamp);
        DialogClose();
    }

    public void PopupClose()
    {
        LeanTween.scale(popupObj, Vector3.zero, 0.7f).setEase(LeanTweenType.clamp);
        dialogText.text = "더 하고 싶은 일이 있어?\n" + "Press Key[Y/N]";
        DialogOpen();
    }

    public void DialogOpen()
    {
        LeanTween.scale(dialog, Vector3.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        talkNPC = true;
    }

    public void DialogClose()
    {
        LeanTween.scale(dialog, Vector3.zero, 0.1f).setEase(LeanTweenType.easeInOutElastic);
        talkNPC = false;
    }

    public void OnClick_ExitBtn()
    {
        PopupClose();
    }
}
