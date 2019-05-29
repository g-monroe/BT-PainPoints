using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.RequestObjects;
using BTSuggestions.Managers.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.Managers.Extensions
{
    public static class PainPointExtension
    {
        public static PainPointResponseList ToListResponse(this IEnumerable<PainPoint> me)
        {
            var resp = new PainPointResponseList();
            resp.TotalResults = me.Count();
            resp.PainPointsList = me.Select(x => x.ToListItem()).ToList();
            return resp;
        }
        public static PainPointResponse ToListItem(this PainPoint me)
        {
            return new PainPointResponse()
            {
                User = me.User,
                PriorityLevel = me.PriorityLevel,
                UserId = me.UserId,
                Annotation = me.Annotation,
                ComapnyLocation = me.CompanyLocation,
                CompanyContact = me.CompanyContact,
                CompanyName = me.CompanyName,
                Title = me.Title,
                PainPointId = me.Id,
                CreatedOn = me.CreatedOn.ToString(),
                Summary = me.Summary,
                IndustryType = me.IndustryType,
                Status = me.Status
            };
        }
        public static PainPoint ToDbItem(this PainPointRequest me, PainPoint updating = null)
        {
            if (updating == null)
            {
                updating = new PainPoint();
            }
            updating.User = me.User;
            updating.PriorityLevel = me.PriorityLevel;
            updating.UserId = me.UserId;
            updating.Annotation = me.Annotation;
            updating.CompanyLocation = me.CompanyLocation;
            updating.CompanyContact = me.CompanyContact;
            updating.CompanyName = me.CompanyName;
            updating.Title = me.Title;
            updating.Id = me.PainPointId;
            updating.CreatedOn = me.CreatedOn;
            updating.Summary = me.Summary;
            updating.IndustryType = me.IndustryType;
            updating.Status = me.Status;
            return updating;
        }
    }
}
