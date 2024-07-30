using System;
using System.Collections.Generic;
using System.Linq;
using SlotMachine.Business.Domain.Inventory;
using SlotMachine.Game.Domain.Inventory.Events;
using SlotMachine.Game.Util.Extensions;
using UI.Pagination;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SlotMachine.Game.Domain.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _weaponPrefab;

        [SerializeField]
        private PagedRect _weaponsContent;

        [SerializeField]
        private List<InventoryImages> _inventoryImages;

        private IInventoryInfo _inventoryInfo;
        private InventorySelectWeaponEvent _inventorySelectWeaponEvent;

        private List<GameObject> _weapons = new List<GameObject>();


        [Inject]
        public void Construct(IInventoryInfo inventoryInfo, InventorySelectWeaponEvent inventorySelectWeaponEvent)
        {
            _inventoryInfo = inventoryInfo;
            _inventorySelectWeaponEvent = inventorySelectWeaponEvent;
        }

        private void Start()
        {
            InstantiateWeapons();
        }

        private void InstantiateWeapons()
        {
            foreach(var weapon in _inventoryInfo.Weapons)
            {

                var weaponGameObject = Instantiate(_weaponPrefab);
                _weapons.Add(weaponGameObject);

                var name = weaponGameObject.
                    FindChildOrThrow("Name")
                    .GetComponentOrThrow<Text>()
                ;


                name.text = weapon.Value.Name;

                var image = weaponGameObject
                   .FindChildOrThrow("Image")
                   .GetComponentOrThrow<Image>()
                ;

                var expectedInventoryImage = _inventoryImages.FirstOrDefault(inventoryImage => inventoryImage.WeaponType == weapon.Value.WeaponType);
                if (expectedInventoryImage == null)
                {
                    throw new Exception($"The '{weapon.Value.WeaponType}' weaponType is not supported");
                }

                image.sprite = expectedInventoryImage.Image;

                var button = weaponGameObject
                  .FindChildOrThrow("SelectButton")
                  .GetComponentOrThrow<Button>()
                ;


                var isSelected = _inventoryInfo.SelectedWeapon.WeaponType == weapon.Value.WeaponType;

                var selected = weaponGameObject.FindChildOrThrow("Selected");
                selected.SetActive(isSelected);
                button.gameObject.SetActive(isSelected);


                button.onClick.AddListener(delegate {
                    Unselect();

                    _inventorySelectWeaponEvent.Notify(weapon.Value.WeaponType);
                    button.gameObject.SetActive(false);
                    selected.SetActive(true);
                });

                button.gameObject.SetActive(!isSelected);
                selected.SetActive(isSelected);

                var page = weaponGameObject.GetComponentOrThrow<Page>();

                _weaponsContent.AddPage(page);
            }
        }

        private void Unselect()
        {
            foreach (var weapon in _weapons)
            {

                var button = weapon
                  .FindChildOrThrow("SelectButton")
                  .GetComponentOrThrow<Button>()
                ;

                var selected = weapon.FindChildOrThrow("Selected");

                selected.SetActive(false);
                button.gameObject.SetActive(true);
            }
        }
    }
}
