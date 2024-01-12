using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAction : Singleton<PlayerAction>
{
    private Image action;
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

    private bool isAction;
    public bool ISACTION
    {
        get => isAction;
    }

    private int itemID;
    public int ITEMID
    {
        get => itemID;
    }
    private TownManager town;

    private void Awake()
    {
        town = GameObject.Find("TownManager").GetComponent<TownManager>();
        myChar = GameObject.Find("MyCharacter");
        obj = GameObject.Find("Action");
        action = obj.GetComponent<Image>();
        obj = GameObject.Find("Interaction");
        interaction = obj.GetComponent<TextMeshProUGUI>();

        vector.y = myChar.transform.position.y + 125;
        action.transform.localPosition = vector;
        action.enabled = false;
    }

    private void Update()
    {
        obj = CharacterController.Inst.SCANOBJ;

        if(isAction == true)
        {
            if (flag == true && Input.GetKeyDown(KeyCode.B))
            {
                flag = false;
                // todo: 상호작용 하기
                // 물에서 낚시
                if (obj.CompareTag("Water"))
                {
                    InventoryitemData data = new InventoryitemData();
                    data.itemID = FishTable();
                    GameManager.Inst.GetItem(data);
                    GameManager.Inst.SaveData();
                    town.Communicate(data);
                }
                // 나무에서 벌목
                else if (obj.CompareTag("Tree"))
                {
                    InventoryitemData data = new InventoryitemData();
                    data.itemID = FruitTable();
                    GameManager.Inst.GetItem(data);
                    GameManager.Inst.SaveData();
                    town.Communicate(data);
                }
                // 꽃에서 채집
                else if (obj.CompareTag("Flower"))
                {
                    InventoryitemData data = new InventoryitemData();
                    data.itemID = VegetableTable();
                    GameManager.Inst.GetItem(data);
                    GameManager.Inst.SaveData();
                    town.Communicate(data);
                }

            }
            else if (flag == false && Input.GetKeyDown(KeyCode.B))
            {
                town.dialogText.text = "실패한 것 같다.";
                town.DialogOpen();
            }
        }
        
    }


    public void Action()
    {
        isAction = true;
        time = Random.Range(2f, 5f);

        Invoke("StartAction", time);
    }


    public void StartAction()
    {
        action.enabled = true;
        flag = true;
        interaction.enabled = true;
        interaction.text = "Press [B] Key";
        float finish = Random.Range(0.5f, 1f);
        Invoke("EndAction", finish);
    }

    public void EndAction()
    {
        action.enabled = false;
        interaction.enabled = false;
        interaction.text = "Press [G] Key";
        flag = false;
        isAction = false;
    }


    #region _DataTable_

    public int FishTable()
    {
        int num = Random.Range(0, 200);
        if (num < 80)
        {
            itemID = 1002;
        }
        else if (num < 110)
        {
            itemID = 1001;
        }
        else if (num < 140)
        {
            itemID = 1006;
        }
        else if (num < 170)
        {
            itemID = 1007;
        }
        else if (num < 190)
        {
            itemID = 1005;
        }
        else
        {
            itemID = 1004;
        }

        Debug.Log(itemID);
        return itemID;
    }

    public int FruitTable()
    {
        int num = Random.Range(0, 200);
        if (num < 80)
        {
            itemID = 2001;
        }
        else if (num < 110)
        {
            itemID = 2002;
        }
        else if (num < 140)
        {
            itemID = 2003;
        }
        else if (num < 170)
        {
            itemID = 2004;
        }
        else if (num < 190)
        {
            itemID = 2005;
        }
        else
        {
            itemID = 2006;
        }
        return itemID;
    }

    public int VegetableTable()
    {
        int num = Random.Range(0, 240);
        if (num < 10)
        {
            itemID = 3001;
        }
        else if (num < 20)
        {
            itemID = 3002;
        }
        else if (num < 30)
        {
            itemID = 3003;
        }
        else if (num < 40)
        {
            itemID = 3004;
        }
        else if (num < 50)
        {
            itemID = 3005;
        }
        else if (num < 60)
        {
            itemID = 3006;
        }
        else if (num < 70)
        {
            itemID = 3007;
        }
        else if (num < 80)
        {
            itemID = 3008;
        }
        else if (num < 90)
        {
            itemID = 3009;
        }
        else if (num < 100)
        {
            itemID = 3010;
        }
        else if (num < 110)
        {
            itemID = 3011;
        }
        else if (num < 120)
        {
            itemID = 3012;
        }
        else if (num < 130)
        {
            itemID = 3013;
        }
        else if (num < 140)
        {
            itemID = 3014;
        }
        else if (num < 150)
        {
            itemID = 3015;
        }
        else if (num < 160)
        {
            itemID = 3016;
        }
        else if (num < 170)
        {
            itemID = 3017;
        }
        else if (num < 180)
        {
            itemID = 3018;
        }
        else if (num < 190)
        {
            itemID = 3019;
        }
        else if (num < 200)
        {
            itemID = 3020;
        }
        else if (num < 210)
        {
            itemID = 3021;
        }
        else if (num < 220)
        {
            itemID = 3022;
        }
        else if (num < 230)
        {
            itemID = 3023;
        }
        else
        {
            itemID = 3024;
        }

        return itemID;
    }

    #endregion

}