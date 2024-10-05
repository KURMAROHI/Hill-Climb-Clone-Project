
using System;
using Unity.VisualScripting;
using UnityEngine;


public class CollisionChek : MonoBehaviour
{

    void OnEnable()
    {
        Debug.Log("Collision Check");
        PlayerPrefs.SetInt("Num", 1);
        //Debug.Log("==>" +PlayerPrefs.GetFloat("Num"));
        Debug.Log("==>" +PlayerPrefs.GetString("Num"));
    }
    public static Action HeadCollision;
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("==>" + col.gameObject.name);
        if (col.gameObject.CompareTag("Head"))
        {
            if (PlayerPrefs.GetInt("OnGameEnd", 0) == 0)
            {
                Debug.Log("===>Done yaar");
                PlayerPrefs.SetInt("OnGameEnd", 1);
                FuelController.Instance.ISfuelAvilable = false;
                DriveCar.Instance.IsStartMoving = false;
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



}
