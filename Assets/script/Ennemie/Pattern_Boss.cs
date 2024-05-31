using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Pattern_Boss : MonoBehaviour
{
    public Trigg_Boss_Attack trigg_boss;
    [SerializeField] Rigidbody2D ArmeRb;
    private BoxCollider2D rb_boss;
    private float Return_pointX;
    private float Return_pointY;
    private int Random_Number;
    private bool Now_Attack;
    public Trigg_Boss_Attack HaveTrigg;
    private bool Time_Front_Attack;
    [SerializeField] float Speed = 30;
    private bool Ctime;
    public Mov_Boss Movement;
    public Pattern_Boss pattern;
    [SerializeField] Transform[] Attack1;
    [SerializeField] Transform[] Attack2;
    [SerializeField] Transform[] Attack3;
    private Transform[][] AllWaypoint = new Transform[3][];
    private Transform target;
    [SerializeField] Transform Targets_retour;
    private int desPoint = 0;
    private int i = 0;
    private bool CorouBoucle = true;
    public int number_attack;
    public int number_boo;
    private BoxCollider2D rb_touch;
    public bool R_retour;
    public bool fight;
    private GameObject Boss;
    private SpriteRenderer boss_sprite;
    [SerializeField] BoxCollider2D Box_Boss;
    [SerializeField] CinemachineVirtualCamera Main_cam;
    [SerializeField] CinemachineVirtualCamera Boss_Cam;
    [SerializeField] Animator boss_animation;


    //          Movement


    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        number_attack = 0;
        number_boo = 0;
        rb_touch = GameObject.Find("Trigger_attack_chara").GetComponent<BoxCollider2D>();
        rb_boss = GameObject.Find("Boss").GetComponent<BoxCollider2D>();
        Boss = GameObject.Find("Boss");
        boss_sprite = Boss.GetComponent<SpriteRenderer>();
        Return_pointX = ArmeRb.position.x;
        Return_pointY = ArmeRb.position.y;
        Now_Attack = true;
        Ctime = true;
        AllWaypoint[0] = Attack1;
        AllWaypoint[1] = Attack2;
        AllWaypoint[2] = Attack3;
        desPoint = 1;
        target = AllWaypoint[i][1];
        R_retour = true;
        fight = false;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (fight)
        {
            boss_animation.SetBool("attack", false);
            boss_animation.SetBool("marche", false);
            boss_animation.SetBool("idle", true);


            if (number_boo >= 3)
            {
                Debug.Log("Gagné");
                Movement.enabled = false;
                trigg_boss.enabled = false;
                pattern.enabled = false;


            }
            if (Now_Attack == true && R_retour)
            {
                if (Ctime)
                {
                    Ctime = false;
                    StartCoroutine(Cooldown_attack());
                }


            }
            else if (number_attack == 4 && R_retour)
            {

                Movement.bon_retour = false;
                //Debug.Log("Marche");
                Movement.Recherche();
                transform.position = new Vector3(Return_pointX, Return_pointY, 0);


            }
            else if (!R_retour)
            {
                Ennemie_Retour();
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
        else
        {
            boss_animation.SetBool("attack", false);
            boss_animation.SetBool("marche", false);
            boss_animation.SetBool("idle", true);
            Movement.Retour_Position();
            transform.position = new Vector3(Return_pointX, Return_pointY, 0);
            Boss.transform.position = Targets_retour.position;
            if (!boss_sprite.flipX)
            {
                boss_sprite.flipX = true;
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
                    //Debug.Log("1");

                    return 1;
                case 2:
                    //Debug.Log("2");
                    return 2;
                case 3:
                    //Debug.Log("3");
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
        number_attack += 1;
        //Debug.Log(number_attack);
        Now_Attack = false;

    }

    IEnumerator coroutine_Front_Attack()
    {
        yield return new WaitForSeconds(2);
        Now_Attack = true;
        transform.position = new Vector3(Return_pointX, Return_pointY, 0);
        //Debug.Log("attaque terminé");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Death_Effect.instance.Death_Player();

            Box_Boss.enabled = false;
            Main_cam.Priority = 10;
            Boss_Cam.Priority = 1;
            number_attack = 0;
            number_boo = 0;
            fight = false;
            transform.position = new Vector3(Return_pointX, Return_pointY, 0);
            //StopAllCoroutines();

        }
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (rb_touch.IsTouching(rb_boss) && R_retour)
        {
            R_retour = false;
        }
    }
    private void Ennemie_Retour()
    {

                HaveTrigg.enabled = false;

                if (Movement.bon_retour == false)
                {
                    Movement.Retour_Position();
                }

                else if (Movement.bon_retour == true)
                {
                    Debug.Log("Retour au bercaille");
                    R_retour = true;
                    HaveTrigg.enabled = true;
                    transform.position = new Vector3(Return_pointX, Return_pointY, 0);
                    number_boo += 1;
                    number_attack = 0;

                }
    }


}
