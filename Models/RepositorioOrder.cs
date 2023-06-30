using System.Net.Mail;
using System.Net;
using System.Text;

namespace SistemasWeb01.Models
{
    public class RepositorioOrder :InterfazOrder
    {
        private readonly BdContexTiendaTecnoBoliviaSc _BdContexTiendaTecnoBoliviaSc;

        private readonly InterfazShoppingCart _shoppingCart;

        public RepositorioOrder(BdContexTiendaTecnoBoliviaSc bdContexTiendaTecnoBoliviaSc ,InterfazShoppingCart shoppingCart)
        {
            _BdContexTiendaTecnoBoliviaSc = bdContexTiendaTecnoBoliviaSc;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductoId = shoppingCartItem.producto.ProductoId,
                    Precio = shoppingCartItem.producto.PrecioProducto
                };

                order.OrderDetails.Add(orderDetail);
            }

            _BdContexTiendaTecnoBoliviaSc.Orders.Add(order);

            _BdContexTiendaTecnoBoliviaSc.SaveChanges();
        }
        public string detalleOrden(Order order)
        {
            StringBuilder sb = new StringBuilder();

            // Estilos CSS
            string cssStyles = @"
        <style>
            body {
                font-family: Arial, sans-serif;
                font-size: 14px;
                line-height: 1.5;
                color: #333333;
            }
            .card {
                border: 1px solid #CCCCCC;
                padding: 10px;
                margin-bottom: 10px;
                border-radius: 5px;
            }
            .titulo {
                font-size: 18px;
                font-weight: bold;
                margin-bottom: 10px;
            }
            .separador {
                border-top: 1px solid #CCCCCC;
                margin: 10px 0;
            }
            .producto {
                margin-bottom: 5px;
            }
            .producto-nombre {
                font-weight: bold;
                color: black;
            }
            .producto-precio {
                color: #666666;
            }
            .total {
                font-size: 18px;
                font-weight: bold;
                margin-top: 10px;
            }
        </style>
    ";

            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Detalle de la orden</title>");
            sb.AppendLine(cssStyles);
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<div class='card'>");
            sb.AppendLine("<div class='titulo'style='color: black;'>Lista de productos Comprados</div>");
            sb.AppendLine("<div class='separador'></div>");

            foreach (ShoppingCartItem shoppingCartItem in _shoppingCart.ShoppingCartItems)
            {
                sb.AppendLine("<div class='producto'>");
                sb.AppendLine($"<span class='producto-nombre' style='color: black;'>Producto: {shoppingCartItem.producto.NombreProducto}</span><br>");
                sb.AppendLine($"<span class='producto-precio'style='color: black;'>Precio: {shoppingCartItem.producto.PrecioProducto}</span><br>");
                sb.AppendLine($"<span style='color: black;'>Cantidad: {shoppingCartItem.Amount}</span>");
                sb.AppendLine("</div>");
                
                sb.AppendLine("<div class='separador'></div>");
            }

            sb.AppendLine("<div class='total'>");
            sb.AppendLine($"Total: {order.OrderTotal}");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }




        public void correoSend(string informacion, string Email)
        {
            string destinatario = Email;
            string asunto = "Correo de prueba";
            string contenido = informacion;

            // Configurar la información del remitente y el servidor SMTP
            string remitente = "tecnoboliviasc@gmail.com";
            string contraseña = "awtrpsrnxvxqzfva";
            string servidorSmtp = "smtp.gmail.com";
            int puertoSmtp = 587;

            try
            {
                // Crear el objeto MailMessage con el contenido del correo
                MailMessage correo = new MailMessage(remitente, destinatario, asunto, contenido);

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient(servidorSmtp, puertoSmtp);
                clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);
                clienteSmtp.EnableSsl = true;

                // Establecer el tipo de contenido como HTML
                correo.IsBodyHtml = true;

                // Crear una vista alternativa con el cuerpo del mensaje en formato HTML
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(contenido, Encoding.UTF8, "text/html");
                correo.AlternateViews.Add(htmlView);

                // Enviar el correo
                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }


    }
}
