using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    //Get the vector for camera's position
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    //The transform component for the camera to follow
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Transform from Player
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the position for the camera to follow Player
        this.transform.position = target.TransformPoint(camOffset);
        //Attach camera unto player
        this.transform.LookAt(target);
    }
}
