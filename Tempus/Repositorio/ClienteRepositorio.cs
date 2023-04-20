using Tempus.Data;
using Tempus.Models;

namespace Tempus.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            //gravar no banco

            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }

        public ClienteModel Alterar(ClienteModel cliente)
        {
            ClienteModel clienteBanco = BuscarIdCliente(cliente.Id);

            if (clienteBanco == null)
                throw new System.Exception("Houve um erro ao atualizar o cliente.");

            clienteBanco.Nome = cliente.Nome;
            clienteBanco.Cpf = cliente.Cpf;
            clienteBanco.DataNascimento = cliente.DataNascimento;
            clienteBanco.DataCadastro = cliente.DataCadastro;
            clienteBanco.RendaFamiliar = cliente.RendaFamiliar;

            _bancoContext.Clientes.Update(clienteBanco);
            _bancoContext.SaveChanges();

            return clienteBanco;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteBanco = BuscarIdCliente(id);

            if (clienteBanco == null)
                throw new System.Exception("Houve um erro ao deletar o cliente.");

            _bancoContext.Clientes.Remove(clienteBanco);
            _bancoContext.SaveChanges();
            return true;
        }

        public List<ClienteModel> BuscarClientes()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel BuscarIdCliente(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }
    }
}
