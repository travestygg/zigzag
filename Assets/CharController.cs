using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharController : MonoBehaviour
{
    private GameManager gameManager; 
    public Transform rayStart;
    private Rigidbody rb;
    private bool WalkingRight = true;
    private Animator anim;
    public bool isFalling = false;
    public bool gameStarted = false;    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if (!gameManager.gameStarted)
        {
            //Debug.Log("Game has not started");
            return;
        }
        else 
        {

            
            Debug.Log("Game started");
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
            if (!gameStarted) {
                gameStarted = true;
                anim.SetTrigger("gameStarted");
            }
               
          
            Debug.Log(isFalling);
        }

    }

    private void Update()
    {

       
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();

        }

        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, direction: -transform.up, out hit, Mathf.Infinity))
        {
            if (!isFalling)
            {
                anim.SetTrigger("IsFalling");
                isFalling = true;
                
            }
            
         
        }

        if (transform.position.y < -4)
        {
            gameManager.EndGame();
        }
    }



    private void Switch(){

        if (!gameManager.gameStarted) {
            return;
        }
        WalkingRight = !WalkingRight;

        if (WalkingRight)
            transform.eulerAngles += new Vector3(0, 90, 0);
        else
            transform.eulerAngles += new Vector3(0, -90, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collect") { 
            Destroy(other.gameObject);
            gameManager.IncreaseScore();
            Debug.Log("Score Increased" );
        }
    }
}
