using RedPanda.Project.Data;

namespace RedPanda.Project.Interfaces
{
    public interface IPromoModel
    {
        string Title { get; }
        string GetIcon();
        string GetRarityBackground();
        PromoType Type { get; }
        PromoRarity Rarity { get; }
        int Cost { get; }
    }
}