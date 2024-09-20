using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakedaMockData;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaServices.Repositories
{
    public class TrainingActivityRepository : Repository<TrainingActivity>, ITrainingActivityRepository
    {
        private ApplicationDbContext _db;
        public TrainingActivityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(TrainingActivity obj)
        {
            _db.TrainingActivities.Update(obj);
        }
    }
}
