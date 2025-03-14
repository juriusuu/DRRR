using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    public void LoadGameSelection()
    {
        SceneManager.LoadScene("GameSelection"); // Load the first stage scene
        Debug.Log("Game Selection Loaded");
    }
}