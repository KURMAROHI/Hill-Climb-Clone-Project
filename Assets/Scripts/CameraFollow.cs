using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // The player's transform
    public Vector3 offset;       // The initial offset from the player

    public Vector3 TargetPosition;
    public Vector3 velocity = Vector3.zero;
    float Ypsoition, Xpsoition;

    public float smoothing = 0.05f; // The smoothing factor for the camera's movement
    public float Thresold = 0.5f;
    public float Speed = 30f;
    // private Vector3 velocity = Vector3.zero;
    float XoldPos;
    void Start()
    {
        offset = player.position - transform.position;
        offset = new Vector3(offset.x, offset.y, offset.z);
        transform.position = player.position - offset;
        XoldPos = player.position.x;
    }


[SerializeField] float ExperimentVlaueFor=20f;
    void Update()
    {
        Ypsoition = Mathf.Clamp(player.position.y, 10, 12);
        TargetPosition = new Vector3(player.position.x - offset.x, 12f, player.position.z - offset.z);

        Debug.Log("==>Velocity|" + DriveCar.Instance.Car.velocity);
        if (DriveCar.Instance.Car.velocity.x > Thresold )
        {
            offset.x = 0;
        }
        else if(DriveCar.Instance.Car.velocity.x>=0)
        {
           offset.x = 40;
        }
        else if(DriveCar.Instance.Car.velocity.x< -Thresold)
        {
             offset.x =90f;
        }
        else if(DriveCar.Instance.Car.velocity.x<=0)
        {
             offset.x =60;
        }

        //transform.position = Vector3.Lerp(transform.position, TargetPosition, smoothing*Time.deltaTime);
        //transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity,smoothing*Time.deltaTime);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, TargetPosition.x, smoothing * Time.deltaTime), TargetPosition.y, TargetPosition.z);
        //  offset = player.position-TargetPosition;

    }
}
