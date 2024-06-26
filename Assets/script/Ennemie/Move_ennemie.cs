using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Move_ennemie : MonoBehaviour
{
    public float Speed;
    [SerializeField] Transform[] Waypoint;
    [SerializeField] SpriteRenderer Graph;
    [SerializeField] BoxCollider2D triggHit;

    private Transform target;
    private int desPoint = 0;
    public bool canHit;
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
            desPoint = (desPoint + 1) % Waypoint.Length;   // Utilisation du reste pour switch� entre le point 1 et 2
            target = Waypoint[desPoint];                   // Change de target
            Graph.flipX = !Graph.flipX;
            triggHit.offset = new Vector3(-triggHit.offset.x, triggHit.offset.y);

        }


    }

}
