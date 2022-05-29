using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ParryHandler : MonoBehaviour
{
    private Player player;
    private ParryEvent parryEvent;
    private Coroutine parryCoroutine;
    [SerializeField] private ParryFlashEffectSO flashEffect;

    [SerializeField] private float parryCoolDownSeconds = 1.5f;
    [SerializeField] private float parryTimeSeconds = 0.3f;
    [HideInInspector] public bool isParryOnCD = false;

    private void Awake()
    {
        parryEvent = GetComponent<ParryEvent>();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        parryEvent.OnParry += ParryEvent_HandleOnParry;
    }

    private void OnDisable()
    {
        parryEvent.OnParry -= ParryEvent_HandleOnParry;
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

    private void ParryEvent_HandleOnParry(ParryEvent parryEvent)
    {
        if (parryCoroutine == null)
        {
            parryCoroutine = StartCoroutine(Parry());
        }
    }

    IEnumerator Parry()
    {
        Vector3 initialScale = player.playerControl.GetScale();

        player.playerControl.isParrying = true;
        ParryFlashEffect();
        yield return new WaitForSeconds(parryTimeSeconds);
        player.playerControl.isParrying = false;

        isParryOnCD = true;
        yield return new WaitForSeconds(parryCoolDownSeconds);
        isParryOnCD = false;

        parryCoroutine = null;
    }
}
