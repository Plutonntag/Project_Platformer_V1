using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] BoxCollider2D Box_attack_chara;


    [SerializeField] Animator Player_idle;
    [SerializeField] Animator Player_walk;
    [SerializeField] Animator Player_walk_plat;
    [SerializeField] Animator Player_idle_plat;

    public bool isplaned;
    [SerializeField] bool Grounded;
    public bool plat_absorb;
    private float XTrigg;
    private Vector2 moveInput;
    

    IEnumerator coroutine;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        XTrigg = Box_attack_chara.offset.x;


    }

    private void FixedUpdate()
    {
        groundJump();
        Movement();
        Jump();
    }

    private void groundJump()
    {
        Grounded = Physics2D.OverlapCircle(check.position, groundCheckRadius, collisionPlayer);
        if (Grounded == true) { 

            //StopAllCoroutines();
            //isplaned = false;

            //Debug.Log("Stop");
        }
        else
        {
            
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(check.position, groundCheckRadius);
    }

    
    public void Déplacement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Movement() /* Cette fonction permet de faire déplacer le personnage ainsi que de faire jouer ses animation
                            */
    {
        //float moveInput = Input.GetAxis("Horizontal");
        //Vector2 moveVelocity = new Vector2(moveInput * Movespeed, rb.velocity.y);
        //Debug.Log(moveVelocity);
        Vector2 moveVelocity = new Vector2(moveInput.x * Movespeed, rb.velocity.y);
        rb.velocity = moveVelocity;


        rb.velocity = moveVelocity;
        if (moveInput.x == 0 && plat_absorb == false)
        {
            Player_walk.SetBool("Marche", false);
            Player_idle_plat.SetBool("Idle_plat", false);
            Player_walk_plat.SetBool("Marche_plat", false);
            Player_idle.SetBool("Idle", true);
        }
        else if( moveInput.x == 0 && plat_absorb != false) 
        {
            Player_walk.SetBool("Marche", false);
            Player_walk_plat.SetBool("Marche_plat", false);
            Player_idle.SetBool("Idle", false);
            Player_idle_plat.SetBool("Idle_plat", true);
            
        }



        // Mouvement droite

        if (moveInput.x > 0 && plat_absorb == false) {
            Player_idle_plat.SetBool("Idle_plat", false);
            Player_walk_plat.SetBool("Marche_plat", false);
            Player_idle.SetBool("Idle", false);
            Player_walk.SetBool("Marche", true);
            sprite.flipX = false;
            Box_attack_chara.offset = new Vector3(XTrigg, 0, 0);
        }
        else if (moveInput.x > 0 && plat_absorb != false) 
        {
            Player_idle_plat.SetBool("Idle_plat", false);
            Player_walk_plat.SetBool("Marche", false);
            Player_idle.SetBool("Idle", false);
            Player_walk.SetBool("Marche_plat", true);
            sprite.flipX = false;
            Box_attack_chara.offset = new Vector3(XTrigg, 0, 0);
        }


            //transform.Translate(Vector3.right * Movespeed * Time.deltaTime);
            //rb.velocity = new Vector2(1 * Movespeed, 0);
            //rb.velocity =  Vector3.right * Movespeed;
            //rb.AddForce(Vector3.right * Movespeed * 5);
            //Vector3 velocity = Vector3.left * Movespeed;


    // Mouvement gauche
        
            if (moveInput.x < 0 && plat_absorb == false)
            {
                Player_idle_plat.SetBool("Idle_plat", false);
                Player_walk_plat.SetBool("Marche_plat", false);
                Player_idle.SetBool("Idle", false);
                Player_walk.SetBool("Marche", true);
                sprite.flipX = true;
                Box_attack_chara.offset = new Vector3(-XTrigg, 0, 0);
        }
            else if(moveInput.x < 0 && plat_absorb != false)
            {
                Player_idle_plat.SetBool("Idle_plat", false);
                Player_walk_plat.SetBool("Marche", false);
                Player_idle.SetBool("Idle", false);
                Player_walk.SetBool("Marche_plat", true);
                sprite.flipX = true;
                Box_attack_chara.offset = new Vector3(-XTrigg, 0, 0);
        }

            //transform.Translate(Vector3.left * Movespeed * Time.deltaTime);
            //rb.velocity = new Vector2(1 * -Movespeed, 0);
        
            //rb.AddForce(Vector3.left * Movespeed * 5);


        //                                  MECANIQUE DE SAUT




        //if (Input.GetKey(KeyCode.Space) && Grounded == true) // Si relaché avant le décompte, un petit saut
        //{
        //    //Debug.Log(" petit saut");
        //    rb.AddForce(Vector2.up * jumpHeight * 10);
        //    if (rb.velocity.magnitude > 15)
        //    {
        //        rb.velocity = Vector2.zero;
        //    };
        //    //Debug.Log(rb.velocity);
        //    StartCoroutine(Time_jumped());


        //}


        //if (Input.GetKey(KeyCode.Space) && isplaned == true) // Si relaché avant le décompte, un petit saut
        //{
        //    //Debug.Log(" plane");

        //    rb.gravityScale = 0.9f;

            
            
        //}
        //else
        //{
        //    rb.gravityScale = 9.8f;
        //}


    }

    public void InputJump(InputAction.CallbackContext context)
    {
        
        StartCoroutine(Time_jumped() );
        if (Grounded == true) // Si relaché avant le décompte, un petit saut
        {
            //Debug.Log(" petit saut");
            
            rb.AddForce(Vector2.up * jumpHeight * 10);
            if (rb.velocity.magnitude > 15)
            {
                rb.velocity = Vector2.zero;
            }
            //Debug.Log(rb.velocity);
        }

        
        if (context.canceled)
        {
            Debug.Log("fini");
            isplaned = false;
            rb.gravityScale = 9.8f;
            StopAllCoroutines();

        }




    }
    private void Jump()
    {
        //if (Grounded == true) // Si relaché avant le décompte, un petit saut
        //{
        //    //Debug.Log(" petit saut");
        //    rb.AddForce(Vector2.up * jumpHeight * 10);
        //    if (rb.velocity.magnitude > 15)
        //    {
        //        rb.velocity = Vector2.zero;
        //    }
        //    //Debug.Log(rb.velocity);
        //    StartCoroutine(Time_jumped());


        //}

        if (isplaned == true) // Si relaché avant le décompte, un petit saut
        {
            //Debug.Log(" plane");

            rb.gravityScale = 0.9f;



        }
        //else
        //{
        //    rb.gravityScale = 9.8f;
        //}

    }


    IEnumerator Time_jumped()
    {
        yield return new WaitForSeconds(0.2f);
        Grounded = false;
        rb.velocity = Vector2.zero;
        isplaned = true;
        Debug.Log("Stop");

    }

}
