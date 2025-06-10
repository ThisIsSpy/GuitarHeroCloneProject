using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(fileName = "SoundSO", menuName = "SO/New Sounds SO", order = 1)]
    public class SoundsSO : ScriptableObject
    {
        [field: SerializeField] public AudioClip[] BadNoteSFX { get; private set; }
        [field: SerializeField] public AudioClip StarPowerReadySFX { get; private set; }
    }
}