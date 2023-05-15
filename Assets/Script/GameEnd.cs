using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    private Button quitButton;

    private void Start()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

