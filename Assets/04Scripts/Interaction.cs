using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Interaction : Singleton<Interaction>
{
    private TextMeshProUGUI interaction;
    private GameObject obj;
    private Vector2 vector;

    private void Awake()
    {
        obj = GameObject.Find("Interaction");
        interaction = obj.GetComponent<TextMeshProUGUI>();
        vector.y = gameObject.transform.position.y + 80;
        interaction.transform.localPosition = vector;
        interaction.enabled = false;
    }

    public void Closed()
    {
        interaction.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interaction.enabled = true;
        interaction.text = "Press [G] Key";
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Closed();
    }
}
