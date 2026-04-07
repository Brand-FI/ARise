using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageTargetManager : MonoBehaviour
{
    public AppState appState;
    public int animalID;
    bool triggered = false;

    public void OnTargetFound()
    {
        if (triggered == false)
        {
            triggered = true;
            appState.selectedAnimalID = animalID;
            LoadScene();
        }

    }
    void LoadScene()
    {
        SceneManager.LoadScene("Markerless");
    }
}
