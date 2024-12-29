using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour {

    [SerializeField] private GameObject creditsPopup;
    
    
    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void OpenCredits() {
        creditsPopup.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
