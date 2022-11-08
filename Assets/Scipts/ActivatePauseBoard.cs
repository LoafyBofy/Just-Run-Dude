using UnityEngine;

public class ActivatePauseBoard : MonoBehaviour
{
    [SerializeField] private GameObject _pauseBoard;

    public void EnablePauseBoard()
    {
        if (FinalBoard.IsGameOnPause == false)
        {
            _pauseBoard.SetActive(true);
            SetTimeScaleZero();
        }
    }

    private void SetTimeScaleZero()
    {
        Time.timeScale = 0;
    }
}
