using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5.0f;
    [SerializeField] private Transform m_CameraTransform;
    [SerializeField] private float m_Angle = 15.0f;

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void Execute()
    {
        Move();
        if (Input.GetMouseButton((int)MouseButton.Left)) RotateCamera();
    }

    private void Move()
    {
        // obtient les valeurs des touches horizontales et verticales
        float hDeplacement = Input.GetAxis(GameParameters.InputName.AXIS_HORIZONTAL);
        float vDeplacement = Input.GetAxis(GameParameters.InputName.AXIS_VERTICAL);

        //obtient la nouvelle direction ( (avant/arrièrre) + (gauche/droite) )
        Vector3 directionDep = GetCameraTransform().forward * vDeplacement + GetCameraTransform().right * hDeplacement;
        directionDep.y = 0; //pas de valeur en y , le cas où la caméra regarde vers le bas ou vers le haut
        Vector3 velocity = Vector3.zero;
        if (directionDep != Vector3.zero) //change de direction s’il y a un changement
        {
            //Oriente le personnage vers la direction de déplacement et applique la vélocité dans la même direction
            transform.forward = directionDep;
            
            velocity = directionDep * m_Speed;
        }
        m_Animator.SetFloat(GameParameters.AnimationPlayer.FLOAT_VELOCITY, velocity.magnitude);
        velocity.y = m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = velocity;
    }

    private void RotateCamera()
    {
        Vector3 eulerAngle = GetCameraTransform().rotation.eulerAngles;
        // Horizontal camera
        eulerAngle.y += m_Angle * Input.GetAxis(GameParameters.InputName.AXIS_MOUSE_HORIZONTAL);
        eulerAngle.y = eulerAngle.y > 360 ? eulerAngle.y - 360 : eulerAngle.y;
        eulerAngle.y = eulerAngle.y < 0 ? eulerAngle.y + 360 : eulerAngle.y;

        // J'ai eu des problèmes pour mettre de limite dans la camera Vertical
        // Donc, j'ai abandoné ça
        /*eulerAngle.x += m_Angle * Input.GetAxis("Mouse Y"); // Vertical camera
        eulerAngle.x = eulerAngle.x > 40 ? 40 : eulerAngle.x;
        eulerAngle.x = eulerAngle.x < -45 ? -45 : eulerAngle.x;*/

        GetCameraTransform().rotation = Quaternion.Euler(eulerAngle.x, eulerAngle.y, eulerAngle.z);
    }

    private Transform GetCameraTransform()
    {
        return CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.VirtualCameraGameObject.transform;
    }
}
