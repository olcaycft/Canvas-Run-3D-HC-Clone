using System;
using Game.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class TextUnitCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI unitText;

        private void OnEnable()
        {
            StackManager.ChangeUnitCountTextObserver += ChangeUnitText;
        }


        private void ChangeUnitText(int length, int width)
        {
            unitText.text = (length * width).ToString();
        }
    }
}