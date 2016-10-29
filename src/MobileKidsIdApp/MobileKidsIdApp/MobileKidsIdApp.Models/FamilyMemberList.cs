﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FamilyMemberList : BusinessListBase<FamilyMemberList, FamilyMember>
    {
        protected override void AddNewCore()
        {
            var nextId = 0;
            var maxId = this.OrderByDescending(fm => fm.Id).FirstOrDefault();
            if (maxId != null)
                nextId = maxId.Id + 1;

            Add(new FamilyMember { Id = nextId });
        }

        private void Child_Fetch(List<DataAccess.DataModels.FamilyMember> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<FamilyMember>(item));
        }
    }
}
