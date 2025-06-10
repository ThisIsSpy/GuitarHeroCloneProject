using Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoteSystem
{
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject songChartPrefab;
        [SerializeField] private float bandaidFixDistance;
        [SerializeField] private NoteSettingsSO noteSettingsSO;
        [SerializeField] private Color normalNoteColor;
        [SerializeField] private Color starPowerNoteColor;
        [SerializeField] private AudioSource guitarTrackSource;
        [SerializeField] private AudioSource bandTrackSource;

        [Header("Debug Stuff")]
        [SerializeField] private bool isInDebugMode;
        [SerializeField] private Note notePrefab;
        [SerializeField] private GameObject[] noteSectors;
        private bool useStarPowerColor;

        void Start()
        {
            ComponentWhichWasLoadedBefore componentWhichWasLoadedBefore = FindObjectOfType<ComponentWhichWasLoadedBefore>();
            if (componentWhichWasLoadedBefore != null )
            {
                songChartPrefab.transform.position = new(songChartPrefab.transform.position.x, songChartPrefab.transform.position.y + bandaidFixDistance, songChartPrefab.transform.position.z);
            }
            if (isInDebugMode) StartCoroutine(WarmupCoroutine());
            else
            {
                List<Note> notes = songChartPrefab.GetComponentsInChildren<Note>().ToList();
                foreach(Note note in notes)
                {
                    note.Construct(noteSettingsSO.NoteSpeed);
                }
            }
        }

        void FixedUpdate()
        {
            if (!isInDebugMode) CheckForRemainingNotes();
        }

        private IEnumerator WarmupCoroutine()
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(NoteSpawningCoroutine());
        }

        private IEnumerator NoteSpawningCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(0.1f,0.75f));
            int sectorIndex = Random.Range(0, noteSectors.Length);
            Vector3 spawnPos = noteSectors[sectorIndex].transform.position;
            spawnPos = new(spawnPos.x, transform.position.y - spawnPos.y, spawnPos.z);
            GameObject instantiatedNote = Instantiate(notePrefab.gameObject, spawnPos, Quaternion.Euler(0,0,-90));
            instantiatedNote.GetComponent<Note>().Construct(noteSettingsSO.NoteSpeed);
            if (useStarPowerColor) instantiatedNote.GetComponent<SpriteRenderer>().color = starPowerNoteColor;
            StartCoroutine(NoteSpawningCoroutine());
        }

        public void ChangeNoteColor(bool isStarPower)
        {
            List<Note> notes2 = FindObjectsByType<Note>(FindObjectsSortMode.InstanceID).ToList();
            foreach (Note note in notes2)
            {
                if(isStarPower) note.GetComponent<SpriteRenderer>().color = starPowerNoteColor;
                else note.GetComponent<SpriteRenderer>().color = normalNoteColor;
            }
            if (isStarPower) useStarPowerColor = true;
            else useStarPowerColor = false;
            
        }

        private void CheckForRemainingNotes()
        {
            List<Note> notes = songChartPrefab.GetComponentsInChildren<Note>().ToList();
            if(notes.Count == 0)
            {
                isInDebugMode = true;
                StartCoroutine(NoteSpawningCoroutine());
            }
        }
    }
    
}