using Auvo.Orm.Core.GraphQL.WebApi.GraphqlCore;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace Auvo.Orm.Core.GraphQL.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphqlQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var inputs = new GraphQLSerializer().Deserialize<Inputs>(query.ToString());

            //var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Variables = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
