using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }
    private void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
