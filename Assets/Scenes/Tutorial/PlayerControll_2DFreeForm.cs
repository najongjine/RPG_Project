using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll_2DFreeForm : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // no shiftkey=0, shiftkey = 1
        float offset = 0.5f + Input.GetAxis("Sprint");

        animator.SetFloat("Horizontal", horizontal*offset);
        animator.SetFloat("Vertical", vertical * offset);
    }
}
