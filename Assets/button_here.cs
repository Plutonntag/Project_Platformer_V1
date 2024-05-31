using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_here : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void apparition_button()
    {
        canvas.enabled = true;
    }

    public void disparition_button()
    {
        canvas.enabled = false;
    }
}
