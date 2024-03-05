using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.DTOs;
using Web_API_Proyecto_final.models;

namespace Web_API_Proyecto_final.Services
{
    public class ProductService
    {
        private readonly DatabaseContext context;
        public ProductService(DatabaseContext dbcontext)
        {
            this.context = dbcontext;
        }

        public bool AddProduct(ProductDTO product) {
            return true;
        }
        public IEnumerable <ProductDTO> GetAllProducts()
        {
            var product = context.Products.ToList();
            var productDTOs = product.Select(product => new ProductDTO{
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            });
            return productDTOs;
        }

        public bool DeleteProductById(int id)
        {
            Product? product = this.context.Products.Where(p => p.Id == id).FirstOrDefault();
            if(product != null)
            {
                this.context.Remove(product);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateProduct(int id, ProductDTO productDTO)
        {
            Product? product = this.context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (product != null)
            {
                product.Name = productDTO.Name ?? product.Name;
                product.Description = productDTO.Description ?? product.Description;
                product.Category = productDTO.Category ?? product.Category;
                product.UsersId = productDTO.UsersId ?? product.UsersId;

                //These WILL BE CHANGED
                product.BuyPrice = productDTO.BuyPrice;
                product.SellPrice = productDTO.SellPrice;
                product.TotalProduct = productDTO.TotalProduct;
                product.Stock = productDTO.Stock;


                this.context.Update(product);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
