using UnityEngine;
using UnityEngine.InputSystem; // Tambahkan namespace baru

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float rotationSpeedAndroid = 50f;

    private Vector2 touchDelta;
    private bool isTouching;

    void Update()
    {
        // Untuk PC (Mouse)
        if (Mouse.current.leftButton.isPressed)
        {
            float mouseX = Mouse.current.delta.x.ReadValue();
            transform.Rotate(Vector3.up * -mouseX * rotationSpeed * Time.deltaTime);
        }

        // Untuk Mobile (Touch)
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 delta = Touchscreen.current.primaryTouch.delta.ReadValue();
            transform.Rotate(Vector3.up * -delta.x * rotationSpeedAndroid * Time.deltaTime);
        }
    }
}
