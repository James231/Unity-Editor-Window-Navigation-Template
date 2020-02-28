// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEngine;

namespace EditorWindowNavigation
{
    /// <summary>
    /// Base Class for all panels
    /// </summary>
    public class PanelBase
    {
        public PanelBase(MainWindow win)
        {
            Window = win;
        }

        public MainWindow Window { get; set; }

        /// <summary>
        /// Override this to add content to your panel. Make sure the content stays within the specified rect.
        /// </summary>
        /// <param name="panelRect">Rect to position content within.</param>
        public virtual void Render(Rect panelRect)
        {
        }

        /// <summary>
        /// Override this to change the background colour of a panel. Return null to give it transparent background.
        /// </summary>
        /// <returns>Background colour of panel.</returns>
        public virtual Color? GetBackgroundColor()
        {
            return null;
        }
    }
}
