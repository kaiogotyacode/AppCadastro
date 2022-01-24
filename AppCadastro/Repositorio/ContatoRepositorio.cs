using AppCadastro.Data;
using AppCadastro.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppCadastro.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            /*Gravar no Banco*/
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contadoDB = ListarPorId(contato.Id);

            if (contadoDB == null) throw new System.Exception("Erro ao atualizar usuário...");

            contadoDB.Nome  = contato.Nome; 
            contadoDB.Email = contato.Email;
            contadoDB.Senha = contato.Senha;

            _bancoContext.Contatos.Update(contadoDB);
            _bancoContext.SaveChanges();

            return contadoDB;

        }

        public bool Apagar(int id)
        {
            ContatoModel contadoDB = ListarPorId(id);

            if (contadoDB == null) throw new System.Exception("Erro ao excluir usuário...");

            _bancoContext.Contatos.Remove(contadoDB);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
