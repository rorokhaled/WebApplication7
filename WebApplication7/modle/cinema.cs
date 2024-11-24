using System.Text.Json.Serialization;

namespace WebApplication7.modle
{
    public class cinema
    {
        public int id {  get; set; }    
        public string name { get; set; }
      [JsonIgnore]  public List<movie>? movies { get; set; }
    }
}
