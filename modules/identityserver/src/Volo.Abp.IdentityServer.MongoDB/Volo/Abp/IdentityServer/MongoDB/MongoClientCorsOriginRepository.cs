using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.MongoDB;

namespace Volo.Abp.IdentityServer.MongoDB
{
    public class MongoClientCorsOriginRepository : MongoDbRepository<IAbpIdentityServerMongoDbContext, ClientCorsOrigin>, IClientCorsOriginRepository
    {
        public MongoClientCorsOriginRepository(
            IMongoDbContextProvider<IAbpIdentityServerMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// Get All Client Cors Origins
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetAllClientCorsOrigins(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetMongoQueryable().Select(p => p.Origin).ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
