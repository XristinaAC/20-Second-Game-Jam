using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    private float _xRotation = 0f;
    private float _xMouseSensitivity = 30f;
    private float _yMouseSensititity = 30f;

    public void LookAround(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //CameraRotation - Up and Down
        _xRotation -= (mouseY * Time.deltaTime) * _yMouseSensititity;
        _xRotation = Mathf.Clamp(_xRotation, -40f, 40f);
        mainCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        //Rotate left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xMouseSensitivity);
    }

    public Camera GetCamera()
    {
        return mainCamera;
    }
}
