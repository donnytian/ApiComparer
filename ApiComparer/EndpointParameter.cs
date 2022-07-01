using Newtonsoft.Json.Linq;

public class EndpointParameter
{
    public string Key { get; set; }
    public string QueryString { get; set; }
    public string FilePath { get; set; }
    public JToken Body { get; set; }
}
