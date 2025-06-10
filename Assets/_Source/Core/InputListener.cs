using NoteSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        //This class is obsolete, the project uses the new Input System

        [SerializeField] private NoteDestroyer[] noteSectors;

        void Update()
        {
            CheckForGreenNoteInput();
            CheckForRedNoteInput();
            CheckForYellowNoteInput();
            CheckForBlueNoteInput();
        }

        private void CheckForGreenNoteInput()
        {
            Color noteColor = noteSectors[0].GetComponent<SpriteRenderer>().color;
            if (Input.GetKeyDown(KeyCode.A)) noteSectors[0].CheckForNote();
            if(Input.GetKey(KeyCode.A)) noteSectors[0].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 0.5f);
            else noteSectors[0].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 1f);
        }

        private void CheckForRedNoteInput()
        {
            Color noteColor = noteSectors[1].GetComponent<SpriteRenderer>().color;
            if (Input.GetKeyDown(KeyCode.S)) noteSectors[1].CheckForNote();
            if (Input.GetKey(KeyCode.S)) noteSectors[1].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 0.5f);
            else noteSectors[1].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 1f);
        }

        private void CheckForYellowNoteInput()
        {
            Color noteColor = noteSectors[2].GetComponent<SpriteRenderer>().color;
            if (Input.GetKeyDown(KeyCode.J)) noteSectors[2].CheckForNote();
            if (Input.GetKey(KeyCode.J)) noteSectors[2].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 0.5f);
            else noteSectors[2].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 1f);
        }

        private void CheckForBlueNoteInput()
        {
            Color noteColor = noteSectors[3].GetComponent<SpriteRenderer>().color;
            if (Input.GetKeyDown(KeyCode.K)) noteSectors[3].CheckForNote();
            if (Input.GetKey(KeyCode.K)) noteSectors[3].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 0.5f);
            else noteSectors[3].GetComponent<SpriteRenderer>().color = new(noteColor.r, noteColor.g, noteColor.b, 1f);
        }
    }
}
