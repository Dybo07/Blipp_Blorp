using UnityEngine;

public class EnemyPitchforks : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;
    private AudioSource audioSourceEnemy;
    public AudioClip pitchForkThrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSourceEnemy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

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

}
