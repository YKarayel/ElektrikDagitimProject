using ElektrikDagitim.Entities.Concrete.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ElektrikDagitim.Dal.Abstract
{
    public interface IEntityRepository<T> where T : class
    {
        Mesajlar<T> Getir(Expression<Func<T, bool>> filtre = null);
        Mesajlar<T> Listele(Expression<Func<T, bool>> filtre = null);
        Mesajlar<T> Tum_Listele();
        Mesajlar<T> Ekle(T ent);
        Mesajlar<T> Duzelt(T ent);
        Mesajlar<T> Sil(T ent);
    }
}