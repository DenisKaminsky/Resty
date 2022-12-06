using Resty.Data.Interfaces;

namespace Resty.Business.Functionality
{
    public abstract class BaseCommands
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseCommands(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
