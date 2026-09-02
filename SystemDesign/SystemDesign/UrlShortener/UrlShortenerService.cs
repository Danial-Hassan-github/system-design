namespace SystemDesign.UrlShortener
{
    public class UrlShortenerService
    {
        Dictionary<string, string> shortToLong = new Dictionary<string, string>();
        Dictionary<string, string> longToShort = new Dictionary<string, string>();

        public string ShortenUrl(string longUrl)
        {
            if (longToShort.TryGetValue(longUrl, out var shortUrl))
                return shortUrl;

            shortUrl = GenerateUniqueShortUrl();

            longToShort.Add(longUrl, shortUrl);
            shortToLong.Add(shortUrl, longUrl);

            return shortUrl;
        }

        public string? ExpandUrl(string shortUrl)
        {
            if (shortToLong.TryGetValue(shortUrl, out var longUrl))
                return longUrl;

            return null;
        }

        private string GenerateUniqueShortUrl()
        {
            string shortUrl;

            do
            {
                string code = Guid.NewGuid().ToString("N").Substring(0, 8);
                shortUrl = "www.sip.sh/" + code;

            } while (shortToLong.ContainsKey(shortUrl));

            return shortUrl;
        }
    }
}
