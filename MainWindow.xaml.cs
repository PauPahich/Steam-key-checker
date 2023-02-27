using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Steam_key_checker
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindingGame(object sender, RoutedEventArgs e)
        {
            string textSearch = search.Text;

            string textPriceZaka = "";
            string urlZaka = "";

            string textPriceGS = "";
            string urlGS = "";

            string textPriceSB = "";
            string urlSB = "";

            string textPriceSP = "";
            string urlSP = "";

            string textPriceGR = "";
            string urlGR = "";

            string textPriceGama = "";
            string urlGama = "";

            Zaka(textSearch, out textPriceZaka, out urlZaka);
            GabeStore(textSearch, out textPriceGS, out urlGS);
            SteamBuy(textSearch, out textPriceSB, out urlSB);
            SteamPay(textSearch, out textPriceSP, out urlSP);
            GameRay(textSearch, out textPriceGR, out urlGR);
            Gama(textSearch, out textPriceGama, out urlGama);

            priceZaka.Text = textPriceZaka;
            priceGS.Text = textPriceGS;
            priceSB.Text = textPriceSB;
            priceSP.Text = textPriceSP;
            priceGR.Text = textPriceGR;
            priceGG.Text = textPriceGama;
        }
        
        public static string Zaka(string textSearch, out string textPriceZaka, out string urlZaka)
        {
            textSearch = textSearch.Replace(" ", "-");
            HtmlWeb site = new HtmlWeb();

            urlZaka = "https://zaka-zaka.com/game/" + textSearch;
            HtmlDocument doc = site.Load(urlZaka);

            HtmlNode findPrice = doc.DocumentNode.SelectSingleNode("//div[@class='price']");

            textPriceZaka = findPrice?.InnerText.Trim().Replace("c", "") + " Руб.";

            return textPriceZaka;
        }

        private void GoToLinkZaka(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://zaka-zaka.com/game/" + search.Text);
            driver.Manage().Window.Maximize();
        }

        public static string GabeStore(string textSearch, out string textPriceGS, out string urlGS)
        {
            textSearch = textSearch.Replace(" ", "-");
            HtmlWeb site = new HtmlWeb();

            urlGS = "https://gabestore.ru/game/" + textSearch;
            HtmlDocument doc = site.Load(urlGS);

            HtmlNode findPrice = doc.DocumentNode.SelectSingleNode("//div[@class='b-card__price-currentprice']");

            textPriceGS = findPrice?.InnerText.Trim().Replace("₽", "") + " Руб.";

            return textPriceGS;
        }

        private void GoToLinkGS(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://gabestore.ru/game/" + search.Text);
            driver.Manage().Window.Maximize();
        }

        public static string SteamBuy(string textSearch, out string textPriceSB, out string urlSB)
        {
            textSearch = textSearch.Replace(" ", "-");
            HtmlWeb site = new HtmlWeb();

            urlSB = "https://steambuy.com/steam/" + textSearch;
            HtmlDocument doc = site.Load(urlSB);

            HtmlNode findPrice = doc.DocumentNode.SelectSingleNode("//div[@class='product-price__cost']");

            textPriceSB = findPrice?.InnerText.Trim().Replace("р", "") + " Руб.";

            return textPriceSB;
        }

        private void GoToLinkSB(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://steambuy.com/steam/" + search.Text);
            driver.Manage().Window.Maximize();
        }

        public static string SteamPay(string textSearch, out string textPriceSP, out string urlSP)
        {
            textSearch = textSearch.Replace(" ", "-");
            HtmlWeb site = new HtmlWeb();

            urlSP = "https://steampay.com/game/" + textSearch;
            HtmlDocument doc = site.Load(urlSP);

            HtmlNode findPrice = doc.DocumentNode.SelectSingleNode("//div[@class='product__current-price']");

            textPriceSP = findPrice?.InnerText.Trim().Replace("руб.", "") + " Руб.";

            return textPriceSP;
        }

        private void GoToLinkSP(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://steampay.com/game/" + search.Text);
            driver.Manage().Window.Maximize();
        }

        public static string GameRay(string textSearch, out string textPriceGR, out string urlGR)
        {
            textSearch = textSearch.Replace(" ", "-");
            HtmlWeb site = new HtmlWeb();

            urlGR = "https://www.gameray.ru/" + textSearch;
            HtmlDocument doc = site.Load(urlGR);

            HtmlNode findPrice = doc.DocumentNode.SelectSingleNode("//span[@itemprop='price']");

            textPriceGR = findPrice?.InnerText.Trim() + " Руб.";

            return textPriceGR;
        }

        private void GoToLinkGR(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.gameray.ru/" + search.Text);
            driver.Manage().Window.Maximize();
        }
        public static string Gama(string textSearch, out string textPriceGama, out string urlGama)
        {
            textSearch = textSearch.Replace(" ", "-");
            HtmlWeb site = new HtmlWeb();

            urlGama = "https://gama-gama.ru/detail/" + textSearch;
            HtmlDocument doc = site.Load(urlGama);

            HtmlNode findPrice = doc.DocumentNode.SelectSingleNode("//div[@style='text-align: center']");

            textPriceGama = findPrice?.InnerText.Trim().Replace("Купить за ", "") + " Руб.";

            return textPriceGama;
        }

        private void GoToLinkGG(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://gama-gama.ru/detail/" + search.Text);
            driver.Manage().Window.Maximize();
        }
    }
}
