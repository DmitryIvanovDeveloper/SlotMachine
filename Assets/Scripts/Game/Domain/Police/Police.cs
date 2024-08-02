using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Police;

namespace SlotMachine.Game.Domain.Police
{
    public class Police : MonoBehaviour
    {
        [SerializeField]
        private IPoliceInfo _policeInfo;

        [SerializeField]
        private GameObject _arrestedMenu;

        [Inject]
        public void Construct(IPoliceInfo policeInfo)
        {
            policeInfo.OnDoWork += Active;
            policeInfo.OnArrested += ShowArrestedMenu;
        }

        private void Active()
        {
            gameObject.SetActive(true);
        }

        private void ShowArrestedMenu()
        {
            _arrestedMenu.SetActive(true);
        }
    }
}


