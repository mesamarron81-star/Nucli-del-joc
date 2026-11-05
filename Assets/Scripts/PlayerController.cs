using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody playerRigidbody;
    private Vector2 movementInput;

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
            movementInput = Vector2.zero;
            return;
        }

        float horizontal = (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed ? 1f : 0f)
                         - (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed ? 1f : 0f);
        float vertical = (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed ? 1f : 0f)
                       - (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed ? 1f : 0f);
        movementInput = Vector2.ClampMagnitude(new Vector2(horizontal, vertical), 1f);
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = playerRigidbody.linearVelocity;
        velocity.x = movementInput.x * speed;
        velocity.z = movementInput.y * speed;
        playerRigidbody.linearVelocity = velocity;
    }
}
