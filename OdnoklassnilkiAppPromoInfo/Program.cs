using System;

namespace OdnoklassnilkiAppPromoInfo
{
  class Program
  {
    private const string url = "https://api.ok.ru/fb.do";

    private const string appKey = "CBAJDKJKBBABABABA";
    private const string appSecretKey = "FED2967B692E95E6FD0A26C8";

    static void Main()
    {
      var client = new OdnoklassnikiAppPromoClient(url);

      /*var setres = client.SetAppPromoInfo(appKey, appSecretKey,
        65837432777542, "Настало время вступить в кровопролитную войну!", new DateTime(2017, 6, 12, 17, 30, 0), new DateTime(2017, 6, 12, 17, 31, 0));*/
      var res = client.GetAppPromoInfo(appKey, appSecretKey);

      Console.WriteLine(res.IsEmpty);

      Console.ReadKey();
    }
  }
}
