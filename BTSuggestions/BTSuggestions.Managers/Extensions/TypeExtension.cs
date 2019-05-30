using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.RequestObjects;
using BTSuggestions.Managers.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.Managers.Extensions
{
    public static class TypeExtension
    {
        public static TypeResponseList TypeToListResponse(this IEnumerable<TypeEntity> me)
        {
            var resp = new TypeResponseList
            {
                TotalResults = me.Count(),
                TypesList = me.Select(x => x.TypeToListItem()).ToList()
            };
            return resp;
        }
        public static TypeResponse TypeToListItem(this TypeEntity me)
        {
            return new TypeResponse()
            {
                TypeId = me.Id,
                Name = me.Name,
                PainPoint = me.PainPoint,
                PainPointId = me.PainPointId

            };
        }
        public static TypeEntity TypeToDbItem(this TypeRequest me, TypeEntity updating = null)
        {
            if (updating == null)
            {
                updating = new TypeEntity();
            }
            updating.Id = me.TypeId;
            updating.Name = me.Name;
            updating.PainPoint = me.PainPoint;
            updating.PainPointId = me.PainPointId;
            return updating;
        }
    }
}
