using Tempus.Models;

namespace Tempus.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteModel BuscarIdCliente(int id);
        List<ClienteModel> BuscarClientes();
        ClienteModel Adicionar(ClienteModel cliente);
        ClienteModel Alterar(ClienteModel cliente);
        bool Apagar(int id);
    }
}
