using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ComponentWhichWasLoadedBefore : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }   
}