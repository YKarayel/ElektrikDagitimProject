using Entities.Concrete.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Dal.Abstract
{
    public interface IEntityRepository<T> where T : class, new()
    {
        Mesajlar<T> Getir(Expression<Func<T, bool>> filtre = null);
        Mesajlar<T> Listele(Expression<Func<T, bool>> filtre = null);
        Mesajlar<T> Ekle(T ent);
        Mesajlar<T> Duzelt(T ent);
        Mesajlar<T> Sil(T ent);
    }
}