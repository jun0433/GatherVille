using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private GameObject obj;
    private Image fillImage;


    private void Awake()
    {
        obj = GameObject.Find("Fill");
        if(obj != null)
        {
            fillImage = obj.GetComponent<Image>();
        }
        else
        {
            Debug.Log("LoadingManager.cs - Awake() - fillImage 참조 실패");
        }

        StartCoroutine(LoadAsyncScene());
    }


    IEnumerator LoadAsyncScene()
    {
        yield return null;

        yield return new WaitForSeconds(0.1f);

        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(GameManager.Inst.NEXTSCENE.ToString());
        asyncScene.allowSceneActivation = false;

        float timeC = 0f;

        while (!asyncScene.isDone)
        {
            yield return null;
            timeC += Time.deltaTime;

            if(asyncScene.progress >= 0.9f)
            {
                fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, 1f, timeC);
                if(fillImage.fillAmount > 0.99f)
                {
                    asyncScene.allowSceneActivation = true;
                }
            }
            else
            {
                fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, asyncScene.progress, timeC);
                if(fillImage.fillAmount >= asyncScene.progress)
                {
                    timeC = 0f;
                }
            }
        }
    }
}
