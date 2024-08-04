using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Police;
using UnityEngine.SceneManagement;

namespace SlotMachine.Game.Domain.Police
{
    public class Police : MonoBehaviour
    {
        [SerializeField]
        private IPoliceInfo _policeInfo;

        [SerializeField]
        private GameObject _arrestedMenu;
        private ZenjectSceneLoader _zenjectSceneLoader;

        [Inject]
        public void Construct(IPoliceInfo policeInfo, ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
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

        public async void Run()
        {
            await _zenjectSceneLoader.LoadSceneAsync("Levels", LoadSceneMode.Single);
        }
    }
}


