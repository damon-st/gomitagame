using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DirectorScenes : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject textoOnmitir;
    private bool isSoppedScene;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        string onmitida = GuardarNiveles.CargarEscenaOnmitida(SceneManager.GetActiveScene().name);
        textoOnmitir.SetActive(true);
        
        Debug.Log(onmitida);
        if(onmitida != null  && !onmitida.Equals("") && !onmitida.Equals("Sinematica"))
        {
           // director.playOnAwake = false;
            director.Stop();
            textoOnmitir.SetActive(false);

        }
        else if (onmitida != null &&  onmitida.Equals("Sinematica"))
        {
            director.Stop();
            textoOnmitir.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void GuardarEscenaOnmitida()
    {
        GuardarNiveles.GuardarEscenaOnmitida(SceneManager.GetActiveScene().name);
        textoOnmitir.SetActive(false);
        isSoppedScene = true;
    }

    public void GuardarEscenaPrincipal()
    {
        GuardarNiveles.GuardarEscenaOnmitida(SceneManager.GetActiveScene().name);
        textoOnmitir.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void Update()
    {
        if(director.state == PlayState.Paused)
        {
            textoOnmitir.SetActive(false);
        }
    }

}
