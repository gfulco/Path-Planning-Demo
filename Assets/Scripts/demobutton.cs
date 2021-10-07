using UnityEngine;
using UnityEngine.SceneManagement;

public class demobutton : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
