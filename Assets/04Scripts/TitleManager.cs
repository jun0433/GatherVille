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

        InitScene();
    }

    public void InitScene()
    {
        isHaveData = false; // �ӽ��ڵ�
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
            LeanTween.scale(createPopup, Vector2.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        }
    }

    private string newNickName = "";

    public void OnClick_StartBtn()
    {
        if(newNickName.Length <= 2)
        {
            warningText.text = "�г����� ������ �ùٸ��� �ʽ��ϴ�.";
        }
        else
        {
            LeanTween.scale(createPopup, Vector2.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        }
    }

    public void OnClick_DeleteBtn()
    {

    }
}
