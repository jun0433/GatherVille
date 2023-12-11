using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public enum SceneName
{
    LoadingScene,
    TitleScene,
    TownScene,

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

    public PlayerData PlayerInfo
    {
        get => pData;
    }


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
