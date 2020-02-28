// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace EditorWindowNavigation
{
    /// <summary>
    /// Editor Window Parent Class
    /// </summary>
    public class MainWindow : EditorWindow
    {
        /// <summary>
        /// Instance of <see cref="PanelManager"/> for handling navigation.
        /// </summary>
        public PanelManager PanelManager { get; set; }

        /// <summary>
        /// Called straight after the window has been created
        /// </summary>
        public void InitWindow()
        {
            titleContent = new GUIContent("Demo Window");
            PanelManager = new PanelManager(this);
        }

        private void OnGUI()
        {
            Rect windowRect = new Rect(0, 0, position.width, position.height);
            GUI.DrawTexture(windowRect, TextureGen.GenPlainTexture(Color.grey));

            PanelManager.Render(windowRect);

            // Repaint required by PanelManager animations
            Repaint();
        }
    }
}
