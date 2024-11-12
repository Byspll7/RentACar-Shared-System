

namespace Layout.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
               new() { Id = 1, Name = "Hyundai", Price = 1000, Stock = 200 },
               new () { Id = 2, Name = "Mercedes", Price = 5000, Stock = 100 },
               new () { Id = 3, Name = "Tesla", Price = 2000, Stock = 120 }
        };



       
        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);
        
        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if(hasProduct == null)
            {
                throw new Exception($"We have not product in this({id})");
            }

            _products.Remove(hasProduct);
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
            {
                if(hasProduct==null)
                {
                    throw new Exception($"We have not product in this({updateProduct.Id})");
                }
                hasProduct.Name = updateProduct.Name;
                hasProduct.Price = updateProduct.Price;
                hasProduct.Stock = updateProduct.Stock;

                var index = _products.FindIndex(x => x.Id == updateProduct.Id);

                _products[index] = hasProduct;
            }
        }
        
    }
}
