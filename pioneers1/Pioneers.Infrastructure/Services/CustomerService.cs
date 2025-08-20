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

public class CustomerService
{
    private readonly IGenericRepository<Customer> _repo;
    private readonly IMapper _mapper;

    public CustomerService(IGenericRepository<Customer> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var customers = await _repo.GetAllAsync();
        return customers.Select(c => _mapper.Map<CustomerDto>(c)).ToList();
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return e is null ? null : _mapper.Map<CustomerDto>(e);
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
    {
        var e = _mapper.Map<Customer>(dto);
        await _repo.AddAsync(e);
        return _mapper.Map<CustomerDto>(e);
    }

    public async Task<CustomerDto> UpdateAsync(UpdateCustomerDto dto)
    {
        var e = await _repo.GetByIdAsync(dto.Id) ?? throw new KeyNotFoundException("Customer not found");
        _mapper.Map(dto, e);
        await _repo.UpdateAsync(e);
        return _mapper.Map<CustomerDto>(e);
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id) ?? throw new KeyNotFoundException("Customer not found");
        await _repo.DeleteAsync(e);
    }
}