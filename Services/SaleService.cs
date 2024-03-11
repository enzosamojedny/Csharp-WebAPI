using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.DTOs;
using Web_API_Proyecto_final.models;

namespace Web_API_Proyecto_final.Services
{
    public class SaleService
    {
        private readonly DatabaseContext context;
        public SaleService(DatabaseContext dbcontext)
        {
            this.context = dbcontext;
        }
        public bool AddSale(SaleDTO sale)
        {
            return true;
        }
        public List<Sale> GetAllSales()
        {
            return this.context.Sales.ToList();
        }

        public bool DeleteSaleById(int id)
        {
            Sale? sale = this.context.Sales.Find(id);
            if (sale != null)
            {
                this.context.Remove(sale);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateSale(int id, SaleDTO saleDTO)
        {
            Sale? sale = this.context.Sales.Find(id);

            if (sale != null)
            {
                sale.Comments = saleDTO.Comments ?? saleDTO.Comments;
                sale.UserId = saleDTO.UserId;
                sale.UsersId = saleDTO.UsersId ?? saleDTO.UsersId;
                sale.SalesId = saleDTO.SalesId;
                sale.Sales = saleDTO.Sales;
                sale.Users = saleDTO.Users;

                this.context.Update(sale);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
