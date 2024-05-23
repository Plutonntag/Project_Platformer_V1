using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class disparition : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb_player;
    public movetest Chara;
    [SerializeField] SpriteRenderer image;
    [SerializeField] BoxCollider2D touch_trigger;
    [SerializeField] BoxCollider2D touch;
    public bool absorbed = false;



    void Update() // Fonction Update appelle la fonction Movement
    {
      
        
    }

                  


    public void TouchTrigger(InputAction.CallbackContext context)
    {

        if (rb_player.IsTouching(touch_trigger) && Chara.plat_absorb == false)
        {



            if (absorbed == false)
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
