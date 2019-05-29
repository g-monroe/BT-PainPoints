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
        PainPoint CreatePainPointEntity(string title, string summary, string annotation, int status, User user, int userId,
            string companyName, string companyContact, string companyLocation, string industryType, DateTime createdOn);
        PainPoint UpdatePainPoint(string title, string summary, string annotation, int status, int painPointId);
    }
}
