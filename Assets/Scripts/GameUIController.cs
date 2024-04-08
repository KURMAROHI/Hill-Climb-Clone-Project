using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameUIController : MonoBehaviour
{

    public static GameUIController Instance;
    [SerializeField] Transform AccleratorNormal, AccelaratorPressed;
    [SerializeField] Transform BreakNormal, BreakPressed;

    public bool iSAccelratorApplied = false, isbreakApplied = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

  


    public void AcceleratorBreakPointerDown(BaseEventData data)
    {
       // Debug.Log("onpointer Down");
        PointerEventData _pointerEventData = (PointerEventData)(data as BaseEventData);

        if (_pointerEventData.position.x > 0f && _pointerEventData.position.x < (Screen.width / 2 - 100f))
        {
            BreakNormal.gameObject.SetActive(false);
            BreakPressed.gameObject.SetActive(true);
            isbreakApplied = true;
        }
        else if (_pointerEventData.position.x > Screen.width / 2 + 100f && _pointerEventData.position.x < Screen.width)
        {

            AccleratorNormal.gameObject.SetActive(false);
            AccelaratorPressed.gameObject.SetActive(true);
            iSAccelratorApplied = true;
        }

    }




    public void AccleratorBreakPointerUp(BaseEventData data)
    {
       // Debug.Log("onpointer up");
        PointerEventData _pointerEventData = (PointerEventData)(data as BaseEventData);

        if (_pointerEventData.position.x > 0f && _pointerEventData.position.x < (Screen.width / 2 - 100f))
        {
            BreakNormal.gameObject.SetActive(true);
            BreakPressed.gameObject.SetActive(false);

            isbreakApplied = false;
        }
        else if (_pointerEventData.position.x > Screen.width / 2 + 100f && _pointerEventData.position.x < Screen.width)
        {
            AccleratorNormal.gameObject.SetActive(true);
            AccelaratorPressed.gameObject.SetActive(false);

            iSAccelratorApplied = false;
        }


    }

    // public void BreakPointerDown(BaseEventData data)
    // {
    //     PointerEventData _pointerEventData = (PointerEventData)(data as BaseEventData);
    //     BreakNormal.gameObject.SetActive(false);
    //     BreakPressed.gameObject.SetActive(true);
    // }

    // public void BreakPointerUp(BaseEventData data)
    // {
    //     PointerEventData _pointerEventData = (PointerEventData)(data as BaseEventData);
    //     BreakNormal.gameObject.SetActive(true);
    //     BreakPressed.gameObject.SetActive(false);
    // }
}


