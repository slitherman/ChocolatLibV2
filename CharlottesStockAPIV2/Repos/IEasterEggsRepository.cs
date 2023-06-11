using ChocolatLibV2;

namespace CharlottesStockAPIV2.Repos
{
    public interface IEasterEggsRepository
    {
        List<EasterEgg> GetAllEasterEggs();
        EasterEgg? GetEasterEggByProductNo(int productNo);
        List<EasterEgg> GetLowStock(int stock);
        EasterEgg? Update(EasterEgg easterEgg);
    }
}