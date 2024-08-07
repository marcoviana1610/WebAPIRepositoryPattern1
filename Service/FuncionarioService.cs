using WebAPIRepositoryPattern.DataContext;
using WebAPIRepositoryPattern.Models;

namespace WebAPIRepositoryPattern.Service
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AppDbContext _context;
        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        #region Create
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {

                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencha todos os dados necessários!";
                    serviceResponse.Sucesso = false;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.FuncionariosDB.ToList();
                serviceResponse.Mensagem = "Funcionario adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Ocorreu um erro";
            }

            return serviceResponse;
        }
        #endregion

        #region Delete
        public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetById
        public Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetAll
        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.FuncionariosDB.ToList();
                serviceResponse.Mensagem = "Funcionarios listados com sucesso";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Ocorreu um erro ao tentar listar os funcionarios";
            }

            return serviceResponse;
        }
        #endregion

        #region InativaFuncionario
        public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
