using Spike.ProjectX.Api.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spike.ProjectX.Api.Example.Subscribers
{
    public class UserAccountObserver : IObserver<UserAccountEvent>
    {
        public void OnCompleted() => Console.WriteLine($"onCOmpleted: {nameof(UserAccountObserver)}");

        public void OnError(Exception error) => Console.WriteLine(error);
        public void OnNext(UserAccountEvent value) => Console.WriteLine(value);
    }
}
