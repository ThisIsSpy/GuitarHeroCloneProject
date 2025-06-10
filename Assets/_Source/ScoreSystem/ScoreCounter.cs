using NoteSystem;
using StarPowerSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreUI;
        [SerializeField] private TextMeshProUGUI scoreMultUI;
        [SerializeField] private NoteSettingsSO noteSettingsSO;
        [HideInInspector] public bool AllowToGoBeyondMaxCap;

        private int score;
        private int scoreMult;

        void Start()
        {
            Score = 0;
            ScoreMult = 1;
        }

        public int Score { get { return score; } 
            set 
            {
                if (score == value) return;
                score = Mathf.Clamp(value, 0, 9999999);
                scoreUI.text = score.ToString();
            }
        }
        public int ScoreMult { get { return scoreMult; }
            set 
            {
                if (scoreMult == value) return;
                scoreMult = Mathf.Clamp(value, 1, noteSettingsSO.MaxMult);
                if (AllowToGoBeyondMaxCap) scoreMult *= 2;
                scoreMultUI.text = $"{scoreMult}x";
            }
        }
    }
}