﻿using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Sales.Promotions.DTOs.Request;
using PointOfSale.Sales.Promotions.DTOs.Response;

namespace PointOfSale.Sales.Promotions.Services
{
    public class PromotionService(SalesContext context) : IPromotionService
    {
        private readonly SalesContext _context = context;
        public Task CreatePromotion(Promotion promotion)
        {
            _context.Add(promotion);
            return _context.SaveChangesAsync();
        }

        public async Task DeletePromotion(Promotion promotion)
        {

            _context.Remove(promotion);
            await _context.SaveChangesAsync();
        }

        public Task<List<PromotionResponse>> GetProductPromotions(string barcode, GetPromotionsQueryParams queryParams)
        {
            var chain = _context.Promotions.AsQueryable();


            bool? active = queryParams.Active;

            if (active != null)
            {
                chain = chain.Where(p => p.Active == active);
            }


            return chain.Where(p => p.ProductBarcodes.Any(pr => pr.Barcode.Equals(barcode)))
            .Select(p => new PromotionResponse
            {
                Id = p.Id,
                Active = p.Active,
                Name = p.Name,
                Description = p.Description,
                EndAt = p.EndAt,
                PorcentageDiscount = p.PorcentageDiscount,
                StartAt = p.StartAt
            })
            .ToListAsync();
        }

        // Obtener promoción por ID
        public async Task<Promotion?> GetPromotionById(int id)
        {
            return await _context.Promotions
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Obtener la respuesta de la promoción por ID
        public async Task<PromotionResponse?> GetPromotionResponseById(int id)
        {
            return await _context.Promotions
                                 .Where(p => p.Id == id)
                                 .Select(p => new PromotionResponse
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     PorcentageDiscount = p.PorcentageDiscount,
                                     Active = p.Active,
                                     Description = p.Description,
                                     EndAt = p.EndAt,
                                     StartAt = p.StartAt
                                 })
                                 .FirstOrDefaultAsync();
        }

        // Obtener una lista de promociones con parámetros de consulta
        public async Task<List<Promotion>> GetPromotions(GetPromotionsQueryParams queryParams)
        {
            var chain = _context.Promotions.AsQueryable();

            bool? active = queryParams.Active;


            if (active != null)
            {
                chain = chain.Where(p => p.Active.Equals(active));
            }

            return await chain.ToListAsync();
        }

        // Obtener una lista de respuestas de promociones con parámetros de consulta
        public async Task<List<PromotionResponse>> GetPromotionsResponse(GetPromotionsQueryParams queryParams)
        {
            var chain = _context.Promotions.AsQueryable();

            bool? active = queryParams.Active;


            if (active != null)
            {
                chain = chain.Where(p => p.Active.Equals(active));
            }



            return await chain
                .Select(p => new PromotionResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PorcentageDiscount = p.PorcentageDiscount,
                    Active = p.Active,
                    EndAt = p.EndAt,
                    StartAt = p.StartAt
                })
                .ToListAsync();
        }

        // Actualizar una promoción existente
        public async Task UpdatePromotion(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
            await _context.SaveChangesAsync();
        }
    }
}
