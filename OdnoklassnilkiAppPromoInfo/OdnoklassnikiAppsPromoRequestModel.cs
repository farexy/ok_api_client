using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdnoklassnilkiAppPromoInfo
{
  class OdnoklassnikiAppsPromoRequestModel
  {
    public long TopicId { set; get; }
    public string Text { set; get; }
    public DateTime StartTime { set; get; }
    public DateTime EndTime { set; get; }
  }
}
