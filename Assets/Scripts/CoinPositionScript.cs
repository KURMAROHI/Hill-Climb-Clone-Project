
using System;
using UnityEngine;
using DG.Tweening;

public class CoinPositionScript : MonoBehaviour
{


    // public static event Action FuelFullEvent;
     //public static event Action<int> CoinCountEvent;


    void Start()
    {
        RaycastHit2D HitCollider = Physics2D.Raycast(transform.position, Vector2.down);
        if (HitCollider.transform != null)
        {
            // transform.position = new Vector3(transform.position.x, HitCollider.transform.position.y + 1,)
            // Debug.LogError("Name|" + HitCollider.transform.name + "::" + HitCollider.point);
            transform.position = new Vector3(transform.position.x, HitCollider.point.y + 3, 0f);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        //Debug.Log("Col|" + col.transform.name + "::" + transform.name);
        if (transform.name == "Fuel" && FuelController.Instance != null)
        {
          //  transform.GetComponent<Animator>().enabled = true;
            transform.DOMoveY(transform.position.y + 2.5f, 0.4f).SetEase(Ease.Linear);
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0f, 0.7f).SetDelay(0.1f).SetEase(Ease.Linear);


            FuelController.Instance.SetFuelFull();

        }
        else if ((transform.name == "5" || transform.name == "25" || transform.name == "100" || transform.name == "500") && CoinController.Instance != null)
        {
            transform.GetComponent<CircleCollider2D>().enabled = false;
            int.TryParse(transform.name, out int Amount);
            // transform.GetComponent<Animator>().Play(Amount.ToString());
            transform.DOMoveY(transform.position.y + 4f, 0.4f).SetEase(Ease.Linear);
            transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0f, 0.7f).SetDelay(0.1f).SetEase(Ease.Linear);

            CoinController.Instance.CountingCoins(Amount);

        }

        Destroy(gameObject, 2f);
    }


}
