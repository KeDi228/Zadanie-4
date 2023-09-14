using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeanutButter.TinyEventAggregator;
using Library.Gui;

namespace Library_2023
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();

            mainScreen.Show();
        }

        #region Properties And Methods

        /// <summary>
        /// Service provider.
        /// </summary>
        public static IServiceProvider? ServiceProvider { get; private set; } = null;

        /// <summary>
        /// Creates a host builder.
        /// </summary>
        /// <returns></returns>
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IEventAggregator, EventAggregator>();
                    services.AddSingleton<MainScreen, MainScreen>();
                    services.AddSingleton<BooksScreen, BooksScreen>();
                    services.AddSingleton<ReaderScreen, ReaderScreen>();
                    services.AddSingleton<LendReturnScreen, LendReturnScreen>();
                });
        }

        #endregion // Properties And Methods
    }


}