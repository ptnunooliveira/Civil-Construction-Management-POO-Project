using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels
{
    public class MaterialViewModel : BaseViewModel
    {

        private readonly Material _material;

        public int ID => _material.ID;
        public string Name => _material.Name;
        public int Qauntity => _material.Quantity;
        public double UnitPrice => _material.UnitPrice;


        public MaterialViewModel(Material material)
        {
            _material = material;
        }
    }
}
