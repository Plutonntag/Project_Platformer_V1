using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparition : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb_player;
    [SerializeField] SpriteRenderer image;
    [SerializeField] BoxCollider2D touch;
    public bool absorbed = false;

    void Start()
    {

    }

    void Update() // Fonction Update appelle la fonction Movement
    {
        TouchTrigger();
        
    }

                  


    private void TouchTrigger()
    {

        if (rb_player.IsTouching(touch))
        {



            if (Input.GetKey(KeyCode.F) && absorbed == false)
            {

                Debug.Log("absorption");
                
                absorbed = true;
                image.enabled = false;
                touch.enabled = false;

            }


        }

    }
}
