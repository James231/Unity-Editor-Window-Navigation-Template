// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEditor;

namespace EditorWindowNavigation
{
    public static class MenuItems
    {
        /// <summary>
        /// Menu Item on the top menu bar to open the window
        /// </summary>
        [MenuItem("Window/Editor Window Navigation Demo")]
        public static void Init()
        {
            MainWindow mainWindow = (MainWindow)EditorWindow.GetWindow(typeof(MainWindow));
            mainWindow.InitWindow();
        }
    }
}
