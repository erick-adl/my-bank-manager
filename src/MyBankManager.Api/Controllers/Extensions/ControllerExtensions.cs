using Microsoft.AspNetCore.Mvc;
using MyBankManager.Api.Responses;
using System.Linq;

namespace MyBankManager.Api.Controllers.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ToActionResult(this Controller controller, Response response) =>
            response.Errors != null && response.Errors.Any() ? controller.BadRequest(response.Errors) : (IActionResult)controller.Ok(new { response.Message });
    }
}
