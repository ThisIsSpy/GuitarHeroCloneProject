using NoteSystem;
using ScoreSystem;
using SoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace StarPowerSystem
{
    public class StarPowerCounter : MonoBehaviour
    {
        [Header("UI Stuff")]
        [SerializeField] private Slider starPowerUI;
        [SerializeField] private Image starPowerBarFillImage;
        [SerializeField] private Color normalStarPowerFillBarColor;
        [SerializeField] private Color readyStarPowerFillBarColor;
        [Header("Sound Stuff")]
        [SerializeField] private AudioSource sfxPlayer;
        [SerializeField] private SoundsSO soundsSO;
        [SerializeField] private AudioMixer guitarTrackAudioMixer;
        [Header("Note Stuff")]
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private NoteSpawner noteSpawner;
        [SerializeField] private NoteDestroyer[] noteSectors;
        private float starPower;

        public bool IsActive { get; private set; }
        public float StarPower { get { return starPower; } 
            set 
            {
                if (starPower == value) return;
                if (starPower < 50 && value >= 50) sfxPlayer.PlayOneShot(soundsSO.StarPowerReadySFX);
                starPower = Mathf.Clamp(value, 0, 100);
                starPowerUI.value = starPower;
                if(starPower <= 0) IsActive = false;
                if (!IsActive && starPower < 50) starPowerBarFillImage.color = normalStarPowerFillBarColor;
                else if (starPower >= 50) starPowerBarFillImage.color = readyStarPowerFillBarColor;
            } 
        }

        void Start()
        {
            StarPower = 0;
            starPowerUI.maxValue = 100;
            starPowerUI.value = StarPower;
        }

        public IEnumerator ActivateStarPower()
        {
            IsActive = true;
            noteSpawner.ChangeNoteColor(true);
            foreach (var noteSector in noteSectors)
            {
                noteSector.ChangeFlameColor(true);
            }
            scoreCounter.AllowToGoBeyondMaxCap = true;
            scoreCounter.ScoreMult *= 2;
            guitarTrackAudioMixer.SetFloat("DistortionLevel", 0.25f);
            guitarTrackAudioMixer.SetFloat("WetmixLevel", 100f);
            while(StarPower > 0)
            {
                StarPower -= 0.25f;
                yield return new WaitForSeconds(0.02f);
            }
            IsActive = false;
            noteSpawner.ChangeNoteColor(false);
            foreach (var noteSector in noteSectors)
            {
                noteSector.ChangeFlameColor(false);
            }
            scoreCounter.AllowToGoBeyondMaxCap = false;
            scoreCounter.ScoreMult /= 2;
            guitarTrackAudioMixer.SetFloat("DistortionLevel", 0f);
            guitarTrackAudioMixer.SetFloat("WetmixLevel", 0f);
        }
    }
}