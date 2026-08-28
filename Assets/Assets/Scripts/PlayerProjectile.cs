using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private float timer;
    // Awake is called once when the script instance is being loaded
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void SetDirection(Vector2 direction)
    {
        rb.linearVelocity = direction * force;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            Destroy(gameObject);
        }
    }

}
