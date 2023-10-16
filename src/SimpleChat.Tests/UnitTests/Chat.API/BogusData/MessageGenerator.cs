using Bogus;
using SimpleChat.Core.Entities;

namespace SimpleChat.Tests.UnitTests.Chat.API.BogusData
{
    public class MessageGenerator
    {
        public Message GenerateFakeMessage()
        {
            return new Faker<Message>()
                .RuleFor(message => message.Id, faker => faker.Random.Number(1, int.MaxValue))
                .RuleFor(message => message.Content, faker => faker.Lorem.Sentence())
                .Generate();
        }
    }
}
