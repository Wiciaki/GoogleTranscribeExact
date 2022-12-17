using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json.Linq;

var json = JObject.Parse(File.ReadAllText("transcript.json"));

var sb = new StringBuilder();

foreach (var jobject in json["results"]!)
{
    sb.Append(jobject["alternatives"]![0]!["transcript"]);
    sb.AppendLine();
}

var result = Regex.Replace(sb.ToString(), "yy+", string.Empty);
File.WriteAllText("wynik.txt", result);