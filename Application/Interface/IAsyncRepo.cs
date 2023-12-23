using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IAsyncRepo<T> : IRepositoryBase<T> where T : class
    {}

    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {}
}
