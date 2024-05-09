using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GameUIController : MonoBehaviour
{

    public static GameUIController Instance;
    [SerializeField] Transform AccleratorNormal, AccelaratorPressed;
    [SerializeField] Transform BreakNormal, BreakPressed;
    [SerializeField] RectTransform _DistanceContent;
    [SerializeField] Text _DistText;

    float _Multiplier, _ContentYpos;
    HorizontalLayoutGroup _DistHorizantallayoutGroup;

    public bool iSAccelratorApplied = false, isbreakApplied = false;

    [SerializeField] GameObject _Bar;

    float ViewPortWidth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _ContentYpos = _DistanceContent.anchoredPosition.y;
        _DistHorizantallayoutGroup = _DistanceContent.GetComponent<HorizontalLayoutGroup>();
        _Multiplier = _DistanceContent.GetChild(0).GetComponent<RectTransform>().rect.width / 100;
        ViewPortWidth = _DistanceContent.parent.GetComponent<RectTransform>().rect.width + 100f; //100f is An offset that i am Adding Extra

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

    int OldDistance = 0;
    public void SetDistanceTravelled(int Distancetravelled)
    {

        if (_DistanceContent.anchoredPosition.x < -(_DistanceContent.rect.width - ViewPortWidth))
        {
            Instantiate(_Bar, _DistanceContent);
        }
        if (OldDistance != Distancetravelled)
        {
           //` Debug.Log("Distnce travelled==>" + Distancetravelled);
            OldDistance = Distancetravelled;
            _DistanceContent.DOAnchorPosX(-Distancetravelled * 2, 0.1f).SetEase(Ease.Linear);
        }
        _DistText.text = Distancetravelled.ToString();
    }
}


