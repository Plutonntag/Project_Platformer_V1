using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparition : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb_player;
    public movetest Chara;
    [SerializeField] SpriteRenderer image;
    [SerializeField] BoxCollider2D touch_trigger;
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

        if (rb_player.IsTouching(touch_trigger) && Chara.plat_absorb == false)
        {



            if (Input.GetKey(KeyCode.J) && absorbed == false)
            {

                Debug.Log("absorption");
                
                absorbed = true;
                image.enabled = false;
                touch.enabled = false;
                touch_trigger.enabled = false;
                Chara.plat_absorb = true;


            }


        }

    }
}
