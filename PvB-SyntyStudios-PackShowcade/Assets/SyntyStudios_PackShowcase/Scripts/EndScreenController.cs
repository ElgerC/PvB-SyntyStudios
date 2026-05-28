using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
