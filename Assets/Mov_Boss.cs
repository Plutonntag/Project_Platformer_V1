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
    public BoxCollider2D triggHit;
    [SerializeField] Animator boss_animation;
    public bool bon_retour;

    private Transform target_Move;
    public int desPoint_Move = 1;
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
            boss_animation.SetBool("attack", true);
            boss_animation.SetBool("marche", true);
            boss_animation.SetBool("idle", false);
            
            Vector3 dir = target_Move.position - transform.position;     //Donne la direction
            transform.Translate(dir.normalized * Speed_Move * Time.deltaTime, Space.World);  //Donne le mouvement



            if (Vector3.Distance(transform.position, target_Move.position) < 0.3f)    // Si pas trop loin du target, on change.
            {
                Graph.flipX = !Graph.flipX;
                triggHit.offset = new Vector3(-triggHit.offset.x, triggHit.offset.y);
                desPoint_Move = (desPoint_Move + 1) % Waypoint.Length;   // Utilisation du reste pour switché entre le point 1 et 2
                target_Move = Waypoint[desPoint_Move];                   // Change de target
                Debug.Log("Change");
                

            }
        }
    }

    public void Retour_Position()
    {
        boss_animation.SetBool("attack", true);
        boss_animation.SetBool("marche", true);
        boss_animation.SetBool("idle", false);
        target_Move = Waypoint[0];
        Vector3 dir = target_Move.position - transform.position;     //Donne la direction
        transform.Translate(dir.normalized * Speed_Move * Time.deltaTime, Space.World);  //Donne le mouvement

        if (Vector3.Distance(transform.position, target_Move.position) < 0.3f)
        {
           // Utilisation du reste pour switché entre le point 1 et 2                  // Change de target
            Graph.flipX = true;
            triggHit.offset = new Vector3(-triggHit.offset.x, triggHit.offset.y);
            bon_retour = true;

        }

    }
}
