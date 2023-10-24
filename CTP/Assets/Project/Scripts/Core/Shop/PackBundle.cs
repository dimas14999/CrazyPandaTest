using System.Collections.Generic;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Core.Shop
{
    public class PackBundle : MonoBehaviour
    {
        [SerializeField] private PackItem _packItem;
        [SerializeField] private Transform _parent;
        [SerializeField] private Text _title;
        
        public void Init(IReadOnlyList<IPromoModel> promoModels, IUserService userService)
        {
            _title.text = $"{promoModels[0].Type}";
            foreach (var promoModel in promoModels)
            {
                PackItem packItem = Instantiate(_packItem, _parent);
            
                packItem.Init(promoModel, userService);
            }
        }
    }
}
