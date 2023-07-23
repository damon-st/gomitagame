using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public RectTransform pauseMenu;
    public string nameScene;

    public void ActivarPause()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void VolverJuego()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        AudioManager.PlayAudioMenu();
        pauseMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(nameScene);
    }

    public void QuitAplication()
    {
        Application.Quit();
    }



}
