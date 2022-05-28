using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]

public class PlayerControl : MonoBehaviour
{
    private Player player;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private ParryFlashEffectSO flashEffect;
    private Vector2 moveInput;

    Coroutine parryCoroutine;
    [SerializeField] private float parryCoolDownSeconds = 1.5f;
    [SerializeField] private float parryTimeSeconds = 0.3f;
    [HideInInspector] public bool isParrying = false;
    [HideInInspector] public bool isParryOnCD = false;

    Fireball fireball;

    void Awake()
    {
        player = GetComponent<Player>();
        fireball = GetComponent<Fireball>();
    }

    void Update()
    {
        Debug.Log(isParryOnCD);
        Debug.Log(isParrying);
        handleMovementInput();
    }

    void OnMove(InputValue value)
    {
        // TODO: is this the best way to do this?
        moveInput = value.Get<Vector2>();
    }

    void OnParry()
    {
        if (parryCoroutine == null)
        {
            parryCoroutine = StartCoroutine(Parry());
        }
    }

    IEnumerator Parry()
    {
        Vector3 initialScale = GetScale();
        Debug.Log("Parrying");
        isParrying = true;
        ParryFlashEffect();
        yield return new WaitForSeconds(parryTimeSeconds);

        isParrying = false;
        isParryOnCD = true;

        yield return new WaitForSeconds(parryCoolDownSeconds);
        isParryOnCD = false;

        parryCoroutine = null;
    }

    private void ParryFlashEffect()
    {
        // Process if there is a shoot effect & prefab
        if (flashEffect != null && flashEffect.flashEffectPrefab != null)
        {
            // Instantiate the flash effect
            ParryFlashEffect parryFlashEffect = Instantiate(flashEffect.flashEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParryFlashEffect>();
            // Set shoot effect
            parryFlashEffect.SetShootEffect(flashEffect);

            parryFlashEffect.gameObject.SetActive(true);
        }
    }

    public void ScaleModelTo(Vector3 scale)
    {
        playerModel.transform.localScale = scale;
    }

    public Vector3 GetScale()
    {
        return playerModel.transform.localScale;
    }


    void OnFire(InputValue value)
    {
        if (fireball != null && value.isPressed)
        {
            fireball.Fire();
        }
    }

    private void handleMovementInput()
    {

        float horizontalMovement = moveInput.x;
        float verticalMovement = moveInput.y;

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);

        // Diagonal movement
        if (horizontalMovement != 0f && verticalMovement != 0f)
        {
            direction *= 0.7f;
        }

        bool isMovement = direction != Vector2.zero;
        if (isMovement)
        {
            player.movementEvent.CallMovementEvent(direction, moveSpeed);
        }
        else
        {
            player.idleEvent.CallIdleEvent();
        }
    }
}
