using UnityEngine;
using UnityEngine.SceneManagement;

public class codebutton : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("CodeSlideshow");
    }
}
