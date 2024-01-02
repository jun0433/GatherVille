using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fishing : Singleton<Fishing>
{
    private Image fishing;
    private GameObject obj;
    private Vector2 vector;
    private float time;
    private float another;

    private void Awake()
    {
        obj = GameObject.Find("Fishing");
        fishing = obj.GetComponent<Image>();
        vector.y = gameObject.transform.position.y + 80;
        fishing.transform.localPosition = vector;
        fishing.enabled = false;

        Fish();
    }

    public void Fish()
    {
        time = Random.Range(0f, 2f);

        Debug.Log(time);
        another = 0f;
        while(time >= another)
        {
            Debug.Log(another);
            another += Time.deltaTime;
        }
        fishing.enabled = true;


    }
    
}
