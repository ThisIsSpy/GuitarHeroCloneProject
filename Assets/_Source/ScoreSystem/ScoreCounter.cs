using NoteSystem;
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
                //if (score == value) return;
                score = Mathf.Clamp(value, 0, 9999999);
                scoreUI.text = score.ToString();
            }
        }
        public int ScoreMult { get { return scoreMult; }
            set 
            {
                //if (scoreMult == value) return;
                scoreMult = Mathf.Clamp(value, 1, noteSettingsSO.MaxMult);
                scoreMultUI.text = $"{scoreMult}x";
            }
        }
    }
}