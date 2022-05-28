using UnityEngine;


[CreateAssetMenu(fileName = "_FlashEffect", menuName = "Scriptable Objects/Flash Effect")]
public class ParryFlashEffectSO : ScriptableObject
{
    public Gradient colorGradient;
    public float duration = 0.5f;
    public float startParticleSize = 0.25f;
    public float startParticleSpeed = 2f;
    public float startLifetime = 0.3f;
    public int maxParticleNumber = 500;
    public int emissionRate = 500;
    public int burstParticleNumber = 300;
    public float effectGravity = 0f;
    public Sprite sprite;
    public Vector3 velocityOverLifetimeMin;
    public Vector3 velocityOverLifetimeMax;
    public GameObject flashEffectPrefab;


}