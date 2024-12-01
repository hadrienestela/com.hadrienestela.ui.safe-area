using UnityEngine;
using UnityEngine.EventSystems;

namespace HadrienEstela.UI.SafeArea
{

    /// <summary>
    /// Adapts the RectTransform dimensions to the mobile SafeArea
    /// </summary>
    [ExecuteInEditMode, RequireComponent(typeof(RectTransform)), DisallowMultipleComponent]
    public class SafeArea: UIBehaviour
    {

        /// <summary>
        /// The Canvas instance
        /// </summary>
        private Canvas Canvas { get; set; }

        /// <summary>
        /// The RectTransform instance
        /// </summary>
        private RectTransform RectTransform => this.transform as RectTransform;

        /// <summary>
        /// The parent RectTransform instance
        /// </summary>
        private RectTransform Parent => this.transform.parent as RectTransform;

        /// <summary>
        /// The current Screen dimensions
        /// </summary>
        private Vector2 ScreenDimensions { get; set; }

        /// <summary>
        /// The previous size of rect transform parent.
        /// </summary>
        private Vector2 ParentSize { get; set; }
        
        /// <summary>
        /// Boolean indicating if the bounds should be recalculated
        /// </summary>
        private bool Dirty { get; set; }
        
        /// <inheritdoc/>
        protected override void OnEnable()
        {
            base.OnEnable();
            this.Canvas = this.GetComponentInParent<Canvas>();
            this.Dirty = true;
        }

        /// <inheritdoc/>
        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            this.Dirty = true;
        }

        /// <unitycallback/>
        private void LateUpdate()
        {
            if (!this.ScreenDimensions.Equals(new Vector2(Screen.width, Screen.height))) // Screen orientation changed
            {
                this.ScreenDimensions = new Vector2(Screen.width, Screen.height);
                this.ResizeSafeArea();
            }
            else if (this.transform.hasChanged) // Resized by hierarchy
            {
                this.transform.hasChanged = false;
                this.ResizeSafeArea();
                return;
            }

            RectTransform parentRT = this.transform.parent as RectTransform;
            
            if (parentRT && !parentRT.rect.size.Equals(this.ParentSize))
            {
                this.ResizeSafeArea();
                this.ParentSize = parentRT.rect.size;
                return;
            }

            if (this.Dirty)
                this.ResizeSafeArea();
        }

        /// <summary>
        /// Reset anchors configuration
        /// </summary>
        private void ReconfigureAnchors()
        {
            // Origin should be bottom left
            this.RectTransform.anchorMin = Vector2.zero;
            this.RectTransform.anchorMax = Vector2.zero;
            this.RectTransform.pivot = Vector2.zero;
        }

        /// <summary>
        /// Compute the new size of the component RectTransform
        /// </summary>
        private void ResizeSafeArea()
        {
            if (!this.Canvas || this.Parent is null)
                return ;

            Vector2 safeAreaOrigin = Screen.safeArea.position / this.Canvas.scaleFactor;
            Vector2 safeAreaSize = Screen.safeArea.size / this.Canvas.scaleFactor;
            Vector2 parentOrigin = SafeAreaHelper.GetRectTransformOriginOffset(this.Parent) / this.Canvas.scaleFactor;
            Vector2 parentSize = this.Parent.rect.size;

            float xInset = Mathf.Max(parentOrigin.x - safeAreaOrigin.x, 0f);
            float yInset = Mathf.Max(parentOrigin.y - safeAreaOrigin.y, 0f);

            safeAreaOrigin.x = Mathf.Max(safeAreaOrigin.x - parentOrigin.x, 0f);
            safeAreaOrigin.y = Mathf.Max(safeAreaOrigin.y - parentOrigin.y, 0f);

            safeAreaSize.x = Mathf.Min(safeAreaSize.x - xInset, parentSize.x - safeAreaOrigin.x);
            safeAreaSize.y = Mathf.Min(safeAreaSize.y - yInset, parentSize.y - safeAreaOrigin.y);

            // Apply new dimensions
            this.ReconfigureAnchors();
            this.RectTransform.sizeDelta = safeAreaSize;
            this.RectTransform.anchoredPosition = safeAreaOrigin;

            this.Dirty = false;
        }

    }

}
