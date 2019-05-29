using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers
{
    public class PainPointManager : IPainPointManager
    {
        private readonly IPainPointEngine _painPointEngine;
        public PainPointManager(IPainPointEngine painPointEngine)
        {
            _painPointEngine = painPointEngine;
        }

        public PainPoint AddNewPainPoint(string title, int type, string summary, string annotation, string status, User user, int userId,
            string companyName, string companyContact, string companyLocation, string industryType, DateTime createdOn)
        {
            return _painPointEngine.CreatePainPoint(title, type, summary, annotation, status, user, userId, companyName, companyContact,
                companyLocation, industryType, createdOn);
        }

        public IEnumerable<PainPoint> GetPainPoints()
        {
            return _painPointEngine.GetPainPoints();
        }

        public PainPoint UpdatePainPoint(int painPointId, string title, string summary, string annotation, string status)
        {
            var painPoint = _painPointEngine.GetPainPoint(painPointId);
            return _painPointEngine.UpdatePainPoint(painPoint, title, summary, annotation, status);
        }
    }
}
