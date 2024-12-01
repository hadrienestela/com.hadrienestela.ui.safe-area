using UnityEngine;

namespace HadrienEstela.UI.SafeArea
{

    /// <summary>
    /// Draw the safe area on screen in Debug mode
    /// </summary>
    [ExecuteAlways, DisallowMultipleComponent]
    public class SafeAreaVisualizer : MonoBehaviour
    {

        [SerializeField] private Color color = new Color(1,0,0,0.2f);

        #if DEBUG

            private Texture2D _texture;

            void Awake()
            {
                _texture = new Texture2D(1, 1);
                _texture.SetPixel(0, 0, this.color);
                _texture.Apply();
            }

            void OnValidate()
            {
                _texture.SetPixel(0, 0, this.color);
            }

            void OnGUI()
            {
                // Safe area origin if bottom-left
                Rect top = new Rect(0, 0, Screen.width, Screen.height - (Screen.safeArea.y + Screen.safeArea.height));
                Rect bottom = new Rect(0, Screen.height - Screen.safeArea.y, Screen.width, Screen.safeArea.y);
                Rect left = new Rect(0, Screen.safeArea.y, Screen.safeArea.x, Screen.safeArea.height);
                Rect right = new Rect(Screen.safeArea.x + Screen.safeArea.width, Screen.safeArea.y, Screen.width - (Screen.safeArea.x + Screen.safeArea.width), Screen.safeArea.height);

                GUI.DrawTexture(top, _texture);
                GUI.DrawTexture(bottom, _texture);
                GUI.DrawTexture(left, _texture);
                GUI.DrawTexture(right, _texture);
            }

        #endif

    }

}
