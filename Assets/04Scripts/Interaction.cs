using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Interaction : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Water"))
        {
            interaction.enabled = true;
            Fishing();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        interaction.enabled = false;
    }

    public void Fishing()
    {
        interaction.text = "Press [G] Key";
    }
}
