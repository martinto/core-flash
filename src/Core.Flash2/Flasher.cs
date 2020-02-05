using Core.Flash2.Extensions;
using Core.Flash2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace Core.Flash2
{
    public class Flasher : IFlasher
    {
        private readonly ITempDataDictionary tempData;

        public Flasher(ITempDataDictionaryFactory factory, IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor?.HttpContext != null)
            {
                tempData = factory.GetTempData(contextAccessor.HttpContext);
            }
        }

        public void Flash(string type, string message, bool dismissable = false)
        {
            if (tempData is ITempDataDictionary)
            {
                var messages = tempData.Get<Queue<Message>>(Constants.Key) ?? new Queue<Message>();
                messages.Enqueue(new Message(type, message, dismissable));
                tempData.Put(Constants.Key, messages);
            }
        }
    }
}
