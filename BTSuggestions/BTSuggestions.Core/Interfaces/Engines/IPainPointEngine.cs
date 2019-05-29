using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IPainPointEngine
    {
        IEnumerable<PainPoint> GetPainPoints();
        PainPoint GetPainPoint(int id);
        PainPoint CreatePainPoint(string title, int type, string summary, string annotation,
            string status, User user, int userId, string companyName, string companyConntact,
            string companyLocation, string industryType, DateTime createdOn);
        PainPoint UpdatePainPoint(PainPoint painPoint, string title, string summary, string comments, string status);
    }
}
