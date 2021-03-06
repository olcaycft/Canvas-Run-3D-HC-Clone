using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class InteractableManager : MonoSingleton<InteractableManager>
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
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
                case InteractableType.Obstacle:
                    StackManager.Instance.DecreaseWidth();
                    break;
                case InteractableType.Diamond:
                    GameManager.Instance.IncreaseDiamond(1);
                    break;
            }

            switch (state)
            {
                case InteractableType.PlinkoX1:
                    GameManager.Instance.IncreaseGold(1);
                    break;
                case InteractableType.PlinkoX2:
                    GameManager.Instance.IncreaseGold(2);
                    break;
                case InteractableType.PlinkoX5:
                    GameManager.Instance.IncreaseGold(5);
                    break;
            }
        }
    }

    public enum InteractableType
    {
        Gate,
        WidthGate,
        LengthGate,
        PlinkoX1,
        PlinkoX2,
        PlinkoX5,
        Obstacle,
        Diamond
    }
}