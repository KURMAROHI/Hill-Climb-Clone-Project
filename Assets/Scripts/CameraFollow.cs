using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // The player's transform
    public float smoothing = 5f; // The smoothing factor for the camera's movement
    public Vector3 offset;       // The initial offset from the player

    public Vector3 targetCamPos;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        targetCamPos = player.position + offset;
        //transform.position = new Vector3(targetCamPos.x, 18f, targetCamPos.z);
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, 18f, transform.position.z), new Vector3(targetCamPos.x, 18, targetCamPos.z), smoothing * Time.deltaTime);
    }
}
