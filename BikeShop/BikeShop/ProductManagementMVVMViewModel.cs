using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    class ProductManagementMVVMViewModel : Notifier
    {
        #region
        private string searchInput;

        public string SearchInput
        {
            get { return searchInput; }
            set
            {
                searchInput = value;
                base.OnPropertyChanged("SearchInput");
                OnSearchInputChanged();
            }
        }

        private IEnumerable<Product> foundProducts;

        public IEnumerable<Product> FoundProducts
        {
            get { return foundProducts; }
            set
            {
                foundProducts = value;
                OnPropertyChanged("FoundProducts");
            }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProducts");
            }
        }

        #endregion

        ProductsFactory factory = new ProductsFactory();

        public ProductManagementMVVMViewModel()
        {
            FoundProducts = Enumerable.Empty<Product>();
        }

        private void OnSearchInputChanged()
        {
            SelectedProduct = null;
            FoundProducts = factory.FindProducts(SearchInput);
        }
    }


}
