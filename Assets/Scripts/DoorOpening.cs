using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{


    Animator animator;

    int move;

    bool cantEnter;

    public GameObject particulas;
    
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") && LLaveItem.enterisKey)
        {
            cantEnter = true;
            collision.gameObject.GetComponent<PlayerMoveJosctick>().PlayPuertaNivelAudio();
            collision.gameObject.GetComponent<PlayerController>().PlayPuertaNivelAudio();

            Invoke("DesactiveColaider", 0.5f);
        }
    }

    private void DesactiveColaider()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }


    private void Awake()
    {
        animator = GetComponentInParent<Animator>();

       
    }

    // Start is called before the first frame update
    void Start()
    {
        move = Animator.StringToHash("IsMove");
    }

 

    private void LateUpdate()
    {


        if (cantEnter)
        {
            particulas.SetActive(true);
           animator.SetBool(move, true);
        }
    }


}
