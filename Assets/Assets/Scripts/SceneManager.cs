using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public float cowCount;
    public float cowQuota;   

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }


    // Update is called once per frame
    void Update()
    {


    }

    public void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
    }
    public void quit()
    {
        Application.Quit();
    }
}
