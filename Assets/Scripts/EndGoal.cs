using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")||gameManager.quotaMet == true)
        {
            Destroy(other.gameObject);
            gameManager.GoalReached();
        }
    }
}
