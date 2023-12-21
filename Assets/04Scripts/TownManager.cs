using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownManager : MonoBehaviour
{
    private BoxCollider2D col;
    private TextMeshProUGUI action;
    private GameObject obj;

    private GameObject player;

    private void Awake()
    {
        obj = GameObject.Find("Action");
        action = obj.GetComponent<TextMeshProUGUI>();
        if (!TryGetComponent<TextMeshProUGUI>(out action))
        {
            Debug.Log("TownManager.cs - Awake() - action 참조 실패");
        }
        
    }

    private void Update()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            Vector3 newPos = player.transform.position;
            newPos.y += 75f;
            action.transform.position = newPos;
        }

    }

    

}
