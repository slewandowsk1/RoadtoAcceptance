using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUpGame : MonoBehaviour
{


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


}