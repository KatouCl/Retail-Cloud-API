using System.Collections.Generic;

namespace RetailCloud.Api.Errors
{
    /// <summary>
    ///     <example>
    ///     Писать методах контроллера
    ///     return BadRequest(new APIValidationErrorResponce { Errors= new [] {"Emial is already in use" } });
    ///     </example>
    /// </summary>
    public class APIValidationErrorResponse : APIResponse
    {
        public APIValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}