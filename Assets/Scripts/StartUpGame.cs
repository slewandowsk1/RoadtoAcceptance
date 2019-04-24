using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUpGame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void Quit()
    {
        Application.Quit();

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
	public void Credits()
	{
		SceneManager.LoadScene (4);
	}

    public void MiniRace()
    {
        SceneManager.LoadScene(5);
    }

	public void MiniQuiz ()
	{
		SceneManager.LoadScene (6);
	}
}