using Microsoft.AspNetCore.Components;
using Potato.Application.Models.ViewModels;
using Potato.Domain.Models;
using Potato.Domain.Services.Abstractions;
using Potato.Web.Components.Shared;

namespace Potato.Web.Components.Pages.Controls
{
    public partial class AddVegetableControl : CustomComponent
    {
        public AddVegetableViewModel Model { get; set; } = new ();

        [Inject] public required IServiceScopeFactory ServiceScopeFactory { get; set; }

        protected async Task PlantAsync()
        {
            var scope = ServiceScopeFactory.CreateAsyncScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var vegetable = Vegetable.Create(Model.Name);

            await unitOfWork.VegetablesRepository.AddAsync(vegetable, CancellationToken);
            await unitOfWork.SaveChangesAsync(CancellationToken);
        }
    }
}
