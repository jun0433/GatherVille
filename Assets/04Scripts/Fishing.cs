using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Fishing : Singleton<Fishing>
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
        }
        else if(flag == false && Input.GetKeyDown(KeyCode.B))
        {
            town.dialogText.text = "실패한 것 같다.";
            town.DialogOpen();
        }
    }


    public void Fish()
    {
        time = Random.Range(2f, 5f);

        Invoke("StartFishing", time);
    }


    public void StartFishing()
    {
        action.enabled = true;
        flag = true;
        interaction.enabled = true;
        interaction.text = "Press [B] Key";
        float finish = Random.Range(0.5f, 1f);
        Invoke("EndFishing", finish);
    }

    public void EndFishing()
    {
        action.enabled = false;
        interaction.enabled = false;
        interaction.text = "Press [G] Key";
        flag = false;
    }


    public int FishTable()
    {
        int num = Random.Range(0, 200);
        if (num < 80)
        {
            itemID = 1002;
        }
        else if(num < 110)
        {
            itemID = 1001;
        }
        else if(num < 140)
        {
            itemID = 1006;
        }
        else if(num < 170)
        {
            itemID = 1007;
        }
        else if(num < 190)
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
}
