using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_application
{

    public class Construct
    {


        internal class query6
        {
            public string ФИО_клиента { get; set; }
            public string Название_фирмы_клиента { get; set; }
            public string ФИО_контрагента { get; set; }
            public string Название_агенства { get; set; }
        }

        internal class query5
        {
            public string Наименование_продукта { get; set; }
            public string Количество_продукта { get; set; }
            public string Дата { get; set; }
        }


        internal class query4
        {
            public string Название_агенства { get; set; }
            public string ФИО_контрагента { get; set; }
            public string Опыт_работы { get; set; }
            public string Успешные_сделки_за_год { get; set; }
        }


        internal class query3
        {
            public string Адрес { get; set; }
            public string Количество_продукта { get; set; }
            public string Наименование_продукта { get; set; }
            public string Дата { get; set; }
        }



        internal class query2
        {
            public string ФИО_клиента { get; set; }
            public string Название_фирмы_клиента { get; set; }
            public string Наименование_продукта { get; set; }
            public string Количество_продукта { get; set; }
        }



        internal class query1
        {
            public string ФИО_контрагента { get; set; }
            public string Рейтинг_контрагента { get; set; }
            public string Опыт_работы { get; set; }
            public string ФИО_клиента { get; set; }         
        }





        internal class PromotionAgency
        {
            public int Id { get; set; }
            public string Годовой_оборот_продаж { get; set; }
            public string ФИО_руководителя { get; set; }
            public string Название_агенства { get; set; }
            public string Количество_сотрудников { get; set; }
        }
        internal class Agent
        {
            public int Id { get; set; }
            public int Id_агенства { get; set; }
            public string ФИО_контрагента { get; set; }
            public string Рейтинг_контрагента { get; set; }
            public string Опыт_работы { get; set; }
            public string Успешные_сделки_за_год { get; set; }       
        }




        internal class Client
        {
            public int Id { get; set; }
            public int Id_Контрагента { get; set; }
            public string ФИО_клиента { get; set; }
            public string Желаемые_продажи { get; set; }
            public string Бюджет { get; set; }
            public string Название_фирмы_клиента { get; set; }
        }

        internal class Purchase
        {
            public int Id { get; set; }
            public int Id_продукта { get; set; }
            public int Id_клиента { get; set; }
            public string Наименование_продукта { get; set; }
            public string Количество_продукта { get; set; }
        }


        internal class Product
        {
            public int Id { get; set; }
            public string Количество_продукта { get; set; }
            public string Наименование_продукта { get; set; }
            public string Цена { get; set; }
            public string Габариты { get; set; }
        }

        internal class Batch
        {
            public int Id { get; set; }
            public int Id_продукта { get; set; }
            public int Id_производителя { get; set; }
            public string Количество_продукта { get; set; }
            public string Наименование_продукта { get; set; }
            public string Дата { get; set; }
        }

        internal class Made
        {
            public int Id { get; set; }
            public string Текущая_выработка { get; set; }
            public string Адрес { get; set; }
            public string Максимальная_выработка { get; set; }
            public string Количество_сотрудников { get; set; }
        }

       


        public dynamic ConstPAPM(int a, int b, string c, string d, string e, string f)
        {
            Agent ag = new Agent
            {
                Id = a,
                Id_агенства = b,
                ФИО_контрагента = c,
                Рейтинг_контрагента = d,
                Опыт_работы = e,
                Успешные_сделки_за_год = f,
            };
            return ag;
        }
       

        public dynamic ConstPAPM(int a, string b, string c, string d, string e)
        {
            PromotionAgency ag = new PromotionAgency()
            {
                Id = a,
                Годовой_оборот_продаж =b,
                ФИО_руководителя = c,
                Название_агенства = d,
                Количество_сотрудников =e,
            };
            return ag;
        }

        public dynamic ConstPAPM(int a, int b, int c, string d, string e)
        {
            Purchase ag = new Purchase()
            {
                Id = a,
                Id_продукта = b,
                Id_клиента = c,
                Наименование_продукта = d,
                Количество_продукта = e,
            };
            return ag;
        }
        public dynamic ConstPAPM(int a, int b, int c, string d, string e, string f)
        {
            Batch ag = new Batch()
            {
                Id = a,
                Id_продукта = b,
                Id_производителя = c,
                Количество_продукта = d,
                Наименование_продукта = e,
                Дата = f,
            };
            return ag;
        }

        public dynamic ConstrMade(int a, string b, string c, string d, string e)
        {
            Made ag = new Made()
            {
                Id = a,
                Текущая_выработка = b,
                Адрес = c,
                Максимальная_выработка = d,
                Количество_сотрудников = e,
            };
            return ag;
        }


        public dynamic ConstCProd(int a, int b, string c, string d, string e, string f)
        {
            Client ag = new Client()
            {
                Id = a,
                Id_Контрагента = b,
                ФИО_клиента = c,
                Желаемые_продажи = d,
                Бюджет = e,
                Название_фирмы_клиента = f,
            };
            return ag;
        }
        public dynamic ConstCProd(int a, string b, string c, string d, string e)
        {
            Product ag = new Product()
            {
                Id = a,
                Количество_продукта = b,
                Наименование_продукта = c,
                Цена = d,
                Габариты = e,              
            };
            return ag;
        }



    }
}
