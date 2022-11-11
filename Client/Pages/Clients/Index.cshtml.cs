using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Client.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                string ConnectionString = "Data Source= NRANJANE-LAP-06\\MSSQLSERVER02; Initial Catalog = DBSample; Integrated Security=SSPI";
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    Connection.Open();
                    string query = "Select * from clients";
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.id = "" + reader.GetInt32(0);
                        clientInfo.name = reader.GetString(1);
                        clientInfo.email = reader.GetString(2);
                        clientInfo.phone = reader.GetString(3);
                        clientInfo.address = reader.GetString(4);
                        clientInfo.createdAt = reader.GetDateTime(5).ToString();
                        listClients.Add(clientInfo);
                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.Message);
            }
        }
    }
    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string createdAt;

    }
}
