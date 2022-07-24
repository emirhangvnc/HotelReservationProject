﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSocialMediaDal : EfEntityRepositoryBase<SocialMedia, HotelReservationContext>, ISocialMediaDal
    {
    }
}