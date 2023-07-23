using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CointsManage : MonoBehaviour
{
    public Text textoExito;

    public Text allCoints;

    public Text cointsColected;

    private int allCointsLevel;


    public Temporizador tempo;


    public RectTransform _menuWin;


    public bool _isNextScene;

    public Image[] estrellas;

    int estrellasPuntos;

    bool _playWinAudio = true;

    [Header("Jugador")]
    public GameObject playerObject;


    

    private void Start()
    {
        allCointsLevel = transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        AllCointsCollected();
        allCoints.text = allCointsLevel.ToString();
        cointsColected.text = transform.childCount.ToString();

        if (_isNextScene) Time.timeScale = 1;
    }

    public void AllCointsCollected()
    {

        if(transform.childCount == 0)
        {
            Debug.Log("Victoria");

            //aqui cuando gane cambiar de esena

            SeenText();

            GuardarNiveles.GuardarNivel(SceneManager.GetActiveScene().name);

            Debug.Log(SceneManager.GetActiveScene().name);

            AudioManager.StopTemporizadorAudio();
            //Invoke("LoadScene",0.1f);

           

            _menuWin.gameObject.SetActive(true);

            if (_playWinAudio)
            {
                AudioManager.PlayWinLevel();
                _playWinAudio = false;
            }

            string es = GuardarNiveles.CargarEstrellas(SceneManager.GetActiveScene().name+ "e");
            estrellasPuntos = Int32.Parse(es);

            for(int i = 0; i< estrellasPuntos; i++)
            {
                estrellas[i].gameObject.SetActive(true);
            }



            //Time.timeScale = 0;
            playerObject.SetActive(false);
        }
    }

   

    public void SeenText()
    {
        tempo.enabled = false;
        textoExito.gameObject.SetActive(true);
    }




    public void LoadScene()
    {
        try
        {
            _isNextScene = true;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        catch (System.Exception)
        {
            return;
        }
      
    }

    public void NextScene()
    {
        try
        {
            _isNextScene = true;

           // GuardarNiveles.GuardarEstrellas(SceneManager.GetActiveScene().name, "3");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch (System.Exception)
        {
            return;
        }
    }


    public void MainMenu()
    {
        try
        {
            _isNextScene = true;
            
            SceneManager.LoadScene("Principal");
        }
        catch (System.Exception)
        {
            return;
        }
    }

    
}
