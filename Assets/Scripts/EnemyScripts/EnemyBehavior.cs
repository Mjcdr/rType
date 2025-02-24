using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float shootingInterval = 2f; 
    public GameObject projectilePrefab; 
    public Transform player; 

    private float nextShootTime;

    void Start()
    {
        
        player = GameObject.FindWithTag("Player").transform;
        nextShootTime = Time.time + shootingInterval; 
    }

    void Update()
    {
        MoveTowardsPlayer();
        HandleShooting();
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
         
            Vector2 direction = (player.position - transform.position).normalized;
           
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void HandleShooting()
    {
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootingInterval; 
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null)
        {
            // Instantiate the projectile and set its position and rotation
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // If you need to set the projectile speed or direction, do it here
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.linearVelocity = direction * 5f; // Set the projectile speed
            }
        }
    }
}