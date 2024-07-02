using System;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.U2D;
[ExecuteInEditMode]
public class SpriteShapegenerator : MonoBehaviour
{
    [SerializeField] SpriteShapeController _spriteShapeController;
    [SerializeField][Range(1f, 1000f)] int levellenegth = 20;
    [SerializeField][Range(1f, 100f)] float DistanceBetweenPoints =10;
    [SerializeField][Range(1f, 100f)] float _ymultiplier = 15;


    [SerializeField] float NoiseStep = 0.5f;

    [Range(1f, 10f)]
    [SerializeField] float _lefttangetvalue = 4f, _RightTangetValue = 4f;

    private Vector3 Lastpos;

    // private void OnValidate()
    private void Start()
    {
        // Debug.Log("Onvalidate" + (_spriteShapeController.spline == null));
        //_spriteShapeController.spline.Clear();

        //Debug.Log("point At 2|" + _spriteShapeController.spline.GetPosition(2) + "|::|" + _spriteShapeController.spline.GetPosition(3));
        _spriteShapeController.spline.SetPosition(0, _spriteShapeController.spline.GetPosition(0) + new Vector3(0f, -1f, 0f) * 50f);
        _spriteShapeController.spline.SetPosition(3, _spriteShapeController.spline.GetPosition(3) + new Vector3(0f, -1f, 0f) * 50f);
        _spriteShapeController.spline.SetPosition(2, _spriteShapeController.spline.GetPosition(2) + Vector3.right * levellenegth * DistanceBetweenPoints);
        _spriteShapeController.spline.SetPosition(3, _spriteShapeController.spline.GetPosition(3) + Vector3.right * levellenegth * DistanceBetweenPoints);
        //  _spriteShapeController.spline.SetPosition(0, _spriteShapeController.spline.GetPosition(0) + new Vector3(-1,10f,0));
        for (int i = 0; i < levellenegth; i++)
        {
            float _Xpos = _spriteShapeController.spline.GetPosition(i + 1).x + DistanceBetweenPoints;
            Lastpos = new Vector3(_Xpos, Mathf.PerlinNoise(0, UnityEngine.Random.Range(1f, 30f) * i) * _ymultiplier);
            _spriteShapeController.spline.InsertPointAt(i + 2, Lastpos);
            _spriteShapeController.spline.SetHeight(i + 2, 4);

            if (i != 0 && i != levellenegth - 1 && i != 1 && i != levellenegth - 2)
            {
                Debug.LogError(" Last pos y value|" + Lastpos.y);
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, new Vector3(-_lefttangetvalue, 0f, 0f));
                _spriteShapeController.spline.SetRightTangent(i, new Vector3(_RightTangetValue, 0f, 0f));

                // _spriteShapeController.spline.
            }



        }

        Debug.LogError("Lastpos|" + Lastpos.x + "::" + transform.position.x + "::");
        // _spriteShapeController.spline.InsertPointAt(levellenegth, new Vector3(Lastpos.x, transform.position.y - Bottom));
        // _spriteShapeController.spline.InsertPointAt(levellenegth, new Vector3(transform.position.x, transform.position.y - Bottom));
    }


}
