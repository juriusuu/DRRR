using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void GoToGameSelection()
    {
        SceneManager.LoadScene("GameSelection"); // Load the game selection scene
    }
}