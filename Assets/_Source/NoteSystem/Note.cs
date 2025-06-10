using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoteSystem
{
    public class Note : MonoBehaviour
    {
        [field: SerializeField] public bool IsLongNote { get; private set; } = false;
        [SerializeField] private float noteLength;
        private Vector3 downDir;
        private float previousY;

        public void Construct(float speed)
        {
            downDir = new(0, -speed, 0);
            if (IsLongNote)
            {
                SpriteRenderer noteTail = GetComponentInChildren<SpriteRenderer>();
                noteTail.transform.localScale = new(noteLength, 0.25f, 1);
                noteTail.transform.localPosition = new(-1.75f + (-1.25f * (noteLength - 1)), 0, 0);
            }
        }

        void FixedUpdate()
        {
            if(downDir != null) transform.position += downDir * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out NoteDestroyer noteDestroyer) && noteDestroyer.IsBarrier)
            {
                noteDestroyer.OnNoteMissed();
                Destroy(gameObject);
            }
        }
    }   
}