using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenTutorial()
    {
        tutorial.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
