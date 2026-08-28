using UnityEngine;

public class SceneManager : MonoBehaviour
{




    // Update is called once per frame
    void Update()
    {

        
    }

    void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMap");
    }
    void quit()
    {
        Application.Quit();
    }
}
