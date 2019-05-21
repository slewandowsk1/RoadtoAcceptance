using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public Transform Canvas;
    public Transform PauseMenu;
    //public Transform audioSettingsMenu;
    //public Transform quitMenu;
    public Transform Player;
    

    public bool isActive;

    public bool stopPlayerMovement;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();   
        }
        
    }
    public void Pause()
    {

        if (Canvas.gameObject.activeInHierarchy == false)
        {
            if (PauseMenu.gameObject.activeInHierarchy == false)
            {
                PauseMenu.gameObject.SetActive(true);
                //audioSettingsMenu.gameObject.SetActive(false);


            }


            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            //Player.GetComponent<PlayerController>().enabled = false;

        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            //Player.GetComponent<PlayerController>().enabled = true;
        }
    }


    /*public void AudioSettings(bool Open)
    {
        if (Open) {
            audioSettingsMenu.gameObject.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
        }
        if (!Open) {
            audioSettingsMenu.gameObject.SetActive(false);
            PauseMenu.gameObject.SetActive(true);

        }
    }
    public void QuitMenu(bool Open)
    {
        if (Open)
        {
            quitMenu.gameObject.SetActive(true);
            PauseMenu.gameObject.SetActive(false);
        }
        if (!Open)
        {
            quitMenu.gameObject.SetActive(false);
            PauseMenu.gameObject.SetActive(true);

        }
    }*/
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


}



