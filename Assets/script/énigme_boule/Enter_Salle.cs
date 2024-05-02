using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_Salle : MonoBehaviour
{

    [SerializeField] Rigidbody2D Ball;
    [SerializeField] GameObject G_Ball;
    [SerializeField] Canvas canva;
    public float Xball;
    public float Yball;

    // Start is called before the first frame update
    void Start()
    {
        Ball.constraints = RigidbodyConstraints2D.FreezePositionY;
        Xball = Ball.transform.position.x;
        Yball = Ball.transform.position.y;
        Debug.Log("Commence");
        canva.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canva.enabled = true;

            if (Input.GetKey(KeyCode.E))
            {

                Ball.velocity = Vector3.zero;
                G_Ball.transform.position = new Vector3(Xball, Yball, 0);

                Ball.constraints = RigidbodyConstraints2D.None;
                Ball.gravityScale = 5f;
                Debug.Log(" La boule tombe");

            }
        }
        else
        {
            canva.enabled = false;
        }

        //else if (collision.CompareTag("Player") && deux_pass == true)
        //{

        //    //Ball.transform.TransformDirection(Xball,Yball, 0);
        //    G_Ball.transform.position = new Vector3(Xball, Yball, 0);

        //    Ball.constraints = RigidbodyConstraints2D.FreezeAll;
        //    Ball.gravityScale = 0;
        //    first_pass = true;
        //    deux_pass = false;

        //}
    }

}
