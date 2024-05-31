using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigg_attack : MonoBehaviour
{
    public Move_ennemie hit;
    public bool istrigg;
    [SerializeField] Animator attack_animation;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
         istrigg = false;
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
            attack_animation.SetBool("Attack", true);
            StartCoroutine(Hit());
            


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("voit plus");
            istrigg = false;
            attack_animation.SetBool("Attack", false);
            StopAllCoroutines();
            StartCoroutine(TheWait());

        }
    }


    IEnumerator Hit()
    {
        while (hit.canHit)
        {
            yield return new WaitForSeconds(1);
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
