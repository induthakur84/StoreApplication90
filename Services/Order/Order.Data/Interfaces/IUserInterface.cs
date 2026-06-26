using Order.Dto.DTO.Request;
using Order.Dto.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommonFiles.RegisterDependency;

namespace Order.Data.Interfaces
{

    //PAgeresult{
    //   IEnumerable<T> Items { get; set; }
    //   int TotalCount { get; set; }
    //   int PageSize { get; set; }
    //   int CurrentPage { get; set; }
    //   int Pagenumber { get; set; }
    // 

    [RegisterScoped]
    public interface IUserInterface
    {
        Task<UserResponse> Create(UserRequest request);
        Task<UserResponse> GetById(int id);
        Task<IEnumerable<UserResponse>> GetAll();
        Task<UserResponse> Update(int id, UserRequest request);
        Task<bool> Delete(int id);
    }
}