using Game.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Interactables.Gate
{
    public class GateUnitCountChanges : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lengthGateCount;
        [SerializeField] private TextMeshProUGUI widthGateCount;

        private void Awake()
        {
            StackManager.ChangeLengthTextObserver += TextLengthValue;
            StackManager.ChangeWidthTextObserver += TextWidthValue;
        }

        private void OnDestroy()
        {
            StackManager.ChangeLengthTextObserver -= TextLengthValue;
            StackManager.ChangeWidthTextObserver -= TextWidthValue;
        }

        private void TextLengthValue(int length, int width)
        {
            lengthGateCount.text = length < 0 ? "" + (length * width) : "+ " + (length * width);
        }

        private void TextWidthValue(int length, int width)
        {
            widthGateCount.text = width < 0 ? "" + (length * width) : "+ " + (length * width);
        }
    }
}