using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed = 20;
    void Start()
    {
        Debug.Log("spawnlandim");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity= transform.right * speed;
    }
}
