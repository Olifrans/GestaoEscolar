using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<T, TDto> where T : class where TDto : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> CreateAsync(TDto dto);
        Task UpdateAsync(int id, TDto dto);
        Task DeleteAsync(int id);
    }
}
