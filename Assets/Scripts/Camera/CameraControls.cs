using Unity.VisualScripting;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float m_Angle = 15f;

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton((int)MouseButton.Left))
        {
            Vector3 eulerAngle = transform.rotation.eulerAngles;
            // Horizontal camera
            eulerAngle.y += m_Angle * Input.GetAxis(GameParameters.InputName.AXIS_MOUSE_HORIZONTAL); 
            eulerAngle.y = eulerAngle.y > 360 ? eulerAngle.y - 360 : eulerAngle.y;
            eulerAngle.y = eulerAngle.y < 0 ? eulerAngle.y + 360 : eulerAngle.y;            
            
            // J'ai eu des probl�mes pour mettre de limite dans la camera Vertical
            // Donc, j'ai abandon� �a
            /*eulerAngle.x += m_Angle * Input.GetAxis("Mouse Y"); // Vertical camera
            eulerAngle.x = eulerAngle.x > 40 ? 40 : eulerAngle.x;
            eulerAngle.x = eulerAngle.x < -45 ? -45 : eulerAngle.x;*/

            transform.rotation = Quaternion.Euler(eulerAngle.x, eulerAngle.y, eulerAngle.z);
        }
    }
}
