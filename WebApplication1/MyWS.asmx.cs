using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Serialization.Json;

namespace WebApplication1
{
    /// <summary>
    /// Сводное описание для MyWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class MyWS : System.Web.Services.WebService
    {
        private readonly MyDC2DataContext dc2 = new MyDC2DataContext();   
        [WebMethod]
        public DBContact GetContactById(string contactId)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            

            var contact = from result in dc2.Contacts
                          where result.Id == int.Parse(contactId)
                          select result;
            string resultString = jss.Serialize(contact);//для запроса по таблице контактов

            List<DBContact> listContact = (List<DBContact>)jss.Deserialize(resultString, typeof(List<DBContact>));
            if (listContact.Count == 0)//учитываем что возможно контакты пусты
            {
                listContact.Add(new DBContact
                {
                    Id = 0,
                    ThirdName = "empty",
                    SecondName = "empty",
                    FirstName = "empty",
                    IdTelephone = "empty",
                    Address = "empty"
                });
                return listContact[0];
            }

            var telephone = from result in dc2.Telephones
                            where result.Id == int.Parse(listContact[0].IdTelephone)
                            select result;
            resultString = jss.Serialize(telephone);//для запроса по таблице номеров
            List<DBTelephones> listTeeTelephones = (List<DBTelephones>)jss.Deserialize(resultString, typeof(List<DBTelephones>));
            
            if (listTeeTelephones.Count == 0)
            {
                listContact[0].IdTelephone = "empty";
            }
            else
            {
                listContact[0].IdTelephone = listTeeTelephones[0].Telephone_Number;
            }
            return listContact[0];
        }
    }
}
