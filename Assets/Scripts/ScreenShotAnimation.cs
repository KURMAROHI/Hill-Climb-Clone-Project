using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotAnimation : MonoBehaviour
{

    [SerializeField] Image ScreenShotImage;

    void Awake()
    {
        ScreenShotImage.sprite = GameUIController.Instance.UIScreenShotImage;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
