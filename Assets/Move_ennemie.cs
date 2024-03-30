using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Move_ennemie : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Transform[] Waypoint;
    [SerializeField] SpriteRenderer Graph;
    [SerializeField] BoxCollider2D triggHit;

    private Transform target;
    private int desPoint = 0;
    [SerializeField] bool canHit;
    IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoint[0];
        canHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canHit)
        {
            Basic_movement();

        }

    }

    private void Basic_movement()
    {
        Vector3 dir = target.position - transform.position;     //Donne la direction
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);  //Donne le mouvement



        if (Vector3.Distance(transform.position, target.position) < 0.3f)    // Si pas trop loin du target, on change.
        {
            desPoint = (desPoint + 1) % Waypoint.Length;   // Utilisation du reste pour switché entre le point 1 et 2
            target = Waypoint[desPoint];                   // Change de target
            Graph.flipX = !Graph.flipX;
            triggHit.offset = new Vector3(-triggHit.offset.x, triggHit.offset.y);

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Voit");
            canHit = true;
            StartCoroutine(Hit());
        

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("voit plus");
            StopAllCoroutines();
            StartCoroutine(TheWait());

        }
    }


    IEnumerator Hit()
    {
        while (canHit)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Hit");

        }

    }

    IEnumerator TheWait()
    {
        yield return new WaitForSeconds(2);
        canHit = false;
    }

}
