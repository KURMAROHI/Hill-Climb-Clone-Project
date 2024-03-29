
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class BackGroundControl : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    



    void Update()
    {
#if UNITY_KK_GOOGLE
            CheckStatusOfFinger();
#elif UNITY_KK_WINDOWS
        CheckStatusOfPointer();
#endif
    }



    void CheckStatusOfFinger()
    {
        Touch touch = Input.GetTouch(0);
        if (TouchPhase.Began == touch.phase)
        {
            RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector2.right, 50f);
            Debug.DrawRay(touch.position, Vector2.right, Color.green, 10f);
            if (hit.collider.gameObject.name == "Speed")
            {

            }
            else if (hit.collider.gameObject.name == "Break")
            {

            }
        }

        if (TouchPhase.Stationary == touch.phase)
        {

        }

        if (TouchPhase.Ended == touch.phase)
        {

        }
    }




    void CheckStatusOfPointer()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.LogError("Enter For GetMouseButton");
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 50f);
            Debug.DrawRay(Input.mousePosition, Vector2.right, Color.green, 10f);
            if (hit.collider.gameObject.name == "Speed")
            {
                Debug.Log("====Speed");
            }
            else if (hit.collider.gameObject.name == "Break")
            {
                Debug.Log("====Break");
            }
        }
        if (Input.GetMouseButtonDown(0))
        {

        }
        if (Input.GetMouseButtonUp(0))
        {

        }
    }





    #region Events region

    //bool speed = false;
    //public void OnPointerDown(PointerEventData data)
    // {
    //     // if(data.pointerClick.name)
    //     // Debug.LogError("on pointer Down" + data.pointerPressRaycast.module.gameObject.name + "::");
    //     if (data.pointerPressRaycast.module.gameObject.name == "Speed")
    //     {
    //         speed = true;
    //     }
    //     else if (data.pointerPressRaycast.module.gameObject.name == "Break")
    //     {

    //     }
    // }

    // public void OnPointerUp(PointerEventData data)
    // {
    //     Debug.LogError("on pointer UP");
    // }

    // public void OnPointerEnter(PointerEventData data)
    // {
    //     Debug.LogError("on pointer Enter");
    // }


    #endregion
}
