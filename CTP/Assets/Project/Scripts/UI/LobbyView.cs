using RedPanda.Project.Services;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        private const string LOBBY_VIEW = "LobbyView";
        private const string PROMOS_VIEW = "PromoView";
        
        [SerializeField] private Button _startButton;
        private void Awake()
        {
            _startButton.onClick.AddListener(ShowPromos);
            //Example for services
            //var promoService = Container.Locate<IPromoService>();
          //  promoService.GetPromos();
          
        }

        private void ShowPromos()
        {
            UIService.Close(LOBBY_VIEW);
            UIService.Show(PROMOS_VIEW);
        }
    }
}