using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketCheckout.Offers;

namespace SupermarketCheckout.Tests
{
    [TestClass]
    public class SupermarketChecoutTests
    {
        [TestMethod]
        public void Scan_SingleItem_DoesNotError()
        {
            var offers = new List<IOffer>();
            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("A", 50));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Total_EmptyBasket_TotalCorrect()
        {
            var offers = new List<IOffer>();
            var checkout = new Checkout(offers);

            int total = checkout.Total();

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void Total_EmptyBasket_WithOffers_TotalCorrect()
        {
            var offers = new List<IOffer>()
            {
                new PriceForXOffer("A", 3, 130),
                new PriceForXOffer("B", 2, 45)
            };
            var checkout = new Checkout(offers);

            int total = checkout.Total();

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void Total_BasketScanned_TotalCorrect()
        {
            var offers = new List<IOffer>();
            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));

            int total = checkout.Total();

            Assert.AreEqual(100, total);
        }

        [TestMethod]
        public void Total_BasketScanned_WithInValidOffer_TotalCorrect()
        {
            var offers = new List<IOffer>()
            {
                new PriceForXOffer("A", 3, 130)
            };

            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));

            int total = checkout.Total();

            Assert.AreEqual(100, total);
        }

        [TestMethod]
        public void Total_BasketScanned_WithValidOffer_TotalCorrect()
        {
            var offers = new List<IOffer>()
            {
                new PriceForXOffer("A", 3, 130)
            };

            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));

            int total = checkout.Total();

            Assert.AreEqual(130, total);
        }

        [TestMethod]
        public void Total_BasketScanned_WithMixedValidOffers_TotalCorrect()
        {
            var offers = new List<IOffer>()
            {
                new PriceForXOffer("A", 3, 130),
                new PriceForXOffer("B", 2, 45)
            };

            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));

            checkout.Scan(new BasketItem("B", 30));
            checkout.Scan(new BasketItem("B", 30));

            int total = checkout.Total();

            Assert.AreEqual(175, total);
        }

        [TestMethod]
        public void Total_BasketScanned_WithMixedValidAndInvalidOffers_TotalCorrect()
        {
            var offers = new List<IOffer>()
            {
                new PriceForXOffer("A", 3, 130),
                new PriceForXOffer("B", 2, 45)
            };

            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));
            checkout.Scan(new BasketItem("A", 50));

            checkout.Scan(new BasketItem("B", 30));

            int total = checkout.Total();

            Assert.AreEqual(160, total);
        }

        [TestMethod]
        public void Total_BasketScanned_WithMixedItems_TotalCorrect()
        {
            var offers = new List<IOffer>()
            {
                new PriceForXOffer("A", 3, 130),
                new PriceForXOffer("B", 2, 45)
            };

            var checkout = new Checkout(offers);

            checkout.Scan(new BasketItem("B", 30));

            checkout.Scan(new BasketItem("A", 50));            
            checkout.Scan(new BasketItem("A", 50));
            
            checkout.Scan(new BasketItem("B", 30));
            checkout.Scan(new BasketItem("B", 30));

            checkout.Scan(new BasketItem("A", 50));
            
            checkout.Scan(new BasketItem("C", 20));

            checkout.Scan(new BasketItem("D", 15));

            checkout.Scan(new BasketItem("C", 20));

            int total = checkout.Total();

            Assert.AreEqual(260, total);
        }
    }
}
