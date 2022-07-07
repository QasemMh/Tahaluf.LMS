﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.LMS.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        public void Save();
    }
}