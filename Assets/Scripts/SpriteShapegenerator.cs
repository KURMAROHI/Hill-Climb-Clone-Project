using System;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.U2D;
[ExecuteInEditMode]
public class SpriteShapegenerator : MonoBehaviour
{
    [SerializeField] SpriteShapeController _spriteShapeController;
    [SerializeField][Range(1f, 1000f)] int levellenegth = 500;
    [SerializeField][Range(1f, 100f)] float _Xmultiplier = 4;
    [SerializeField][Range(1f, 100f)] float _ymultiplier = 2;
    [SerializeField][Range(0f, 1f)] float CurveSmoothNess = 0;

    [SerializeField] float NoiseStep = 0.5f;
    [SerializeField] float Bottom = 10f;

    private Vector3 Lastpos;

    // private void OnValidate()
    private void Start()
    {
        // Debug.Log("Onvalidate" + (_spriteShapeController.spline == null));
        //_spriteShapeController.spline.Clear();

        //Debug.Log("point At 2|" + _spriteShapeController.spline.GetPosition(2) + "|::|" + _spriteShapeController.spline.GetPosition(3));
        _spriteShapeController.spline.SetPosition(2, _spriteShapeController.spline.GetPosition(2) + Vector3.right * 100);
        _spriteShapeController.spline.SetPosition(3, _spriteShapeController.spline.GetPosition(3) + Vector3.right * 100);

        for (int i = 0; i < levellenegth; i++)
        {
            float _Xpos = _spriteShapeController.spline.GetPosition(i + 1).x + _Xmultiplier;
            Lastpos = new Vector3(_Xpos, Mathf.PerlinNoise(0, UnityEngine.Random.Range(1f, 10f) * i) * _ymultiplier);
            _spriteShapeController.spline.InsertPointAt(i + 2, Lastpos);

            if (i != 0 && i != levellenegth - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right);
            }

        }

        Debug.LogError("Lastpos|" + Lastpos.x + "::" + transform.position.x + "::");
        // _spriteShapeController.spline.InsertPointAt(levellenegth, new Vector3(Lastpos.x, transform.position.y - Bottom));
        // _spriteShapeController.spline.InsertPointAt(levellenegth, new Vector3(transform.position.x, transform.position.y - Bottom));
    }


}
