using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Core.Shop
{
    public class PackItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _background;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Text _coinCost;
        [SerializeField] private Text _title;

        private IUserService _userService;
        private IPromoModel  _promoModel;
    
        private void Start()
        {
            _buyButton.onClick.AddListener(OnBuyPackClick);
        }
        
        public void Init(IPromoModel promoModel, IUserService userService)
        {
            _icon.sprite = Resources.Load<Sprite>(promoModel.GetIcon());
            _background.sprite = Resources.Load<Sprite>(promoModel.GetRarityBackground());
            _coinCost.text = $"x{promoModel.Cost}";
            _title.text = $"{promoModel.Title}";
            _promoModel = promoModel;
            _userService = userService;
        }

        private void OnBuyPackClick()
        {
            //Animation
            
            if (_userService.HasCurrency(_promoModel.Cost))
            {
                _userService.ReduceCurrency(_promoModel.Cost);
                Debug.Log($"Purchase completed: {_promoModel.Title} x{_promoModel.Cost}");   
            }
            else
            {
                Debug.Log("Purchase not completed");
            }
        }
    }
}
