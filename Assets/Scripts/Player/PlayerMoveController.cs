using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float m_SpeedPlayer = 5.0f;
    [SerializeField] private float m_SpeedAngleCamera = 15.0f;
    [SerializeField] private Vector2 m_BoundMax;
    [SerializeField] private Vector2 m_BoundMin;

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
        RotateCamera();
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector3 position = transform.position;
        position.x = m_BoundMin.x > position.x ? m_BoundMin.x : position.x;
        position.x = m_BoundMax.x < position.x ? m_BoundMax.x : position.x;
        position.z = m_BoundMin.y > position.z ? m_BoundMin.y : position.z;
        position.z = m_BoundMax.y < position.z ? m_BoundMax.y : position.z;
        transform.position = position;
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
            
            velocity = directionDep * m_SpeedPlayer;
        }
        m_Animator.SetFloat(GameParameters.AnimationPlayer.FLOAT_VELOCITY, velocity.magnitude);
        velocity.y = m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = velocity;
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton((int)MouseButton.Left))
        {
            Vector3 eulerAngle = GetCameraTransform().rotation.eulerAngles;
            // Horizontal camera
            eulerAngle.y += m_SpeedAngleCamera * Input.GetAxis(GameParameters.InputName.AXIS_MOUSE_HORIZONTAL);
            eulerAngle.y = eulerAngle.y > 360 ? eulerAngle.y - 360 : eulerAngle.y;
            eulerAngle.y = eulerAngle.y < 0 ? eulerAngle.y + 360 : eulerAngle.y;

            GetCameraTransform().rotation = Quaternion.Euler(eulerAngle.x, eulerAngle.y, eulerAngle.z);

        }

    }

    private Transform GetCameraTransform()
    {
        return CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.VirtualCameraGameObject.transform;
    }
}
