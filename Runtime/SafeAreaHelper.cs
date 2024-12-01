using UnityEngine;

namespace HadrienEstela.UI.SafeArea
{
    
    internal static class SafeAreaHelper
    {
        /// <summary>
        /// Get the rect origin offset of the given RectTransform inside the given target or screen.
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="target"></param>
        /// <returns>The origin offset of the given rect transform inside the given one, or in screen from the bottom-left corner</returns>
        public static Vector2 GetRectTransformOriginOffset(RectTransform rectTransform, RectTransform target = null)
        {
            Vector3 worldPosition = rectTransform.TransformPoint(-rectTransform.rect.width * rectTransform.pivot.x, -rectTransform.rect.height * rectTransform.pivot.y, 0);
            Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(null, worldPosition);

            if (target is not null)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(target, screenPoint, null, out Vector2 localPosition);
                return localPosition - new Vector2(-target.rect.width * target.pivot.x, -target.rect.height * target.pivot.y);
            }
            return screenPoint;
        }
    }
    
}
