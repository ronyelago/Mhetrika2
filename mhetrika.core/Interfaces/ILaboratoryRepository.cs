﻿using mhetrika.core.Entities;

namespace mhetrika.core.Interfaces
{
    public interface ILaboratoryRepository : IRepositoryBase<Laboratory>
    {
        Laboratory GetByIdWithAddress(int id);
    }
}
