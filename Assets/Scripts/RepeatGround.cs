using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject ground;
    float zSizeGround;


    // Start is called before the first frame update
    void Start()
    {
        zSizeGround = ground.GetComponent<BoxCollider>().size.z ; // size of box collider of ground
    
    }

    void FixedUpdate()
    {
        //checks if player is still alive/not destroyed
        if(player!=null)
        {
            Repeat();
        }
    }

    void Repeat()
    {
        //check if player z position is greater than ground z position
        if(player.position.z > ground.transform.position.z) 
        {
            Vector3 newPos = ground.transform.position; // saves ground position
            newPos.z += zSizeGround; // new spawn position by adding size of ground
            ground = Instantiate(groundPrefab, newPos, transform.rotation); //Instantiating Groundprefab and saving it in ground to get the latest spawned ground position 
        }
    }

    
}
