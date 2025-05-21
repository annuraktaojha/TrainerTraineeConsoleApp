namespace StockTradingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockMarket market = new StockMarket();
            StockSubscriber subscriber = new StockSubscriber();
            Stock apple = new Stock("AAPL", 150.00m);
            Stock google = new Stock("GOOGL", 2800.00m);
            subscriber.Subscribe(apple);
            subscriber.Subscribe(google);
            market.AddStock(apple);
            market.AddStock(google);
            market.UpdateStockPrice("AAPL", 155.00m);
            market.UpdateStockPrice("GOOGL", 2900.00m);
        }
    }

    public delegate void PriceChangedHandler(string symbol, decimal newPrice);

    public class Stock
    {
        private string symbol;
        private decimal price;
        public Stock(string symbol, decimal price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public event PriceChangedHandler PriceChanged;
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                price = value;
                OnPriceChanged();
            }
        }
        public string Symbol
        {
            get { return symbol; }
        }
        protected virtual void OnPriceChanged()
        {
            PriceChanged?.Invoke(symbol, price);
        }
        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }

    public class StockMarket
    {
        private readonly List<Stock> stocks = new List<Stock>();

        public void AddStock(Stock stock)
        {
            stocks.Add(stock);
        }

        public void UpdateStockPrice(string symbol, decimal newPrice)
        {
            var stock = stocks.FirstOrDefault(s => s.Symbol == symbol);
            if (stock != null)
            {
                stock.UpdatePrice(newPrice);
                Console.WriteLine($"Stock price of {symbol} has changed to {newPrice}");
            }
        }
    }

    public class StockSubscriber
    {
        public void Subscribe(Stock stock)
        {
            stock.PriceChanged += OnPriceChanged;
        }

        private void OnPriceChanged(string symbol, decimal newPrice)
        {
            Console.WriteLine($"The price of {symbol} has changed to { newPrice} "); 
        }
    }

}
