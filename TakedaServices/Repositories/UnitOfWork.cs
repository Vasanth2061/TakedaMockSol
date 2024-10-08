﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakedaMockData;
using TakedaServices.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TakedaServices.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IColleagueRepository ColleagueRepository { get; private set; }

        public IMemberRepository MemberRepository { get; private set; }

        public IPersonalImageRepository PersonalImageRepository { get; private set; }

        public ITechnologyRepository TechnologyRepository { get; private set; }

        public IHobbyRepository HobbyRepository { get; private set; }

        public ITrainingActivityRepository TrainingActivityRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ColleagueRepository= new ColleagueRepository(_db);
            MemberRepository= new MemberRepository(_db);
            TrainingActivityRepository= new TrainingActivityRepository(_db);
            TechnologyRepository= new TechnologyRepository(_db);
            HobbyRepository= new HobbyRepository(_db);
            PersonalImageRepository= new PersonalImageRepository(_db);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
