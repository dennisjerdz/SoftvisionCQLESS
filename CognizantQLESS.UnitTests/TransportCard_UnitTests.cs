using CognizantQLESS.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CognizantQLESS.UnitTests
{
    [TestClass]
    public class TransportCard_UnitTests
    {
        [TestMethod]
        public void TransportCard_Valid_IsTrue()
        {
            var now = System.DateTime.Now;
            List<TransportCard> transportCards = new List<TransportCard>
            {
                new TransportCard{
                    PurchaseDate = now
                },
                new TransportCard{
                    LastUsedDate = now.AddYears(-1)
                },
                new TransportCard{
                    LastUsedDate = now.AddYears(-2)
                },
                new TransportCard{
                    LastUsedDate = now.AddYears(-4)
                }
            };

            foreach(var item in transportCards)
            {
                Assert.IsTrue(item.IsValid);
            }
        }

        [TestMethod]
        public void TransportCard_Valid_IsFalse()
        {
            var now = System.DateTime.Now;
            List<TransportCard> transportCards = new List<TransportCard>
            {
                new TransportCard{
                    PurchaseDate = now.AddYears(-6)
                },
                new TransportCard{
                    LastUsedDate = now.AddYears(-7)
                },
                new TransportCard{
                    LastUsedDate = now.AddYears(-8)
                },
                new TransportCard{
                    LastUsedDate = now.AddYears(-5).AddMinutes(-5)
                }
            };

            foreach (var item in transportCards)
            {
                Assert.IsFalse(item.IsValid);
            }
        }

        [TestMethod]
        public void TransportCard_CanBeRegistered_IsTrue()
        {
            var now = System.DateTime.Now;
            List<TransportCard> transportCards = new List<TransportCard>
            {
                new TransportCard{
                    PurchaseDate = now
                },
                new TransportCard{
                    PurchaseDate = now.AddMonths(-5)
                },
                new TransportCard{
                    PurchaseDate = now.AddMonths(-2)
                },
                new TransportCard{
                    PurchaseDate = now.AddMonths(-1)
                }
            };

            foreach (var item in transportCards)
            {
                Assert.IsTrue(item.CanBeRegisteredAsDiscount);
            }
        }

        [TestMethod]
        public void TransportCard_CanBeRegistered_IsFalse()
        {
            var now = System.DateTime.Now;
            List<TransportCard> transportCards = new List<TransportCard>
            {
                new TransportCard{
                    DiscountRegistrationDate = now
                },
                new TransportCard{
                    PurchaseDate = now.AddMonths(-6).AddMinutes(-5)
                },
                new TransportCard{
                    PurchaseDate = now.AddMonths(-7)
                },
                new TransportCard{
                    PurchaseDate = now.AddMonths(-9)
                }
            };

            foreach (var item in transportCards)
            {
                Assert.IsFalse(item.CanBeRegisteredAsDiscount);
            }
        }
    }


}
