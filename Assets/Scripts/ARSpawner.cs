using UnityEngine;

public class ARSpawner : MonoBehaviour
{
    public GameObject joystickUI;
    public GameObject btnSwitch;
    private bool isTracking = false;
    bool joyIsActive = false;

    private void Start()
    {
        btnSwitch.SetActive(false);
        joystickUI.SetActive(false);
    }

    public void OnTrack()
    {
        if (!isTracking)
        {
            btnSwitch.SetActive(true);
            joystickUI.SetActive(false);
            isTracking = true;
        }
    }
    public void OnLost()
    {
        btnSwitch.SetActive(false);
        joystickUI.SetActive(false);

        joyIsActive = false;
        isTracking = false;
    }

    public void SwitchMode()
    {
        joyIsActive = !joyIsActive;
        joystickUI.SetActive(joyIsActive);
    }
}
