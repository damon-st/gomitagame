using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{


    public static DamageEnemy current;

    public static bool isover;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            isover = true;
            collision.gameObject.GetComponent<PlayerController>().DamageEnemy();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            isover = false;

        }
    }

}
