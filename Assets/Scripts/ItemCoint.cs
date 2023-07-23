using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCoint : MonoBehaviour
{

    public int couintCount = 1;
    public GameObject bursParticles;

    public SpriteRenderer rendeR;
    public Collider2D colaideR;

    [Header("AnimacionMoneda")]
    public Animator animacion;
    private int nameAnimationMove;


    private void Awake()
    {
        nameAnimationMove = Animator.StringToHash("move");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // mandar mensaje para que se añada moneda

            //desabilitar el colaider
            colaideR.enabled = false;

            //activar el efecto de particula
            rendeR.enabled = false;
            bursParticles.SetActive(true);

            //play audio
            AudioManager.PlayCoinStepAudio();

            //aplicar animacion
            animacion.SetTrigger(nameAnimationMove);

            //destruimos el item despues de 2s
            Destroy(gameObject, 0.5f);
        }
    }
}
