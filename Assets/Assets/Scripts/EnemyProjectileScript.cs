using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = (Vector2)direction.normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if(timer > 4)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().hitPoints -= 1;
            Destroy(gameObject);
        }
    }

}
