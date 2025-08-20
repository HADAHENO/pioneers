using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pioneers.Application.DTOs;
using Pioneers.Domain.Entities;
using Pioneers.Domain.Repositories;

namespace Pioneers.Infrastructure.Services;

public class CountryService
{
    private readonly IGenericRepository<Country> _repo;
    private readonly IMapper _mapper;
    public CountryService(IGenericRepository<Country> repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

    public async Task<List<CountryDto>> GetAllAsync() =>
        (await _repo.GetAllAsync()).Select(_mapper.Map<CountryDto>).ToList();

    public async Task<CountryDto?> GetByIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return e is null ? null : _mapper.Map<CountryDto>(e);
    }

    public async Task<CountryDto> CreateAsync(CreateCountryDto dto)
    {
        var e = _mapper.Map<Country>(dto);
        await _repo.AddAsync(e);
        return _mapper.Map<CountryDto>(e);
    }

    public async Task<CountryDto> UpdateAsync(UpdateCountryDto dto)
    {
        var e = await _repo.GetByIdAsync(dto.Id) ?? throw new KeyNotFoundException("Country not found");
        _mapper.Map(dto, e);
        await _repo.UpdateAsync(e);
        return _mapper.Map<CountryDto>(e);
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id) ?? throw new KeyNotFoundException("Country not found");
        await _repo.DeleteAsync(e);
    }
}