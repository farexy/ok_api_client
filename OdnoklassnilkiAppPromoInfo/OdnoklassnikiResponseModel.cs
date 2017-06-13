using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace OdnoklassnilkiAppPromoInfo
{
  class OdnoklassnikiResponseModel
  {
    [JsonProperty(OdnoklassnikiParametersMetadata.TopicId)]
    public long TopicId { set; get; }
    [JsonProperty(OdnoklassnikiParametersMetadata.Text)]
    public string Text { set; get; }
    [JsonProperty("start")]
    public string StartTime { set; get; }
    [JsonProperty("end")]
    public string EndTime;

    [JsonIgnore]
    public bool IsEmpty
    {
      get
      {
        const string currentPropertyName = "IsEmpty";
        var properties = GetType().GetProperties().Where(prop => prop.Name != currentPropertyName);

        return properties.All(prop =>
            Equals(
              prop.GetValue(this),
              prop.PropertyType
                .IsValueType
                  ? Activator.CreateInstance(prop.PropertyType)
                  : null));
      }
    }
  }
  //class OdnoklassnikiResponseModel
  //{
  //  [JsonProperty(OdnoklassnikiParametersMetadata.TopicId)] public long TopicId { set; get; }
  //  [JsonProperty(OdnoklassnikiParametersMetadata.Text)] public string Text { set; get; }               
  //  [JsonProperty(OdnoklassnikiParametersMetadata.StartTime)] public string StartTime { set; get; }
  //  [JsonProperty(OdnoklassnikiParametersMetadata.EndTime)] public string EndTime;

  //  [JsonProperty("anchor")] public string Anchor { set; get; }
  //  [JsonProperty("etag")] public string Etag { set; get; }
  //  [JsonProperty("has_more")] public bool HasMore { set; get; }
  //  [JsonProperty("success")] public bool Success { set; get; }
  //  [JsonProperty("totalCount")] public int TotalCount { set; get; }

  //  [JsonIgnore]
  //  public bool IsEmpty
  //  {
  //    get
  //    {
  //      const string currentPropertyName = "IsEmpty";
  //      var properties = GetType().GetProperties().Where(prop => prop.Name != currentPropertyName);

  //      return properties.All(prop =>
  //          Equals(
  //            prop.GetValue(this), 
  //            prop.PropertyType
  //              .IsValueType
  //                ? Activator.CreateInstance(prop.PropertyType)
  //                : null));
  //    }
  //  }
  //}
}
