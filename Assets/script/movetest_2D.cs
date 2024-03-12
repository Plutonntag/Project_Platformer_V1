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
    [SerializeField] int powar_JP;
    [SerializeField] float jumpHeight = 7f;
    [SerializeField] bool jumped = true;
    [SerializeField] bool isPressed;

    IEnumerator coroutine;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionStay2D(Collision2D collision) // permet de d�sactiver le saut si pas encore retomb�
    {   
        jumped = false;
        
    }

    void Update() // Fonction Update appelle la fonction Movement
    {
        Movement();

    }


    private void Movement() /* Cette fonction permet de faire d�placer le personnage ainsi que de faire jouer ses animation
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


        if ((Input.GetKeyDown(KeyCode.Space)) && (jumped == false)) // Appuyer fait d�marr� le d�compte
        {
            StartCoroutine(pressed());
            jumped = true;

        }
        else if (isPressed == true && (jumped == false) && (Input.GetKeyUp(KeyCode.Space))) // Si relach� apr�s le d�compte, un grand saut
        {
            Debug.Log(" Grand saut");
            rb.AddForce(Vector2.up * 60 * powar_JP);
            jumped = true;
            isPressed = false;
            StopAllCoroutines();
        }
        else if (isPressed == false && (Input.GetKeyUp(KeyCode.Space)) && (jumped == false)) // Si relach� avant le d�compte, un petit saut
        {
            Debug.Log(" petit saut");
            rb.AddForce(Vector2.up * 60 * jumpHeight);
            jumped = true;
            StopAllCoroutines();
        }


        if (Input.GetKey(KeyCode.Space) && jumped == true) // Si relach� avant le d�compte, un petit saut
        {
            Debug.Log(" plane");
            rb.velocity = Vector3.zero;
            rb.gravityScale = 4;
        }
        else
        {
            rb.gravityScale = 9.8f; 
        }



    }

    IEnumerator pressed()
    {
        yield return new WaitForSeconds(1);
        isPressed = true;
    }
   
   

}
