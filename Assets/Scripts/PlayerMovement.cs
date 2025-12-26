using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 input;
    private void Start()
    {
        Debug.Log("doesntwork");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate() 
    {    
        rb.linearVelocity = input.normalized * speed;
    }
}
