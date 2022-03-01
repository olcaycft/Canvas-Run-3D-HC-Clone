using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    public static class Extentions
    {
        private static Camera _camera;

        public static Camera Camera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }

        private static readonly Dictionary<float, WaitForSeconds> WaitDictionary =
            new Dictionary<float, WaitForSeconds>();

        public static WaitForSeconds GetWait(float time)
        {
            if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

            WaitDictionary[time] = new WaitForSeconds(time);
            return WaitDictionary[time];
        }

        private static PointerEventData eventDataCurrentPosition;
        private static List<RaycastResult> results;

        public static bool IsOverUi()
        {
            eventDataCurrentPosition = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
            results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }