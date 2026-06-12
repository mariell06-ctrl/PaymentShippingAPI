using PaymentShippingAPI.Model;
using Microsoft.Data.SqlClient;

namespace PaymentShippingAPI.Data
{
    //USER
    public class RepData
    {
        private const string connString =
            "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";

        //POST
        public void saveUser(InfoM user)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "INSERT INTO Users (Fname, Lname) VALUES (@fName, @lName)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fName", user.fName);
                    cmd.Parameters.AddWithValue("@lName", user.lName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //GET BY ID - USERS
        public InfoM getUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM Users WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InfoM
                            {
                                fName = reader["Fname"].ToString(),
                                lName = reader["Lname"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        //UPDATE - USERS
        public void updateUser(int id, InfoM user)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"UPDATE Users
                         SET Fname = @fName,
                             Lname = @lName
                         WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@fName", user.fName ?? "");
                    cmd.Parameters.AddWithValue("@lName", user.lName ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE - USERS
        public void deleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM Users WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    //PAYMENTS
    public class Orderrepo
    {
        private const string connString =
            "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";

        //POST - PAYMENT
        public void savePay(payinfo payment)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"INSERT INTO Payments 
                                (method, cardNumber, phoneNumber, cardHolder, email) 
                                VALUES 
                                (@Method, @CardNumber, @PhoneNumber, @CardHolder, @Email)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Method", payment.method ?? "");
                    cmd.Parameters.AddWithValue("@CardNumber", payment.cardNumber ?? "");
                    cmd.Parameters.AddWithValue("@PhoneNumber", payment.phoneNumber ?? "");
                    cmd.Parameters.AddWithValue("@CardHolder", payment.cardHolder ?? "");
                    cmd.Parameters.AddWithValue("@Email", payment.email ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //GET BY ID - PAYMENT
        public payinfo paymentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM Payments WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new payinfo
                            {
                                method = reader["method"].ToString(),
                                cardNumber = reader["cardNumber"].ToString(),
                                phoneNumber = reader["phoneNumber"].ToString(),
                                cardHolder = reader["cardHolder"].ToString(),
                                email = reader["email"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        //UPDATE - PAYMENT
        public void updatePayment(int id, payinfo payment)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"UPDATE Payments
                                 SET method = @Method,
                                     cardNumber = @CardNumber,
                                     phoneNumber = @PhoneNumber,
                                     cardHolder = @CardHolder,
                                     email = @Email
                                 WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Method", payment.method ?? "");
                    cmd.Parameters.AddWithValue("@CardNumber", payment.cardNumber ?? "");
                    cmd.Parameters.AddWithValue("@PhoneNumber", payment.phoneNumber ?? "");
                    cmd.Parameters.AddWithValue("@CardHolder", payment.cardHolder ?? "");
                    cmd.Parameters.AddWithValue("@Email", payment.email ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE ID - PAYMENT
        public void deletePayment(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM Payments WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }


    //SHIPPING
    public class shippingpath
    {
        private const string connString =
            "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";

        //POST - SHIPPING
        public void saveShip(shipinfo shipping)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"INSERT INTO Shippings 
                                (address, contactNumber) 
                                VALUES 
                                (@Address, @ContactNum)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Address", shipping.address ?? "");
                    cmd.Parameters.AddWithValue("@ContactNum", shipping.contactnum ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //GET BY ID - SHIPPING
        public shipinfo shippingById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM Shippings WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new shipinfo
                            {
                                address = reader["address"].ToString(),
                                contactnum = reader["contactNumber"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        //UPDATE - SHIPPING
        public void updateShipping(int id, shipinfo shipping)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"UPDATE Shippings
                                 SET address = @Address,
                                     contactNumber = @ContactNum
                                 WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Address", shipping.address ?? "");
                    cmd.Parameters.AddWithValue("@ContactNum", shipping.contactnum ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE ID - SHIPPING
        public void deleteShipping(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM Shippings WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}