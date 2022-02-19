using Smart_Cookers.Dtos.OutletDtos;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class GetSingleOutletProductDto
    {
        public int AvailableQuantity { get; set; }
      
        public GetOutletOrderDto Outlet { get; set; }
        
        public GetProductDto Product { get; set; }
    }
}
