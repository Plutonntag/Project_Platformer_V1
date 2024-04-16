using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class Patern_Boss : MonoBehaviour
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

    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Return_pointX = ArmeRb.position.x;
        Return_pointY = ArmeRb.position.y;
        Now_Attack = true;
        Ctime = true;
    }

    // Update is called once per frame
    void Update()
    {
        //StopAllCoroutines();
        if (Now_Attack == true)
        {
            if (Ctime) {
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
                    FrontAttack();
                    //Attack
                    break;
                case 3:
                    FrontAttack();
                    //Attack
                    break;
            }
           
        }

    }


    private int Random_Attack()
    {
        if (Now_Attack) {
            Now_Attack = false;
            Random_Number = Random.Range(1, 3);

            switch (Random_Number)
            {
                case 1:
                   // Debug.Log("1");

                    return 1;
                case 2:
                   // Debug.Log("2");
                    return 2;
                case 3:
                   // Debug.Log("3");
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

    private void VerticalAttack(Transform[] Waypoint)
    {
        if (!Ctime)
        {
            Ctime = true;
            StartCoroutine(coroutine_Front_Attack());
        }

        transform.position = Attack1.position;
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    
    }

    IEnumerator Cooldown_attack()
    {
        
        yield return new WaitForSeconds(3);
        Debug.Log("Fin cooldown");
        Random_Number = Random_Attack();
        Now_Attack = false;

    }

    IEnumerator coroutine_Front_Attack()
    {
        yield return new WaitForSeconds(2);
        Now_Attack = true;
        transform.position = new Vector3(Return_pointX, Return_pointY, 0);
        Debug.Log("attaque terminé");


    }



}
