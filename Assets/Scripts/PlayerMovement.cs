using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    [SerializeField] Sprite gunholding;
    Vector2 input;
    [SerializeField] GameObject pointer;
    private void Start()
    {
        Debug.Log("sj");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("gun")&& Input.GetKeyDown(KeyCode.E)){
            sr.sprite = gunholding;
            Destroy(other.gameObject);
        }
    }
        
}
