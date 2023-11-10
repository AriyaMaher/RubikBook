using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RubikBook.Core.Classes;
using RubikBook.Core.Interface;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Context;
using RubikBook.Database.Models;

namespace RubikBook.Core.Services;

public class ProfileService : IProfile
{
    private readonly DatabaseContext _context;
    public ProfileService(DatabaseContext context)
    {
        _context = context;
    }


    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<User> GetUser(string userMobile)
    {
        var user = await _context.Users.Include(a=>a.UserAddress).Where(u => u.Mobile == userMobile).
            Select(s => new User()
            {
                Id = s.Id,
                Mobile = s.Mobile,
                IsActive = s.IsActive,
                Role = new Role()
                {
                    Id = s.Role.Id,
                    RoleName = s.Role.RoleName,
                }
            }).FirstOrDefaultAsync();

        //var user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile==userMobile);
        return user;
    }

    public async Task<Guid> AddShopping(ShoppingViewModel shopping)
    {
        //1
        //find product by Id
        var product =
            await _context.Products.FindAsync(shopping.ProductId);

        if (product == null) return Guid.Empty;
        var price = product.Price - (product.Price * product.SellOff / 100);





        //2
        //user factor where isPay==false
        var factor = await _context.Factors.
                            Include(f => f.FactorDetails).
                            FirstOrDefaultAsync(f =>
                            f.UserId == shopping.UserId && !f.IsPay);


        //update total price in factor
        if (factor!=null)
        {
            factor.TotalPrice += price;
        }

        try
        {
            //3
            //create new factor where factor==null 
            if (factor == null)
            {
                Factor newFactor = new Factor()
                {
                    Id = Guid.NewGuid(),
                    UserId = shopping.UserId,
                    OpenDateTime = await new CoreClass().GetPersianDate(),
                    IsPay = false,
                    Status = "در انتظار پرداخت",
                    TotalPrice = price,
                };

                await _context.Factors.AddAsync(newFactor);

                //create newFactor detail
                FactorDetail newDetail = new FactorDetail()
                {
                    FactorId = newFactor.Id,
                    ProductId = product.Id,
                    DetailCount = 1,
                    DetailPrice = price * 1,//price * detailCount
                };

                await _context.FactorDetails.AddAsync(newDetail);
                await _context.SaveChangesAsync();

                return newFactor.Id;
            }


            //3
            //update existing factor
            var detail = factor.FactorDetails.FirstOrDefault(d => d.ProductId == shopping.ProductId);

            //add detail in existing factor
            if (detail == null)
            {
                FactorDetail newDetail = new FactorDetail()
                {
                    FactorId = factor.Id,
                    ProductId = product.Id,
                    DetailCount = 1,
                    DetailPrice = price * 1,//price * detailCount
                };

                await _context.FactorDetails.AddAsync(newDetail);
                await _context.SaveChangesAsync();

                return factor.Id;
            }


            //update existing factorDetail in existing factor
            detail.DetailCount += 1;
            detail.DetailPrice = price * detail.DetailCount;

            await _context.SaveChangesAsync();

            


            return factor.Id;


        }
        catch (Exception error)
        {
            Console.WriteLine("add shopping error ===> {0}", error.Message);
            return Guid.Empty;
        }

    }


    public async Task<Factor> GetFactor(Guid userId, bool? isPay = false)
    {
        var factor = await _context.Factors.Include(f => f.FactorDetails).Include("FactorDetails.Product").FirstOrDefaultAsync(f => f.UserId == userId && f.IsPay == isPay);
        return factor;
    }

    public async Task<Factor> GetFactor(Guid factorId)
    {
        var factor = await _context.Factors.Include(f => f.FactorDetails).Include("FactorDetails.Product").FirstOrDefaultAsync(f => f.Id == factorId);
        return factor;
    }

    public async Task<bool> DeleteFactorDetail(Guid factorId, Guid productId, Guid? userId)
    {
        var factorDetail = await _context.FactorDetails.FirstOrDefaultAsync(f => f.FactorId == factorId && f.ProductId == productId);
        var factorDetails = _context.FactorDetails.Where(i => i.FactorId == factorId).ToList();
        var factor = await _context.Factors.FirstOrDefaultAsync(u => u.Id == factorId);

        if (factorDetail != null)
        {
            _context.FactorDetails.Remove(factorDetail);
            factor.TotalPrice -= factorDetail.DetailPrice;
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();

            if (factorDetails.Count > 1)
            {
                return await Task.FromResult(true);
            }
            _context.Factors.Remove(factor);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);

        }

        return await Task.FromResult(false);

    }

    public Task<bool> DeleteFactor(Guid factorId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Factor>> GetFactors(bool? isPay)
    {
        if (isPay != null)
        {
            var factors = _context.Factors.Where(f => f.IsPay == isPay).ToList();
            return await Task.FromResult(factors);
        };
        var factors1 = _context.Factors.ToList();
        return await Task.FromResult(factors1);

    }


    public async Task<bool> AddUserAddress(UserAddressViewModel userAddressViewModel)
    {
        if (userAddressViewModel != null)
        {
            UserAddress newUserA = new UserAddress()
            {
                Fname = userAddressViewModel.Fname,
                Lname = userAddressViewModel.Lname,
                Phone = userAddressViewModel.Phone,
                State = userAddressViewModel.State,
                City = userAddressViewModel.City,
                PostalCode = userAddressViewModel.PostalCode,
                FullAdress = userAddressViewModel.FullAdress,
                UserId = userAddressViewModel.UserId,
            };
            await _context.userAddresses.AddAsync(newUserA);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<UserAddress> GetUserAddress(Guid userId)
    {
        var userAddress = await _context.userAddresses.FirstOrDefaultAsync(u => u.UserId == userId);
        if (userAddress!=null)
        {
            return await Task.FromResult(userAddress);
        }
        return null;
    }

    public async Task<bool> DeleteUserAddress(Guid userId)
    {
        var userAddress = _context.userAddresses.FirstOrDefault(u => u.UserId == userId);
        if (userAddress != null)
        {
            _context.userAddresses.Remove(userAddress);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public Task<UserAddress> EditUserAddress(UserAddressViewModel userAddressViewModel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> MinusFactorDetail(Guid factorId, Guid productId, Guid? userId)
    {
        var factorDetail = await _context.FactorDetails.FirstOrDefaultAsync(f => f.FactorId == factorId && f.ProductId == productId);
        var factorDetails = _context.FactorDetails.Where(i => i.FactorId == factorId).ToList();
        var factor = await _context.Factors.FirstOrDefaultAsync(u => u.Id == factorId);

        if (factorDetail != null)
        {
            
            factorDetail.DetailCount -= 1;
            await _context.SaveChangesAsync();

            if (factorDetail.DetailCount == 1)
            {
                _context.FactorDetails.Remove(factorDetail);
                await _context.SaveChangesAsync();
            }            
            return await Task.FromResult(true);
        }
        return false;

    //public async task<bool> deletefactor(guid factorid)
    //{
    //    var factordetail = await _context.factordetails.firstordefaultasync(f => f.factorid == factorid);
    //    if (factordetail == null)
    //    {
    //        var factor = await _context.factors.firstordefaultasync(f => f.id == factorid);
    //        if (factor == null)
    //        {
    //            return await task.fromresult(false);
    //        }
    //        _context.factors.remove(factor);
    //        await _context.savechangesasync();
    //        return await task.fromresult(true);
    //    }
    //    return await task.fromresult(false);
    //}

    //public async Task<bool> MinusFactorDetail(FactorDetail factorDetail)
    //{
    //    var factor = await _context.FactorDetails.FirstOrDefaultAsync(f => f.FactorId == factorDetail.FactorId && f.ProductId == factorDetail.ProductId);
    //    if (factor != null && factor.DetailCount > 0)
    //    {
    //        _context.FactorDetails.Update(factor);
    //        return await Task.FromResult(true);
    //    }
    //    return await Task.FromResult(false);
    //}

    //public async Task<FactorDetail> GetFactorDetail(Guid factorId, Guid ProductId)
    //{
    //    var factorDetail = await _context.FactorDetails.FirstOrDefaultAsync(f => f.FactorId == factorId && f.ProductId == ProductId);
    //    if (factorDetail != null)
    //    {
    //        return await Task.FromResult(factorDetail);
    //    }
    //    return await Task.FromResult(factorDetail);
    //}
}
