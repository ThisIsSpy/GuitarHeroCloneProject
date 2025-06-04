using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoteSystem
{
    public class NoteDestroyer : MonoBehaviour
    {
        [field: SerializeField] public bool IsBarrier { get; private set; }
        [SerializeField] private NoteCounter noteCounter;
        private ContactFilter2D contactFilter;

        void Awake()
        {
            contactFilter = new ContactFilter2D();
            contactFilter.NoFilter();
        }

        public void CheckForNote()
        {
            RaycastHit2D[] results = new RaycastHit2D[1];
            int hits = Physics2D.Raycast(new(transform.position.x, transform.position.y - 0.5f), new(0, 0.55f), contactFilter, results, 1.1f);
            Debug.DrawRay(new(transform.position.x, transform.position.y - 0.5f), new(0, 1.1f, 0), Color.red, 0.25f);
            if (hits > 0 && results[0].collider.TryGetComponent(out Note _))
            {
                Destroy(results[0].collider.gameObject);
                noteCounter.NotesHit++;
            }
            else noteCounter.NoteStreak = 0;
        }

        public void OnNoteMissed()
        {
            noteCounter.NoteStreak = 0;
        }
    }
}