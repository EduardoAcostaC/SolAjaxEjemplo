using DatosMascotas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMascotas
{
    public class DBMascotas
    {

        private Generacion22Entities db = new Generacion22Entities();

        public List<Mascotas> Obtener()
        {
            List<Mascotas> lista = db.Mascotas.ToList();
            db.Dispose();
            return lista;
        }

        public Mascotas Obtener(int id)
        {
            Mascotas mascota = db.Mascotas.Find(id);
            db.Dispose();
            return mascota;
        }

        public void Agregar(Mascotas mascota)
        {
            db.Mascotas.Add(mascota);
            db.SaveChanges();
            db.Dispose();
        }
        
        public void Borrar(int id)
        {
            Mascotas mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
            db.SaveChanges();
            db.Dispose();
        }

        public void Editar(Mascotas mascota)
        {
            db.Mascotas.AddOrUpdate(mascota);
            db.SaveChanges();
            db.Dispose();
        }
        public List<Mascotas> Buscar(string valor)
        {
            List<Mascotas> lista = db.Mascotas.Where(x => x.nombre.Contains(valor)).ToList();
            db.Dispose();
            return lista;
        }
    }
}
