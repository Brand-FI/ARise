using UnityEngine;

public class ARManager : MonoBehaviour
{
    public GameObject joystickUI;

    private GameObject currentObject;
    private Move moveScript;
    private bool isControlMode = false;

    void Start()
    {
        joystickUI.SetActive(false);
    }

    public void SetCurrentObject(GameObject obj)
    {
        currentObject = obj;
        moveScript = obj.GetComponent<Move>();
        if (moveScript != null)
        {
            moveScript.enabled = false;
        }
    }

    public void ToggleMode()
    {
        if (currentObject == null) return;

        isControlMode = !isControlMode;

        joystickUI.SetActive(isControlMode);

        if (moveScript != null)
        {
            moveScript.enabled = isControlMode;
        }
    }

    public void ResetMode()
    {
        joystickUI.SetActive(false);
        isControlMode = false;

        if (moveScript != null)
        {
            moveScript.enabled = false;
        }

        currentObject = null;
    }
}