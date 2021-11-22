using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] ParticleSystem deathBlast;

    public float transformSpeed = 20f; //speed of changing scale of player
    public float scaleChangeSpeed = 0.1f; // amount of how much the scale should be changed every fixed update cycle
    public float moveForwardSpeed = 10f; // player moving forward speed
    public float yScale,xScale, zScale = 0.5f; // user latest scale
    private float upperBound = 3f; // player maximum width and height limit
    private float lowerBound = 0.2f; // player minimum width and height limit

    

    private Rigidbody playerRb; // rigid body reference to add force on player

    //public bool isupperBound, isxLowerBound, isyUpperBound, isyLowerBound;


    void Awake()
    {
        playerRb = GetComponent<Rigidbody>(); //  getting rigid body component
    }

    // Update is called once per frame
    void Update()
    {
        ManageInput(); 
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    // All Input related code
    void ManageInput()
    {

        // if user press left click change shape of player (+ height - width) else (-height + width)
        if(Input.GetMouseButton(0))
        {
            ChangeShape(scaleChangeSpeed,-scaleChangeSpeed);
        } 

        if(Input.GetMouseButton(1))
        {
            ChangeShape(-scaleChangeSpeed, scaleChangeSpeed);
        }
        
    }

    //changes shape and size of player by changing its x and y scale
    void ChangeShape(float yScaleChangeSpeed, float xScaleChangeSpeed)
    {
        // getting latest x and yscale of player
        yScale = transform.localScale.y; 
        xScale = transform.localScale.x;
        // adding scale change amount to player scale 
        yScale += yScaleChangeSpeed; 
        xScale += xScaleChangeSpeed;
        

        Vector3 scale = new Vector3(xScale, yScale,zScale); // updated scale of player

        //isyUpperBound = yScale <= yUpperBound;
        //isxLowerBound = xScale >= xLowerBound;
        //isyLowerBound = yScale >= yLowerBound;
        //isupperBound = xScale <= upperBound;
        

        if(yScale <= upperBound && xScale >= lowerBound && yScale >= lowerBound && xScale <= upperBound) // checks if player scale/size is within bounds and changes scale if in bounds
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale,transformSpeed* Time.deltaTime ); // to change scale of player smoothly
        }

    }

    void MoveForward()
    {
        playerRb.AddForce(Vector3.forward * moveForwardSpeed); // Adding force on player to move forward

    }


    // coroutine so game is not ended immediatly instead wait for 2 seconds so Particle effect can start and finish
    IEnumerator DeathEffect()
    {
        deathBlast =  Instantiate(deathBlast, transform.position,transform.rotation); // instantiating a new particle effect
        deathBlast.Play(); // playing particle effect

        yield return new WaitForSeconds(1); // wait for 2 seconds before calling gameOver()
        Debug.Log("Hee");
        Destroy(gameObject); // destry player
        GameManager.Instance.GameOver(); 
    }


    
    void OnCollisionEnter(Collision collision)
    {
        //check if player collides with obstacle
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(DeathEffect());
        }
    }

}
