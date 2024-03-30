using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Leave : MonoBehaviour
{
    [SerializeField] GameObject ennemie;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemie"))
        {

            Debug.Log("Let's Play");

            if (Input.GetKey(KeyCode.E))
            {
                ennemie.GetComponent<Rigidbody2D>().velocity = Vector3.right * 4;
                ennemie.GetComponent<Rigidbody2D>().velocity = Vector3.up * 4;



            }
        }
    }
}
