using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject FollowTarget;
    [SerializeField] private float RotationSpeed = 1f;
    [SerializeField] private float HorizontalDamping = 1f;
    [SerializeField] private float VerticalDamping = 1f;

    public PlayerController controller;

    private Transform FollowTargetTransform;

    private Vector2 PreviousMouseInput;

    // Start is called before the first frame update
    private void Start()
    {
        FollowTargetTransform = FollowTarget.transform;
        PreviousMouseInput = Vector2.zero;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnLook(InputValue delta)
    {
        if (controller.gamePaused == true) return;

        float CameraRotationX;
        Vector2 aimValue = delta.Get<Vector2>();

        FollowTargetTransform.rotation *= Quaternion.AngleAxis(Mathf.Lerp(PreviousMouseInput.x, aimValue.x, 1f / HorizontalDamping) * RotationSpeed,transform.up);

        FollowTargetTransform.rotation *= 
            Quaternion.AngleAxis(Mathf.Lerp(PreviousMouseInput.y, (aimValue.y), 1f / VerticalDamping) * RotationSpeed, transform.right);

        CameraRotationX = FollowTargetTransform.rotation.eulerAngles.x;
        //CameraRotationX = Mathf.Clamp(FollowTargetTransform.transform.rotation.eulerAngles.x, 0f, 15f);

        //Debug.Log(CameraRotationX);
        transform.rotation = Quaternion.Euler(0, FollowTargetTransform.transform.rotation.eulerAngles.y, 0);

        FollowTargetTransform.localEulerAngles = new Vector3(CameraRotationX, 0,0);

        PreviousMouseInput = aimValue;
    }
}
