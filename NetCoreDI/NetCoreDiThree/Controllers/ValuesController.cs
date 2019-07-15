using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreDiThree.Infrastructure;

namespace NetCoreDiThree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly OperationService operationService;
        public ValuesController(OperationService _operationService)
        {
            this.operationService = _operationService;
        }

        [HttpGet]
        [Route("GetScopeTransient")]
        public ActionResult<string> GetScopeTransient()
        {
            var firstGuid = this.operationService.TransientOperation.OperationId;
            var secondGuid = this.operationService.TransientOperation.OperationId;

            return $"{firstGuid} and {secondGuid}";
        }

        [HttpGet]
        [Route("GetSingletonScoped")]
        public ActionResult<string> GetSingletonScoped()
        {
            var firstGuid = this.operationService.ScopedOperation.OperationId;
            var secondGuid = this.operationService.ScopedOperation.OperationId;

            return $"{firstGuid} and {secondGuid}";
        }

        [HttpGet]
        [Route("GetSingletonTransient")]
        public ActionResult<string> GetSingletonTransient()
        {
            var firstGuid = this.operationService.TransientOperation.OperationId;
            var secondGuid = this.operationService.TransientOperation.OperationId;

            return $"{firstGuid} and {secondGuid}";
        }
    }
}
