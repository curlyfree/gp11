using Graduation.Project.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Project.Api.DataAccess
{
    public interface IDBContext
    {
        DbSet<SehirlerEntity> Sehirler { get; set; }
        DbSet<GezilecekYerlerEntity> Yerler { get; set; }
        DbSet<YerBilgileriEntity> YerBilgileri { get; set; }
        int SaveChanges();
    }
}
