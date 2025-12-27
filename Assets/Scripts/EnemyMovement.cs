using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	Transform player;
    Rigidbody2D rb;
    bool chaseplayer=true;
    SpriteRenderer sr;
    [SerializeField] Sprite deadsprite;
    Animator animator;
    Collider2D col;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerMovement.Instance.transform;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

	void FixedUpdate(){
        if(chaseplayer){
            ChasePlayer();
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("bullet")){
            Destroy(other.gameObject);
            chaseplayer = false;
            sr.sprite = deadsprite;
            animator.enabled=false;
            col.enabled= false;
            rb.freezeRotation = true;


        }
    }
    void ChasePlayer(){
        float z = Mathf.Atan2 ((player.transform.position.y - this.transform.position.y), (player.transform.position.x - this.transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3 (0, 0, z);
        rb.AddForce (gameObject.transform.up * speed);

    }
}
