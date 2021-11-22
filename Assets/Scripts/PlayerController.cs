using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] ParticleSystem deathBlast;

    public float transformSpeed = 20f; //speed of changing scale of player
    public float scaleChangeSpeed = 0.1f;
    public float moveForwardSpeed = 10f;
    public float yScale,xScale;
    private float xUpperBound = 3f;
    private float xLowerBound = 0.2f;
    private float yUpperBound = 3f;
    private float yLowerBound = 0.2f;
    private float zScale = 0.5f;

    

    private Rigidbody playerRb;

    //public bool isxUpperBound, isxLowerBound, isyUpperBound, isyLowerBound;


    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageInput();
        //ChangeShape();
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    // All Input related code
    void ManageInput()
    {

        if(Input.GetMouseButton(0))
        {
            ChangeShape(scaleChangeSpeed,-scaleChangeSpeed);
        } 

        if(Input.GetMouseButton(1))
        {
            ChangeShape(-scaleChangeSpeed, scaleChangeSpeed);
        }
        //verticalInput = Input.GetAxis("Vertical"); // getting input w/s or up/down arrow
        
    }

    //changes shape and size of player by changing its x and y scale
    void ChangeShape(float yScaleChangeSpeed, float xScaleChangeSpeed)
    {
        
        yScale = transform.localScale.y;
        yScale += yScaleChangeSpeed;
        xScale = transform.localScale.x;
        xScale += xScaleChangeSpeed;
        

        Vector3 scale = new Vector3(xScale, yScale,zScale);

        //isyUpperBound = yScale <= yUpperBound;
        //isxLowerBound = xScale >= xLowerBound;
        //isyLowerBound = yScale >= yLowerBound;
        //isxUpperBound = xScale <= xUpperBound;
        

        if(yScale <= yUpperBound && xScale >= xLowerBound && yScale >= yLowerBound && xScale <= xUpperBound) // checks if player scale/size is within bounds and changes scale if in bounds
        {
            //transform.localScale = scale;
            transform.localScale = Vector3.Lerp(transform.localScale, scale,transformSpeed* Time.deltaTime ); // to change scale of player smoothly
        }

    }

    void MoveForward()
    {
        //transform.Translate(Vector3.forward* moveForwardSpeed); // to move player forward constantly with same speed

        playerRb.AddForce(Vector3.forward * moveForwardSpeed);

    }

    IEnumerator DeathEffect()
    {
        deathBlast =  Instantiate(deathBlast, transform.position,transform.rotation);
        deathBlast.Play();

        Destroy(gameObject);
        yield return new WaitForSeconds(2);
        GameManager.Instance.GameOver();
    }


    void OnCollisionEnter(Collision collision)
    {

        

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(DeathEffect());
            
        }
    }

}
