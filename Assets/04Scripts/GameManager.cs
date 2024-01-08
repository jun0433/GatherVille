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
    public Inventory inventory;
}
public class GameManager : Singleton<GameManager>
{
    private PlayerData pData;
    private GameObject obj;
    private TextMeshProUGUI dialogText;



    // PlayerData�� �ٸ� Ŭ�������� ������ �� �ְ�
    public PlayerData PlayerInfo
    {
        get => pData;
    }



    private void Awake()
    {

        base.Awake();
        datapath = Application.persistentDataPath + "/save";
        pData = new PlayerData();

        #region _TableData_
        table = Resources.Load<TownGame>("TownGame");

        for(int i = 0; i< table.ItemData.Count; i++)
        {
            dicItemData.Add(table.ItemData[i].id, table.ItemData[i]);
        }


        #endregion


        UpdateGMinfo();
    }

    public void UpdateGMinfo()
    {
        LoadData();
    }

    #region _TableData_
    private TownGame table;
    private Dictionary<int, ItemData_Entity> dicItemData = new Dictionary<int, ItemData_Entity>();

    public bool GetItemData(int itemID, out ItemData_Entity data)
    {
        return dicItemData.TryGetValue(itemID, out data);
    }
    #endregion

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
        pData.gold = 5000;
        pData.uidCounter = 0;
    }



    #endregion


    #region _Items_

    public bool GetItem(InventoryitemData newItem)
    {
        if (!pData.inventory.ISFull())
        {
            pData.inventory.AddItem(newItem);
            return true;
        }
        return false;
    }

    public void DeleteItem(InventoryitemData deleteItem)
    {
        pData.inventory.DeleteItem(deleteItem);
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

    public Inventory Inven
    {
        get => pData.inventory;
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
