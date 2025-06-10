using NoteSystem;
using StarPowerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputSystemListener : MonoBehaviour
    {
        [SerializeField] private NoteDestroyer[] noteSectors;
        [SerializeField] private StarPowerCounter starPowerCounter;
        private bool isGreenFretHeldDown;
        private bool isRedFretHeldDown;
        private bool isYellowFretHeldDown;
        private bool isBlueFretHeldDown;

        void Start()
        {
            GuitarControls guitarControls = new();
            guitarControls.GuitarMapping.Enable();

            guitarControls.GuitarMapping.GreenFret.performed += PlayGreenFret;
            guitarControls.GuitarMapping.GreenFret.started += VisualizeGreenFret;
            guitarControls.GuitarMapping.GreenFret.canceled += UnvisualizeGreenFret;
            guitarControls.GuitarMapping.GreenFretPress.started += VisualizeGreenFret;
            guitarControls.GuitarMapping.GreenFretPress.canceled += UnvisualizeGreenFret;

            guitarControls.GuitarMapping.RedFret.performed += PlayRedFret;
            guitarControls.GuitarMapping.RedFret.started += VisualizeRedFret;
            guitarControls.GuitarMapping.RedFret.canceled += UnvisualizeRedFret;
            guitarControls.GuitarMapping.RedFretPress.started += VisualizeRedFret;
            guitarControls.GuitarMapping.RedFretPress.canceled += UnvisualizeRedFret;

            guitarControls.GuitarMapping.YellowFret.performed += PlayYellowFret;
            guitarControls.GuitarMapping.YellowFret.started += VisualizeYellowFret;
            guitarControls.GuitarMapping.YellowFret.canceled += UnvisualizeYellowFret;
            guitarControls.GuitarMapping.YellowFretPress.started += VisualizeYellowFret;
            guitarControls.GuitarMapping.YellowFretPress.canceled += UnvisualizeYellowFret;

            guitarControls.GuitarMapping.BlueFret.performed += PlayBlueFret;
            guitarControls.GuitarMapping.BlueFret.started += VisualizeBlueFret;
            guitarControls.GuitarMapping.BlueFret.canceled += UnvisualizeBlueFret;
            guitarControls.GuitarMapping.BlueFretPress.started += VisualizeBlueFret;
            guitarControls.GuitarMapping.BlueFretPress.canceled += UnvisualizeBlueFret;

            guitarControls.GuitarMapping.StarPower.performed += ActivateStarPower;

            guitarControls.GuitarMapping.Strum.performed += Strum;

            isGreenFretHeldDown = false;
            isRedFretHeldDown = false;
            isYellowFretHeldDown = false;
            isBlueFretHeldDown = false;

        }

        public void PlayGreenFret(InputAction.CallbackContext context)
        {
            noteSectors[0].CheckForNote();
        }

        public void VisualizeGreenFret(InputAction.CallbackContext context)
        {
            noteSectors[0].ChangeVisibility(true);
            isGreenFretHeldDown = true;
        }

        public void UnvisualizeGreenFret(InputAction.CallbackContext context)
        {
            noteSectors[0].ChangeVisibility(false);
            isGreenFretHeldDown = false;
        }

        public void PlayRedFret(InputAction.CallbackContext context)
        {
            noteSectors[1].CheckForNote();
        }

        public void VisualizeRedFret(InputAction.CallbackContext context)
        {
            noteSectors[1].ChangeVisibility(true);
            isRedFretHeldDown = true;
        }

        public void UnvisualizeRedFret(InputAction.CallbackContext context)
        {
            noteSectors[1].ChangeVisibility(false);
            isRedFretHeldDown = false;
        }

        public void PlayYellowFret(InputAction.CallbackContext context)
        {
            noteSectors[2].CheckForNote();
        }

        public void VisualizeYellowFret(InputAction.CallbackContext context)
        {
            noteSectors[2].ChangeVisibility(true);
            isYellowFretHeldDown = true;
        }

        public void UnvisualizeYellowFret(InputAction.CallbackContext context)
        {
            noteSectors[2].ChangeVisibility(false);
            isYellowFretHeldDown = false;
        }

        public void PlayBlueFret(InputAction.CallbackContext context)
        {
            noteSectors[3].CheckForNote();
        }

        public void VisualizeBlueFret(InputAction.CallbackContext context)
        {
            noteSectors[3].ChangeVisibility(true);
            isBlueFretHeldDown = true;
        }

        public void UnvisualizeBlueFret(InputAction.CallbackContext context)
        {
            noteSectors[3].ChangeVisibility(false);
            isBlueFretHeldDown= false;
        }

        public void ActivateStarPower(InputAction.CallbackContext context)
        {
            if(!starPowerCounter.IsActive && starPowerCounter.StarPower >= 50f) starPowerCounter.StartCoroutine(starPowerCounter.ActivateStarPower());
        }

        public void Strum(InputAction.CallbackContext context)
        {
            if (isGreenFretHeldDown) noteSectors[0].CheckForNote();
            if (isRedFretHeldDown) noteSectors[1].CheckForNote();
            if (isYellowFretHeldDown) noteSectors[2].CheckForNote();
            if (isBlueFretHeldDown) noteSectors[3].CheckForNote();
        }
    }
}