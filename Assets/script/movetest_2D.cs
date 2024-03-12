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
    [SerializeField] bool jumped = true;
    [SerializeField] bool isJumped;


    IEnumerator coroutine;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionStay2D(Collision2D collision) // permet de désactiver le saut si pas encore retombé
    {   
        jumped = false;
        isJumped = false;
        StopAllCoroutines();
        
    }

    void Update() // Fonction Update appelle la fonction Movement
    {
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



        if (Input.GetKey(KeyCode.Space) && (jumped == false)) // Si relaché avant le décompte, un petit saut
        {
            Debug.Log(" petit saut");
            rb.AddForce(Vector2.up * 25 * jumpHeight);
            jumped = true;
            StartCoroutine(Time_jumped());

           
        }


        if (Input.GetKey(KeyCode.Space) && isJumped == true) // Si relaché avant le décompte, un petit saut
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
        yield return new WaitForSeconds(0.3f);
        isJumped = true;

    }

}
