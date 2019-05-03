using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorText3 : MonoBehaviour
{
    public Text UIp;


    // Use this for initialization
    void Start()
    {
        UIp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIp.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIp.gameObject.SetActive(false);
    }
}

