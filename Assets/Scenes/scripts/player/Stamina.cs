using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement playerMovement;
    public Slider staminaBar;

    [Header("Stamina")]
    public float maxStamina = 5f;
    public float currentStamina;

    public float drainSpeed = 1.5f;
    public float regenSpeed = 0.7f;

    [Header("Speeds")]
    public float walkSpeed = 3f;
    public float sprintSpeed = 8f;

    private bool exhausted = false;

    void Start()
    {
        currentStamina = maxStamina;

        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;

        playerMovement.walkSpeed = walkSpeed;
    }

    void Update()
    {
        bool isMoving =
            Input.GetAxisRaw("Vertical") != 0 ||
            Input.GetAxisRaw("Horizontal") != 0;

        bool wantsToSprint = Input.GetKey(KeyCode.LeftShift);

        // si se agotó completamente
        if (currentStamina <= 0)
        {
            exhausted = true;
        }

        // se recuperó lo suficiente para volver a correr
        if (currentStamina >= maxStamina * 0.3f)
        {
            exhausted = false;
        }

        // sprint solo si NO está exhausto
        if (wantsToSprint && isMoving && !exhausted)
        {
            currentStamina -= drainSpeed * Time.deltaTime;
            playerMovement.walkSpeed = sprintSpeed;
        }
        else
        {
            currentStamina += regenSpeed * Time.deltaTime;
            playerMovement.walkSpeed = walkSpeed;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        staminaBar.value = currentStamina;
    }
}