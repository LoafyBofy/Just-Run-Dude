using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SetTimeScaleOne();
    }

    public void LoadPlayingScene()
    {
        SceneManager.LoadScene("PlayingScene");
        SetTimeScaleOne();
        SetCurrentScoreZero();
        SetCurrentCoinsZero();
        FinalBoard.IsGameOnPause = false;
    }

    public void ContinueGame()
    {
        var ganeObj = GameObject.Find("PauseBoard");
        ganeObj.gameObject.SetActive(false);
        SetTimeScaleOne();
    }

    private void SetTimeScaleOne() => Time.timeScale = 1;

    private void SetCurrentScoreZero() => Score.CurrentScore = 0;

    private void SetCurrentCoinsZero() => Pumpkin.PumpkinCount = 0;
}
