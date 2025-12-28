using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    Gun gun;
    [SerializeField] float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    // [SerializeField] Sprite gunholdingsprite; // Artýk buna gerek yok, animasyon halledecek
    Vector2 input;
    [SerializeField] GameObject pointer;
    Collider2D nearbyGun;
    bool canPickUpGun = false;
    public bool justTeleported;
    [SerializeField] Animator animator;

    // Silah durumu için yeni deðiþken
    private bool IsGun = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gun = GetComponent<Gun>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Speed parametresini güncelle
        animator.SetFloat("Speed", Mathf.Abs(input.magnitude));

        // Silah alma kontrolü
        if (canPickUpGun && Input.GetKeyDown(KeyCode.E))
        {
            PickUpGun();
        }
    }

    private void PickUpGun()
    {
        Debug.Log("Silah Alýndý!");
        IsGun = true;

        // Animator'a silahý aldýðýmýzý söylüyoruz
        animator.SetBool("IsGun", true);

        gun.enabled = true;
        canPickUpGun = false;
        pointer.GetComponent<SpriteRenderer>().enabled = true;

        if (nearbyGun != null)
            Destroy(nearbyGun.gameObject);
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
        rb.linearVelocity = input.normalized * speed;
        rb.angularVelocity = 0;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mousePos);

        pointer.transform.position = mouseWorld;

        Vector2 direction = mouseWorld - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
