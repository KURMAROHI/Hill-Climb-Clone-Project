using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{

   public Scrollbar _ScroollBar;
   [SerializeField] Transform Content;
   float[] pos;
   float Distance;
   float Scroll_updatedPos = 0;
   public void OnValueChanged(Vector2 a)
   {
      // Debug.Log("onvalue Changed|" + a.x + ", " + a.y);
   }

   void Awake()
   {

      pos = new float[Content.childCount];
      Distance = 1f / (pos.Length - 1f);
      for (int i = 0; i < pos.Length; i++)
      {
         pos[i] = Distance * i;
      }

      previousVlaue = _ScroollBar.value;
   }


   public float lerpDuration = 0.4f;
   public float thresold = 0.01f;

   private float elapsedTime = 0f;
   float previousVlaue;
   float ScrollBarVelocity;
   void Update()
   {
      float DeltaVlaue = Mathf.Abs(_ScroollBar.value - previousVlaue);
      ScrollBarVelocity = DeltaVlaue / Time.deltaTime;
      //Debug.Log("==>" + _ScroollBar.value + "::" + pos.Length + "::" + (DeltaVlaue / Time.deltaTime));
      previousVlaue = _ScroollBar.value;




      //Here Also When Condition meets  At the Cenrter And the Scroll Velocity Must be less thresold
      //Thresold we are taking as 0.01f And lerpDuartaion As 0.4s if velocity is high We Are upadatinf Scroll_updatedPos
#if KK_UNITY_WINDOWS || UNITY_EDITOR
      if (Input.GetMouseButton(0))
      {
         elapsedTime = 0f;
         Scroll_updatedPos = _ScroollBar.value;
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
         for (int i = 0; i < pos.Length; i++)
         {
            if (Scroll_updatedPos < pos[i] + (Distance / 2) && Scroll_updatedPos > pos[i] - (Distance / 2))
            {

               if (elapsedTime < lerpDuration && ScrollBarVelocity <= thresold)
               {
                  elapsedTime += Time.deltaTime;
                  float t = elapsedTime / lerpDuration;
                  t = Mathf.Clamp01(t);
                  _ScroollBar.value = Mathf.Lerp(_ScroollBar.value, pos[i], t);
               }
               else
               {
                  Scroll_updatedPos = _ScroollBar.value;
               }
            }
         }
      }


      //For Sclaingup And Down if Condition meets means its At the Desired position So We increase the Size
      // After Move From Center We Scaling Down to vector3.one Normal Size
      for (int i = 0; i < pos.Length; i++)
      {
         if (Scroll_updatedPos < pos[i] + (Distance / 2) && Scroll_updatedPos > pos[i] - (Distance / 2))
         {
            Content.GetChild(i).localScale = Vector2.Lerp(Content.GetChild(i).localScale, new Vector2(1.5f, 1.5f), 0.1f);
         }
         else
         {
            Content.GetChild(i).localScale = Vector2.Lerp(Content.GetChild(i).localScale, Vector2.one, 0.1f);
         }
      }



   }


}
