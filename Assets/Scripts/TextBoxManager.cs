using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerController Player;

    public bool isActive;

    public bool stopPlayerMovement;


    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

    }

    void Update()
    {
        Player.enabled = !isActive;

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine += 1;
        }

        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        Time.timeScale = 0;
        isActive = true;
    }

    public void DisableTextBox()
    {
        print("x");
        textBox.SetActive(false);
        Time.timeScale = 1;
        isActive = false;
    }
}
