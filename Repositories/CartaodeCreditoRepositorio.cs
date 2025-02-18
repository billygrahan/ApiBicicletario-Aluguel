﻿

using ApiAluguel.Context;
using ApiAluguel.Models;
using ApiAluguel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiAluguel.Repositories;

public class CartaodeCreditoRepositorio : ICartaodeCreditoRepositorio
{
    private readonly AppDbContext _appDbContext;

    public CartaodeCreditoRepositorio(AppDbContext context)
    {
        _appDbContext = context;
    }

    public async Task<CartaoDeCredito> Adicionar(CartaoDeCredito cartaodecredito)
    {
        await _appDbContext.CartoesDeCreditos.AddAsync(cartaodecredito);
        await _appDbContext.SaveChangesAsync();

        return cartaodecredito;
    }

    public async Task<CartaoDeCredito> BuscarPorId(int id)
    {
        var cartaodecredito = await _appDbContext.CartoesDeCreditos.FirstOrDefaultAsync(c => c.Id == id);

        //tratar erros e null!

        return cartaodecredito;
    }

    public async Task<List<CartaoDeCredito>> BuscarTodos()
    {
        //tratar erros!
        return await _appDbContext.CartoesDeCreditos.ToListAsync();
    }

    public async Task<CartaoDeCredito> Atualizar(CartaoDeCredito cartaodecredito)
    {
        //tratar erros!
        _appDbContext.Entry(cartaodecredito).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();

        return cartaodecredito;
    }

    public async Task<bool> Apagar(int id)
    {
        var cartaodecredito = await _appDbContext.CartoesDeCreditos.FirstOrDefaultAsync(c => c.Id == id);

        //tratar erros e null!

        try
        {
            _appDbContext.CartoesDeCreditos.Remove(cartaodecredito);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        catch
        {
            return false; 
        }
    }
}
