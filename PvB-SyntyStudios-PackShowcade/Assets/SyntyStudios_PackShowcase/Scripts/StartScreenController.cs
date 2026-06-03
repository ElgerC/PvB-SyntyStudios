
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private BlackBoxesController blackBoxesController;
    [SerializeField] private GameObject UI;

    void Awake()
    {
        blackBoxesController.Close(instant: true);
        UI.SetActive(false);
    }

    private void Start()
    {
        OpeningSequence().Forget();
    }

    private async UniTask OpeningSequence()
    {
        await UniTask.Delay(1000);
        await blackBoxesController.Open(instant: false);
        UI.SetActive(true);
    }

    private async UniTask OpenTutorialSequence()
    {
        await blackBoxesController.Close(instant: false);
        tutorial.SetActive(true);
    }

    private async UniTask OpenGameSequence()
    {
        await blackBoxesController.Close(instant: false);
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        OpenGameSequence().Forget();
    }

    public void OpenTutorial()
    {
        OpenTutorialSequence().Forget();
    }

    public void CloseTutorial()
    {
        CloseTutorialSequence().Forget();
    }

    private async UniTask CloseTutorialSequence()
    {
        tutorial.SetActive(false);
        await blackBoxesController.Open();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
