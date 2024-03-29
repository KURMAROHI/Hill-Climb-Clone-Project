using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    Rigidbody rigidbody;
    [SerializeField] float magnitude;
    void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Acceleration");
            rigidbody.AddForce(transform.up * magnitude, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            Debug.Log("Right Control Impulse");
            rigidbody.AddForce(transform.forward * magnitude, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("leftControl VelocityChange");
           rigidbody.AddForce(-transform.forward*magnitude,ForceMode.VelocityChange);
        }

    }
    void Setforce()
    {
        rigidbody.AddForce(transform.up * magnitude, ForceMode.Acceleration);
    }

}
