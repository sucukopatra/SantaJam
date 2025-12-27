using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] float offsetDistance = 0.5f; // how far in front of player the bullet spawns
    private float nextFireTime;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // direction the player is facing
        Vector3 direction = transform.right; // in 2D top-down, right is forward
        // spawn position offset in that direction
        Vector3 spawnPos = transform.position + direction * offsetDistance;

        Instantiate(bullet, spawnPos, transform.rotation);
    }
}
