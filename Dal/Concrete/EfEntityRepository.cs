using ElektrikDagitim.Dal.Abstract;
using ElektrikDagitim.Entities.Concrete.General;
using ElektrikDagitim.Entities.Concrete.Muhasebe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Dal.Concrete
{
    public class EfEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext cnt;

        public EfEntityRepository(AppDbContext cnt)
        {
            this.cnt = cnt;
        }

        public Mesajlar<TEntity> Duzelt(TEntity ent)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();
            try
            {
                cnt.Entry(ent).State = EntityState.Modified;
                cnt.Update(ent);

                cnt.SaveChanges();

                m.Nesne = ent;
                m.Durum = true;
                m.Mesaj = "Kayıt güncellendi";
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıt güncellenemedi.";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;


        }
        public async Task<Mesajlar<TEntity>> Duzelt_Async(TEntity ent)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();
            try
            {


                EntityEntry<TEntity> addEntity = cnt.Entry(ent);
                //addEntity.State = EntityState.Modified;

                IEnumerable<PropertyEntry> lst = cnt.Entry(ent).Properties;

                string pKey = addEntity.Metadata.FindPrimaryKey().Properties.Select(x => x.Name).Single();

                foreach (var i in lst)
                {
                    if (i.CurrentValue != null && i.Metadata.Name != pKey)
                    {
                        i.IsModified = true;
                    }
                }

                await cnt.SaveChangesAsync();

                m.Nesne = addEntity.Entity;
                m.Durum = true;
                m.Mesaj = "Kayıt güncellendi";
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıt güncellenemedi.";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;


        }
        public Mesajlar<TEntity> Ekle(TEntity ent)
        {

            Mesajlar<TEntity> m = new Mesajlar<TEntity>();
            try
            {
                var addEntity = cnt.Entry(ent);
                addEntity.State = EntityState.Added;
                cnt.SaveChanges();

                m.Nesne = addEntity.Entity;
                m.Durum = true;
                m.Mesaj = "Kayıt eklendi";
            }

            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıt eklenemedi.";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public async Task<Mesajlar<TEntity>> Ekle_Async(TEntity ent)
        {

            Mesajlar<TEntity> m = new Mesajlar<TEntity>();
            try
            {
                var addEntity = cnt.Entry(ent);
                addEntity.State = EntityState.Added;
                await cnt.SaveChangesAsync();

                m.Nesne = addEntity.Entity;
                m.Durum = true;
                m.Mesaj = "Kayıt eklendi";
            }

            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıt eklenemedi.";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public Mesajlar<TEntity> Getir(Expression<Func<TEntity, bool>> filtre)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();

            try
            {
                m.Nesne = cnt.Set<TEntity>().FirstOrDefault(filtre);
                m.Durum = true;
                m.Mesaj = "Kayıt görüntülendi";
            }
            catch (Exception ex)
            {

                m.Durum = false;
                m.Mesaj = "Kayıt görüntülenemedi";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;

        }
        public async Task<Mesajlar<TEntity>> Getir_Async(Expression<Func<TEntity, bool>> filtre)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();

            try
            {
                m.Nesne = await cnt.Set<TEntity>().FirstOrDefaultAsync(filtre);
                m.Durum = true;
                m.Mesaj = "Kayıt görüntülendi";
            }
            catch (Exception ex)
            {

                m.Durum = false;
                m.Mesaj = "Kayıt görüntülenemedi";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;

        }
        public Mesajlar<TEntity> Listele(Expression<Func<TEntity, bool>> filtre = null)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();

            try
            {
                m.Liste = cnt.Set<TEntity>().Where(filtre).ToList();
                m.Durum = true;
                m.Mesaj = "Kayıtlar görüntülendi";
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıtlar görüntülenemedi";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public async Task<Mesajlar<TEntity>> Listele_Async(Expression<Func<TEntity, bool>> filtre = null)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();

            try
            {
                m.Liste = await cnt.Set<TEntity>().Where(filtre).ToListAsync();
                m.Durum = true;
                m.Mesaj = "Kayıtlar görüntülendi";
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıtlar görüntülenemedi";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public Mesajlar<TEntity> Tum_Listele()
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();

            try
            {
                m.Liste = cnt.Set<TEntity>().ToList();
                m.Durum = true;
                m.Mesaj = "Kayıtlar görüntülendi";
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıtlar görüntülenemedi";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public Mesajlar<TEntity> Sil(TEntity ent)
        {
            Mesajlar<TEntity> m = new Mesajlar<TEntity>();

            try
            {
                PropertyInfo aktif = ent.GetType().GetProperty("Aktif");
                if (aktif != null)
                    aktif.SetValue(ent, false);

                var addEntity = cnt.Entry(ent);
                addEntity.State = EntityState.Modified;
                cnt.SaveChanges();

                m.Nesne = addEntity.Entity;
                m.Durum = true;
                m.Mesaj = "Kayıt bilgileri silindi";
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kayıt bilgileri silinemedi";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
    }
}
