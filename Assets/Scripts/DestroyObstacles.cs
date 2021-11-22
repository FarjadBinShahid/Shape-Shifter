using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    
    //Destroys every obstacle whop collides with it
    private void OnTriggerEnter(Collider other)
    {    
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject); 
        }
    }

    
}
