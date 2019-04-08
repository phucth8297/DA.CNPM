using Microsoft.EntityFrameworkCore;
using MyAlarm.EFStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class MemberLogic : BaseLogic
    {
        public MemberLogic(string connectionString) : base(connectionString)
        {

        }
        public MemberLogic(dataContext dbContext) : base(dbContext)
        {

        }
        public IQueryable<Member> GetAllAsync()
        {
            //CheckRole(employee, ListAccessRoleCode);

            IQueryable<Member> query = _DbContext.Member;
            query = query.AsNoTracking();
            return query;
        }
    }
}
