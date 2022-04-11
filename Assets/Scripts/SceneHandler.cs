using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;

    void Awake()
    {
        Instance = this;
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void DeltaScene(int Delta)
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + Delta);
    }
    public void RestartScene()
    {
        DeltaScene(0);
    }
}
