using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Abstractions;
using System.Runtime.CompilerServices;
using static database_application.Construct;
namespace database_application

{



    internal class Database
    {



        public static string login = Authoritaition.logon;
        public static string password = Authoritaition.pass;
        public static string table;
        public static string colomn;
        public static bool flag;



        public static string con = "Server=(local);Database=Kursach;User="+login+";Password="+password+";TrustServerCertificate=true";
        //SqlConnection sqlconnect = new SqlConnection(@"Data Source=XUSTON;Initial Catalog=Kursach;Integrated Security=True");
        public void connect()
        {
             login = Authoritaition.logon;
             password = Authoritaition.pass;
             con = "Server=(local);Database=Kursach;User="+login+";Password=" + password + ";TrustServerCertificate=true";           
             SqlConnection connect = new SqlConnection(con);
             connect.Open();
             connect.Close();
            login = null;
            password = null;
            
        }
        public void opcon()
        {
            SqlConnection connect = new SqlConnection(con);
            connect.Open();

        }

        public void closecon()
        {
            SqlConnection connect = new SqlConnection(con);
            connect.Close();
        }












        public dynamic gettable()
        {
            
            SqlConnection connection = new SqlConnection(con);
            connection.Open();          
            SqlCommand cmd = new SqlCommand("SELECT * FROM [" + table + "]", connection);      
            List<Construct.PromotionAgency> promotion = new List<Construct.PromotionAgency>();
            List<Construct.Agent> agent = new List<Construct.Agent>();
            List<Construct.Client> client = new List<Construct.Client>();
            List<Construct.Purchase> purshase = new List<Construct.Purchase>();
            List<Construct.Product> product = new List<Construct.Product>();
            List<Construct.Batch> batch = new List<Construct.Batch>();
            List<Construct.Made> made = new List<Construct.Made>();       
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Construct constr = new Construct();
                switch (table)
                {

                    case "Рекламное агенство":
                        while (reader.Read())
                        {
                            Construct.PromotionAgency a = new Construct.PromotionAgency();
                            a = constr.ConstPAPM(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 
                                reader.GetString(3), reader.GetString(4));                         
                            promotion.Add(a);
                        }
                        connection.Close();
                        return promotion;
                    case "Контрагент":
                        while (reader.Read())
                        {
                            Construct.Agent a = new Construct.Agent();                            
                            a = constr.ConstPAPM(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), 
                                reader.GetString(3), reader.GetString(4), reader.GetString(5));              
                            agent.Add(a);
                        }
                        connection.Close();
                        return agent;
                    case "Клиент":
                        while (reader.Read())
                        {
                            Construct.Client a = new Construct.Client();
                            a = constr.ConstCProd(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), 
                                reader.GetString(3), reader.GetString(4), reader.GetString(5));                           
                            client.Add(a);
                        }
                        connection.Close();                
                        return client;
                    case "Закупка":
                        while (reader.Read())
                        {
                            Construct.Purchase a = new Construct.Purchase();
                            a = constr.ConstPAPM(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                                reader.GetString(3), reader.GetString(4));                    
                            purshase.Add(a);
                        }
                        connection.Close();
                        return purshase;
                    case "Продукт":
                        while (reader.Read())
                        {
                            Construct.Product a = new Construct.Product();
                            a = constr.ConstCProd(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetString(4));                     
                            product.Add(a);
                        }
                        connection.Close();
                        return product;
                    case "Партия":
                        while (reader.Read())
                        {
                            Construct.Batch a = new Construct.Batch();
                            a = constr.ConstPAPM(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                                reader.GetString(3), reader.GetString(4), Convert.ToString(reader.GetDateTime(5)));                
                            batch.Add(a);
                        }
                        connection.Close();
                        return batch;
                    case "Производитель":
                        while (reader.Read())
                        {
                            Construct.Made a = new Construct.Made();
                            a = constr.ConstrMade(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetString(4));                
                            made.Add(a);
                        }
                        connection.Close();
                        return made;
                    default: connection.Close(); return null;
                }
            }
            


        }
        public List<string> GetColumns()
        {
            List<string> a = new List<string>();

            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cm = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + table + "'", connection);
            using (SqlDataReader reader = cm.ExecuteReader())
            {
                while (reader.Read())
                {
                    a.Add(reader.GetString(0));
                }
                connection.Close( );
                a.Add("<Выберите столбец для поиска>");
                return a;
            }

        }

        public dynamic Search(string searchword)
        {

            try
            {
                string searchphrase = "%" + searchword + "%";
                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                
                SqlCommand cmd = new SqlCommand();
                if (flag == false)
                {
                    cmd.CommandText = "SELECT * FROM [" + table + "] WHERE [" + colomn + "] LIKE @search";                
                    cmd.Parameters.AddWithValue("@search", searchphrase);
                    cmd.Connection = connection;
                }
                else
                { 
                    cmd.CommandText = "SELECT * FROM ["+table+"] WHERE CONTAINS (["+colomn+ "], '\""+searchword+"\"')";
                    cmd.Connection = connection;
                }
                
                
                List<Construct.PromotionAgency> promotion = new List<Construct.PromotionAgency>();
                List<Construct.Agent> agent = new List<Construct.Agent>();
                List<Construct.Client> client = new List<Construct.Client>();
                List<Construct.Purchase> purshase = new List<Construct.Purchase>();
                List<Construct.Product> product = new List<Construct.Product>();
                List<Construct.Batch> batch = new List<Construct.Batch>();
                List<Construct.Made> made = new List<Construct.Made>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Construct constr = new Construct();
                    switch (table)
                    {

                        case "Рекламное агенство":
                            while (reader.Read())
                            {
                                Construct.PromotionAgency a = new Construct.PromotionAgency();
                                a = constr.ConstPAPM(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4));
                                promotion.Add(a);
                            }
                            connection.Close();
                            return promotion;
                        case "Контрагент":
                            while (reader.Read())
                            {
                                Construct.Agent a = new Construct.Agent();
                                a = constr.ConstPAPM(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5));
                                agent.Add(a);
                            }
                            connection.Close();
                            return agent;
                        case "Клиент":
                            while (reader.Read())
                            {
                                Construct.Client a = new Construct.Client();
                                a = constr.ConstCProd(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5));
                                client.Add(a);
                            }
                            connection.Close();
                            return client;
                        case "Закупка":
                            while (reader.Read())
                            {
                                Construct.Purchase a = new Construct.Purchase();
                                a = constr.ConstPAPM(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                                    reader.GetString(3), reader.GetString(4));
                                purshase.Add(a);
                            }
                            connection.Close();
                            return purshase;
                        case "Продукт":
                            while (reader.Read())
                            {
                                Construct.Product a = new Construct.Product();
                                a = constr.ConstCProd(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4));
                                product.Add(a);
                            }
                            connection.Close();
                            return product;
                        case "Партия":
                            while (reader.Read())
                            {
                                Construct.Batch a = new Construct.Batch();
                                a = constr.ConstPAPM(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5));
                                batch.Add(a);
                            }
                            connection.Close();
                            return batch;
                        case "Производитель":
                            while (reader.Read())
                            {
                                Construct.Made a = new Construct.Made();
                                a = constr.ConstrMade(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4));
                                made.Add(a);
                            }
                            connection.Close();
                            return made;
                        default: connection.Close(); return null;
                    }
                }
           }
            catch (Exception ex){

               MessageBox.Show("Проверьте данных на соответствие");
                return null;
            }
        }

        public static void adding( string tb1, string tb2, string tb3, string tb4, string lb1, string lb2, string lb3, string lb4)
        {
            SqlConnection connection = new SqlConnection(con);         
            connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ["+table+"] ([" + lb1 +"], ["+lb2+"],["+lb3+"],["+lb4+"]) " +
                    "VALUES ('"+ tb1 +"','"+tb2+"','"+tb3+"','"+tb4+"') ", connection);
            cmd.ExecuteNonQuery();
            connection.Close();          
        }

        public static void adding(string tb1, string tb2, string tb3, string tb4, string tb5, 
            string lb1, string lb2, string lb3, string lb4, string lb5)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [" + table + "] ([" + lb1 + "], [" + lb2 + "],[" + lb3 + "],[" + lb4 + "],[" + lb5 + "]) " +
                "VALUES ('" + tb1 + "','" + tb2 + "','" + tb3 + "','" + tb4 + "','"+tb5+"') ", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void deletefrom(string id, string colmname)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ["+table + "] WHERE ["+colmname+"] = "+id, connection);
            cmd.ExecuteNonQuery();
            connection.Close();


        }

        public static void changing(string tb1, string tb2, string tb3, string tb4, 
            string lb1, string lb2, string lb3, string lb4, string id, string colmname)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ["+table+"] SET ["+lb1+"]='"+tb1+"', ["+lb2+"]='"+tb2+"'," +
                "["+lb3+"]='"+tb3+"',["+lb4+"]='"+tb4+"' WHERE ["+colmname+"] = "+id , connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void changing(string tb1, string tb2, string tb3, string tb4, string tb5,
            string lb1, string lb2, string lb3, string lb4, string lb5, string id, string colmname)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [" + table + "] SET [" + lb1 + "]='" + tb1 + "', [" + lb2 + "]='" + tb2 + "'," +
                "[" + lb3 + "]='" + tb3 + "',[" + lb4 + "]='" + tb4 + "',["+lb5+"]='"+tb5+"'   WHERE [" + colmname + "] = " + id, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Construct.query1> query1()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT [ФИО контрагента], [Рейтинг контрагента], [Опыт работы], [ФИО клиента] FROM Контрагент JOIN\r\nКлиент ON Контрагент.[Идентификатор контрагента] = Клиент.[Идентификатор контрагента]\r\nORDER BY [Рейтинг контрагента] DESC", connection);
            List<Construct.query1> query = new List<Construct.query1>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Construct.query1 a = new Construct.query1()
                    {
                        ФИО_контрагента = reader.GetString(0),
                        Рейтинг_контрагента = reader.GetString(1),
                        Опыт_работы = reader.GetString(2),
                        ФИО_клиента = reader.GetString(3),
                    };
                    query.Add(a);

                }
            }    
            connection.Close();
            return query;
        }


        public static List<Construct.query2> query2()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT [ФИО клиента], [Название фирмы клиента], [Наименование продукта], [Количество продукта] FROM Клиент \r\nJOIN Закупка ON Клиент.[Индентификатор клиента] = Закупка.[Идентификатор клиента]\r\n", connection);
            List<Construct.query2> query = new List<Construct.query2>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Construct.query2 a = new Construct.query2()
                    {
                        ФИО_клиента = reader.GetString(0),
                        Название_фирмы_клиента = reader.GetString(1),
                        Наименование_продукта = reader.GetString(2),
                        Количество_продукта = reader.GetString(3),
                    };
                    query.Add(a);

                }
            }
            connection.Close();
            return query;
        }


        public static List<Construct.query3> query3()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Адрес, [Количество продукта], [Наименование продукта], дата FROM Производитель \r\nJOIN Партия ON Производитель.[Идентификатор производителя] = Партия.[Идентификатор производителя]", connection);
            List<Construct.query3> query = new List<Construct.query3>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Construct.query3 a = new Construct.query3()
                    {
                        Адрес = reader.GetString(0),
                        Количество_продукта = reader.GetString(1),
                        Наименование_продукта = reader.GetString(2),
                        Дата = Convert.ToString(reader.GetDateTime(3)),
                    };
                    query.Add(a);

                }
            }
            connection.Close();
            return query;
        }


        public static List<Construct.query4> query4()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT [Название агенства], [ФИО контрагента], [Опыт работы], [Количество успешных сделок за год] FROM [Рекламное агенство] \r\nJOIN Контрагент ON [Рекламное агенство].[Идентификатор агенства] = Контрагент.[Идентификатор агенства]", connection);
            List<Construct.query4> query = new List<Construct.query4>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Construct.query4 a = new Construct.query4()
                    {
                        Название_агенства = reader.GetString(0),
                        ФИО_контрагента = reader.GetString(1),
                        Опыт_работы = reader.GetString(2),
                        Успешные_сделки_за_год = reader.GetString(3),
                    };
                    query.Add(a);

                }
            }
            connection.Close();
            return query;
        }

        public static List<Construct.query5> query5()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Продукт.[Наименование продукта], Продукт.[Количество продукта], дата FROM Продукт JOIN\r\nПартия ON Партия.[Идентификатор продукта] = Продукт.[Идентификатор продукта]", connection);
            List<Construct.query5> query = new List<Construct.query5>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Construct.query5 a = new Construct.query5()
                    {
                        Наименование_продукта = reader.GetString(0),
                        Количество_продукта = reader.GetString(1),
                        Дата = Convert.ToString(reader.GetDateTime(2)),
                    };
                    query.Add(a);

                }
            }
            connection.Close();
            return query;
        }



        public static List<Construct.query6> query6()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT [ФИО клиента], [Название фирмы клиента],[ФИО контрагента],[Название агенства] FROM Клиент JOIN \r\nКонтрагент ON Клиент.[Идентификатор контрагента] = Контрагент.[Идентификатор контрагента]\r\nJOIN [Рекламное агенство] ON Контрагент.[Идентификатор агенства] = [Рекламное агенство].[Идентификатор агенства]", connection);
            List<Construct.query6> query = new List<Construct.query6>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Construct.query6 a = new Construct.query6()
                    {
                        ФИО_клиента = reader.GetString(0),
                        Название_фирмы_клиента = reader.GetString(1),
                        ФИО_контрагента = reader.GetString(2),
                        Название_агенства = reader.GetString(3),
                    };
                    query.Add(a);

                }
            }
            connection.Close();
            return query;
        }



    }
}
