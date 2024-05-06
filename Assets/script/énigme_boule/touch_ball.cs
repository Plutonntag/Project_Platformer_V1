using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_ball : MonoBehaviour
{

    [SerializeField] CircleCollider2D G_Ball;
    [SerializeField] BoxCollider2D Soluc;
    [SerializeField] GameObject Plateforme;
    [SerializeField] GameObject checker;
    [SerializeField] GameObject Ball;
    private bool One;
    // Start is called before the first frame update
    void Start()
    {
        One = false;
    }

    // Update is called once per frame
    void Update()
    {
        winning();
    }

    private void winning()
    {
        if (Soluc.IsTouching(G_Ball) && One == false)
        {
            One = true;
            Plateforme.transform.position = (checker.transform.position);
            Ball.SetActive(false);

        
        }
    }
}
