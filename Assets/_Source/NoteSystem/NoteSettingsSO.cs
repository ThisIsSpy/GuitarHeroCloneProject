using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoteSystem
{
    [CreateAssetMenu(fileName = "NoteSettingsSO", menuName = "SO/New Note Settings SO", order = 0)]
    public class NoteSettingsSO : ScriptableObject
    {
        [field: SerializeField] public float NoteSpeed { get; private set; } = 1f;
        [field: SerializeField] public int NoteCost { get; private set; } = 50;
        [field: SerializeField] public int NotesForMultIncrease { get; private set; } = 10;
        [field: SerializeField] public int MaxMult { get; private set; } = 4;
        [field: SerializeField] public float StarPowerMult { get; private set; } = 2f;
    }
}
