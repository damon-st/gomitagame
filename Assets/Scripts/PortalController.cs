using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    public bool _isExit;
    public Transform _pointEnter;
    public Transform _pointExit;
    public SpriteRenderer bodyPlayer;
    public GameObject personaje;


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_isExit)
            {
                AudioManager.PlayPortalAudio();
                Transportar(_pointExit);
            }
            else if (!_isExit)
            {
                AudioManager.PlayPortalAudio();
                Transportar(_pointEnter);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_isExit)
            {
                Invoke("AudioStop", 2f);
                ActiveSprite(true);
            }
            else if (!_isExit)
            {
                Invoke("AudioStop",2f);
                ActiveSprite(true);
            }
        }
    }


    private void AudioStop()
    {
        AudioManager.StopPortalAudio();
    }


    private void Transportar(Transform transporte)
    {
          
       personaje.transform.position = transporte.position;
       bodyPlayer.enabled = false;
       ActiveSprite(false);
        
    }


    private void ActiveSprite(bool activar)
    {
        bodyPlayer.enabled = activar;
    }


}
