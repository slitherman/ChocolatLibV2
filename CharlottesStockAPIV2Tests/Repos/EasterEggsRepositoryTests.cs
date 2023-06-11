using Microsoft.VisualStudio.TestTools.UnitTesting;
using CharlottesStockAPIV2.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlottesStockAPIV2.Repos.Tests
{
    [TestClass()]
    public class EasterEggsRepositoryTests
    {

        public IEasterEggsRepository EasterEggsRepository = new EasterEggsRepository();


        [TestMethod()]
        public void GetAllEasterEggsTest()
        {
            Assert.AreEqual(5, EasterEggsRepository.GetAllEasterEggs().Count);
        }
        
  

        [TestMethod()]
        public void GetEasterEggByProductNoTest()
        {
            Assert.AreEqual(1, EasterEggsRepository.GetEasterEggByProductNo(1)?.ProductNo);
        }

        [TestMethod()]
        public void GetLowStockTest()
        {
            int stock = 5;
            var result = EasterEggsRepository.GetLowStock(stock);
            Assert.AreEqual(result.All(result => result.InStock <= stock), true);
           
        }   
    }
}