using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NoteSystem
{ 
    public class NoteCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI noteStreakUI;
        [SerializeField] private TextMeshProUGUI notesHitUI;
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private NoteSettingsSO noteSettingsSO;

        private int notesHit;
        private int noteStreak;

        void Start()
        {
            NotesHit = 0;
            NoteStreak = 0;
        }

        public int NotesHit { get { return notesHit; } 
            set 
            {
                if (notesHit == value) return;
                notesHit = Mathf.Clamp(value, 0, int.MaxValue);
                notesHitUI.text = notesHit.ToString();
                NoteStreak++;
                scoreCounter.Score += (noteSettingsSO.NoteCost * scoreCounter.ScoreMult);
            } 
        }
        public int NoteStreak { get { return noteStreak; }
            set
            {
                if (noteStreak == value) return;
                noteStreak = Mathf.Clamp(value, 0, int.MaxValue);
                noteStreakUI.text = noteStreak.ToString();
                if (noteStreak == 0) scoreCounter.ScoreMult = 1;
                if (noteStreak % 10 == 0 && scoreCounter.ScoreMult < noteSettingsSO.MaxMult && noteStreak != 0) scoreCounter.ScoreMult++;
            }
        }
    }
}