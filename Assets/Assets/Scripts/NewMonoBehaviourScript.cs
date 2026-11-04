using System.Collections;
using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public bool isGF;
    [Header("Text Bubbles")]
    public string[] textBubblesBF;
    public string[] textBubblesGF;
    public GameObject textBF;
    public GameObject textGF;


    [Header("Time Between Bubbles")]
    public float textDelay;
    public float textDelayMin;
    public float textDelayMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BubbleDelay());


    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator BubbleDelay()
    {
        while (true)
        {
            Debug.Log("Start Agian");
            yield return new WaitForSeconds(Random.Range(textDelayMin, textDelayMax));
            if (isGF == true)
            {
                textGF.SetActive(true);
                textGF.GetComponent<TMP_Text>().text = textBubblesGF[Random.Range(0, textBubblesGF.Length)];

            }
            else
            {
                textBF.SetActive(true);
                textBF.GetComponent<TMP_Text>().text = textBubblesBF[Random.Range(0, textBubblesBF.Length)];
            }
            yield return new WaitForSeconds(textDelay);
            textBF.SetActive(false);
            textGF.SetActive(false);
        }
        

    }

}
