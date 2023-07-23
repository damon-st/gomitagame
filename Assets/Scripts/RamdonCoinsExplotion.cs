using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdonCoinsExplotion : MonoBehaviour
{

    public GameObject prefabCoin;
    public float ForceExplotion = 3f;

    public GameObject hijoEfecto;

    private void Awake()
    {

        for(int i = 0; i < 20; i++)
        {
            Vector2 pos = new Vector2(transform.position.x + Random.Range(0, 1), transform.position.y + Random.Range(0, 0.1f));
            
            Instantiate(prefabCoin, pos, Quaternion.identity,transform);
        }
    }

    private void Start()
    {
        Invoke("RamdomExplotion", 1f);
    }

    void RamdomExplotion()
    {
        StartCoroutine("ramdo");
    }

    IEnumerator ramdo()
    {
        Rigidbody2D[] hijos = GetComponentsInChildren<Rigidbody2D>();
        SpriteRenderer[] s = GetComponentsInChildren<SpriteRenderer>();

        

        for (int i = 0; i < hijos.Length; i++)
        {
            hijos[i].bodyType = RigidbodyType2D.Dynamic;
            s[i].sortingLayerName = "Foreground";
            // hijos[i].AddForce(Random.insideUnitCircle.normalized * ForceExplotion);
            yield return new WaitForSeconds(0.3f);
        }
    }


    private void OnEnable()
    {
        hijoEfecto.SetActive(true);
    }

    private void OnDisable()
    {
        hijoEfecto.SetActive(false);
    }

}
