using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public static GameHelper Instance;
    public GameObject btnPlaySound;
 

    public static bool joyMode = false;

    public GameObject joystickUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        hideBtnPlay();
    }
    public void SwitchMode()
    {
        joyMode = !joyMode;

        if (joystickUI != null)
            joystickUI.SetActive(joyMode);
    }

    public void showBtnPlay()
    {
        btnPlaySound.SetActive(true);  
    }

    public void hideBtnPlay()
    {
        btnPlaySound.SetActive(false); 
    }

    public void PlaySoundButton()
    {
        if (ARSpawner.currentTracked != null)
        {
            ARSpawner.currentTracked.PlaySound();
        }
    }
}