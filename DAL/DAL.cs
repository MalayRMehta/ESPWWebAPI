using System.Data.SqlClient;
namespace ESPWWebAPI.DAL
{
	public class DAL
	{
		public List<ClientInfo> listClients = new List<ClientInfo>();

		public List<ClientInfo> OnGet()
		{
			try
			{

				String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=AberInstruments;Integrated Security=True;";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "SELECT * FROM clients";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								ClientInfo clientInfo = new ClientInfo();
								clientInfo.id = "" + reader.GetInt32(0);
								clientInfo.name = reader.GetString(1);
								clientInfo.doses = "" + reader.GetInt32(2);
								clientInfo.time = "" + reader.GetDouble(3);
								clientInfo.mass = "" + reader.GetDouble(4);
								clientInfo.created_at = reader.GetDateTime(5).ToString();

								listClients.Add(clientInfo);
							}
						}
					}
				}
				return listClients;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
				return null;
			}
		}


		public bool OnPost(ClientInfo clientInfo)
		{
			try
			{
				String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=AberInstruments;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "INSERT INTO clients " +
								 "(name,doses,time,mass) VALUES " +
								 "(@name,@doses,@time,@mass);";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@name", clientInfo.name);
						command.Parameters.AddWithValue("@doses", clientInfo.doses);
						command.Parameters.AddWithValue("@time", clientInfo.time);
						command.Parameters.AddWithValue("@mass", clientInfo.mass);

						var result = command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}


			return true;

		}

	}
}
