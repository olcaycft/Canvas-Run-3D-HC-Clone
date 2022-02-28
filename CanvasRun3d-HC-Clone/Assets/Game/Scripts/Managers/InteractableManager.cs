using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class InteractableManager : MonoSingleton<InteractableManager>
    {
        public void SetInteractable(InteractableType state)
        {
            switch (state)
            {
                case InteractableType.LengthGate:
                    StackManager.Instance.SetNewLength();
                    break;
                case InteractableType.WidthGate:
                    StackManager.Instance.SetNewWidth();
                    break;
            }
        }
    }

    public enum InteractableType
    {
        Gate,
        WidthGate,
        LengthGate
    }
}