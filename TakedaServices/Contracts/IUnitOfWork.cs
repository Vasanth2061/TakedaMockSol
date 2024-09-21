using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakedaServices.Contracts
{
    public interface IUnitOfWork
    {
        public IColleagueRepository ColleagueRepository { get; }

        public IMemberRepository MemberRepository { get; }

        public ITrainingActivityRepository TrainingActivityRepository { get; }
        Task Save();
    }
}
