using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Potato.Domain.Models;
using Potato.Domain.Services.Abstractions;
using Potato.Web.Components.Shared;

namespace Potato.Web.Components.Pages
{
    public partial class Vegetables : CustomComponent
    {
        public VegetablesViewModel Model { get; set; } = new();

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

    public sealed class VegetablesViewModel
    {
        [Required]
        [Range(1, 64)]
        public string Name { get; set; } = null!;
    }
}
