using System;

namespace OdnoklassnilkiAppPromoInfo
{
  class OdnoklassnikiAppsPromoValidator
  {
    private const int MaxDayTimeSpan = 3;
    private const int MinTextLength = 8;
    private const int MaxTextLength = 48;

    private readonly OdnoklassnikiAppsPromoRequestModel _model;

    public OdnoklassnikiAppsPromoValidator(OdnoklassnikiAppsPromoRequestModel model)
    {
      _model = model;
    }

    public void Validate()
    {
      if (_model.StartTime <= DateTime.UtcNow)
      {
        throw new Exception();
      }
      if (_model.EndTime <= _model.StartTime)
      {
        throw new Exception();
      }
      if (_model.EndTime - _model.StartTime > TimeSpan.FromDays(MaxDayTimeSpan))
      {
        throw new Exception();
      }
      if (string.IsNullOrEmpty(_model.Text) || _model.Text.Length < MinTextLength || _model.Text.Length > MaxTextLength)
      {
        throw new Exception();
      }
    }
  }
}
