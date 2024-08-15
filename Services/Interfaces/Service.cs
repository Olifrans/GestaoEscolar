using AutoMapper;
using FluentValidation;
using Services.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public class Service<T, TDto> : IService<T, TDto> where T : class where TDto : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TDto> _validator;

        public Service(IRepository<T> repository, IMapper mapper, IValidator<TDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var entity = _mapper.Map<T>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync(int id, TDto dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var entity = await _repository.GetByIdAsync(id);
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
