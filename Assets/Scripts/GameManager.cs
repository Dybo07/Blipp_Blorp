using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Quota settings")]
    [SerializeField] private float cowCount;
    [SerializeField] private float cowQuota;
    public bool quotaMet;
    [SerializeField] private TMPro.TextMeshProUGUI cowCounter;

    [Header("Goal settings")]
    [SerializeField] private GameObject endGoal;
    [SerializeField] private Sprite playerInShip;
    [SerializeField] private float launchForce;
    [SerializeField] private Rigidbody2D endGoalRb;
    private bool goalReached = false;


    [SerializeField] private float smoothSpeed = 5f;
    [Header("Player settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCamera;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = Camera.main;
        cowCount = 0;
        cowCounter.text = cowCount.ToString() + "/" + cowQuota.ToString();
         endGoalRb = endGoal.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        endGoalRb.linearVelocity = Vector2.up * launchForce;
        if(goalReached == true)
        {
            playerCamera.transform.position = Vector3.Lerp(
            playerCamera.transform.position,
            endGoal.transform.position + new Vector3(0, 1, -10),
            smoothSpeed * Time.deltaTime);
        }
    }
    public void IncrementCowCount()
    {
        cowCount++;
        cowCounter.text = cowCount.ToString() + "/" + cowQuota.ToString();
        if (cowCount >= cowQuota)
        {
            quotaMet = true;
        }
    }
    public void GoalReached()
    {
        endGoal.GetComponentInChildren<SpriteRenderer>().sprite = playerInShip;
        goalReached = true;
        StartCoroutine(DestroyAfterTime());
    }
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(4f);
        goalReached = false;
        endGoalRb.constraints = RigidbodyConstraints2D.None;
        

        yield return new WaitForSeconds(8f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
