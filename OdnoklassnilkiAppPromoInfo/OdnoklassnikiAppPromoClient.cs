using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace OdnoklassnilkiAppPromoInfo
{
  class OdnoklassnikiAppPromoClient
  {
    private readonly string _url;

    private const string GetAppPromoInfoMethod = "apps.getAppPromoInfo";
    private const string SetAppPromoInfoMethod = "apps.setAppPromoInfo";
    private const string DateFormat = "yyyy.MM.dd HH:mm";

    public OdnoklassnikiAppPromoClient(string url)
    {
      _url = url;
    }

    public OdnoklassnikiResponseModel GetAppPromoInfo(string applicationKey, string applicationSecretKey)
    {
      using (var client = new HttpClient())
      {
        var parameters = BuildRequestParams(new Dictionary<string, string>
        {
          {OdnoklassnikiParametersMetadata.ApplicationKey, applicationKey},
          {OdnoklassnikiParametersMetadata.Method, GetAppPromoInfoMethod}
        }, applicationSecretKey);

        var response = client.GetAsync(_url + parameters);
        var responseString = response.Result.Content.ReadAsStringAsync().Result;
        return ReadResponse(responseString);
      }
    }

    public OdnoklassnikiResponseModel SetAppPromoInfo(string applicationKey, string applicationSecretKey, long topicId, string text, DateTime startTime, DateTime endTime)
    {
      using (var client = new HttpClient())
      {
        var parameters = BuildRequestParams(new Dictionary<string, string>
        {
          {OdnoklassnikiParametersMetadata.ApplicationKey, applicationKey},
          {OdnoklassnikiParametersMetadata.Method, SetAppPromoInfoMethod},
          {OdnoklassnikiParametersMetadata.TopicId, topicId.ToString()},
          {OdnoklassnikiParametersMetadata.Text, text},
          {OdnoklassnikiParametersMetadata.StartTime, startTime.ToString(DateFormat)},
          {OdnoklassnikiParametersMetadata.EndTime, endTime.ToString(DateFormat)}
        }, applicationSecretKey);

        var response = client.GetAsync(_url + parameters);
        var responseString = response.Result.Content.ReadAsStringAsync().Result;
        return ReadResponse(responseString);
      }
    }

    private static string BuildRequestParams(IDictionary<string, string> parameters, string secretKey)
    {
      var paramsStringBuilder = new StringBuilder();

      foreach (var param in parameters.OrderBy(param => param.Key))
      {
        paramsStringBuilder.AppendFormat("{0}={1}&", param.Key, param.Value);
      }

      var sign = GetSignature(paramsStringBuilder.ToString(), secretKey);

      return string.Format("?{0}{1}={2}", paramsStringBuilder, OdnoklassnikiParametersMetadata.Signature, sign);
    }

    private static string GetSignature(string parameters, string secretKey)
    {
      var md5 = GetMd5Hash(parameters.Replace("&", String.Empty) + secretKey);
      return md5.ToLower(); 
    }
    
    private static string GetMd5Hash(string input)
    {
      var md5Provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
      var bs = Encoding.UTF8.GetBytes(input);
      bs = md5Provider.ComputeHash(bs);
      var s = new StringBuilder();
      foreach (var b in bs)
      {
        s.Append(b.ToString("x2").ToLower());
      }
      return s.ToString();
    }

    private static OdnoklassnikiResponseModel ReadResponse(string response)
    {
      //if (response.Contains(OdnoklassnikiParametersMetadata.ErrorCode))
      //{
      //  throw new Exception(response);
      //}
      return JsonConvert.DeserializeObject<OdnoklassnikiResponseModel>(response);
    }
  }
}
