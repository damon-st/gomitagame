using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CofreOpening : MonoBehaviour
{

    private Animator animacion;

    public TextMeshProUGUI message;

    private bool _isCofreEnter;

    private bool _isOneEnter;


    private void Awake()
    {
        animacion = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& LLaveItem.enterisKey)
        {
            _isCofreEnter = true;
            if (!_isOneEnter)
            message.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isCofreEnter = false;
            message.gameObject.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && _isCofreEnter && LLaveItem.enterisKey)
        {
            animacion.SetBool("IsOpening",true);
            message.gameObject.SetActive(false);
            _isCofreEnter = false;
            _isOneEnter = true;
        }
    }
}
