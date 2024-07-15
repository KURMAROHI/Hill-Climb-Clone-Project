using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ScreenShotAnimation : MonoBehaviour
{

    [SerializeField] Image ScreenShotImage;
    [SerializeField] GameObject ScreenShot;
    [SerializeField] GameObject DistanceImage, CoinsImage;
    [SerializeField] Transform TitleDriverDown, TiltleOutOfFuel;
    [SerializeField] Transform Distance, Coins, AirTime, Flip, BackFlip, NeckFlip, ContinueButton;
    [SerializeField] Text ContinueButtontext;



    void Awake()
    {
        ScreenShotImage.sprite = GameUIController.Instance.UIScreenShotImage;
        ScreenShot.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.5f).SetEase(Ease.OutQuart);
        ScreenShot.transform.DORotate(new Vector3(0, 0, 5f), 0.5f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            SetSequneceAnimation();
        });
    }


    void SetSequneceAnimation()
    {
        TitleDriverDown.gameObject.SetActive(true);
        TitleDriverDown.DORotate(new Vector3(0, 0, 2f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
       {
           DistanceImage.SetActive(true);
           Distance.gameObject.SetActive(true);
           Distance.DORotate(new Vector3(0, 0, 0f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
           {
               CoinsImage.SetActive(true);
               Coins.gameObject.SetActive(true);
               Coins.DORotate(new Vector3(0, 0, 0f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
               {
                   AirTime.gameObject.SetActive(true);
                   AirTime.DORotate(new Vector3(0, 0, 4f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                   {
                       Flip.gameObject.SetActive(true);
                       Flip.DORotate(new Vector3(0, 0, 4f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                       {
                           BackFlip.gameObject.SetActive(true);
                           BackFlip.DORotate(new Vector3(0, 0, -4f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                           {
                               NeckFlip.gameObject.SetActive(true);
                               NeckFlip.DORotate(new Vector3(0, 0, -4f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                               {
                                   ContinueButton.gameObject.SetActive(true);
                                   ContinueButton.DORotate(new Vector3(0, 0, 0f), 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                                   {
                                       ContinueButtontext.GetComponent<CanvasGroup>().DOFade(0.1f, 1f).SetEase(Ease.OutQuint).SetLoops(-1, LoopType.Yoyo);
                                   });

                               });
                           });

                       });
                   });
               });
           });
       });
    }

    public void OnContinueButtonClick()
    {
        Debug.Log("On Continue Button Click");
        //SceneManager.GetSceneByBuildIndex(0).
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }

}
