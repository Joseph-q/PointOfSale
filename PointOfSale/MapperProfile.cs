using AutoMapper;
using PointOfSale.Identity.Roles.DTOs.Request;
using PointOfSale.Identity.Roles.DTOs.Response;
using PointOfSale.Identity.Users.Controllers.DTOs.Request;
using PointOfSale.Identity.Users.Controllers.DTOs.Responses;
using PointOfSale.Models;
using PointOfSale.Sales.Category.DTOs.Request;
using PointOfSale.Sales.Products.DTOs.Request;
using PointOfSale.Sales.Products.DTOs.Response;
using PointOfSale.Sales.Promotions.DTOs.Request;
using PointOfSale.Sales.Purchases.DTOs.Request;

namespace PointOfSale
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User MAPPING

            // Hashes the password before mapping it to the PasswordHash field.
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.PasswordHash, o => o.MapFrom(s => BCrypt.Net.BCrypt.HashPassword(s.Password)));

            // - If the password is empty, it keeps the current PasswordHash.
            // - If a password is provided, it generates a new hashed password.
            // - If the username is null, it keeps the current Username.
            CreateMap<UpdateUserRequest, User>()
                .ForMember(d => d.PasswordHash, o => o.MapFrom((s, d) =>
                    string.IsNullOrEmpty(s.Password) ? d.PasswordHash // If the password is empty, keep the current hash
                    : BCrypt.Net.BCrypt.HashPassword(s.Password) // If not, generate a new hash
                ))
                .ForMember(d => d.Username, o => o.MapFrom((s, d) => s.Username ?? d.Username)); // If username is null, keep the current one

            // Maps the user's role from the roles list, using the first role if available.
            CreateMap<User, UserDetailResponse>();

            CreateMap<Role, UserRoleResponse>(); // Asegúrate de incluir esta línea

            //Role MAPPING
            CreateMap<CreateRoleRequest, Role>();

            CreateMap<UpdateRoleRequest, Role>()
                .ForMember(d => d.Name, o => o.MapFrom((s, d) => s.Name ?? d.Name))
                .ForMember(d => d.Description, o => o.MapFrom((s, d) => s.Description ?? d.Description));

            CreateMap<Role, RoleResponse>();


            //Products MAPPING
            CreateMap<CreateProductItem, ProductsItem>();
            CreateMap<UpdateProductItem, ProductsItem>()
                .ForMember(d => d.Name, o => o.MapFrom((s, d) => s.Name ?? d.Name)) // If the name in Update Product item is null, retun original name
                .ForMember(d => d.Barcode, o => o.MapFrom((s, d) => s.Barcode ?? s.Barcode))
                .ForMember(d => d.Price, o => o.MapFrom((s, d) => s.Price ?? s.Price))
                .ForMember(d => d.Stock, o => o.MapFrom((s, d) => d.Stock + s.Stock)) // Stock change add if stock
                ;
            CreateMap<ProductsItem, GetProductItemResponse>();

            // Category MAPPING
            CreateMap<CreateUpdateCategoryRequest, ProductCategory>();


            // Promotion MAPPING
            CreateMap<CreatePromotionRequest, Promotion>();
            CreateMap<UpdatePromotionRequest, Promotion>()
            .ForMember(d => d.Name, o => o.MapFrom((s, d) => s.Name ?? d.Name))
            .ForMember(d => d.PorcentageDiscount, o => o.MapFrom((s, d) => s.PorcentageDiscount ?? d.PorcentageDiscount))
            .ForMember(d => d.Description, o => o.MapFrom((s, d) => s.Description ?? d.Description))
            .ForMember(d => d.Active, o => o.MapFrom((s, d) => s.Active ?? d.Active));

            //PURCHASE MAPPING
            CreateMap<ProductToSaleRequest, PurchaseDetail>();


        }
    }
}
