using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Oprazi.Bll.Services;
using Oprazi.Bll.Services.IServices;
using Oprazi.Dto.DTOs;
using Oprazi.Dto.DTOs.Error;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Oprazi.Api.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ErrorResponseDTO Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Your exception
            KeyValuePair<int, string> errorCode = HttpStatusCode.Exception; // Internal Server Error by default

            if (exception is AccessViolationException) errorCode = HttpStatusCode.AccessViolation;
            else if (exception is AppDomainUnloadedException) errorCode = HttpStatusCode.AppDomainUnloaded;
            else if (exception is ApplicationException) errorCode = HttpStatusCode.Application;
            
            Response.StatusCode = errorCode.Key;
            
            var errorResponse = new ErrorResponseDTO();
            errorResponse.Type = exception.GetType().Name;
            errorResponse.Message = errorCode.Value;
            errorResponse.StackTrace = exception.ToString();

            return errorResponse;
        }
    }

    public static class HttpStatusCode
    {
        public static KeyValuePair<int, string> AccessViolation = new KeyValuePair<int, string>(1001, "ERROR.MESSAGE.ACCESSVALIDATION");
        public static KeyValuePair<int, string> AppDomainUnloaded = new KeyValuePair<int, string>(1002, "ERROR.MESSAGE.APPDOMAINUNLOADED");
        public static KeyValuePair<int, string> Application = new KeyValuePair<int, string>(1003, "ERROR.MESSAGE.APPLICATION");
        



        public static KeyValuePair<int, string> Exception = new KeyValuePair<int, string>(9999, "ERROR.MESSAGE.EXCEPTION");
    }
}
