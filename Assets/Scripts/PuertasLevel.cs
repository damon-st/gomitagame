using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PuertasLevel : MonoBehaviour
{

    public string nameScene;
    public TextMeshProUGUI textMessageKey;

    private bool _presentBtn = false;

    public GameObject[] estrellas;

    private bool _isDoor;

    public GameObject barraSerrada;

    public GameObject personaje;

    public string Nivel;

    public  bool _cantEnterDoor = false;

    private string NameLevel;

    public Button btnOpen;

    private string startsOpten;

    int myStars;

    public GameObject transitionObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _cantEnterDoor)
        {
            Debug.Log(Nivel);
            _isDoor = true;
            textMessageKey.gameObject.SetActive(false);
            btnOpen.gameObject.SetActive(true);

            
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isDoor = false;
            textMessageKey.gameObject.SetActive(false);
            btnOpen.gameObject.SetActive(false);
            
        }
    }

    private void Awake()
    {
        btnOpen.onClick.AddListener(PaseNivel);
    }

    // Start is called before the first frame update
    void Start()
    {
        NameLevel = GuardarNiveles.CargarDatos(nameScene);
        if ( NameLevel != "")
        {
            barraSerrada.SetActive(false);
            _cantEnterDoor = true;

            startsOpten = GuardarNiveles.CargarEstrellas(NameLevel + "e");

            Debug.Log(startsOpten);

             myStars = Int32.Parse(startsOpten);

            for (int i = 0; i < myStars; i++)
            {
                estrellas[i].SetActive(true);
            }

            if (PlayerPrefs.GetFloat("positionx") != 0)
            {
                personaje.transform.position = (GuardarNiveles.CargarPosicionPuerta());
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        
        
        if(_isDoor &&   _presentBtn)
        {
            Debug.Log(Nivel);
            AudioManager.PlayOpenDoorAudio();
            transitionObject.SetActive(true);
            Invoke("OpenDoor", 1f);
        }

        


    }

    public void OpenDoor()
    {
       
        GuardarNiveles.GuardarPosicionPuerta(transform.position.x, transform.position.y);
        SceneManager.LoadScene(Nivel);

    }

    private void PaseNivel()
    {
        Debug.Log("Boton presionado" + Nivel);
        _presentBtn = true;
       // Update();

        //SceneManager.LoadScene(Nivel);
    }
}
