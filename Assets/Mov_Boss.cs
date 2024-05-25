using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.AxisState;

public class Mov_Boss : MonoBehaviour
{
    public float Speed_Move;
    [SerializeField] Transform[] Waypoint;
    [SerializeField] SpriteRenderer Graph;
    [SerializeField] BoxCollider2D triggHit;
    public bool bon_retour;

    private Transform target_Move;
    private int desPoint_Move = 0;
    public bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        target_Move = Waypoint[1];
        canHit = false;
        bon_retour = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Recherche()
    {
        if (!canHit)
        {

            Vector3 dir = target_Move.position - transform.position;     //Donne la direction
            transform.Translate(dir.normalized * Speed_Move * Time.deltaTime, Space.World);  //Donne le mouvement



            if (Vector3.Distance(transform.position, target_Move.position) < 0.3f)    // Si pas trop loin du target, on change.
            {
                desPoint_Move = (desPoint_Move + 1) % Waypoint.Length;   // Utilisation du reste pour switch� entre le point 1 et 2
                target_Move = Waypoint[desPoint_Move];                   // Change de target
                Graph.flipX = !Graph.flipX;
                Debug.Log("Change");
                triggHit.offset = new Vector3(-triggHit.offset.x, triggHit.offset.y);

            }
        }
    }

    public void Retour_Position()
    {
        target_Move = Waypoint[0];
        Vector3 dir = target_Move.position - transform.position;     //Donne la direction
        transform.Translate(dir.normalized * Speed_Move * Time.deltaTime, Space.World);  //Donne le mouvement

        if (Vector3.Distance(transform.position, target_Move.position) < 0.3f)
        {
           // Utilisation du reste pour switch� entre le point 1 et 2                  // Change de target
            Graph.flipX = true;
            triggHit.offset = new Vector3(-triggHit.offset.x, triggHit.offset.y);
            bon_retour = true;

        }

    }
}