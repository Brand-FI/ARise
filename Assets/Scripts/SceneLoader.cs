using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void GoToImageTarget()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToPlaneDetection()
    {
        SceneManager.LoadScene("Markerless");
    }
}
