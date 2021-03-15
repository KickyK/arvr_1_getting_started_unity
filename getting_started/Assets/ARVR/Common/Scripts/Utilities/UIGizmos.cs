using UnityEditor;
using UnityEngine;

namespace ARVR.Utilities
{
    internal class UIGizmos
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="worldPos"></param>
        /// <param name="colour"></param>
        /// <see cref="https://gist.github.com/Arakade/9dd844c2f9c10e97e3d0"/>
        public static void DrawString(string text, Vector3 worldPos, Color? colour = null)
        {
            Handles.BeginGUI();

            var restoreColor = GUI.color;
            if (colour.HasValue)
            {
                GUI.color = colour.Value;
            }

            var view = SceneView.currentDrawingSceneView;
            Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);

            if (screenPos.y < 0 || screenPos.y > Screen.height || screenPos.x < 0 || screenPos.x > Screen.width || screenPos.z < 0)
            {
                GUI.color = restoreColor;
                Handles.EndGUI();
                return;
            }

            Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));
            GUI.Label(new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height + 4, size.x, size.y), text);
            GUI.color = restoreColor;
            Handles.EndGUI();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="worldPos"></param>
        /// <param name="textColor"></param>
        /// <param name="backColor"></param>
        /// <see cref="https://gist.github.com/jeffvella/fc7e66dd3f871785bb6ebb6d98ca1b2f"/>
        public static void DrawString(string text, Vector3 worldPos, Color? textColor = null, Color? backColor = null)
        {
            Handles.BeginGUI();
            var restoreTextColor = GUI.color;
            var restoreBackColor = GUI.backgroundColor;

            GUI.color = textColor ?? Color.white;
            GUI.backgroundColor = backColor ?? Color.black;

            var view = SceneView.currentDrawingSceneView;
            if (view != null && view.camera != null)
            {
                Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);
                if (screenPos.y < 0 || screenPos.y > Screen.height || screenPos.x < 0 || screenPos.x > Screen.width || screenPos.z < 0)
                {
                    GUI.color = restoreTextColor;
                    Handles.EndGUI();
                    return;
                }
                Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));
                var r = new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height + 4, size.x, size.y);
                GUI.Box(r, text, EditorStyles.textArea);
                GUI.Label(r, text);
                GUI.color = restoreTextColor;
                GUI.backgroundColor = restoreBackColor;
            }
            Handles.EndGUI();
        }
    }
}