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
        public async Task Update(int id,TrainingActivity obj)
        {
            TrainingActivity DbTrainingActivity = await Get(u => u.Id == id);
            DbTrainingActivity.Name = obj.Name;
            DbTrainingActivity.Description = obj.Description;
            DbTrainingActivity.StartDate = obj.StartDate;
            DbTrainingActivity.EndDate = obj.EndDate;
            _db.TrainingActivities.Update(DbTrainingActivity);
        }
    }
}
