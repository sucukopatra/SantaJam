using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Gun gun;
    [SerializeField] float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    [SerializeField] Sprite gunholdingsprite;
    Vector2 input;
    [SerializeField] GameObject pointer;
    Collider2D nearbyGun;
    bool canPickUpGun = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gun = GetComponent<Gun>();
    }

    private void Update()
    {
        // Movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Gun pickup input
        if (canPickUpGun && Input.GetKeyDown(KeyCode.E))
        {
            sr.sprite = gunholdingsprite;
            gun.enabled = true;
            canPickUpGun = false;
            pointer.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(nearbyGun.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("gun"))
        {
            nearbyGun = other;
            canPickUpGun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("gun"))
        {
            nearbyGun = null;
            canPickUpGun = false;
        }
    }
    private void FixedUpdate() 
    {    
        // Movement
        rb.linearVelocity = input.normalized * speed;
        rb.angularVelocity = 0;

        // Mouse position in world
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z; // set distance from camera to player
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mousePos);

        // Pointer follows mouse
        pointer.transform.position = mouseWorld;

        // Rotate player towards mouse i didnt understand a shit
        Vector2 direction = mouseWorld - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
