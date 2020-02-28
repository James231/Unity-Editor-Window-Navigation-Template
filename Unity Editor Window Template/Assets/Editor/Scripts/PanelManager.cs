// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorWindowNavigation
{
    /// <summary>
    /// Class to handle naviagation and panel animations.
    /// </summary>
    public class PanelManager
    {
        private PanelBase oldPanel;
        private PanelBase currentPanel;

        private bool transitioning = false;
        private float transitionSpeed = 0.01f;
        private PanelDirection transitionDir;
        private float transitionPerc;
        private AnimationCurve transitionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelManager"/> class.
        /// </summary>
        /// <param name="window">Reference to the Editor Window class.</param>
        public PanelManager(MainWindow window)
        {
            PanelStack = new List<PanelBase>();
            currentPanel = new WelcomePanel(window);
        }

        public enum PanelDirection
        {
            Left,
            Right,
        }

        /// <summary>
        /// Navigation stack of previous panels which you can return to using Back.
        /// </summary>
        public List<PanelBase> PanelStack { get; set; }

        /// <summary>
        /// Renders panels to editor window (called by OnGUI).
        /// </summary>
        /// <param name="windowRect">Window rect to render within.</param>
        public void Render(Rect windowRect)
        {
            // TODO: Add transparent overlay over old panel so buttons don't work
            if (transitioning)
            {
                float posPerc = transitionCurve.Evaluate(transitionPerc);

                if (transitionPerc >= 1)
                {
                    transitioning = false;
                    transitionPerc = 0;
                    oldPanel = null;
                }

                transitionPerc = Math.Min(transitionPerc + transitionSpeed, 1);

                Rect newPanelRect = default(Rect);
                Rect oldPanelRect = default(Rect);

                if (transitionDir == PanelDirection.Left)
                {
                    float posPerc1 = posPerc;
                    newPanelRect = new Rect((posPerc1 - 1) * windowRect.width, 0, windowRect.width, windowRect.height);
                    oldPanelRect = new Rect(posPerc * windowRect.width, 0, windowRect.width, windowRect.height);
                }
                else
                {
                    newPanelRect = new Rect((1 - posPerc) * windowRect.width, 0, windowRect.width, windowRect.height);
                    oldPanelRect = new Rect(-posPerc * windowRect.width, 0, windowRect.width, windowRect.height);
                }

                RenderPanel(oldPanelRect, oldPanel);
                RenderPanel(newPanelRect, currentPanel);
            }
            else
            {
                RenderPanel(windowRect, currentPanel);
            }
        }

        /// <summary>
        /// Change the currently displayed panel (without adding to the panelStack).
        /// </summary>
        /// <param name="newPanel">The new panel to display.</param>
        /// <param name="dir">Direction to animate the new panel into the window from.</param>
        public void ChangePanel(PanelBase newPanel, PanelDirection dir = PanelDirection.Right)
        {
            transitioning = true;
            oldPanel = currentPanel;
            currentPanel = newPanel;
            transitionDir = dir;
            transitionPerc = 0;
        }

        /// <summary>
        /// Changes the currently displayed panel (adding to panelStack, allowing backwards navigation).
        /// </summary>
        /// <param name="newPanel">The new panel to display.</param>
        public void Navigate(PanelBase newPanel)
        {
            if (!PanelStack.Contains(currentPanel))
            {
                PanelStack.Add(currentPanel);
            }

            PanelStack.Add(newPanel);
            ChangePanel(newPanel, PanelDirection.Right);
        }

        /// <summary>
        /// Clears the naviagtion stack preventing user from navigating backwards.
        /// </summary>
        public void ClearStack()
        {
            if (PanelStack.Contains(currentPanel))
            {
                PanelStack.Clear();
                PanelStack.Add(currentPanel);
                return;
            }

            PanelStack.Clear();
        }

        /// <summary>
        /// Navigate backwards to the previous panel on the stack.
        /// </summary>
        /// <returns>True if possible, false otherwise (e.g. if stack is empty)</returns>
        public bool Back()
        {
            if (PanelStack.Count > 0)
            {
                PanelBase lastPanel = PanelStack[PanelStack.Count - 1];
                if (lastPanel == currentPanel)
                {
                    if (PanelStack.Count > 1)
                    {
                        lastPanel = PanelStack[PanelStack.Count - 2];
                        PanelStack.RemoveAt(PanelStack.Count - 1);
                    }
                    else
                    {
                        return false;
                    }
                }

                ChangePanel(lastPanel, PanelDirection.Left);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RenderPanel(Rect panelRect, PanelBase panel)
        {
            Color? backgroundColor = panel.GetBackgroundColor();

            if (backgroundColor.HasValue)
            {
                Texture panelCol = TextureGen.GenPlainTexture(backgroundColor.Value);
                GUI.DrawTexture(panelRect, panelCol);
            }

            panel.Render(panelRect);
        }
    }
}
