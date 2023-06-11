using ChocolatLibV2;

namespace CharlottesStockAPIV2.Repos
{
    public class EasterEggsRepository : IEasterEggsRepository
    {
        public List<EasterEgg> EasterEggs;

        public EasterEggsRepository()
        {
            EasterEggs = new List<EasterEgg>()
            {
                new EasterEgg() {ProductNo = 8011, ChocolateType = "Milk", Price = 11, InStock = 30, AmountSold= 100},
                new EasterEgg() {ProductNo = 8012, ChocolateType = "Dark 70%", Price = 16, InStock = 20, AmountSold = 55},
                new EasterEgg() {ProductNo = 8013, ChocolateType = "White", Price = 10, InStock = 15, AmountSold = 25},
                new EasterEgg() {ProductNo = 8014, ChocolateType = "Salted Caramel", Price = 15, InStock = 12, AmountSold = 100},
                new EasterEgg() {ProductNo = 8015, ChocolateType = "Ruby", Price = 40, InStock = 5, AmountSold = 70},




            };
        }

        public List<EasterEgg> GetAllEasterEggs()
        {
            return EasterEggs;
        }

        public EasterEgg? GetEasterEggByProductNo(int productNo)
        {
            return EasterEggs?.FirstOrDefault(e => e.ProductNo == productNo);
        }
        public List<EasterEgg> GetLowStock(int stock)
        {
            return EasterEggs.Where(e => e.InStock < stock || e.InStock == stock).OrderBy(e => e.InStock).ToList();
        }

        public EasterEgg? Update(EasterEgg easterEgg)
        {
            var easterEggToUpdate = GetEasterEggByProductNo(easterEgg.ProductNo);
            if (easterEggToUpdate != null)
            {
                easterEggToUpdate.ChocolateType = easterEgg.ChocolateType;
                easterEggToUpdate.Price = easterEgg.Price;
                easterEggToUpdate.InStock = easterEgg.InStock;
                easterEggToUpdate.AmountSold = easterEgg.AmountSold;
            }
            return easterEggToUpdate;

        }


    }
}
