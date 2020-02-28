// -------------------------------------------------------------------------------------------------
// Unity Editor Window Navigation Template - © Copyright 2020 - Jam-Es.com
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using UnityEngine;

namespace EditorWindowNavigation
{
    public static class TextureGen
    {
        /// <summary>
        /// Generates 1x1 texture for a given colour
        /// </summary>
        /// <param name="color">Colour to create texture for</param>
        /// <returns>1x1 texture</returns>
        public static Texture GenPlainTexture(Color color)
        {
            var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return texture;
        }
    }
}
