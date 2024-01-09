using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Fishing : Singleton<Fishing>
{
    private Image fishing;
    private GameObject obj;
    private Vector2 vector;
    private float time;
    private float another;
    private GameObject myChar;
    private TextMeshProUGUI interaction;
    private bool flag;
    public bool FLAG
    {
        get => flag;
    }

    private void Awake()
    {
        myChar = GameObject.Find("MyCharacter");
        obj = GameObject.Find("Fishing");
        fishing = obj.GetComponent<Image>();
        obj = GameObject.Find("Interaction");
        interaction = obj.GetComponent<TextMeshProUGUI>();

        vector.y = myChar.transform.position.y + 125;
        fishing.transform.localPosition = vector;
        fishing.enabled = false;
    }

    private void Update()
    {
        obj = CharacterController.Inst.SCANOBJ;
        if (flag == true && Input.GetKeyDown(KeyCode.Space))
        {
            // todo: 상호작용 하기
            // 물에서 낚시
            if (obj.CompareTag("Water"))
            {
                InventoryitemData data = new InventoryitemData();
                data.itemID = FishTable();
                GameManager.Inst.GetItem(data);
                flag = false;
            }
            // 나무에서 벌목
            else if (obj.CompareTag("Tree"))
            {

            }


        }
    }

    public void Fish()
    {
        time = Random.Range(2f, 5f);

        Invoke("StartFishing", time);
    }

    public void StartFishing()
    {
        fishing.enabled = true;
        flag = true;
        interaction.enabled = true;
        interaction.text = "Press [Space]";
        float finish = Random.Range(0.5f, 1f);
        Invoke("EndFishing", finish);
    }

    public void EndFishing()
    {
        fishing.enabled = false;
        interaction.enabled = false;
        interaction.text = "Press [G] Key";
        flag = false;
    }


    public int FishTable()
    {
        int num = Random.Range(0, 200);
        int id;
        if (num < 80)
        {
            id = 1002;
        }
        else if(num < 110)
        {
            id = 1001;
        }
        else if(num < 140)
        {
            id = 1006;
        }
        else if(num < 170)
        {
            id = 1007;
        }
        else if(num < 190)
        {
            id = 1005;
        }
        else
        {
            id = 1004;
        }

        return id;
    }
}
