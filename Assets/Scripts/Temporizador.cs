using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{

    public float TimeStar = 30f;

    public TextMeshProUGUI txtTime;

    public RectTransform retryMeny;
    private float timerRester;

    public GameObject playerObject;

    public PlayerController controler;


    public Animator animacionTime;


    public static Temporizador current;

    private bool _isOver;

    // Start is called before the first frame update
    void Start()
    {
        GuardarNiveles.GuardarEstrellas(SceneManager.GetActiveScene().name, "3");
    }

    // Update is called once per frame
    void Update()
    {

        TimeStar -= Time.deltaTime;
        txtTime.text = " " + TimeStar.ToString("f0");

        if(TimeStar < 1)
        {
            _isOver = true;
            Debug.Log("Perdiste");
            txtTime.text ="0";
            //Time.timeScale = 0;
            controler.enabled = false;
            retryMeny.gameObject.SetActive(true);
            animacionTime.SetBool("TimeIsOver", false);
            AudioManager.StopTemporizadorAudio();
            GuardarNiveles.GuardarEstrellas(SceneManager.GetActiveScene().name, "0");

        }
    }


    private void FixedUpdate()
    {
        if (TimeStar < 16 && TimeStar > 1 && !_isOver)
        {
            AudioManager.PlayTemporizadorAudio();
            animacionTime.SetBool("TimeIsOver", true);

            GuardarNiveles.GuardarEstrellas(SceneManager.GetActiveScene().name, "2");
        }

        if (DamageEnemy.isover)
        {
            AudioManager.StopTemporizadorAudio();
        }
    }

    public void RetryGame()
    {
        _isOver = false;
        Time.timeScale = 1;
        controler.enabled = true;
        retryMeny.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(0);
       
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

 
}
