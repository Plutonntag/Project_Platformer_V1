using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Leave : MonoBehaviour
{
    [SerializeField] GameObject ennemie;
    private bool isLeave;
    public Move_ennemie script;
    public Trigg_attack HaveTrigg;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fuite()
    {
            while (isLeave)
            {
                ennemie.transform.Translate(Vector3.right * script.Speed * Time.deltaTime);

            }
            ennemie.GetComponent<SpriteRenderer>().enabled = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemie"))
        {

            Debug.Log("Let's Play");

            if (Input.GetKey(KeyCode.E) && HaveTrigg.istrigg == false)
            {
                ennemie.GetComponent<Rigidbody2D>().velocity = Vector3.right * 10;
                ennemie.GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
                ennemie.GetComponent<CapsuleCollider2D>().enabled = false;
                StartCoroutine(TimeLeave());



            }
        }
    }


    IEnumerator TimeLeave()
    {
        yield return new WaitForSeconds(3);
        isLeave = false;

    }
}
