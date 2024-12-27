namespace Potato.Application.Models.ViewModels
{
    public sealed class VegetablesListViewModel()
    {
        public IEnumerable<VegetableViewModel> Vegetables { get; init; } = Array.Empty<VegetableViewModel>();
    }

    public sealed class VegetableViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
    };
}
