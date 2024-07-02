
using System;
using Unity.VisualScripting;
using UnityEngine;


public class CollisionChek : MonoBehaviour
{

    void OnEnable()
    {
        Debug.Log("Collision Check");
    }
    public static Action HeadCollision;
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("==>" + col.gameObject.name);
        if (col.gameObject.CompareTag("Head"))
        {
            Debug.Log("Done yaar");
            if (PlayerPrefs.GetInt("OnGameEnd", 0) == 0)
            {
                PlayerPrefs.SetInt("OnGameEnd", 1);
                FuelController.Instance.ISfuelAvilable = false;
                DriveCar.Instance.IsStartMoving = false;
                // HeadCollision?.Invoke();
            }

        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        // Debug.Log("==>" + col.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D coll)
    {

    }


    // void EndTheGame()
    // {

    // }
}
