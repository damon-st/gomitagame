using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LLaveItem : MonoBehaviour
{

    private SpriteRenderer spriteRender;
    private Collider2D colaider2D;

    public Image imageKey;

    static LLaveItem lLaveItem;

    public static bool enterisKey;

    public GameObject particles;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        colaider2D = GetComponent<Collider2D>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enterisKey = true;
            spriteRender.enabled = false;
            colaider2D.enabled = false;
            AudioManager.PlayCoinStepAudio();
            particles.SetActive(true);
            imageKey.gameObject.SetActive(true);
            Destroy(gameObject, 1f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        enterisKey = false;
    }

}
