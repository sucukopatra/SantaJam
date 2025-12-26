using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 input;
    [SerializeField] GameObject pointer;
    private void Start()
    {
        Debug.Log("sj");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate() 
    {    
		// capture mouse position. We need to convert between pixels and World Unities
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		// Basicly it's looking to the mouse position. And rotating.
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition,
		                                         Vector3.forward);
        pointer.transform.position = mousePosition;

		// LOOKING AT MOUSE
		// set our gameobject rotation to the calculated one rotation
		transform.rotation = rot;
		// doesnt changerotation angles for x, y.
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		// prevents from "slide"
		rb.angularVelocity = 0;

        rb.linearVelocity = input.normalized * speed;
        
    }
}
