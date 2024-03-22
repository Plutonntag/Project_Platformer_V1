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
    [SerializeField] Transform check;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask collisionPlayer;
    [SerializeField] SpriteRenderer sprite;
    private bool isplaned;
    [SerializeField] bool Grounded;
    public bool plat_absorb;


    IEnumerator coroutine;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    private void Jump()
    {
         Grounded = Physics2D.OverlapCircle(check.position, groundCheckRadius, collisionPlayer);
        if (Grounded == true)
        {
            StopAllCoroutines();
            isplaned = false;
            //Debug.Log("Stop");
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(check.position, groundCheckRadius);
    }

    void Update() // Fonction Update appelle la fonction Movement
    {
       
       

    }


    private void Movement() /* Cette fonction permet de faire déplacer le personnage ainsi que de faire jouer ses animation
                            */
    {

        if (Input.GetKey(KeyCode.RightArrow)) // Mouvement droite
        {
            sprite.flipX = false;
            transform.Translate(Vector3.right * Movespeed * Time.deltaTime);
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow)) // Mouvement gauche
        {
            sprite.flipX = true;
            transform.Translate(Vector3.left * Movespeed * Time.deltaTime);

        }

//                                  MECANIQUE DE SAUT



        if (Input.GetKey(KeyCode.Space) && Grounded == true) // Si relaché avant le décompte, un petit saut
        {
            //Debug.Log(" petit saut");
            rb.AddForce( Vector2.up * jumpHeight * 10 ) ;
            StartCoroutine(Time_jumped());

           
        }


        if (Input.GetKey(KeyCode.Space) && isplaned == true) // Si relaché avant le décompte, un petit saut
        {
            //Debug.Log(" plane");
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
