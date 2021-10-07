using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Scene2");
    }
}
