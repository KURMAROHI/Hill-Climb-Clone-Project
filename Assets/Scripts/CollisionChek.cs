
using UnityEngine;

public class CollisionChek : MonoBehaviour
{

    void OnEnable()
    {
        Debug.Log("Collision Check");
    }
    //public Action<bool> HeadCollision;
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("==>" + col.gameObject.name);
        if (col.gameObject.CompareTag("Head"))
        {
            Debug.Log("Done yaar");
            FuelController.Instance.ISfuelAvilable = false;
            DriveCar.Instance.IsStartMoving = false;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        // Debug.Log("==>" + col.gameObject.name);
    }

    // void OnTriggerEnter2D(Collider2D coll)
    // {

    // }
}
