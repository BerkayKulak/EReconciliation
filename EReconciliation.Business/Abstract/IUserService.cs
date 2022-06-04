﻿using EReconciliation.Core.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user, int companyId);
        void Add(User user);
        User GetByMail(string email);
    }
}
