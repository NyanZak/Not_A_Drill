using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public GameObject strike1, strike2, strike3;
    public static int strikes;
    public GameObject gameoverPanel;
    public static bool GameIsPaused = false;
    public bool isGameOver = false;
    public GameObject pauseScreen;

    private void Awake()
    {
        gameoverPanel.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Start()
    {
        strikes = 0;
        strike1.gameObject.SetActive(true);
        strike2.gameObject.SetActive(true);
        strike3.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
                FindObjectOfType<AudioManager>().Play("PauseSFX");
            }
            else
            {
                Pause();
                FindObjectOfType<AudioManager>().Play("PauseSFX");
            }
        }
        if (strikes < 0)
        {
            strikes = 0;
        }
        switch (strikes)
        {
            case 0:
                strike1.gameObject.SetActive(true);
                strike2.gameObject.SetActive(true);
                strike3.gameObject.SetActive(true);
                break;
            case 1:
                strike1.gameObject.SetActive(true);
                strike2.gameObject.SetActive(true);
                strike3.gameObject.SetActive(false);
                break;
            case 2:
                strike1.gameObject.SetActive(true);
                strike2.gameObject.SetActive(false);
                strike3.gameObject.SetActive(false);
                break;
            case 3:
                strike1.gameObject.SetActive(false);
                strike2.gameObject.SetActive(false);
                strike3.gameObject.SetActive(false);
                isGameOver = true;
                StartCoroutine("Wait");
                break;
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<AudioManager>().Play("GameOverSFX");
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        Resume();
    }

}