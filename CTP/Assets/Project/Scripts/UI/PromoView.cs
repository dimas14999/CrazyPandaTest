using System.Collections.Generic;
using System.Linq;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Core.Shop;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public class PromoView : View
    {
        [SerializeField] private Text _coinText;
        [SerializeField] private PackBundle _packBundle;
        [SerializeField] private Transform _parentPackBundle;
        
        private IPromoService _promoService;
        private IUserService _userService;
        private IReadOnlyList<IPromoModel> _promoModels = new List<IPromoModel>();

        [Import]
        public void Inject(IPromoService promoService, IUserService userService)
        {
            _promoService = promoService;
            _userService = userService;
        }

        private void Start()
        {
            _promoModels = _promoService.GetPromos();
            _coinText.text = $"{_userService.Currency}";
            _userService.OnChangedCurrency += count => _coinText.text = $"{count}";
            InitPacks();
        }

        private void InitPacks()
        {
            PackBundle chestPack = Instantiate(_packBundle, _parentPackBundle);
            PackBundle inAppPack = Instantiate(_packBundle, _parentPackBundle);
            PackBundle specialPack = Instantiate(_packBundle, _parentPackBundle);
              
            chestPack.Init(PromoModels(PromoType.Chest), _userService);
            inAppPack.Init(PromoModels(PromoType.InApp), _userService);
            specialPack.Init(PromoModels(PromoType.Special), _userService);
        }

        private List<IPromoModel> PromoModels(PromoType promoType)
        {
            return _promoModels.Where(x => x.Type == promoType).OrderByDescending(x => x.Rarity).ThenByDescending(x => x.Cost).ToList();
        }
    }
}