using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    public Transform orbitPoint;
    public float distanceFromPlayer = 1f;
    private Camera mainCamera;

    public GameObject bullet;
    public Transform shootPos;


    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 aimDirection = (mousePos - orbitPoint.position).normalized;
        Vector2 shootDirection = (mousePos - shootPos.position).normalized;


        transform.position = orbitPoint.position + (Vector3)(aimDirection * distanceFromPlayer);

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90f || angle < -90f)
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipY = false;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

            newBullet.GetComponent<PlayerProjectile>().SetDirection(shootDirection);
        }

    }
    
}