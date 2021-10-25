using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace Financeasy.Core
{
    public abstract class BaseController : ControllerBase
    {
        private readonly INotifier _notifier;

        protected BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool IsValidOperation()
            => !_notifier.HasNotifications();

        protected void Notify(string message)
            => _notifier.Notify(message);

        protected void Notify(Exception e)
        {
            var error = e.InnerException == null ? e.Message : e.InnerException.Message;
            Notify(error);
        }

        protected void Notify(ModelStateDictionary modelState)
        {
            foreach (var error in modelState.Values.SelectMany(e => e.Errors))
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                Notify(errorMessage);
            }
        }

        protected new IActionResult Response(ModelStateDictionary modelState)
        {
            Notify(modelState);
            return Response();
        }

        protected new IActionResult Response(Exception expection)
        {
            Notify(expection);
            return Response();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new { success = true, data = result });

            return BadRequest(new { success = false, errors = _notifier.GetNotifications().Select(n => n.Message) });
        }
    }
}