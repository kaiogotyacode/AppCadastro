using AppCadastro.Models;
using System.Collections.Generic;

namespace AppCadastro.Repositorio
{
    public interface IContatoRepositorio
    {



        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
