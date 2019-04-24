using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class reload : MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}