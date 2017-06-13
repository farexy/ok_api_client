namespace OdnoklassnilkiAppPromoInfo
{/*
  class OdnoklassnikiSetAppPromoRequestModel : OdnoklassnikiRequestModel
  {
    [JsonProperty("topic_id")] public int TopicId { set; get; }
    [JsonProperty("text")] public string Text{ set; get; }
    [JsonProperty("start_time")] public string StartTime{ set; get; }
    [JsonProperty("end_time")] public string EndTime;

    public override string Signature
    {
      get
      {
        var properties = typeof(OdnoklassnikiSetAppPromoRequestModel).GetProperties()
          .Where(prop => prop.Name != "Signature")
          .OrderBy(prop => prop.Name);

        var paramsStringBuilder = new StringBuilder();
        foreach (var prop in properties)
        {
          var jsonAttribute = prop.GetCustomAttributes().First() as JsonPropertyAttribute;
          paramsStringBuilder.Append(jsonAttribute.PropertyName);
          paramsStringBuilder.Append("=");
          paramsStringBuilder.Append(prop.GetValue(this));
        }
        var md5 = GetMd5Hash(paramsStringBuilder + ApplicationSecretKey);
        return md5.ToLower();
      }
    }

    public override string Method
    {
      get { return "apps.setAppPromoInfo"; }
    }
  }*/
}
