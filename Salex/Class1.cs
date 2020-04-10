﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Salex
{
    public struct BevetelDatum
    {
        public int bevetel { get; set; }
        public DateTime datum { get;set;}
    }
  public   struct Nagyker
    {
        public int nagykerId { get; set; }
        public string nagykerNev { get; set; }
    }
    public class Kapcsolatok
    {
        public static String connect = "DATABASE=salex;DATASOURCE=localhost;USER=root;PASSWORD=kiraly89;SslMode=none";
       
        public Product p1;
        public string vissza;
        public Kapcsolatok()
        {
            


        }


        public void insertProduct(int i, string n, int ar1, int ar2, int kdb, int nker, int minkeszlet)
        {
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into termekek values('" + i + "','" + n + "','" + ar1 + "','" + ar2 + "','" + kdb + "','" + nker + "','" + minkeszlet + "');";
            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();


        }

        public void insertNagyker(int i, string n, string c, string t, string e)
        {
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into nagyker values('" + i + "','" + n + "','" + c + "','" + t + "','" + e + "');";
            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();


        }


        public List<String> lekerdezNagyker()
        {
            List<String> lista = new List<String>();
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "Select * from nagyker;";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader["nagykerNev"].ToString());
            }


            return (lista);
        }

        public int lekerdezNagyKerId(string a)
        {

            int vissza = 0;
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "Select * from nagyker;";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["nagykerNev"].ToString() == a)
                {
                    vissza = Convert.ToInt32(reader["nagykerId"].ToString());
                }
            }


            return (vissza);
        }


        public List<Product> lekerdezTermekek()
        {
            List<Product> termekLista = new List<Product>();
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "Select * from termekek;";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                termekLista.Add(new Product
                {
                    productId = Convert.ToInt32(reader["id"].ToString()),
                    productName = reader["termekNev"].ToString(),
                    priceBuy = Convert.ToInt32(reader["beszeresiAr"].ToString()),
                    priceSale = Convert.ToInt32(reader["eladasiAr"].ToString()),
                    warehouse = Convert.ToInt32(reader["keszletdb"].ToString()),
                    companyId = Convert.ToInt32(reader["nagykerId"].ToString()),
                    minLevel = Convert.ToInt32(reader["minkeszlet"].ToString()),



                }
                );
            }
            return (termekLista);
        }

        public int lekerdezArukeszletBeszerzesi()
        {
            int vissza = 0;

            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "select SUM(beszeresiAr*keszletdb) from termekek;";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vissza = Convert.ToInt32(reader["SUM(beszeresiAr*keszletdb)"].ToString());
            }

            connection.Close();

            return (vissza);

        }

        public int lekerdezArukeszletEladasi()
        {
            int vissza = 0;

            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "select SUM(eladasiAr*keszletdb) from termekek;";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vissza = Convert.ToInt32(reader["SUM(eladasiAr*keszletdb)"].ToString());
            }

            connection.Close();

            return (vissza);

        }

        public Product lekerdezTermekekIdSzerint(int a)
        {



            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "Select * from termekek where id='" + a + "';";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["id"].ToString()) == a)
                {

                    p1 = new Product() {
                        productId = Convert.ToInt32(reader["id"].ToString()),
                        productName = reader["termekNev"].ToString(),
                        priceBuy = Convert.ToInt32(reader["beszeresiAr"].ToString()),
                        priceSale = Convert.ToInt32(reader["eladasiAr"].ToString()),
                        warehouse = Convert.ToInt32(reader["keszletdb"].ToString()),
                        companyId = Convert.ToInt32(reader["nagykerId"].ToString()),
                        minLevel = Convert.ToInt32(reader["minkeszlet"].ToString()),


                    };

                }




            }
            return (p1);
        }

        public void addBevetel(int a, int b, string c)
        {
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into bevetel values('" + a + "','" + b + "','" + c + "');";
            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        public List<double> getNapiBevetel()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = new DateTime(d1.Year, d1.Month, d1.Day);

            string datum = d2.ToString();
            List<double> vissza = new List<double>();
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select ertek from bevetel where datum='"+datum+"' order by ertek Desc limit 5;";

            connection.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vissza.Add(Convert.ToDouble(reader["ertek"].ToString()));
            }


            return (vissza);
        }


        public void modositKeszlet(int x,int y)
        {
            int vissza = 0;
            int modosit = 0;
            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            MySqlCommand parancs = connection.CreateCommand();
            cmd.CommandText = "select keszletdb from termekek where id='"+x+"' ";
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vissza = Convert.ToInt32(reader["keszletdb"].ToString());

            }


            connection.Close();

            connection.Open();
            modosit = vissza - y;
            parancs.CommandText = "update termekek set keszletdb='"+modosit+"' where id='"+x+"';";
            parancs.ExecuteNonQuery();




            connection.Close();
        }

        public List<Product> getKeszletRendelendo()
        {
            List<Product> vissza = new List<Product>();


            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            MySqlCommand parancs = connection.CreateCommand();
            cmd.CommandText = "select * from termekek where keszletdb<minkeszlet;";
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vissza.Add(new Product {
                    productId = Convert.ToInt32(reader["id"].ToString()),
                    productName = reader["termekNev"].ToString(),
                    priceBuy = Convert.ToInt32(reader["beszeresiAr"].ToString()),
                    priceSale = Convert.ToInt32(reader["eladasiAr"].ToString()),
                    warehouse = Convert.ToInt32(reader["keszletdb"].ToString()),
                    companyId = Convert.ToInt32(reader["nagykerId"].ToString()),
                    minLevel = Convert.ToInt32(reader["minkeszlet"].ToString()),
                });
            }


            return (vissza);
        }


        public List<Nagyker> fillNagyker()
        {
            List<Nagyker> nagykerLista = new List<Nagyker>();

            MySqlConnection connection = new MySqlConnection(connect);
            MySqlCommand cmd = connection.CreateCommand();
            MySqlCommand parancs = connection.CreateCommand();
            cmd.CommandText = "select * from nagyker;";
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nagykerLista.Add(new Nagyker
                {
                    nagykerId = Convert.ToInt32(reader["nagykerId"].ToString()),
                    nagykerNev = reader["nagykerNev"].ToString(),
                    
                });
            }


            return (nagykerLista);
        }


        public List<Product> lekerdezTermekekNagyKerSzerint(string x)
        {
            List<Product> termekLista = new List<Product>();
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "select *from termekek where nagykerId=(Select nagykerId from nagyker where nagykerNev='"+x+"');";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                termekLista.Add(new Product
                {
                    productId = Convert.ToInt32(reader["id"].ToString()),
                    productName = reader["termekNev"].ToString(),
                    priceBuy = Convert.ToInt32(reader["beszeresiAr"].ToString()),
                    priceSale = Convert.ToInt32(reader["eladasiAr"].ToString()),
                    warehouse = Convert.ToInt32(reader["keszletdb"].ToString()),
                    companyId = Convert.ToInt32(reader["nagykerId"].ToString()),
                    minLevel = Convert.ToInt32(reader["minkeszlet"].ToString()),



                }
                );
            }
            return (termekLista);
        }

        public int getBevetelNapi(string d)
        {
            int vissza = 0;
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "select SUM(ertek)  from bevetel where datum='"+d+"';";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool columnnull = false;
            while (reader.Read())
            {
                vissza = Convert.ToInt32(reader["SUM(ertek)"].ToString());
               

            }
            return (vissza);
        }

        public int getBevetelHeti(string j,string a)
        {
            int vissza = 0;
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();
            string lekerdez = "select SUM(ertek)  from bevetel where datum between '"+a+"' AND '"+j+"';";
            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

               
                    vissza = Convert.ToInt32(reader["SUM(ertek)"].ToString());
                
            }
            return (vissza);
        }

        public string getLastDate()
        {
            
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();

            string lekerdez = "SELECT * FROM bevetel ORDER by datum desc LIMIT 1;";

                 MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                vissza = reader["datum"].ToString();
              

            }

            return (vissza);
        }

        public List<BevetelDatum> getTop4Bevetel()
        {
            List<BevetelDatum> vissza = new List<BevetelDatum>();


            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();

            string lekerdez = "select SUM(ertek), datum  from bevetel group by datum order by SUM(ertek) desc limit 4;";


            MySqlCommand cmd = new MySqlCommand(lekerdez, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                vissza.Add(new BevetelDatum
                {
                    bevetel = Convert.ToInt32(reader["SUM(ertek)"].ToString()),
                    datum = DateTime.Parse(reader["datum"].ToString()),
                }); ;


            }



            return (vissza);

        }


    }
}