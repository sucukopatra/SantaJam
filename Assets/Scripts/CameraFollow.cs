using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float smoothSpeed = 8f;
    [SerializeField] float mouseOffsetStrength = 2f;

    Transform player;

    void LateUpdate()
    {
        if (player == null)
        {
            if (PlayerMovement.Instance == null) return;
            player = PlayerMovement.Instance.transform;
        }

        // Mouse position in world
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // because camera is at -10
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mousePos);

        // Direction from player to mouse
        Vector2 dir = mouseWorld - player.position;
        dir = Vector2.ClampMagnitude(dir, 1f);

        Vector3 targetPos = new Vector3(
            player.position.x + dir.x * mouseOffsetStrength,
            player.position.y + dir.y * mouseOffsetStrength,
            -10f
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smoothSpeed * Time.deltaTime
        );
    }
}
