using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UIElements;

public class movetest : MonoBehaviour
{
    [SerializeField] int Movespeed = 5;
    private Rigidbody2D rb;

    [SerializeField] float jumpHeight = 7f;
    [SerializeField] CircleCollider2D Trigger_jump;
    [SerializeField] bool jumped = true;
    [SerializeField] Transform check;
    public float groundCheckRadius;
    [SerializeField] LayerMask collisionPlayer;
    private bool isplaned;
    public bool Grounded;


    IEnumerator coroutine;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void Jump()
    {
         Grounded = Physics2D.OverlapCircle(check.position, groundCheckRadius, collisionPlayer);
        if (Grounded == true)
        {
            StopAllCoroutines();
            isplaned = false;
            Debug.Log("Stop");
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(check.position, groundCheckRadius);
    }

    void Update() // Fonction Update appelle la fonction Movement
    {
        Jump();
        Movement();

    }


    private void Movement() /* Cette fonction permet de faire déplacer le personnage ainsi que de faire jouer ses animation
                            */
    {

        if (Input.GetKey(KeyCode.RightArrow)) // Mouvement droite
        {

            transform.Translate(Vector3.right * Movespeed * Time.deltaTime);
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow)) // Mouvement gauche
        {

            transform.Translate(Vector3.left * Movespeed * Time.deltaTime);

        }

//                                  MECANIQUE DE SAUT



        if (Input.GetKey(KeyCode.Space) && Grounded == true) // Si relaché avant le décompte, un petit saut
        {
            Debug.Log(" petit saut");
            rb.AddForce(Vector2.up * jumpHeight * 25);
            StartCoroutine(Time_jumped());

           
        }


        if (Input.GetKey(KeyCode.Space) && isplaned == true) // Si relaché avant le décompte, un petit saut
        {
            Debug.Log(" plane");
            rb.velocity = Vector3.zero;
            rb.gravityScale =  7;
        }
        else
        {
            rb.gravityScale = 9.8f; 
        }



    }

    IEnumerator Time_jumped()
    {
        yield return new WaitForSeconds(0.2f);
        isplaned = true;

    }

}
