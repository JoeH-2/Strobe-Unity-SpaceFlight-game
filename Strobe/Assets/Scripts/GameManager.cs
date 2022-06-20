using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnded = false;
    public float RestartDelay = 2f;
    public GameObject CompleteLevelUI;
    public GameObject LevelName;
    public int Level = 1;

    void Start()
    {
        LoadLevel();
    }
    public void CompleteLevel ()
    {
        CompleteLevelUI.SetActive(true);
        int x = SceneManager.GetActiveScene().buildIndex;
        if (Level < x)
            Level = x;

        SaveSystem.SaveLevel(this);
    }

    public void LoadLevel()
    {
        PlayerData data = SaveSystem.LoadLevel();

        Level = data.Level;
    }

    public void EndGame()
    {
        if (GameEnded == false)
        {
            GameEnded = true;
            Debug.Log("deded");
            Invoke("RestartLevel", RestartDelay);
        }

    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
