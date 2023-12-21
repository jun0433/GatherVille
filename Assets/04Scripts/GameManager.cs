using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;

public enum SceneName
{
    LoadingScene,
    TitleScene,
    TownScene,
    HomeScene,

}

[SerializeField]
public class PlayerData
{
    public string userNickName;
    public int gold;
    public int uidCounter;
}
public class GameManager : Singleton<GameManager>
{
    private PlayerData pData;
    private GameObject obj;
    private TextMeshProUGUI dialogText;
    public bool isAction;
    public bool ISACTION
    {
        get => isAction;
    }
    private GameObject dialog;

    // PlayerData�� �ٸ� Ŭ�������� ������ �� �ְ�
    public PlayerData PlayerInfo
    {
        get => pData;
    }


    private void Awake()
    {
        obj = GameObject.Find("DialogText");
        dialogText = obj.GetComponent<TextMeshProUGUI>();
        dialog = GameObject.Find("Dialog");


        base.Awake();
        datapath = Application.persistentDataPath + "/save";
        pData = new PlayerData();


        UpdateGMinfo();
    }

    public void UpdateGMinfo()
    {
        LoadData();
    }

    public void Action(GameObject scan)
    {
        if (isAction)
        {
            isAction = false;
            LeanTween.scale(dialog, Vector2.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
        }
        else
        {
            isAction = true;
            LeanTween.scale(dialog, Vector2.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            obj = scan;
            dialogText.text = obj.name;
        }
    }


    #region _Save&Delete_
    private string datapath; // ������ ��θ� ������ ����

    // �����͸� �����ϴ� �Լ�
    public void SaveData()
    {
        // json ����
        string data = JsonUtility.ToJson(pData);
        File.WriteAllText(datapath, data); // datapath�� data�� ����
    }

    // �����͸� �ҷ��� �� �ִ��� Ȯ���ϴ� �Լ�
    public bool LoadData()
    {
        // datapath�� datafile�� �����ϴ���
        if (File.Exists(datapath))
        {
            string data = File.ReadAllText(datapath); // datapath�� �����͸� data ������ ����
            pData = JsonUtility.FromJson<PlayerData>(data); // pData�� JSON �������� �ҷ��� �����͸� ����
            return true; // ������ ���� O
        }

        return false; // ������ ���� X
    }

    // �����͸� �����ϴ� �Լ�
    public void DeleteData()
    {
        File.Delete(datapath);
    }

    #endregion

    #region _CreateData_
    public void CreateUserData(string newNickName)
    {
        pData.userNickName = newNickName;
        pData.gold = 0;
        pData.uidCounter = 0;
    }



    #endregion

    #region _ReadPlayerData_
    public int PlayerGold
    {
        get => pData.gold;
        set => pData.gold = value;
    }

    public string PlayerName
    {
        get => pData.userNickName;
    }

    public int PlayerUID
    {
        get
        {
            return ++pData.uidCounter;
        }
    }

    #endregion

    #region _SceneChange_
    private SceneName nextLoadSceneName;
    public SceneName NEXTSCENE
    {
        get => nextLoadSceneName;
    }

    // ���� ��ü�� �� ȣ���ϴ� �Լ�
    public void AsyncLoadingNextScene(SceneName nextScene)
    {
        nextLoadSceneName = nextScene;

        SceneManager.LoadScene(SceneName.LoadingScene.ToString());
    }

    #endregion

    

}
