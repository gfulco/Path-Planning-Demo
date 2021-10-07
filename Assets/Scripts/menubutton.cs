using UnityEngine;
using UnityEngine.SceneManagement;

public class menubutton : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
