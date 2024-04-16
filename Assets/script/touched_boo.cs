using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touched_boo : MonoBehaviour

{
    public Move_ennemie script;
    public Trigg_attack HaveTrigg;
    private bool isLeave;
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
            transform.Translate(Vector3.right * script.Speed * Time.deltaTime);

        }
        GetComponent<SpriteRenderer>().enabled = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log("Let's Play");

            if (Input.GetKey(KeyCode.E) && HaveTrigg.istrigg == false)
            {
                Debug.Log("hit");
                GetComponent<Rigidbody2D>().velocity = Vector3.right * 10;
                GetComponent<Rigidbody2D>().velocity = Vector3.up * 10;
                GetComponent<CapsuleCollider2D>().enabled = false;
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
