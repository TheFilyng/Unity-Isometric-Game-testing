using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverOG : MonoBehaviour
{

    public Transform player;
    public Vector3 distCamPlayer;
    Vector3 vel = Vector3.zero;
    Quaternion targetRotation;


    [Range(0.01f, 1f)]
    public float cameraMovSmoothness;

    public CameraMover instance;

    [Range(0.1f, 1f)]
    public float rotSpeed;

    private void Awake()
    {
        if (instance != null){
            return;
        }
        instance = this;
    }

    void Start()
    {
        distCamPlayer = transform.position - player.position; //Distance between camera and player
        cameraMovSmoothness = 0.5f;
        rotSpeed = 0.3f;
        targetRotation = transform.rotation;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            //StartCoroutine(RotateCamera());
            RotateCamera();
        }
        FollowPlayer();

    }

    void FollowPlayer()
    {
        Vector3 newPos = player.position + distCamPlayer;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref vel, cameraMovSmoothness);
    }

    void RotateCamera()
    {
        transform.RotateAround(player.position, Vector3.up, 90*rotSpeed*Time.deltaTime);
        distCamPlayer = transform.position - player.position;
    }

    /*IEnumerator RotateCamera()
    {
        float rotateDegrees = 0;
        float lastRotation = 0;
        float rotationSpeed = 90f / rotSpeed;

        while (true)
        {
            lastRotation = rotationSpeed * Time.deltaTime;
            rotateDegrees += lastRotation;

            if (rotateDegrees >= 90)
            {
                transform.RotateAround(player.position, Vector3.up, lastRotation - (rotateDegrees - 90));
                distCamPlayer = transform.position - player.position;
                break;
            }
            transform.RotateAround(player.position, Vector3.up, lastRotation);
            distCamPlayer = transform.position - player.position;
            yield return null;
        }
    }*/

}
