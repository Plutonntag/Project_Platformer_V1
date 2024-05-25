using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trigg_Boss_Attack : MonoBehaviour
{
    public Mov_Boss hit;
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
            Death_Effect.instance.Death_Player();

        }

    }

    IEnumerator TheWait()
    {
        yield return new WaitForSeconds(2);
        hit.canHit = false;
    }


}
