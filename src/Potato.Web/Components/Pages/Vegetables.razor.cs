using Microsoft.AspNetCore.Components;
using Potato.Application.Models.ViewModels;
using Potato.Domain.Services.Abstractions;
using Potato.Web.Components.Shared;

namespace Potato.Web.Components.Pages
{
    public partial class Vegetables : CustomComponent
    {
        protected VegetablesListViewModel Model { get; set; } = new();

        [Inject] public required IServiceScopeFactory ServiceScopeFactory { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var scope = ServiceScopeFactory.CreateAsyncScope();
            var repository = scope.ServiceProvider.GetRequiredService<IVegetableRepository>();

            var vegetables = await repository.GetAsync(_ => true, CancellationToken);
            Model = new VegetablesListViewModel
            {
                Vegetables = vegetables.Select(x => new VegetableViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
        }
    }
}
