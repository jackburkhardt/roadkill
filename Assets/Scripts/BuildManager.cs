using System;
using UnityEngine;


    public class BuildManager : MonoBehaviour
    {
        private void Awake()
        {
           // Application.targetFrameRate = 60;
        }

        void Update()
        {
#if UNITY_STANDALONE
            if (Input.GetKeyDown("escape")) { Application.Quit(); }
#endif            
        }
    }