﻿using ApiAluguel.Models;
using ApiAluguel.Models.RequestsModels;

namespace ApiAluguel.Repositories.Interfaces;

public interface IFuncionarioRepositorio
{
    Task<Funcionario> Adicionar(Funcionario funcionario);

    Task<List<Funcionario>> BuscarTodos();

    Task<Funcionario> BuscarPorId(int id);

    Task<bool> VerificarCPF(string cpf);

    Task<bool> VerificarCpfEmOutroId(string cpf, int id);
    Task<Funcionario> Atualizar(NovoFuncionario novoFuncionario, int id);

    Task<bool> Apagar(int id);

   
}
