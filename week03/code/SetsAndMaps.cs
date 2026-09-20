using System.Text.Json;

public static class SetsAndMaps
{
  public static string[] FindPairs(string[] words)
{
    var seen = new HashSet<string>();
    var pairs = new List<string>();

    foreach (var word in words)
    {
        if (word[0] == word[1])
        {
            seen.Add(word);
            continue;
        }

        var reversed = $"{word[1]}{word[0]}";

        if (seen.Contains(reversed))
        {
            pairs.Add($"{reversed} & {word}");
        }

        seen.Add(word);
    }

    return pairs.ToArray();
}

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length >= 4)
            {
                var degree = fields[3];

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var letterCounts = new Dictionary<char, int>();

        foreach (var letter in word1.ToLower())
        {
            if (letter == ' ')
            {
                continue;
            }

            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }

        foreach (var letter in word2.ToLower())
        {
            if (letter == ' ')
            {
                continue;
            }

            if (!letterCounts.ContainsKey(letter))
            {
                return false;
            }

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
            {
                return false;
            }
        }

        foreach (var count in letterCounts.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;
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

        var earthquakes = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                earthquakes.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return earthquakes.ToArray();
    }
}