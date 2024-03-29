
using System;
using System.Net.Sockets;
using UnityEngine;

public class CoinPositionScript : MonoBehaviour
{


    public static event Action FuelFullEvent;
    public static event Action<int> CoinCountEvent;
    CircleCollider2D _CirlceCollider2D;

    void OnEnable()
    {
        _CirlceCollider2D = transform.GetComponent<CircleCollider2D>();

    }

    void OnDisable()
    {

    }

    void Start()
    {
        RaycastHit2D HitCollider = Physics2D.Raycast(transform.position, Vector2.down);
        if (HitCollider.transform != null)
        {
            // transform.position = new Vector3(transform.position.x, HitCollider.transform.position.y + 1,)
            Debug.LogError("Name|" + HitCollider.transform.name + "::" + HitCollider.point);
            transform.position = new Vector3(transform.position.x, HitCollider.point.y + 3, 0f);
            // transform.localPosition = new Vector3(transform.position.x, HitCollider.point.y, 0f);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        //  Debug.Log("Col|" + col.transform.name + "::" + transform.name);
        if (transform.name == "Fuel" && FuelController.Instance != null)
        {
            transform.GetComponent<Animator>().enabled = true;
            // FuelController.Instance.SetFuelFull();
            FuelFullEvent?.Invoke();
        }
        else if ((transform.name == "5" || transform.name == "25" || transform.name == "100" || transform.name == "500") && CoinController.Instance != null)
        {
            transform.GetComponent<CircleCollider2D>().enabled = false;
            int.TryParse(transform.name, out int Amount);
            transform.GetComponent<Animator>().Play(Amount.ToString());
            Debug.Log("Amount|" + Amount.ToString());
            CoinCountEvent?.Invoke(Amount);
        }

        Destroy(gameObject, 5f);
    }


}
