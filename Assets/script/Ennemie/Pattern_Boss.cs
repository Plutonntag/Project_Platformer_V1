using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class Pattern_Boss : MonoBehaviour
{
    [SerializeField] Rigidbody2D ArmeRb;
    private float Return_pointX;
    private float Return_pointY;
    private int Random_Number;
    private bool Now_Attack;
    private bool Time_Front_Attack;
    [SerializeField] float Speed = 30;
    private bool Ctime;
    [SerializeField] Transform[] Attack1;
    [SerializeField] Transform[] Attack2;
    [SerializeField] Transform[] Attack3;
    private Transform[][] AllWaypoint = new Transform[3][];
    private Transform target;
    private int desPoint = 0;
    private bool indiceChange;
    public int i = 0;
    private bool CorouBoucle = true;

    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Return_pointX = ArmeRb.position.x;
        Return_pointY = ArmeRb.position.y;
        Now_Attack = true;
        Ctime = true;
        AllWaypoint[0] = Attack1;
        AllWaypoint[1] = Attack2;
        AllWaypoint[2] = Attack3;
        desPoint = 1;
        indiceChange = false;
        target = AllWaypoint[i][1];
    }

    // Update is called once per frame
    void Update()
    {
        //StopAllCoroutines();
        if (Now_Attack == true)
        {
            if (Ctime)
            {
                Ctime = false;
                StartCoroutine(Cooldown_attack());
            }


        }
        else
        {
            switch (Random_Number)
            {
                case 1:
                    FrontAttack();
                    break;
                case 2:

                    VerticalAttack();
                    //Attack
                    break;
                case 3:
                    VerticalAttack();
                    //Attack
                    break;
            }

        }

    }


    private int Random_Attack()
    {
        if (Now_Attack)
        {
            Now_Attack = false;
            Random_Number = Random.Range(1, 3);

            switch (Random_Number)
            {
                case 1:
                    Debug.Log("1");

                    return 1;
                case 2:
                    Debug.Log("2");
                    return 2;
                case 3:
                    Debug.Log("3");
                    return 3;
            }

        }

        return 0;
    }

    private void FrontAttack()
    {
        if (!Ctime)
        {
            Ctime = true;
            StartCoroutine(coroutine_Front_Attack());
        }

        transform.Translate(Vector3.left * Speed * Time.deltaTime);

    }

    private void VerticalEnd()
    {
        Now_Attack = true;
        transform.position = new Vector3(Return_pointX, Return_pointY, 0);
        Ctime = true;
        CorouBoucle = true;
        i = 0;
        desPoint = 1;
        target = AllWaypoint[i][1];
        //Debug.Log("attaque terminé");
    }
    private void VerticalAttack()
    {
        

;
        //if (!Ctime)
        //{
        //    Ctime = true;
        //    //StartCoroutine(coroutine_Front_Attack());
        //}

        if (CorouBoucle)
        {
            CorouBoucle = false;
            //StartCoroutine(Coroutine_vertical());
            transform.position = AllWaypoint[i][0].position;

        }
                    
        
        Vector3 dir = target.position - transform.position;     //Donne la direction
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);  //Donne le mouvement


        if (Vector3.Distance(transform.position, target.position) < 0.3f)    // Si pas trop loin du target, on change.
        {
            if (desPoint == 0)
            {
                i++;
                if (i > 2)
                {
                    VerticalEnd();
                    return;
                }
                transform.position = AllWaypoint[i][0].position;

            }

            desPoint = (desPoint + 1) % AllWaypoint[i].Length;   // Utilisation du reste pour switché entre le point 1 et 2
            target = AllWaypoint[i][desPoint];


        }    

            //transform.position = Waypoint1[0].position;
            //transform.Translate(Vector3.down * Speed * Time.deltaTime);
        
    }

    IEnumerator Cooldown_attack()
    {

        yield return new WaitForSeconds(3);
        //Debug.Log("Fin cooldown");
        Random_Number = Random_Attack();
        Now_Attack = false;

    }

    IEnumerator coroutine_Front_Attack()
    {
        yield return new WaitForSeconds(2);
        Now_Attack = true;
        transform.position = new Vector3(Return_pointX, Return_pointY, 0);
        //Debug.Log("attaque terminé");


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death_Effect.instance.Death_Player();
    }


}
