using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    private TextMeshProUGUI enterText; // 시작 메시지
    private TextMeshProUGUI warningText; // 경고 메시지
    private GameObject createPopup;  // 계정 생성 팝업창

    private Button enterBtn;
    private Button startBtn;
    private Button deleteBtn;

    private GameObject obj;
    private bool isHaveData;

    private InputField inputField;

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

        //inputField.onValueChanged.AddListener(OnChanged_Nickname);

        InitScene();
    }

    public void InitScene()
    {
        isHaveData = GameManager.Inst.LoadData();
        if (isHaveData)
        {
            enterText.text = GameManager.Inst.PlayerInfo.userNickName + " 님 환영합니다.\n";
        }
        else
        {
            enterText.text = "계정을 생성하려면 터치하세요.\n";
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
        Debug.Log(input);
        newNickName = input;
    }
    // StartBtn 클릭 함수
    public void OnClick_StartBtn()
    {
        if(newNickName.Length >= 2)
        {
            GameManager.Inst.CreateUserData(newNickName); // GameMager의 Inst를 호출해 CreateUserData 함수를 호출
            LeanTween.scale(createPopup, Vector2.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            enterText.enabled = true;
            GameManager.Inst.SaveData();
            InitScene();
        }
        else
        {
            WarningText("다른 닉네임을 입력해주세요!!");
        }
    }

    public void OnClick_DeleteBtn()
    {
        WarningText("데이터가 삭제 되었습니다.");
        GameManager.Inst.DeleteData();
        InitScene();
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
