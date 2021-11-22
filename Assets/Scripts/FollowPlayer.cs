using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 CameraOffset = new Vector3(1,1,1);
    // Start is called before the first frame update

    void LateUpdate()
    {
        UpdateCameraPosition();

    }

    void UpdateCameraPosition()
    {
        if(player!=null)
        {
            transform.position = player.transform.position + CameraOffset;
        }
    }

}
