using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform orbitPoint;
    public float distanceFromPlayer = 1f;
    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = (mousePos - orbitPoint.position).normalized;

        transform.position = orbitPoint.position + (Vector3)(direction * distanceFromPlayer);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90f || angle < -90f)
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
    }
}