using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    private Animator animator; // Controlador de animaciones

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack"); 
        }
    }
}

