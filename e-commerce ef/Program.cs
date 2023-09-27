using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace e_commerce_ef
{
    public class work
    {
        public string login { get; set; }
        public string password { get; set; }

        public static void SetAdmin(ordersEntities orders, utenti u1, string login, string password)
        {
            using (orders = new ordersEntities())
            {
                u1 = new utenti();
                var c = orders.utentis.Count();
                if (c == 0)
                {
                    u1 = new utenti() { login = "admin", password = "admin" };
                    orders.utentis.Add(u1);
                    orders.SaveChanges();

                    Console.WriteLine($"{u1.login} {u1.password}");
                }
            }
        }

        public static void Login(ordersEntities orders, utenti u1, string login, string password)
        {
            using(orders = new ordersEntities())
            {
                Console.WriteLine("inserisci le credenziali per il login");
                var a = Console.ReadLine();
                var b = Console.ReadLine();

                if (a == u1.login & b == u1.password)
                {
                    Console.WriteLine($"benvenuto {u1.login}!");
                }
            }
            
        }

        public static void CreaUtente(ordersEntities orders, utenti u1, string login, string password)
        {
            using (orders = new ordersEntities())
            {
                Console.WriteLine("digita login e password per la creazione del nuovo utente!");
                login = Console.ReadLine();
                password = Console.ReadLine();
                u1 = new utenti() { login = login, password = password };
                orders.utentis.Add(u1);
                orders.SaveChanges();
                foreach (var c in orders.utentis)
                {
                    Console.WriteLine($"credenziali appena create {c.login} +  {c.password}");
                }
            }
        }

        public static void ListaOrdini(ordersEntities orders, order oi)
        {
            Console.WriteLine("ecco la lista degli ordini presenti");
            foreach (var o in orders.orders)
            {
                Console.WriteLine($"{oi.orderid} {oi.customer} {oi.orderdate}");
            }
        }

        public static void CreaNuovoOrdine(ordersEntities orders, orderitem or)
        {
            Console.WriteLine("digitare le informazioni da aggiungere al nuovo ordione");
            string nomeProdotto = Console.ReadLine();
            string qty = Console.ReadLine();
            int qtyy = int.Parse(qty);
            string prezzo = Console.ReadLine();
            int price = int.Parse(prezzo);
            or = new orderitem() { item = nomeProdotto, qty = qtyy, price = price };
            orders.orderitems.Add(or);
            orders.SaveChanges();
            Console.WriteLine("il nuovo ordine che è stato creato è il seguente:");
            Console.WriteLine($"{or.orderid} - {or.item} , {or.qty} , {or.price}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
                using (var ctx = new ordersEntities())
                {
                    var u = new utenti();
                    var o = new order();
                    var oit = new orderitem();
                    work.SetAdmin(ctx, u, u.login, u.password);
                    work.Login(ctx, u, u.login, u.password);
                    work.CreaUtente(ctx, u, u.login, u.password);
                    work.ListaOrdini(ctx, o);
                    work.CreaNuovoOrdine(ctx, oit);
                }












                //    Console.WriteLine($"creato contesto {ctx}");
                //    foreach (var c in ctx.customer)
                //    {
                //        Console.WriteLine(c.customer1 + " " + c.country);
                //    }

                //    foreach (order o in ctx.orders)
                //    {
                //        Console.WriteLine($"{o.orderid} : {o.customer1.customer1} {o.customer1.country}");
                //        foreach (orderitem oi in ctx.orderitems)
                //        {
                //            Console.WriteLine($"\t{oi.item1.item1}");
                //        }
                //    }

                //    foreach (var cust in ctx.customer)
                //    {
                //        if (cust.customer1 == "Jack")
                //        {
                //            Console.WriteLine($"aggiorno {cust.country}");
                //            cust.country = cust.country + "(m)";
                //            Console.WriteLine("cambiamenti effettuati");
                //        }
                //    }
                //    ctx.SaveChanges();

                //    var c1 = new customer() { customer1 = "lollo", country = "bussero" };
                //    ctx.customer.Add(c1);
                //    ctx.SaveChanges();


                //    foreach (var cust in ctx.customer)
                //    {
                //        if (cust.customer1 == "new")
                //        {
                //            ctx.customer.Remove(cust);
                //            ctx.SaveChanges();
                //        }
                //    }

                //    var cc = ctx.customer.Find("jack");
                //    Console.WriteLine(cc.customer1);

                //}



                Console.ReadLine();


            }
        }
    }

