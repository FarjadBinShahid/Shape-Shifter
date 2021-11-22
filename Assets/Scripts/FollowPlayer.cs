using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player; // getting player transform to get its position
    [SerializeField] private Vector3 CameraOffset = new Vector3(1,1,1); // camera offset
    // Start is called before the first frame update

    void LateUpdate()
    {
        UpdateCameraPosition();
    }


    //this method make camera follow player
    void UpdateCameraPosition()
    {
        if(player!=null) // checks if player is alive/not destroyed
        {
            transform.position = player.position + CameraOffset; // makes camera position equal to player position + offset
        }
    }

}
