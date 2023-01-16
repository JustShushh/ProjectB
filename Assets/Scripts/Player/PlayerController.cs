using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    /* This script manages the movement of the player using the
     * character controller.
     */
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float gravity = 9.8f;
    /*public LookAtInterect lookAt;*/

    public Camera playerCamera;
    Animator animator;

    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public float Stamina = 100f;
    public float maxStamina = 100f;
    public float jumpSpeed = 10f;
    public Vector3 Offset;

    bool isRunning;
    bool isLanding;
    public bool safe;
    
    private float curSpeedX;
    private float curSpeedY;

    public float health = 100f;
    public float damage = 25f;
    public float time = 2;


    internal CharacterController characterController;

    float rotationX = 0;

    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
       // playerCamera.transform.LookAt(transform.position + Offset);
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
       // InputHandling();
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        isRunning = (Input.GetKey(KeyCode.LeftShift) && Stamina > 0);

        //Stamina will deplete while running
        if (isRunning) { Stamina--; }

        //when not running the stamina will regen to MaxStamina
        if (!isRunning && Stamina < maxStamina)
        {
            StartCoroutine(RegenerateStamina());
        }

        //stops all CoRoutines in this script
        else if (Stamina == maxStamina)
        {
            StopAllCoroutines();
        }

        //speed of the player
        curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;



        // Move the controller
        if (characterController.enabled)
            characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {

            if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
            {

                Jump();
               // animator.SetInteger("Animator", 8);
            }

            //gravity for falling
           if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
               // animator.SetInteger("Animator", 9);

            }

            

            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            
            playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
    private IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(8f);

        while (Stamina < maxStamina)
        {
            Stamina += maxStamina / 100;
            yield return new WaitForSeconds(0.1f);
        }

    }
    public void Jump()
    {
        moveDirection.y = jumpSpeed;
    }
    public void TakeHit()
    {
        //animator.SetInteger("Animator", 7);
         health = health - damage;
        float t = 1;

        while (time > 0)
        {
            time -= 0.1f;
            safe = true;
        }
        safe = false;
    }
 

}
