using ScoreSystem;
using SoundSystem;
using StarPowerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoteSystem
{
    public class NoteDestroyer : MonoBehaviour
    {
        [field: SerializeField] public bool IsBarrier { get; private set; }
        [SerializeField] private SoundsSO soundsSO;
        [SerializeField] private AudioSource guitarTrackPlayer;
        [SerializeField] private AudioSource sfxPlayer;
        [SerializeField] private NoteCounter noteCounter;
        [SerializeField] private Color normalFlameParticleColor;
        [SerializeField] private Color starPowerFlameParticleColor;
        private ContactFilter2D contactFilter;
        private ParticleSystem noteHitParticles;
        private SpriteRenderer noteSectorSprite;
        private Color defaultColor;

        void Awake()
        {
            contactFilter = new ContactFilter2D();
            contactFilter.NoFilter();
            noteHitParticles = GetComponentInChildren<ParticleSystem>();
            if(TryGetComponent(out SpriteRenderer sprite))
            { 
                noteSectorSprite = sprite;
                defaultColor = noteSectorSprite.color;
            }
        }

        public void CheckForNote()
        {
            RaycastHit2D[] results = new RaycastHit2D[1];
            int hits = Physics2D.Raycast(new(transform.position.x, transform.position.y - 0.6f), new(0, 0.7f), contactFilter, results, 1.45f);
            Debug.DrawRay(new(transform.position.x, transform.position.y - 0.6f), new(0, 1.45f, 0), Color.red, 0.25f);
            if (hits > 0 && results[0].collider.TryGetComponent(out Note _))
            {
                Destroy(results[0].collider.gameObject);
                noteHitParticles.Play();
                noteCounter.NotesHit++;
                guitarTrackPlayer.volume = 1f;
            }
            else
            {
                sfxPlayer.PlayOneShot(soundsSO.BadNoteSFX[Random.Range(0,soundsSO.BadNoteSFX.Length)]);
                noteCounter.NoteStreak = 0;
                guitarTrackPlayer.volume = 0.5f;
            }
        }

        public void OnNoteMissed()
        {
            noteCounter.NoteStreak = 0;
            guitarTrackPlayer.volume = 0.5f;
        }

        public void ChangeFlameColor(bool isStarPower)
        {
            var main = noteHitParticles.main;
            if (isStarPower) main.startColor = starPowerFlameParticleColor;
            else main.startColor = normalFlameParticleColor;
        }

        public void ChangeVisibility(bool isVisible)
        {
            if (isVisible)
            {
                noteSectorSprite.color = new(defaultColor.r, defaultColor.g, defaultColor.b, 1f);
            }
            else
            {
                noteSectorSprite.color = defaultColor;
            }
        }
    }
}