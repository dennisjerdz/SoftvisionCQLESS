using CognizantQLESS.Core.Models;
using CognizantQLESS.Core.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CognizantQLESS.UnitTests
{
    [TestClass]
    public class Reloading_UnitTests
    {
        [TestMethod]
        public void Reload_CashValid_IsTrue_AmountValid_IsTrue()
        {
            List<LoadViewModel> loadList = new List<LoadViewModel>
            {
                new LoadViewModel{
                    Cash = 100,
                    Amount = 100
                },
                new LoadViewModel{
                    Cash = 1000,
                    Amount = 100
                }
            };

            foreach(var item in loadList)
            {
                Assert.IsTrue(item.IsCashAmountValid);
                Assert.IsTrue(item.IsAmountValid);
            }
        }

        [TestMethod]
        public void Reload_CashValid_IsTrue_AmountValid_IsFalse()
        {
            List<LoadViewModel> loadList = new List<LoadViewModel>
            {
                new LoadViewModel{
                    Cash = 100,
                    Amount = 99
                },
                new LoadViewModel{
                    Cash = 1000,
                    Amount = 10
                },
                new LoadViewModel{
                    Cash = 11000,
                    Amount = 11000
                },
            };

            foreach (var item in loadList)
            {
                Assert.IsTrue(item.IsCashAmountValid);
                Assert.IsFalse(item.IsAmountValid);
            }
        }

        [TestMethod]
        public void Reload_CashValid_IsFalse_AmountValid_IsTrue()
        {
            List<LoadViewModel> loadList = new List<LoadViewModel>
            {
                new LoadViewModel{
                    Cash = 50,
                    Amount = 100
                },
                new LoadViewModel{
                    Cash = 9000,
                    Amount = 10000
                }
            };

            foreach (var item in loadList)
            {
                Assert.IsFalse(item.IsCashAmountValid);
                Assert.IsTrue(item.IsAmountValid);
            }
        }
    }


}
