namespace CommonTestUtilities.Requests;

using CashFlow.Communication.Requests;
using Bogus;
using CashFlow.Communication.Enums;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        var faker = new Faker();

        var request = new RequestExpenseJson
        {
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Date = faker.Date.Past(),
            Amount = faker.Random.Decimal(min: 1, max: 1000),
            PaymentType = faker.PickRandom<PaymentType>(),
        };

        return request;
    }
}