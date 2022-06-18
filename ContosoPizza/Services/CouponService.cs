using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class CouponService
{
    private readonly PromotionsContext _context;

    public CouponService(PromotionsContext context)
    {
        _context = context;
    }

    public IEnumerable<Coupon> GetAll()
    {
        return _context.Coupons
            .AsNoTracking()
            .ToList();
    }

}
