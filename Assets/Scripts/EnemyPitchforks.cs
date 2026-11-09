using System.Collections;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class EnemyPitchforks : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;
    private AudioSource audioSourceEnemy;
    public AudioClip pitchForkThrow;
    public float farmerHP = 3;

    public Material Default;
    public Material Flash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material = Default;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSourceEnemy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(farmerHP <= 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 10)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                timer = 0;
                shoot();
            }
        }


    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        audioSourceEnemy.PlayOneShot(pitchForkThrow);
    }
    public void hitFlash()
    {
        StartCoroutine(hitFlashCoroutine());
    }
    public IEnumerator hitFlashCoroutine()
    {
        gameObject.GetComponent<SpriteRenderer>().material = Flash;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().material = Default;
    }

}
