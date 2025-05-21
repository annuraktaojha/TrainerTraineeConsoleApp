using System;

namespace ObserverDesignPattern
{
    internal class Program
    {
       public static void Main(string[] args)
        {
           // create WeatherData (Subject) 
           WeatherData  weatherData = new WeatherData();

            // create Observers and register them with WeatherData

            CurrentConditionsDisplay currentConditionsDisplay =new CurrentConditionsDisplay(weatherData);

            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);

            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

            // simulate new weather measurements

            weatherData.SetMeasurements(80, 65, 30.4f);

            weatherData.SetMeasurements(82, 70, 29.2f);

            weatherData.SetMeasurements(78, 90, 29.2f);

            Console.ReadLine();

        }
    }

    public interface IweatherData
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
    public class WeatherData: IweatherData
    {
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
           observers.Add(observer);
        }

       
        public void NotifyObservers()
        {
            foreach (IObserver observer in observers) 
            {
                observer.Update(temperature, humidity,pressure);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void SetMeasurements(float temperature,float humidity,float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            NotifyObservers();
        }

       
    }

    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface IDisplayELement
    {
        void Display();
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayELement
    {
        private float temperature;
        private float humidity;
        private WeatherData weatherData;
        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
        }
    }

    public class StatisticsDisplay : IObserver, IDisplayELement
    {
        private float temperature;
        private float humidity;
        private WeatherData weatherData;
        public StatisticsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Statistics: {temperature}F degrees and {humidity}% humidity");
        }
    }

    public class ForecastDisplay : IObserver, IDisplayELement
    {
        private float temperature;
        private float humidity;
        private WeatherData weatherData;
        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Forecast: {temperature}F degrees and {humidity}% humidity");
        }
    }
}
