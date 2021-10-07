using UnityEngine;
using UnityEngine.SceneManagement;

public class theorybutton : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("TheorySlideshow");
    }
}
