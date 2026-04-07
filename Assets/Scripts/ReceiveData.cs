using UnityEngine;

public class ReceiveData : MonoBehaviour
{
    public AppState appState;
    void Start()
    {
        Debug.Log("Animal ID: " + appState.selectedAnimalID);
    }
}
