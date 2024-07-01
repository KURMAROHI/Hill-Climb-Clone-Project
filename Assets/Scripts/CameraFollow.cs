
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // The player's transform
    public Vector3 offset;       // The initial offset from the player

    public Vector3 TargetPosition;
    public Vector3 velocity = Vector3.zero;
    float Xpsoition;

    public float smoothing = 0.05f; // The smoothing factor for the camera's movement
    public float Thresold = 0.5f;
    public float CarVelocity = 30f;
    // private Vector3 velocity = Vector3.zero;
    void Start()
    {
        offset = player.position - transform.position;
        transform.position = player.position - offset;
    }


    [SerializeField] float ExperimentVlaueFor = 0;
    void Update()
    {
        CarVelocity = DriveCar.Instance.Car.velocity.magnitude;

        if (DriveCar.Instance.IsStartMoving)
        {
            // if (CarVelocity > 10)
            // {
            //     offset.x = ExperimentVlaueFor;
            // }
            // else
            // {
            //     offset.x = 45f;
            // }

            offset.x = ExperimentVlaueFor;
        }
        Xpsoition = Mathf.Clamp(transform.position.x, player.position.x - offset.x, player.position.x - offset.x + 2f);
        TargetPosition = new Vector3(Xpsoition, 12f, player.position.z - offset.z);
        // Debug.Log("<color=green>Diff|</color>" + (player.position.x - transform.position.x));

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, TargetPosition.x, smoothing * Time.deltaTime), TargetPosition.y, TargetPosition.z);

    }
}
