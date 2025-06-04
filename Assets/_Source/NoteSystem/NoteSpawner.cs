using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoteSystem
{
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject songChartPrefab;
        [SerializeField] private NoteSettingsSO noteSettingsSO;

        [Header("Debug Stuff")]
        [SerializeField] private bool isInDebugMode;
        [SerializeField] private Note notePrefab;
        [SerializeField] private GameObject[] noteSectors;

        void Start()
        {
            if(isInDebugMode) StartCoroutine(WarmupCoroutine());
            else
            {
                List<Note> notes = songChartPrefab.GetComponentsInChildren<Note>().ToList();
                foreach(Note note in notes)
                {
                    note.Construct(noteSettingsSO.NoteSpeed);
                }
            }
        }

        private IEnumerator WarmupCoroutine()
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(NoteSpawningCoroutine());
        }

        private IEnumerator NoteSpawningCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(1,6));
            int sectorIndex = Random.Range(0, noteSectors.Length);
            Vector3 spawnPos = noteSectors[sectorIndex].transform.position;
            spawnPos = new(spawnPos.x, transform.position.y - spawnPos.y, spawnPos.z);
            GameObject instantiatedNote = Instantiate(notePrefab.gameObject, spawnPos, Quaternion.Euler(0,0,-90));
            instantiatedNote.GetComponent<Note>().Construct(noteSettingsSO.NoteSpeed);
            StartCoroutine(NoteSpawningCoroutine());
        }
    }
    
}