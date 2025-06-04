using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoteSystem
{
    public class Note : MonoBehaviour
    {
        private Vector3 downDir;

        public void Construct(float speed)
        {
            downDir = new(0, -speed, 0);
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

        public void DebugMethod()
        {
            Debug.Log("note hit");
        }
    }   
}