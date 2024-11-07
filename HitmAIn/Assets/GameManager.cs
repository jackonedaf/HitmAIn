using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject loseScreen; 
    public GameObject winScreen; 
    public Button replayButtonLose;  // Przycisk Replay dla ekranu przegranej
    public Button replayButtonWin;   // Przycisk Replay dla ekranu wygranej 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
          // Dodaj listener do obu przycisków
        replayButtonLose.onClick.AddListener(RestartGame);
        replayButtonWin.onClick.AddListener(RestartGame);
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true); // Wyświetlamy ekran wygranej
        Time.timeScale=0f; // Przycisk "Replay"
    }
    // Pokazuje ekran wygranej
    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f; // Zatrzymanie czasu gry
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Wznowienie czasu gry
        SceneManager.LoadScene("SampleScene"); // Restart poziomu
    }
}
