using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IPainPointManager
    {
        IEnumerable<PainPoint> GetPainPoints();
        PainPoint AddNewPainPoint(string title, string summary, string annotation, int status,
            int userId, string companyName, string companyContact, string companyLocation, string industryType, DateTime createdOn);
        PainPoint UpdatePainPoint(int painPointId, string title, string summary, string annotation, int status);
    }
}
