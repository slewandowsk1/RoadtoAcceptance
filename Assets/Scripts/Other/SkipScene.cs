using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SkipScene : MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}