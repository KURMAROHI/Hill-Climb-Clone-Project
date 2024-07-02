

using UnityEngine;
// using UnityEngine.UI;

public class FollowVechile : MonoBehaviour
{

    // [SerializeField] RenderTexture renderTexture;
    // public static Image UIScreenShotImage;
    // void OnEnable()
    // {
    //     CollisionChek.HeadCollision += OnGameEnd;
    // }

    // void OnDisable()
    // {

    //     CollisionChek.HeadCollision -= OnGameEnd;
    // }

    // private void OnGameEnd()
    // {
    //     Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ASTC_4x4, false);
    //     texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
    //     texture.Apply();
    //     UIScreenShotImage.sprite=Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);

    // }

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
