namespace VendingMachine
{
    public class VendingMachine
    {
        private decimal _currentAmount;
        private string _display;
        private List<CoinType> _coinReturn;
        private Dictionary<ProductType, Product> _products;
        private bool _thankYouDisplayed;

         public VendingMachine()
        {
            _currentAmount = 0.00m;
            _display = "INSERT COIN";
            _coinReturn = new List<CoinType>();
            _thankYouDisplayed = false;

            // Initialize products
            _products = new Dictionary<ProductType, Product>
            {
                { ProductType.Cola, new Product("Cola", 1.00m, ProductType.Cola) },
                { ProductType.Chips, new Product("Chips", 0.50m, ProductType.Chips) },
                { ProductType.Candy, new Product("Candy", 0.65m, ProductType.Candy) }
            };
        }

        // Accept coin based on physical characteristics (simulated with CoinType enum)
        public void InsertCoin(CoinType coinType)
        {
            decimal coinValue = GetCoinValue(coinType);

            if (coinValue > 0)
            {
                // Valid coin - add to current amount
                _currentAmount += coinValue;
                UpdateDisplay();
                Console.WriteLine($"Coin accepted: {coinType} (${coinValue:F2})");
            }
            else
            {
                // Invalid coin - add to coin return
                _coinReturn.Add(coinType);
                Console.WriteLine($"Coin rejected: {coinType} - placed in coin return");
            }
        }
// Get coin value based on physical characteristics
        private decimal GetCoinValue(CoinType coinType)
        {
            // Simulating coin identification by physical characteristics
            switch (coinType)
            {
                case CoinType.Nickel:
                    return 0.05m;
                case CoinType.Dime:
                    return 0.10m;
                case CoinType.Quarter:
                    return 0.25m;
                case CoinType.Penny:
                default:
                    return 0.00m; // Invalid coins have no value
            }
        }
 // Select and attempt to purchase a product
        public void SelectProduct(ProductType productType)
        {
            if (!_products.ContainsKey(productType))
            {
                Console.WriteLine("Invalid product selection");
                return;
            }

            Product selectedProduct = _products[productType];

            if (_currentAmount >= selectedProduct.Price)
            {
                // Sufficient funds - dispense product
                _currentAmount -= selectedProduct.Price;
                _display = "THANK YOU";
                _thankYouDisplayed = true;
                Console.WriteLine($"Product dispensed: {selectedProduct.Name}");
                Console.WriteLine($"Remaining balance: ${_currentAmount:F2}");
            }
            else
            {
                // Insufficient funds - show price
                _display = $"PRICE ${selectedProduct.Price:F2}";
                Console.WriteLine($"Insufficient funds. {selectedProduct.Name} costs ${selectedProduct.Price:F2}");
            }
        }
 // Check the display
        public string CheckDisplay()
        {
            if (_thankYouDisplayed)
            {
                // Reset after showing THANK YOU
                _thankYouDisplayed = false;
                _currentAmount = 0.00m;
                _display = "INSERT COIN";
                return "THANK YOU";
            }

            if (_display.StartsWith("PRICE"))
            {
                // After showing price, return to normal display
                string priceDisplay = _display;
                UpdateDisplay();
                return priceDisplay;
            }

            return _display;
        }
        // Update display based on current state
        private void UpdateDisplay()
        {
            if (_currentAmount > 0)
            {
                _display = $"${_currentAmount:F2}";
            }
            else
            {
                _display = "INSERT COIN";
            }
        }
 // Get coins from coin return
        public List<CoinType> GetCoinReturn()
        {
            List<CoinType> returnedCoins = new List<CoinType>(_coinReturn);
            _coinReturn.Clear();
            return returnedCoins;
        }

        // Get current amount (for testing/debugging)
        public decimal GetCurrentAmount()
        {
            return _currentAmount;
        }

         // Coin return button
        public void ReturnCoins()
        {
            if (_currentAmount > 0)
            {
                Console.WriteLine($"Returning ${_currentAmount:F2} in coins");
                // In a real machine, this would dispense the actual coins
                // For simulation, we'll just reset the amount
                _currentAmount = 0.00m;
                UpdateDisplay();
            }
        }


    }
}