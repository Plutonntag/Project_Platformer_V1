using System;
using System.Collections;
using System.Collections.Generic;
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
    private bool isplaned;
    [SerializeField] bool Grounded;
    public bool plat_absorb;
    private float XTrigg;
    

    IEnumerator coroutine;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        XTrigg = Box_attack_chara.offset.x;


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
        if (Input.GetKey(KeyCode.Space) && Grounded == true) // Si relaché avant le décompte, un petit saut
        {
                //Debug.Log(" petit saut");
                rb.AddForce(Vector3.up * jumpHeight * 30 ) ;
                //rb.velocity = (Vector3.up * jumpHeight);
                StartCoroutine(Time_jumped());


        }


        if (Input.GetKey(KeyCode.Space) && isplaned == true) // Si relaché avant le décompte, un petit saut
        {
                //Debug.Log(" plane");
                rb.velocity = Vector3.zero;
                rb.gravityScale = 7;
        }
        else
        {
                rb.gravityScale = 9.8f;
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
            Box_attack_chara.offset = new Vector3(XTrigg,0, 0);
            transform.Translate(Vector3.right * Movespeed * Time.deltaTime);
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow)) // Mouvement gauche
        {
            sprite.flipX = true;
            Box_attack_chara.offset = new Vector3(-XTrigg,0, 0);
            transform.Translate(Vector3.left * Movespeed * Time.deltaTime);

        }

//                                  MECANIQUE DE SAUT


    }

    IEnumerator Time_jumped()
    {
        yield return new WaitForSeconds(0.2f);
        isplaned = true;

    }

}
