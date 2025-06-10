using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.SignalR.Client;
using Spike.ProjectX.Api.Events;

namespace Spike.ProjectX.Api.Tests.Hubs
{
    public class EventHubTests
    {
        [Fact]
        public void Publish_ShouldThrowArgumentNullException_WhenProvidedEventIsNull()
        {
            HubConnection providedConnection = null!;
            var providedName = "AFunctionName";

            Assert.Throws<ArgumentNullException>(() => new StubEventHub(providedConnection, providedName));
        }

        // It's difficult to unit test with the HubConnection since there's no way to stub or mock
        // out the SignalR client.
        public void Publish_ShouldThrowArgumentException_WhenProvidedPublishMethodNameIsEmpty()
        {
            HubConnection providedConnection = A.Fake<HubConnection>();
            var providedName = "";

            Assert.Throws<ArgumentException>(() => new StubEventHub(providedConnection, providedName));
        }

    }

    public class StubEventHub : EventHub<Stub>
    {
        public StubEventHub(HubConnection connection, string publishMethodName)
            : base(connection, publishMethodName)
        {
        }
        public override string PublishMethodName => "TestPublishMethod";
        public void Publish(Stub @event)
        {
            base.Publish(@event);
        }
    }
}
