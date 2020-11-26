using Layered.Common.Contract;
using Layered.Common.WebCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Layered.WebApi.Common
{
    /// <summary>
    /// This abstract controller provides base functionality for handling service calls. 
    /// Furthermore it will do some general rest exception handling and the possibility,
    /// to write custom errors for the clients in a general way.
    /// </summary>
    [ApiController]
    public abstract class CustomController : ControllerBase
    {
        /// <summary>
        /// Handles service requests with reponse data.
        /// </summary>
        /// <typeparam name="T">The type of the response from the service.</typeparam>
        /// <param name="serviceRequest">The service method which called by this method.</param>
        /// <returns>The action result task with the returned service method content.</returns>
        protected async Task<IActionResult> HandleRequestAsync<T>(Func<Task<T>> serviceRequest)
        {
            if (serviceRequest == null) throw new ArgumentNullException(nameof(serviceRequest));

            try
            {
                var response = await serviceRequest();
                if (response == null)
                {
                    var message = $"Service response is null, but it should be returned an object with type {typeof(T)}.";
                    if (HttpContext.Request.Method == HttpMethod.Get.Method)
                        return NotFound(message);
                    else
                        return BadRequest(message);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        /// <summary>
        /// Handles service requests without reponse data.
        /// </summary>
        /// <param name="serviceRequest">The service method which called by this method.</param>
        /// <returns>The action result task.</returns>
        protected async Task<IActionResult> HandleRequestAsync(Func<Task> serviceRequest)
        {
            if (serviceRequest == null) throw new ArgumentNullException(nameof(serviceRequest));

            try
            {
                await serviceRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        private Task<IActionResult> HandleExceptionAsync(Exception ex)
        {
            switch (ex)
            {
                case ValidationResultException e:
                    return Task.FromResult<IActionResult>(BadRequest(e.ValidationResult.ToValidationResponseModel()));
                case BusinessValidationException e:
                    {
                        var responseModel = new ValidationResponseModel();
                        responseModel.AddError(e.PropertyName, e.ValidationKey);
                        return Task.FromResult<IActionResult>(BadRequest(responseModel));
                    }
                case ArgumentNullException e:
                    return Task.FromResult<IActionResult>(BadRequest(ex.Message));
                default:
                    throw ex;
            }
        }
    }
}
