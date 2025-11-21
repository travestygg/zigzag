using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharController : MonoBehaviour
{
    public Transform rayStart;
    private Rigidbody rb;
    private bool WalkingRight = true;
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();

        }

        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity)) {
            anim.SetTrigger("IsFalling");
        }
    }

    private void Switch(){
        WalkingRight = !WalkingRight;

        if (WalkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else 
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
}
