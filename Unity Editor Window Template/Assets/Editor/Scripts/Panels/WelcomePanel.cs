// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEngine;

namespace EditorWindowNavigation
{
    /// <summary>
    /// Default Panel.
    /// </summary>
    public class WelcomePanel : PanelBase
    {
        public WelcomePanel(MainWindow window)
            : base(window)
        {
        }

        public override void Render(Rect panelRect)
        {
            GUILayout.BeginArea(panelRect);

            Layout.Center(() =>
            {
                if (GUILayout.Button("New Panels"))
                {
                    ColourPanel sp = new ColourPanel(Window);
                    Window.PanelManager.ChangePanel(sp);
                }
            });

            GUILayout.EndArea();
        }
    }
}
