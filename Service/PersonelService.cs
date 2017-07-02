using Data;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PersonelService:IPersonelService
    {
        Baglan baglan = new Baglan();
        Command cmd = new Command();
        public int insert(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            baglan.baglantiKapat();
            //throw new NotImplementedException();
            return 0;
        }

        public void update(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            baglan.baglantiKapat();
            //throw new NotImplementedException();
        }

        public void delete(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            baglan.baglantiKapat();
            //throw new NotImplementedException();
        }

        public List<PersonelDTO> personelListesi(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            SqlDataReader dr = cmd1.ExecuteReader();
            List<PersonelDTO> pdto = new List<PersonelDTO>();
            while(dr.Read())
            {
                pdto.Add(new PersonelDTO
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Adi = dr["Adi"].ToString(),
                    Soyadi = dr["Soyadi"].ToString(),
                    KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"].ToString())
                });
            }
            baglan.baglantiKapat();
            return pdto;
        }
    }
}
