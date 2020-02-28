// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEngine;

namespace EditorWindowNavigation
{
    /// <summary>
    /// Panel which has random background colour. Used to demonstrate navigation.
    /// </summary>
    public class ColourPanel : PanelBase
    {
        private Color windowCol;

        public ColourPanel(MainWindow window)
            : base(window)
        {
            windowCol = new Color(
              Random.Range(0f, 1f),
              Random.Range(0f, 1f),
              Random.Range(0f, 1f));
        }

        public override void Render(Rect panelRect)
        {
            GUILayout.BeginArea(panelRect);

            Layout.Center(() =>
            {
                if (GUILayout.Button("Change Panel"))
                {
                    ColourPanel sp = new ColourPanel(Window);
                    Window.PanelManager.ChangePanel(sp);
                }

                if (GUILayout.Button("Navigate"))
                {
                    ColourPanel sp = new ColourPanel(Window);
                    Window.PanelManager.Navigate(sp);
                }

                if (GUILayout.Button("Back"))
                {
                    Window.PanelManager.Back();
                }

                if (GUILayout.Button("Clear Stack"))
                {
                    Window.PanelManager.ClearStack();
                }
            });

            GUILayout.EndArea();
        }

        public override Color? GetBackgroundColor()
        {
            return windowCol;
        }
    }
}
