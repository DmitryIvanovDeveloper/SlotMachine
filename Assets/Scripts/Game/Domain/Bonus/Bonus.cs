using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Bonus;
using SlotMachine.Business.Common;
using TMPro;
using System.Collections;

namespace SlotMachine.Game.Domain.Bonus
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _bonus;
        [SerializeField]
        private AudioSource _audioSource;

        private IBonusInfo _bonusInfo;
        private int _earnedBonus;

        [Inject]
        public void Contruct(IBonusInfo bonusInfo)
        {
            _bonusInfo = bonusInfo;
            _bonusInfo.OnAddBonus += ShowBonus;

        }

        private void ShowBonus(CoinType coinType, int num)
        {
            _earnedBonus = num;
            gameObject.SetActive(true);
        }

        private void Start()
        {
            StartCoroutine(ShowBonusByDelay());
        }

        private IEnumerator ShowBonusByDelay()
        {
            yield return new WaitForSeconds(1);


            StartCoroutine(DelayedEncrease());


        }

        private IEnumerator DelayedEncrease()
        {
            for (int i = 0; i < _earnedBonus; i++ )
            {
                yield return new WaitForSeconds(1 / 2);
                _bonus.text = $"+ {i}";
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }
    }
}
