using Bogus;
using Bogus.DataSets;
using SimpleChat.Core.Entities;

namespace SimpleChat.Tests.UnitTests.Chat.API.BogusData
{
    public class UserGenerator
    {
        public User GenerateFakeUser()
        {
            return new Faker<User>()
                .RuleFor(user => user.Id, user => user.Random.Number(1, int.MaxValue))
                .RuleFor(user => user.Name, faker => faker.Person.FullName)
                .Generate();
        }
    }
}