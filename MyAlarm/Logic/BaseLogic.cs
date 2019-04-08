using MyAlarm.EFStandard;
using System;

namespace Logic
{
    public abstract class BaseLogic
    {
        protected dataContext _DbContext { get; private set; }
        public BaseLogic(string connectionString)
        {
            _DbContext = new dataContext(connectionString);
        }

        public BaseLogic(dataContext dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
