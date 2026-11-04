using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Quota settings")]
    [SerializeField] private float cowCount;
    [SerializeField] private float cowQuota;
    private bool quotaMet;
    [SerializeField] private TMPro.TextMeshProUGUI cowCounter;

    [Header("Goal settings")]
    [SerializeField] private GameObject endGoal;
    [SerializeField] private Sprite playerInShip;

    [Header("Player settings")]
    [SerializeField] private GameObject player;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cowCount = 0;
        cowCounter.text = cowCount.ToString() + "/" + cowQuota.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        
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
        endGoal.GetComponent<SpriteRenderer>().sprite = playerInShip;



    }
}
