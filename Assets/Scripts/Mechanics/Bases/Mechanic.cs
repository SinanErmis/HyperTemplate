using System;
using System.Collections;
using System.Collections.Generic;
using Rhodos.Core;
using UnityEngine;

namespace Rhodos.Mechanics.Bases
{
    public abstract class Mechanic : MonoBehaviour
    {
        protected bool CanPlay
        {
            get => GameManager.Instance.canPlay;
            set => GameManager.Instance.canPlay = value;
        }
        
        public virtual IEnumerator OnStart()
        {
            yield break;
        }

        public virtual IEnumerator OnEnd()
        {
            yield break;
        }

        public virtual IEnumerator OnFail()
        {
            yield break;
        }

        public virtual void OnDown()
        {
        }

        public virtual void OnDrag()
        {
        }

        public virtual void OnUp()
        {
        }

        #region Predefined Ray Methods

        protected bool IsRayToPositionHitAnyObjectInLayer(Vector3 position, LayerMask layer)
        {
            Vector3 screenPoint = CameraManager.Camera.WorldToScreenPoint(position);
            Ray ray = CameraManager.Camera.ScreenPointToRay(screenPoint);
            return Physics.Raycast(ray: ray, layerMask: layer, maxDistance: 100f);
        }

        protected Vector3 GetWorldPositionOnPlaneY(float y)
        {
            Vector3 camPos = CameraManager.Camera.transform.position;
            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            Plane xz = new Plane(Vector3.up, new Vector3(camPos.x, y, camPos.z));
            xz.Raycast(ray, out float distance);
            return ray.GetPoint(distance);
        }

        protected Vector3 GetWorldPositionOnPlaneZ(float z)
        {
            Vector3 camPos = CameraManager.Camera.transform.position;
            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            Plane xy = new Plane(Vector3.forward, new Vector3(camPos.x, camPos.y, z));
            xy.Raycast(ray, out float distance);
            return ray.GetPoint(distance);
        }

        protected bool IsMouseRayHitObjectOfType<T>()
        {
            return IsMouseRayHitObjectOfType<T>(out T t);
        }

        protected bool IsMouseRayHitObjectOfTypeWithLayer<T>(out T obj, LayerMask layerMask)
        {
            obj = default;

            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                obj = hit.transform.GetComponent<T>();
                if (obj != null) return true;
            }

            return false;
        }

        protected bool IsMouseRayHitObjectOfType<T>(out T obj)
        {
            obj = default;

            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                obj = hit.transform.GetComponent<T>();
                if (obj != null) return true;
            }

            return false;
        }

        protected bool IsMouseRayHitObject(GameObject gameObject)
        {
            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.transform.gameObject == gameObject) return true;
            }

            return false;
        }

        protected bool IsMouseRayHitObjectInLayer(GameObject gameObject, LayerMask layerMask)
        {
            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                if (hit.transform.gameObject == gameObject) return true;
            }

            return false;
        }

        protected T GetObjectWithMouseRay<T>(string tag)
        {
            T t = default;

            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.CompareTag(tag))
                {
                    t = hit.collider.GetComponent<T>();
                }
            }

            return t;
        }

        protected T GetObjectWithMouseRay<T>(string tag, LayerMask layer)
        {
            T t = default;

            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layer))
            {
                if (hit.collider.CompareTag(tag))
                {
                    t = hit.collider.GetComponent<T>();
                }
            }

            return t;
        }

        protected T GetObjectWithRayToObject<T>(string tag, Transform target)
        {
            T t = default;

            Ray ray = new Ray(CameraManager.Camera.transform.position,
                target.position - CameraManager.Camera.transform.position);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.CompareTag(tag))
                {
                    t = hit.collider.GetComponent<T>();
                }
            }

            return t;
        }

        protected T GetObjectWithRayToObjectWithTagAndLayer<T>(string tag, Transform target, LayerMask layer)
        {
            T t = default;

            Ray ray = new Ray(CameraManager.Camera.transform.position,
                target.position - CameraManager.Camera.transform.position);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layer))
            {
                if (hit.collider.CompareTag(tag))
                {
                    t = hit.collider.GetComponent<T>();
                }
            }

            return t;
        }

        protected T GetObjectWithRayToObjectWithLayer<T>(Transform target, LayerMask layer)
        {
            T t = default;

            Ray ray = new Ray(CameraManager.Camera.transform.position,
                target.position - CameraManager.Camera.transform.position);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layer))
            {
                t = hit.collider.GetComponent<T>();
            }

            return t;
        }

        protected List<T> GetObjectsWithMouseRay<T>(string tag, LayerMask layer)
        {
            List<T> ls = new List<T>();

            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] allHits = Physics.RaycastAll(ray, 100f, layer);
            if (allHits.Length > 0)
            {
                foreach (RaycastHit h in allHits)
                {
                    if (h.collider.CompareTag(tag))
                    {
                        T t = h.collider.GetComponent<T>();

                        if (t != null)
                        {
                            ls.Add(t);
                        }
                    }
                }
            }

            return ls;
        }

        protected List<T> GetObjectsWithMouseRay<T>(string tag)
        {
            List<T> ls = new List<T>();

            Ray ray = CameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] allHits = Physics.RaycastAll(ray, 100f);
            if (allHits.Length > 0)
            {
                foreach (RaycastHit h in allHits)
                {
                    if (h.collider.CompareTag(tag))
                    {
                        T t = h.collider.GetComponent<T>();

                        if (t != null)
                        {
                            ls.Add(t);
                        }
                    }
                }
            }

            return ls;
        }

        #endregion
    }
}
