using UnityEngine;

public class SceneManager : MonoBehaviour
{




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
