using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Engines
{
    public class PainPointEngine : IPainPointEngine
    {
        private readonly IPainPointHandler __painPointHandler;
        public PainPointEngine(IPainPointHandler painPointHandler)
        {
            __painPointHandler = painPointHandler;
        }

        public PainPoint CreatePainPoint(string title, int type, string summary, string annotation,
            string status, User user, int userId, string companyName, string companyConntact,
            string companyLocation, string industryType, DateTime createdOn)
        {
            var painPoint = new PainPoint
            {
                Title = title,
                Type = type,
                Summary = summary,
                Annontation = annotation,
                Status = status,
                User = user,
                UserId = userId,
                CompanyName = companyName,
                CompanyContact = companyConntact,
                CompanyLocation = companyLocation,
                IndustryType = industryType,
                CreatedOn = createdOn
            };
            __painPointHandler.Insert(painPoint);
            __painPointHandler.SaveChanges();

            return painPoint;
        }

        public PainPoint GetPainPoint(int id)
        {
            var painPoint = __painPointHandler.GetById(id);
            return painPoint;
        }

        public IEnumerable<PainPoint> GetPainPoints()
        {
            return __painPointHandler.GetAll();
        }

        public PainPoint UpdatePainPoint(PainPoint painPoint, string title, string summary, string annotations, string status)
        {
            painPoint.Title = title;
            painPoint.Summary = summary;
            painPoint.Annontation = annotations;
            painPoint.Status = status;

            return painPoint;
        }
    }
}
