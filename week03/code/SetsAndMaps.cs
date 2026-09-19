using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace week03.code
{
    public static class SetsAndMaps
    {
        public static string[] FindPairs(string[] words)
        {
            var set = new HashSet<string>(words);
            var results = new List<string>();

            foreach (var word in words)
            {
                // Skip words like "aa"
                if (word[0] == word[1]) continue;

                var reversed = new string(new[] { word[1], word[0] });
                if (set.Contains(reversed))
                {
                    var pair = $"{word} & {reversed}";
                    var reversePair = $"{reversed} & {word}";
                    if (!results.Contains(pair) && !results.Contains(reversePair))
                    {
                        results.Add(pair);
                    }
                }
            }

            return results.ToArray();
        }

        public static Dictionary<string, int> SummarizeDegrees(string filename)
        {
            var degrees = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(",");
                if (fields.Length >= 4)
                {
                    var degree = fields[3].Trim();
                    if (!string.IsNullOrEmpty(degree))
                    {
                        if (degrees.ContainsKey(degree))
                            degrees[degree]++;
                        else
                            degrees[degree] = 1;
                    }
                }
            }

            return degrees;
        }

        public static bool IsAnagram(string word1, string word2)
        {
            word1 = word1.Replace(" ", "").ToLower();
            word2 = word2.Replace(" ", "").ToLower();

            if (word1.Length != word2.Length) return false;

            var counts = new Dictionary<char, int>();

            foreach (var c in word1)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            foreach (var c in word2)
            {
                if (!counts.ContainsKey(c)) return false;
                counts[c]--;
                if (counts[c] < 0) return false;
            }

            return counts.Values.All(v => v == 0);
        }

        public static string[] EarthquakeDailySummary()
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();
            using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
            using var reader = new StreamReader(jsonStream);
            var json = reader.ReadToEnd();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            var results = new List<string>();
            if (featureCollection?.Features != null)
            {
                foreach (var feature in featureCollection.Features)
                {
                    var place = feature.Properties.Place;
                    var mag = feature.Properties.Mag;
                    results.Add($"{place} - Mag {mag}");
                }
            }

            return results.ToArray();
        }
    }
}
