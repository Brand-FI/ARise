using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARSpawner : MonoBehaviour
{
    private static ARSpawner activeSpawner;
    public static ARSpawner currentTracked;

    public GameObject joystickUI;
    public GameObject btnSwitch;
    private bool isTracking = false;

    public AudioSource audioSource;


    public GameObject descCanvas;

    private void Start()
    {
        btnSwitch.SetActive(false);
        joystickUI.SetActive(false);
    }
    private void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void OnTrack()
    {
        if (activeSpawner != null && activeSpawner != this)
            return;

        if (isTracking) return;

        isTracking = true;
        activeSpawner = this;
        currentTracked = this;

        btnSwitch.SetActive(true);
        joystickUI.SetActive(false);

        GameHelper.Instance.showBtnPlay();

        PlaySound();
    }
    public void OnLost()
    {
        if (activeSpawner == this)
            activeSpawner = null;

        if (currentTracked == this)
            currentTracked = null;

        isTracking = false;
        
        btnSwitch.SetActive(false);
        joystickUI.SetActive(false);

        if (GameHelper.joyMode)
        {
            GameHelper.joyMode = false;
        }

        GameHelper.Instance.hideBtnPlay();

        if (audioSource != null)
            audioSource.Stop();
    }

    void Update()
    {
        bool joy = GameHelper.joyMode;
        joystickUI.SetActive(joy);
        descCanvas.SetActive(!joy);
    }

    public void PlaySound()
    {
        Debug.Log("PLAY SOUND: " + gameObject.name);
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.Play();
        }
    }
}
