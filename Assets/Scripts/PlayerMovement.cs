using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    [SerializeField] private string inputNameInteract;


    private Rigidbody rb;
    private Animator animator;

    public GameObject footstepNoise;

    private float inputHorizontal;
    private float inputVertical;
    private float inputInteract;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        footstepNoise.SetActive(false);
    }

    private void Update()
    {
        if (!IsOwner) return;
        inputHorizontal = -1 * Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = -1 * Input.GetAxisRaw(inputNameVertical);

        Vector3 movementDirection = new Vector3(inputHorizontal, 0, inputVertical);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        Vector3 velocity = movementDirection * magnitude;

        rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);

        if (movementDirection != Vector3.zero){
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            footstepNoise.SetActive(true);
        }
        else {
            animator.SetBool("IsMoving", false);
            footstepNoise.SetActive(false);
        }


    }

   
}
