using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pioneers.Application.DTOs;
using Pioneers.Domain.Entities;
using Pioneers.Domain.Repositories;

namespace Pioneers.Infrastructure.Services;

public class CityService
{
    private readonly IGenericRepository<City> _repo;
    private readonly IMapper _mapper;

    public CityService(IGenericRepository<City> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<CityDto>> GetAllAsync() =>
        (await _repo.GetAllAsync()).Select(_mapper.Map<CityDto>).ToList();

    public async Task<CityDto?> GetByIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return e is null ? null : _mapper.Map<CityDto>(e);
    }

    public async Task<CityDto> CreateAsync(CreateCityDto dto)
    {
        var e = _mapper.Map<City>(dto);
        await _repo.AddAsync(e);
        return _mapper.Map<CityDto>(e);
    }

    public async Task<CityDto> UpdateAsync(UpdateCityDto dto)
    {
        var e = await _repo.GetByIdAsync(dto.Id) ?? throw new KeyNotFoundException("City not found");
        _mapper.Map(dto, e);
        await _repo.UpdateAsync(e);
        return _mapper.Map<CityDto>(e);
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id) ?? throw new KeyNotFoundException("City not found");
        await _repo.DeleteAsync(e);
    }
}
