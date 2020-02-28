// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEngine;

namespace EditorWindowNavigation
{
    public static class Layout
    {
        public delegate void RenderDelegate();

        public enum CenterType
        {
            Horizontal,
            Vertical,
            Both,
        }

        /// <summary>
        /// Horizontally and vertically center GUI Content within a Layout Area
        /// </summary>
        /// <param name="rd">Delegate function for creating centered content</param>
        public static void Center(RenderDelegate rd)
        {
            Center(CenterType.Both, rd);
        }

        /// <summary>
        /// Center (Horizontally or Vertically) GUI Content within a Layout Area
        /// </summary>
        /// <param name="ct">Enum specifying the direction to center the content in</param>
        /// <param name="rd">Delegate function for creating centered content</param>
        public static void Center(CenterType ct, RenderDelegate rd)
        {
            if (ct != CenterType.Horizontal)
            {
                GUILayout.BeginVertical();
            }

            GUILayout.FlexibleSpace();
            if (ct != CenterType.Vertical)
            {
                GUILayout.BeginHorizontal();
            }

            GUILayout.FlexibleSpace();
            rd.Invoke();
            GUILayout.FlexibleSpace();
            if (ct != CenterType.Vertical)
            {
                GUILayout.EndHorizontal();
            }

            GUILayout.FlexibleSpace();
            if (ct != CenterType.Horizontal)
            {
                GUILayout.EndVertical();
            }
        }
    }
}
