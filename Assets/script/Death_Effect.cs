using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Effect : MonoBehaviour
{
    public static Death_Effect instance;
    private GameObject Player;
    private Transform CheckPawn;
    [SerializeField] Animator mort_animation;
    IEnumerator coroutine;

    private void Awake()
    {
        if( instance != null)
        {
            Debug.LogError("Singleton problem");
            return;

        }

        instance = this;
    }

    private void Start()
    {
        CheckPawn = GameObject.FindWithTag("Spawn").transform;
        Player = GameObject.FindWithTag("Player");
    }

    public void Death_Player()
    {        
        StartCoroutine(Time_Death_effect());
    }

    IEnumerator Time_Death_effect()
    {
        // Animation mort
        mort_animation.SetBool("mort", true);
        yield return new WaitForSeconds(0.55f);
        Player.transform.position = CheckPawn.position;
        mort_animation.SetBool("mort", false);
        // Animation Respawn
    }

}
