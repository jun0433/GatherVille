using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    private TextMeshProUGUI enterText; // ���� �޽���
    private TextMeshProUGUI warningText; // ��� �޽���
    private GameObject createPopup;  // ���� ���� �˾�â

    private Button enterBtn;
    private Button startBtn;
    private Button deleteBtn;

    private GameObject obj;
    private bool isHaveData;

    private TMP_InputField inputField;

    private void Awake()
    {
        obj = GameObject.Find("EnterText");
        enterText = obj.GetComponent<TextMeshProUGUI>();
        obj = GameObject.Find("WarningText");
        warningText = obj.GetComponent<TextMeshProUGUI>();

        createPopup = GameObject.Find("CreatePopup");

        obj = GameObject.Find("EnterBtn");
        enterBtn = obj.GetComponent<Button>();
        enterBtn.onClick.AddListener(OnClick_EnterBtn);
        obj = GameObject.Find("StartBtn");
        startBtn = obj.GetComponent<Button>();
        startBtn.onClick.AddListener(OnClick_StartBtn);
        obj = GameObject.Find("DeleteBtn");
        deleteBtn = obj.GetComponent<Button>();
        deleteBtn.onClick.AddListener(OnClick_DeleteBtn);


        obj = GameObject.Find("InputField");
        inputField = obj.GetComponent<TMP_InputField>();
        if(inputField != null)
        {
            inputField.onValueChanged.AddListener((newNickName) => OnChanged_Nickname(newNickName));
        }
        InitTitleScene();
    }

    public void InitTitleScene()
    {
        isHaveData = GameManager.Inst.LoadData();
        if (isHaveData)
        {
            enterText.text = GameManager.Inst.PlayerInfo.userNickName + " �� ȯ���մϴ�.\n";
        }
        else
        {
            enterText.text = "������ �����Ϸ��� ��ġ�ϼ���.\n";
        }
    }

    public void OnClick_EnterBtn()
    {
        if (isHaveData)
        {
            GameManager.Inst.AsyncLoadingNextScene(SceneName.TownScene);
        }
        else
        {
            enterText.enabled = false;
            LeanTween.scale(createPopup, Vector2.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        }
    }

    private string newNickName = "";

    public void OnChanged_Nickname(string input)
    {
        newNickName = input;
    }



    // StartBtn Ŭ�� �Լ�
    public void OnClick_StartBtn()
    {
        Debug.Log(gameObject.name);
        if (newNickName.Length >= 2)
        {
            LeanTween.scale(createPopup, Vector2.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            enterText.enabled = true;
            GameManager.Inst.CreateUserData(newNickName); // GameMager�� Inst�� ȣ���� CreateUserData �Լ��� ȣ��
            GameManager.Inst.SaveData();
            InitTitleScene();
        }
        else
        {
            WarningText("�ٸ� �г����� �Է����ּ���!!");
        }
    }

    public void OnClick_DeleteBtn()
    {
        WarningText("�����Ͱ� ���� �Ǿ����ϴ�.");
        GameManager.Inst.DeleteData();
        InitTitleScene();
    }

    public void WarningText(string newMessage)
    {
        warningText.text = newMessage;
        Color fromColor = Color.red;
        fromColor.a = 0f;
        Color toColor = Color.red;
        toColor.a = 1f;

        LeanTween.value(warningText.gameObject, UpdateColor, fromColor, toColor, 1f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.value(warningText.gameObject, UpdateColor, toColor, fromColor, 1f).setEase(LeanTweenType.easeInOutQuad).setDelay(1f);
    }

    private void UpdateColor(Color value)
    {
        warningText.color = value;
    }

    
}
