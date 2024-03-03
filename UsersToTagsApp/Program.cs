using Microsoft.Extensions.DependencyInjection;
using UsersToTagsApp;
using UsersToTagsApp.Core.DataGateways;

var serviceProvider = new ServiceCollection()
    .AddSingleton(new UsersToTagsContextFactory().CreateDbContext(args))
    .AddTransient<IUserGateway, UserGateway>()
    .BuildServiceProvider();

var userGateway = serviceProvider.GetService<IUserGateway>();

var consoleHelper = new ConsoleHelper();

consoleHelper.AddCommand("GetUserById", async () => 
{
    Console.WriteLine("Введите Id пользователя (guid)");
    var id = Guid.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    var user = await userGateway.GetById(id);
});

consoleHelper.AddCommand("GetByIdAndDomain", async () =>
{
    Console.WriteLine("Введите Id пользователя (guid)");
    var id = Guid.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("Введите Domain пользователя");
    var domain = Console.ReadLine();

    var user = await userGateway.GetByIdAndDomain(id, domain);
});

consoleHelper.AddCommand("GetByDomain", async () =>
{
    Console.WriteLine("Введите Domain пользователя");
    var domain = Console.ReadLine();

    Console.WriteLine("Введите номер страницы");
    var page = Console.ReadLine();

    Console.WriteLine("Введите размер страницы");
    var saze = Console.ReadLine();

    var userByDomain = await userGateway.GetByDomain(domain, int.Parse(page), int.Parse(saze));
});

consoleHelper.AddCommand("GetForTag", async () =>
{
    Console.WriteLine("Введите Domain пользователя");
    var domain = Console.ReadLine();

    Console.WriteLine("Введите значение тэга");
    var tagValue = Console.ReadLine();

    var userByTag = await userGateway.GetForTag(domain, tagValue);
});

consoleHelper.Run();