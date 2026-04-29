using UnityEngine;

public class Move : MonoBehaviour
{
    public Joystick joystick;
    private Animator animator;

    public float moveSpeed = 0.5f;
    public float rotationSpeed = 10f;

    private Vector3 initialPos;
    private Quaternion initialRot;


    void Start()
    {
        animator = GetComponent<Animator>();
        initialPos = transform.localPosition;
        initialRot = transform.localRotation;

        if (animator == null) animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (joystick == null) return;

        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        // Arah gerak
        Vector3 moveDirection = new Vector3(h, 0f, v);

        if (moveDirection.magnitude > 0.1f)//jika jstick gerak maka posisi berubah
        {
            transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;

            // Rotasi
            Quaternion lookRot = Quaternion.LookRotation(moveDirection);
            Quaternion targetRot = lookRot * Quaternion.Euler(0, 180f, 0);

            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        //animasi
        if (animator != null)
        {
            animator.SetBool("isWalking", moveDirection.magnitude > 0.1f);
        }
    }

    //agar setelah onlosttrack lgs reset lokasi
    public void ResetPosRot()
    {
        transform.localPosition = initialPos;
        transform.localRotation = initialRot;
    }
}