using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigg_attack : MonoBehaviour
{
    public Move_ennemie hit;
    public bool istrigg;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Voit");
            istrigg = true;
            hit.canHit = true;
            StartCoroutine(Hit());
            


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("voit plus");
            istrigg = false;
            StopAllCoroutines();
            StartCoroutine(TheWait());

        }
    }


    IEnumerator Hit()
    {
        while (hit.canHit)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Hit");

        }

    }

    IEnumerator TheWait()
    {
        yield return new WaitForSeconds(2);
        hit.canHit = false;
    }

}
