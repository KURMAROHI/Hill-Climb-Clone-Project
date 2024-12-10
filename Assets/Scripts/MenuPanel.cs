using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{

   public Scrollbar ScroollBar;
   public float LerpDuration = 0.4f;
   public float Thresold = 0.01f;



   [SerializeField] private Transform _content;
   [SerializeField] private Vector3 _hightLighScale;
   private float _distance;
   private float[] _pos;
   private float Scroll_updatedPos = 0;
   private float _elapsedTime = 0f;
   private float _previousValue;
   private Vector3 _actualScale;
   private float _scale = 0.5f;
   private float _scrollBarVelocity;


   private void Awake()
   {
      _pos = new float[_content.childCount];
      _distance = 1f / (_pos.Length - 1f);
      for (int i = 0; i < _pos.Length; i++)
      {
         _pos[i] = _distance * i;
      }
      _previousValue = ScroollBar.value;
      _actualScale = _content.GetChild(1).localScale;
      _hightLighScale = _actualScale + Vector3.one;
   }



   void Update()
   {
      float DeltaVlaue = Mathf.Abs(ScroollBar.value - _previousValue);
      _scrollBarVelocity = DeltaVlaue / Time.deltaTime;
      //Debug.Log("==>" + _ScroollBar.value + "::" + pos.Length + "::" + (DeltaVlaue / Time.deltaTime));
      _previousValue = ScroollBar.value;




      //Here Also When Condition meets  At the Cenrter And the Scroll Velocity Must be less thresold
      //Thresold we are taking as 0.01f And lerpDuartaion As 0.4s if velocity is high We Are upadatinf Scroll_updatedPos
#if KK_UNITY_WINDOWS || UNITY_EDITOR
      if (Input.GetMouseButton(0))
      {
         _elapsedTime = 0f;
         Scroll_updatedPos = ScroollBar.value;
      }
#elif KK_UNITY_ANDROID
      if(Input.touchCount>0)
      {
           Touch touch = Input.GetTouch(0);
           if(touch.phase==TouchPhase.Moved || touch.phase==TouchPhase.Stationary 
           || touch.phase==TouchPhase.Began)
           {
               elapsedTime = 0f;
               Scroll_updatedPos = _ScroollBar.value;
           }
      }
#endif
      else
      {
         for (int i = 0; i < _pos.Length; i++)
         {
            if (Scroll_updatedPos < _pos[i] + (_distance / 2) && Scroll_updatedPos > _pos[i] - (_distance / 2))
            {

               if (_elapsedTime < LerpDuration && _scrollBarVelocity <= Thresold)
               {
                  _elapsedTime += Time.deltaTime;
                  float t = _elapsedTime / LerpDuration;
                  t = Mathf.Clamp01(t);
                  ScroollBar.value = Mathf.Lerp(ScroollBar.value, _pos[i], t);
               }
               else
               {
                  Scroll_updatedPos = ScroollBar.value;
               }
            }
         }
      }


      //For Sclaingup And Down if Condition meets means its At the Desired position So We increase the Size
      // After Move From Center We Scaling Down to vector3.one Normal Size
      for (int i = 0; i < _pos.Length; i++)
      {
         if (Scroll_updatedPos < _pos[i] + (_distance / 2) && Scroll_updatedPos > _pos[i] - (_distance / 2))
         {
            _content.GetChild(i).localScale = Vector2.Lerp(_content.GetChild(i).localScale, _hightLighScale, 0.1f);
         }
         else
         {
            _content.GetChild(i).localScale = Vector2.Lerp(_content.GetChild(i).localScale, _actualScale, 0.1f);
         }
      }



   }


}
