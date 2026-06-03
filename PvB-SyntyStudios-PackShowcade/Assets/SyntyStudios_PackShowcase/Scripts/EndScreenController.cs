using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private BlackBoxesController blackBoxesController;
    [SerializeField] private GameObject ui;

    private void Awake()
    {
        blackBoxesController.Close(instant: true);
        ui.SetActive(false);
    }

    private void Start()
    {
        StartSequence().Forget(); 
    } 

    private async UniTask StartSequence()
    {
        await blackBoxesController.Open();
        ui.SetActive(true);
    }

    public void Home()
    {
        HomeSequence().Forget();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private async UniTask HomeSequence()
    {
        await blackBoxesController.Close();
        SceneManager.LoadScene("StartScreen");
    }
}
