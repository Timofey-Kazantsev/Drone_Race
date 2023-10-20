using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Vrs.Internal
{
    public class VrsUIGraphicRaycaster : GraphicRaycaster
    {
        protected Canvas currentCanvas;
        protected Vector2 lastKnownPosition;
        protected const float UI_CONTROL_OFFSET = 0.00001f;

        [NonSerialized]
        
        private static List<RaycastResult> s_RaycastResults = new List<RaycastResult>();

        public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
        {
            if (canvas == null)
            {
                return;
            }

            var ray = new Ray(eventData.pointerCurrentRaycast.worldPosition, eventData.pointerCurrentRaycast.worldNormal);
            Raycast(canvas, eventCamera, ray, ref s_RaycastResults);
            SetNearestRaycast(ref eventData, ref resultAppendList, ref s_RaycastResults);
            s_RaycastResults.Clear();
        }

        protected virtual void SetNearestRaycast(ref PointerEventData eventData, ref List<RaycastResult> resultAppendList, ref List<RaycastResult> raycastResults)
        {
            RaycastResult? nearestRaycast = null;
            for (var index = 0; index < raycastResults.Count; index++)
            {
                RaycastResult castResult = raycastResults[index];
                castResult.index = resultAppendList.Count;
                if (!nearestRaycast.HasValue || castResult.distance < nearestRaycast.Value.distance)
                {
                    nearestRaycast = castResult;
                }
                resultAppendList.Add(castResult);
            }

            if (nearestRaycast.HasValue)
            {
                eventData.position = nearestRaycast.Value.screenPosition;
                eventData.delta = eventData.position - lastKnownPosition;
                lastKnownPosition = eventData.position;
                eventData.pointerCurrentRaycast = nearestRaycast.Value;
            }
        }

        protected virtual float GetHitDistance(Ray ray)
        {
            var hitDistance = float.MaxValue;

            if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && blockingObjects != BlockingObjects.None)
            {
                var maxDistance = Vector3.Distance(ray.origin, canvas.transform.position);

                if (blockingObjects == BlockingObjects.ThreeD || blockingObjects == BlockingObjects.All)
                {
                    RaycastHit hit;
                    Physics.Raycast(ray, out hit, maxDistance);
                    if (hit.collider)
                    {
                        hitDistance = hit.distance;
                    }
                }

                if (blockingObjects == BlockingObjects.TwoD || blockingObjects == BlockingObjects.All)
                {
                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, maxDistance);

                    if (hit.collider != null)
                    {
                        hitDistance = hit.fraction * maxDistance;
                    }
                }
            }
            return hitDistance;
        }

        protected virtual void Raycast(Canvas canvas, Camera eventCamera, Ray ray, ref List<RaycastResult> results)
        {
            var hitDistance = GetHitDistance(ray);
            var canvasGraphics = GraphicRegistry.GetGraphicsForCanvas(canvas);
            for (int i = 0; i < canvasGraphics.Count; ++i)
            {
                var graphic = canvasGraphics[i];

                if (graphic.depth == -1 || !graphic.raycastTarget)
                {
                    continue;
                }

                var graphicTransform = graphic.transform;
                Vector3 graphicForward = graphicTransform.forward;
                float distance = Vector3.Dot(graphicForward, graphicTransform.position - ray.origin) / Vector3.Dot(graphicForward, ray.direction);

                if (distance < 0)
                {
                    continue;
                }

                
                if ((distance - UI_CONTROL_OFFSET) > hitDistance)
                {
                    continue;
                }

                Vector3 position = ray.GetPoint(distance);
                Vector2 pointerPosition = eventCamera.WorldToScreenPoint(position);

                if (!RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, pointerPosition, eventCamera))
                {
                    continue;
                }

                if (graphic.Raycast(pointerPosition, eventCamera))
                {
                    var result = new RaycastResult()
                    {
                        gameObject = graphic.gameObject,
                        module = this,
                        distance = distance,
                        screenPosition = pointerPosition,
                        worldPosition = position,
                        depth = graphic.depth,
                        sortingLayer = canvas.sortingLayerID,
                        sortingOrder = canvas.sortingOrder,
                    };
                    results.Add(result);
                }
            }

            results.Sort((g1, g2) => g2.depth.CompareTo(g1.depth));
        }

        protected virtual Canvas canvas
        {
            get
            {
                if (currentCanvas != null)
                {
                    return currentCanvas;
                }

                currentCanvas = gameObject.GetComponent<Canvas>();
                return currentCanvas;
            }
        }
    }
}