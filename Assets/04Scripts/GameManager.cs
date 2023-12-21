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

    // PlayerData를 다른 클래스에서 참조할 수 있게
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
    private string datapath; // 데이터 경로를 저장할 변수

    // 데이터를 저장하는 함수
    public void SaveData()
    {
        // json 포맷
        string data = JsonUtility.ToJson(pData);
        File.WriteAllText(datapath, data); // datapath에 data를 저장
    }

    // 데이터를 불러올 수 있는지 확인하는 함수
    public bool LoadData()
    {
        // datapath에 datafile이 존재하는지
        if (File.Exists(datapath))
        {
            string data = File.ReadAllText(datapath); // datapath의 데이터를 data 변수에 저장
            pData = JsonUtility.FromJson<PlayerData>(data); // pData에 JSON 형식으로 불러온 데이터를 저장
            return true; // 데이터 존재 O
        }

        return false; // 데이터 존재 X
    }

    // 데이터를 삭제하는 함수
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

    // 씬을 교체할 때 호출하는 함수
    public void AsyncLoadingNextScene(SceneName nextScene)
    {
        nextLoadSceneName = nextScene;

        SceneManager.LoadScene(SceneName.LoadingScene.ToString());
    }

    #endregion

    

}
