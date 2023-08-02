using API.Restaurantes.Domain.Models;
using API.Restaurantes.Domain.Repository;
using Dapper;
using System.Data;

namespace API.Restaurantes.DbRepository.Adapter
{
    public class RestaurantesDbRepositoryAdapter : 
        IRestaurantesWriteDbRepositoryAdapter,
        IRestaurantesReadDbRepositoryAdapter
    {
        private readonly IDbConnection dbConnection;

        static RestaurantesDbRepositoryAdapter() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public RestaurantesDbRepositoryAdapter(
            IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection
                ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<int> GravarRestauranteAsync(Restaurante restaurante)
        {
            var query = @"
                        INSERT INTO [dbo].[Restaurantes]
                               ([Nome]
                               ,[Cnpj]
                               ,[Endereco]
                               ,[Telefone])
                         VALUES
                               (@Nome
                               ,@Cnpj
                               ,@Endereco
                               ,@Telefone);

                        SELECT SCOPE_IDENTITY();";

            var parametros = new DynamicParameters();
            parametros.Add("@Nome", restaurante.Nome);
            parametros.Add("@Cnpj", restaurante.Cnpj);
            parametros.Add("@Endereco", restaurante.Endereco);
            parametros.Add("@Telefone", restaurante.Telefone);

            return dbConnection.ExecuteScalar<int>(query, parametros);
        }

        public async Task<Restaurante> ObterRestaurantePorIdAsync(int id)
        {
            var query = @"
                        SELECT [Id]
                                ,[Nome]
                               ,[Cnpj]
                               ,[Endereco]
                               ,[Telefone]
                        FROM [dbo].[Restaurantes] WITH(NOLOCK)
                        where Id = @Id";

            var parametros = new DynamicParameters();
            parametros.Add("@Id", id);

            var restaurante = await dbConnection.QueryFirstOrDefaultAsync<Restaurante>(query, parametros);

            return restaurante;
        }

        public async Task<IEnumerable<Restaurante>> ObterTodosRestaurantesAsync()
        {
            var query = @"
                        SELECT [Id]
                                ,[Nome]
                               ,[Cnpj]
                               ,[Endereco]
                               ,[Telefone]
                        FROM [dbo].[Restaurantes] WITH(NOLOCK)";

            var listaRestaurantes = await dbConnection.QueryAsync<Restaurante>(query);

            return listaRestaurantes;
        }
    }
}
