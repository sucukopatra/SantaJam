using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 input;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() 
    {    
        rb.linearVelocity = input*speed;
    }
    private void OnMove(InputValue inputValue){
        input = inputValue.Get<Vector2>();
    }
}
