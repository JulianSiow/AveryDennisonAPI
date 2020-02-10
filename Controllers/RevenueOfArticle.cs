namespace AveryDennisonAPI.Controllers
{
    public struct RevenueOfArticle
    {
        public string ArticleNumber { get; set; }
        public double Revenue { get; set; }
        public RevenueOfArticle(string articleNumber, double revenue)
        {
            ArticleNumber = articleNumber;
            Revenue = revenue;
        }
    }
}